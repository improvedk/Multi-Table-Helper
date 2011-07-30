/*	 
	Copyright 2007 Mark S. Rasmussen - www.improve.dk

    This file is part of Multi Table Helper.

    Multi Table Helper is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Multi Table Helper is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Desaware.SpyWorks;
using MTH.Framework;

namespace MTH.Plugins.Sites
{
	public class MTHPartyPoker : BasePokerTable, IPlugin, IPokerTable
	{
		private WinHook wh;

		public string Name
		{
			get { return "Party Poker"; }
		}

		public string Description
		{
			get { return "MTH Party Poker plugin"; }
		}

		public string Creator
		{
			get { return "Mark S. Rasmussen - www.improve.dk"; }
		}

		public override Size MinTableSize
		{
			get { return new Size(486, 363); }
		}

		public override Size MaxTableSize
		{
			get { return new Size(796, 579); }
		}

		public override bool IsResizable
		{
			get { return true; }
		}

		public override string SiteName
		{
			get { return "Party"; }
		}

		public override double GetAspectRatio(int width)
		{
			return (double)MaxTableSize.Height / (double)MaxTableSize.Width;
		}

		public override void Die()
		{
			// Remove drawings
			if (Win32.IsWindow(WindowHandle))
				InvalidateDrawings();
		}

		public override IPokerTable Create(int hwnd)
		{
			return new MTHPartyPoker(hwnd, Core);
		}

		public override void MoveCursorToTable()
		{
			Point p = WindowPosition;
			Rectangle size = WindowRectangle;

			Cursor.Position = new Point(p.X + size.Width / 2, p.Y + (int)((double)size.Height / 1.75));
		}

		public MTHPartyPoker() : base() { }
		public MTHPartyPoker(int hwnd, ICore core) : base(hwnd, core)
		{
			TableName = WindowTitle.Substring(0, WindowTitle.IndexOf('-'));

			// Set WinHook to listen for show/hide window
			wh = new WinHook();

			wh.HwndParam = (IntPtr)WindowHandle;
			wh.Monitor = HookMonitor.HwndAndChildren;
			wh.HookType = HookTypes.CallWndProc;
			wh.Messages = new WindowsMessageList();
			wh.Messages.AddMessage(StandardMessages.WM_SHOWWINDOW);
			wh.OnMessageHook += new MessageHookEventHandler(wh_OnMessageHook);
			wh.Enabled = true;

			// Update children
			UpdateChildren();

			// Check if we're seated
			bool foundChild = false;
			foreach (ChildWindow cw in children.Values)
				if (cw.ControlID == 443 && cw.IsVisible)
				{
					foundChild = true;
					break;
				}

			if (foundChild)
			{
				isSeated = true;
				OnSeated();
			}
			else
			{
				isSeated = false;
				OnUnSeated();
			}

			// Check if we're sitting out
			if (isSeated)
			{
				foundChild = false;
				foreach (ChildWindow cw in children.Values)
					if (cw.ControlID == 4000 && cw.IsVisible && cw.Text.ToLower().Replace(" ", "") == "iamback")
					{
						foundChild = true;
						break;
					}

				if (foundChild)
				{
					isSittingOut = true;
					OnSittingOut();
				}
				else
				{
					isSittingOut = false;
					OnSittingIn();
				}
			}

			// TODO: Check for requiring action
		}

		public override bool EnumChildWindowCallBack(int hWnd, int lParam)
		{
			if (children.ContainsKey(hWnd) || bannedChildren.Contains(hWnd))
				return true;

			ChildWindow cw = new ChildWindow(hWnd);

			// Only save this child if it's relevant, otherwise ban the window
			if (cw.ControlID == 339 || cw.ControlID == 443 || cw.ControlID == 4000)
				children.Add(hWnd, new ChildWindow(hWnd));
			else
				bannedChildren.Add(hWnd);

			return true;
		}

		void wh_OnMessageHook(object sender, MessageHookEventArgs e)
		{
			switch (e.msg)
			{
				// A window has been hidden / visible
				case StandardMessages.WM_SHOWWINDOW:
					string txt = Win32.GetText((int)e.hwnd).ToLower();

					if (txt.Length == 0)
						return;

					ChildWindow child = new ChildWindow((int)e.hwnd);

					if ((txt.StartsWith("raise") || txt.StartsWith("bet") || txt.StartsWith("all") || txt.StartsWith("fold") || txt.StartsWith("wait") || txt.StartsWith("call") || txt.StartsWith("check") || txt.StartsWith("post") || txt.StartsWith("sit out")) && !txt.Contains("respond"))
					{
						if (child.SizeRatio < 4)
						{
							if (Convert.ToBoolean(e.wp) && !needsAction)
							{
								// Requires action
								needsAction = true;
								OnRequiresAction();
								ForceRedraw();
							}
							else if (needsAction && !Convert.ToBoolean(e.wp))
							{
								// No longer requires action
								needsAction = false;
								OnNoLongerRequiresAction();
							}
						}
					}
					else if (txt.StartsWith("i am back") && child.SizeRatio < 4)
					{
						if (Convert.ToBoolean(e.wp) && !isSittingOut)
						{
							// Sitting out
							isSittingOut = true;
							OnSittingOut();
						}
						else if (isSittingOut && !Convert.ToBoolean(e.wp))
						{
							// Sitting in
							isSittingOut = false;
							OnSittingIn();
						}
					}
					else if (txt.StartsWith("Deal Me Out"))
					{
						if (Convert.ToBoolean(e.wp) && !isSeated)
						{
							// Seated
							isSeated = true;
							OnSeated();
						}
						else if (isSeated && !Convert.ToBoolean(e.wp))
						{
							// Unseated
							isSeated = false;
							OnUnSeated();
						}
					}
					break;
			}
		}

		public override void InvokeActionTick()
		{
			// Don't do anything here as everything as handled through the Winhook
		}

		public override void CheckCall()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public override void Fold()
		{
			// TODO: Fix
			double xRatio = 0.3140;
			int x = Convert.ToInt32((double)WindowWidth * xRatio);
			double yRatio = 0.8290;
			int y = Convert.ToInt32((double)WindowHeight * yRatio);

			Core.Log(TableName + " - Clicking (" + x + "," + y + ")");

			Win32.PostLeftClick(WindowHandle, x, y);
		}

		public override void BetRaise()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public override bool IsPokerTable(int hwnd)
		{
			StringBuilder sbc = new StringBuilder(256);
			Win32.GetClassName(hwnd, sbc, sbc.Capacity);
			string windowClassName = sbc.ToString();

			// Test for window class
			if (windowClassName != "#32770")
				return false;

			// Test for window title
			string windowTitle = Win32.GetText(hwnd);
			if (windowTitle.Replace(" ", "").ToLower().Contains("partypoker.com:pokerlobby"))
				return false;
			if (!windowTitle.ToLower().Replace(" ", "").Contains("goodluck"))
				return false;

			// Test for owner process exe
			if (Process.GetProcessById(Win32.GetWindowProcessID(hwnd)).ProcessName.ToLower() != "partygaming")
				return false;

			return true;
		}

		private ChildWindow getBetBox()
		{
			foreach (ChildWindow cw in children.Values)
				if (cw.ControlID == 339)
					return cw;

			return null;
		}

		public override void AutoPush()
		{
			UpdateChildren();

			ChildWindow cw = getBetBox();

			if (cw != null)
			{
				Thread t = new Thread(new ThreadStart(delegate()
				{
					string betValue = "99";

					for (int i = 0; i <= 7; i++)
					{
						// Make sure the window has focus, and it's the active window, otherwise the window might not recognize the text update
						Win32.ShowWindow(WindowHandle, (int)Win32.SW.SHOWNORMAL);
						Win32.SetForegroundWindow(WindowHandle);
						Win32.BringWindowToTop(WindowHandle);

						// Click the raise box to ensure that we've got focus
						Win32.ClickButton(cw.Handle);

						// Set the value
						Win32.SetText(cw.Handle, betValue);

						// Add a 9 to the betvalue
						betValue += "9";

						Thread.Sleep(5);
					}

					// Sleep 25ms to make sure the amount get's a chance to be entered
					Thread.Sleep(10);

					// Push the raise button
					BetRaise();
				}));

				t.Start();
			}
		}

		public override string GetRaiseValue()
		{
			UpdateChildren();

			ChildWindow cw = getBetBox();

			if (cw != null)
				return Win32.GetText(cw.Handle);
			else
				return "";
		}

		public override void SetRaiseValue(string raiseValue)
		{
			UpdateChildren();

			ChildWindow cw = getBetBox();

			if (cw != null)
			{
				Win32.ClickButton(cw.Handle);
				Win32.SetText(cw.Handle, raiseValue);
			}
		}
	}
}