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
using System.Collections.Generic;
using System.Text;
using MTH.Framework;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace MTH.Plugins.Sites
{
	public class MTHCrypto : BasePokerTable, IPokerTable, IPlugin
	{
		private Bitmap screenshot;
		private Color actionButtonPixelColor;
		private Color activeMoreChipsButtonPixelColor;
		private Color sitOutButtonPixelColor;

		public string Name
		{
			get { return "Cryptologic"; }
		}

		public string Description
		{
			get { return "MTH Cryptologic plugin"; }
		}

		public string Creator
		{
			get { return "Mark S. Rasmussen - www.improve.dk"; }
		}

		public override Size MinTableSize
		{
			get { return new Size(800, 574); }
		}

		public override Size MaxTableSize
		{
			get { return this.MinTableSize; }
		}

		public override bool IsResizable
		{
			get { return false; }
		}

		public override string SiteName
		{
			get { return "Crypto"; }
		}

		public MTHCrypto() : base()
		{ }

		public MTHCrypto(int hwnd, ICore core) : base(hwnd, core)
		{
			TableName = WindowTitle.Substring(0, WindowTitle.IndexOf('-'));
			//TODO: Get GameForm, GameType, GameLimit

			// Get the action button pixel color
			Bitmap bmp = (Bitmap)Bitmap.FromFile(Path.Combine(Win32.GetModuleDirectory(hwnd), "img\\p_btn_betting.jpg"));
			actionButtonPixelColor = bmp.GetPixel(116, 51);
			bmp.Dispose();

			// Get the "more chips" active button color
			bmp = (Bitmap)Bitmap.FromFile(Path.Combine(Win32.GetModuleDirectory(hwnd), "img\\p_btn_morechips.jpg"));
			activeMoreChipsButtonPixelColor = bmp.GetPixel(0, 0);
			bmp.Dispose();

			// Get the "sit out" button color
			bmp = (Bitmap)Bitmap.FromFile(Path.Combine(Win32.GetModuleDirectory(hwnd), "img\\p_btn_sitout.jpg"));
			sitOutButtonPixelColor = bmp.GetPixel(0, 0);
			bmp.Dispose();
		}

		public override IPokerTable Create(int hwnd)
		{
			return new MTHCrypto(hwnd, Core);
		}

		public override bool IsPokerTable(int hwnd)
		{
			// Test for window size
			Rectangle rect = new Rectangle();
			Win32.GetWindowRect(hwnd, ref rect);

			if (rect.Width - rect.X != MaxTableSize.Width || rect.Height - rect.Y != MaxTableSize.Height)
				return false;

			// Test for window title
			string title = Win32.GetText(hwnd);
			if (!title.Contains("- Logged in as "))
				return false;

			if (title.Contains("- Lobby -"))
				return false;

			// Test for owner process exe
			if (Process.GetProcessById(Win32.GetWindowProcessID(hwnd)).ProcessName.ToLower() != "poker")
				return false;
			
			return true;
		}

		private int colorDiff(Color c1, Color c2)
		{
			return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
		}

		public override void InvokeActionTick()
		{
			// Check if window has been closed
			if (!Win32.IsWindow(WindowHandle))
			{
				OnClosed();
				return;
			}

			// Get an updated screenshot
			if (screenshot != null)
				screenshot.Dispose();
			screenshot = Win32.PrintWindowAsBitmap(WindowHandle, MaxTableSize.Width, MaxTableSize.Height);

			// Check for sitting in/out
			Color pix = screenshot.GetPixel(6, 441);
			if (!(colorDiff(sitOutButtonPixelColor, pix) <= 10))
			{
				// Sitting out
				if (!isSittingOut)
				{
					isSittingOut = true;
					OnSittingOut();
				}
			}
			else
			{
				// Sitting in
				if (isSittingOut)
				{
					isSittingOut = false;
					OnSittingIn();
				}
			}

			// Check for seated / not unseated
			pix = screenshot.GetPixel(6, 49);
			if(colorDiff(pix, activeMoreChipsButtonPixelColor) <= 10)
			{
				// Seated
				if(!isSeated)
				{
					isSeated = true;
					OnSeated();
				}
			}
			else
			{
				// Unseated
				if(isSeated)
				{
					isSeated = false;
					OnUnSeated();
				}
			}

			// Check for action requirement
			if (isSeated && !isSittingOut)
			{
				pix = screenshot.GetPixel(414, 562);
				if (!(colorDiff(pix, actionButtonPixelColor) <= 10))
					pix = screenshot.GetPixel(542, 562);
				if (!(colorDiff(pix, actionButtonPixelColor) <= 10))
					pix = screenshot.GetPixel(670, 562);

				Core.Log(TableName + ": " + colorDiff(pix, actionButtonPixelColor));

				if (colorDiff(pix, actionButtonPixelColor) <= 10)
				{
					if (!needsAction)
					{
						needsAction = true;
						OnRequiresAction();
						ForceRedraw();
					}
				}
				else
				{
					if (needsAction)
					{
						needsAction = false;
						OnNoLongerRequiresAction();
					}
				}
			}
			else
			{
				if (needsAction)
				{
					needsAction = false;
					OnNoLongerRequiresAction();
				}
			}
		}

		public override double GetAspectRatio(int width)
		{
			return (double)MaxTableSize.Height / (double)MaxTableSize.Width;
		}

		public override void Die()
		{
			if (screenshot != null)
				screenshot.Dispose();
		}

		public override void MoveCursorToTable()
		{
			Point p = WindowPosition;
			Rectangle size = WindowRectangle;

			Cursor.Position = new Point(p.X + size.Width / 2, p.Y + (int)((double)size.Height / 1.75));
		}

		public override void CheckCall()
		{
			BringToFront();
			Win32.PostLeftClick(600, 516, WindowHandle);
		}

		public override void Fold()
		{
			BringToFront();
			Win32.PostLeftClick(470, 516, WindowHandle);
		}

		public override void BetRaise()
		{
			BringToFront();
			Win32.PostLeftClick(730, 516, WindowHandle);
		}

		public override bool EnumChildWindowCallBack(int hWnd, int lParam)
		{
			if (children.ContainsKey(hWnd) || bannedChildren.Contains(hWnd))
				return true;

			ChildWindow cw = new ChildWindow(hWnd);

			// Only save this child if it's relevant, otherwise ban the window
			if (cw.ControlID == 401)
				children.Add(hWnd, new ChildWindow(hWnd));
			else
				bannedChildren.Add(hWnd);

			return true;
		}

		private ChildWindow getBetBox()
		{
			foreach (ChildWindow cw in children.Values)
				if (cw.ControlID == 401)
					return cw;

			return null;
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
	}
}