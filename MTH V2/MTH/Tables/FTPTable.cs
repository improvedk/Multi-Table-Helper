using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading;
using Desaware.SpyWorks;
using System.Collections.Generic;
using AutoItX3Lib;

namespace MTH
{
	/// <summary>
	/// Summary description for PartyTable.
	/// </summary>
	public class FTPTable : PokerTable
	{
		protected WinHook wh;
		protected KeyHook kh;
		protected List<int> blockingKeys = new List<int>();
		protected bool actionButtonsVisible = false;
		public static Size SpecialMinTableSize = new Size(800, 575);
		public static Size SpecialMaxTableSize = new Size(800, 575);

		/// <summary>
		/// Inherited constructor, takes care of site specific identification
		/// </summary>
		/// <param name="handle"></param>
		public FTPTable(int handle) : base(handle)
		{
			// Set size restrictions
			MinTableSize = new Size(800, 575);
			MaxTableSize = new Size(800, 575);
			TableSizeRatio = MaxTableSize.Width / MaxTableSize.Height;

			// Set WinHook to listen for show/hide window
			wh = new WinHook();

			wh.HwndParam = (IntPtr)handle;
			wh.Monitor = HookMonitor.HwndAndChildren;
			wh.HookType = HookTypes.CallWndProc;
			wh.Messages = new WindowsMessageList();
			wh.Messages.AddMessage(StandardMessages.WM_SHOWWINDOW);
			wh.OnMessageHook += new MessageHookEventHandler(wh_OnMessageHook);
			wh.Enabled = true;

			Log.Write("WinHooker enabled");

			// Set keyhook to listen for keys
			kh = new KeyHook();
			kh.HwndParam = (IntPtr)handle;
			kh.IgnoreCapsLock = true;
			kh.KeyFilterList = new KeyList();
			kh.Messages = new WindowsMessageList();
			kh.Messages.AddMessage(KeyboardMessages.WM_CHAR);
			kh.Messages.AddMessage(KeyboardMessages.WM_KEYUP);
			kh.Messages.AddMessage(KeyboardMessages.WM_KEYDOWN);
			kh.Monitor = HookMonitor.HwndAndChildren;
			kh.OnKeyDown += new KeyDownHookEventHandler(kh_OnKeyDown);
			kh.HookType = HookTypes.Keyboard;

			// Add all decimal keys
			kh.KeyFilterList.AddKey((int)Keys.D0, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad0, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D1, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad1, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D2, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad2, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D3, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad3, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D4, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad4, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D5, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad5, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D6, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad6, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D7, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad7, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D8, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad8, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.D9, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.NumPad9, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.Decimal, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.OemPeriod, KeyFlags.None);
			kh.KeyFilterList.AddKey((int)Keys.Oemcomma, KeyFlags.None);

			// Add blocking keys
			blockingKeys.Add((int)Keys.D0);
			blockingKeys.Add((int)Keys.NumPad0);
			blockingKeys.Add((int)Keys.D1);
			blockingKeys.Add((int)Keys.NumPad1);
			blockingKeys.Add((int)Keys.D2);
			blockingKeys.Add((int)Keys.NumPad2);
			blockingKeys.Add((int)Keys.D3);
			blockingKeys.Add((int)Keys.NumPad3);
			blockingKeys.Add((int)Keys.D4);
			blockingKeys.Add((int)Keys.NumPad4);
			blockingKeys.Add((int)Keys.D5);
			blockingKeys.Add((int)Keys.NumPad5);
			blockingKeys.Add((int)Keys.D6);
			blockingKeys.Add((int)Keys.NumPad6);
			blockingKeys.Add((int)Keys.D7);
			blockingKeys.Add((int)Keys.NumPad7);
			blockingKeys.Add((int)Keys.D8);
			blockingKeys.Add((int)Keys.NumPad8);
			blockingKeys.Add((int)Keys.D9);
			blockingKeys.Add((int)Keys.NumPad9);
			blockingKeys.Add((int)Keys.Decimal);
			blockingKeys.Add((int)Keys.OemPeriod);
			blockingKeys.Add((int)Keys.Oemcomma);

			// Start the hooker!
			kh.Enabled = true;

			Log.Write("KeyHooker enabled");

			// Determine GameLimit
			if (name.IndexOf(" - No Limit ") != -1)
				gameLimit = TableFactory.GameLimit.NL;
			else if (name.IndexOf(" - Pot Limit ") != -1)
				gameLimit = TableFactory.GameLimit.PL;
			else
				gameLimit = TableFactory.GameLimit.FL;

			// Determine GameType
			if (name.IndexOf(" Hold'em") != -1)
				gameType = TableFactory.GameType.Holdem;
			else if (name.IndexOf(" Omaha") != -1)
				gameType = TableFactory.GameType.Omaha;

			// Determine GameForm
			if (windowTitle.Contains("Sit & Go"))
				gameForm = TableFactory.GameForm.SNG;
			else
				gameForm = TableFactory.GameForm.Unknown;

			// Get our children
			UpdateChildren();

			// Check if we're sitting out from the getco!
			if (!IsSittingOut && IsSittingOutVisible())
			{
				// We're sitting out now, we didn't before
				IsSittingOut = true;
				sittingOut();
			}
		}

		/// <summary>
		/// Returns whether we're seated or not
		/// </summary>
		/// <returns></returns>
		public override bool IsSeated()
		{
			//TODO
			return true;
		}

		/// <summary>
		/// Returns whether we're seated or not
		/// </summary>
		/// <returns></returns>
		public bool IsSittingOutVisible()
		{
			//TODO
			return false;
		}

		/// <summary>
		/// Returns the current blind level of a SNG
		/// </summary>
		/// <returns></returns>
		protected override int getBlindLevel()
		{
			//TODO
			return 1;
		}

		/// <summary>
		/// Fires when a key is received
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void kh_OnKeyDown(object sender, KeyboardHookEventArgs e)
		{
			// Discard the key if we're the active table
			if (Settings.UseKeyboardControls && IsActiveTable && blockingKeys.Contains(e.keycode))
				e.discard = true;
		}

		/// <summary>
		/// Fires when a SHOWWINDOW message is received from the table
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void wh_OnMessageHook(object sender, MessageHookEventArgs e)
		{
			switch (e.msg)
			{
				// A window has been hidden / visible
				case StandardMessages.WM_SHOWWINDOW:
					int buttonCode = Win32.GetControlIDFromHwnd((int)e.hwnd);
					
					Log.Write("WinHooker: WM_SHOWWINDOW - '" + buttonCode + "', visibility: " + e.wp);

					ChildWindow child = new ChildWindow((int)e.hwnd);

					if (buttonCode == 1031 || buttonCode == 1032 || buttonCode == 1033)
					{
						Log.Write("Window has correct size ratio, wp is: " + e.wp + ", needsAction is: " + needsAction);
						if (Convert.ToBoolean(e.wp) && !needsAction)
						{
							Log.Write("Needs action now");

							// Update children
							UpdateChildren();

							// We need action now, we didn't before
							needsAction = true;

							// Fire event
							requiresAction();

							// Start timer
							watch.Reset();
							watch.Start();

							// Update last action date
							lastRequiredAction = DateTime.Now;
						}
						else if (needsAction && !Convert.ToBoolean(e.wp))
						{
							Log.Write("No longer needs action");

							// We don't need action any more
							needsAction = false;

							// Fire event
							noLongerRequiresAction();

							// Stop timer
							watch.Stop();
							cumulativeResponseTime += watch.ElapsedMilliseconds;
							actionCount++;

							// Update last action date
							lastRequiredAction = DateTime.Now;
						}

						actionButtonsVisible = Convert.ToBoolean(e.wp);
					}
					else if (buttonCode == 1035) // "DEAL ME IN"
					{
						Log.Write("Window is sitting out text, wp is: " + e.wp + ", IsSittingOut is: " + IsSittingOut);

						if (Convert.ToBoolean(e.wp) && !IsSittingOut)
						{
							Log.Write("Sitting out now");

							// We're sitting out now, we didn't before
							IsSittingOut = true;

							sittingOut();
						}
						else if (IsSittingOut && !Convert.ToBoolean(e.wp))
						{
							Log.Write("No longer sitting out");

							// We're not sitting out any longer
							IsSittingOut = false;
						}
					}
					break;
			}
		}

		/// <summary>
		/// The callback function which saves a child window in case it's relevant
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		protected override bool EnumChildWindowCallBack(int hwnd, int lParam)
		{
			if (children.ContainsKey(hwnd))
				return true;

			StringBuilder sbc = new StringBuilder(256);

			Win32.GetClassName(hwnd, sbc, sbc.Capacity);

			string cls = sbc.ToString();

			// Only save this child if it's relevant, otherwise ban the window
			if (cls == "FTCButton")
			{
				ChildWindow child = new ChildWindow(hwnd, cls);

				if (child.IsVisible)
					children.Add(hwnd, child);
			}

			return true;
		}

		/// <summary>
		/// Returns the action status for the table
		/// </summary>
		/// <returns></returns>
		public override TableFactory.ActionStatus GetActionStatus()
		{
			if (actionButtonsVisible)
				return TableFactory.ActionStatus.RequiresActionNormal;
			else
				return TableFactory.ActionStatus.None;
		}

		/// <summary>
		/// Returns the betbox if we can find it, otherwise we return null
		/// </summary>
		/// <returns></returns>
		protected override ChildWindow getBetBox()
		{
			UpdateChildren();

			foreach (ChildWindow child in children.Values)
				if (child.ControlID == 256)
					return child;

			return null;
		}

		/// <summary>
		/// Clicks the Bet / Raise button on the table
		/// </summary>
		public override void BetRaise()
		{
			// Update children
			UpdateChildren();

			ChildWindow betRaiseButton = null;

			// Loop children to find bet/raise button
			foreach (ChildWindow child in children.Values)
			{
				if (child.ControlID == 1033) // RAISE/BET
					if (child.IsVisible)
						betRaiseButton = child;
			}

			// If we found the raise button, raise
			if (betRaiseButton != null)
			{
				ChildWindow betBox = getBetBox();

				// If it's NL, check that the user has entered a raise amount before raising, otherwise, just raise
				if (betBox != null)
				{
					if (!Settings.AllowNoAmountBetRaise && Win32.GetTextLength(betBox.Handle) > 0)
						Win32.ClickButton(betRaiseButton.Handle);
					else
						Win32.ClickButton(betRaiseButton.Handle);
				}
				else
					Win32.ClickButton(betRaiseButton.Handle);
			}
		}

		/// <summary>
		/// Automatically pushes the current hand
		/// </summary>
		public override void AutoPush()
		{
			// Update children
			UpdateChildren();

			// Get the bet box
			ChildWindow box = getBetBox();

			// If we found the bet box, set it's value
			if (box != null)
			{
				Thread t = new Thread(new ThreadStart(delegate()
				{
					string betValue = "99";

					for (int i = 0; i <= 5; i++)
					{
						// Make sure the window has focus, and it's the active window, otherwise the window might not recognize the text update
						Win32.ShowWindow(handle, (int)Win32.SW.SHOWNORMAL);
						Win32.SetForegroundWindow(handle);
						Win32.BringWindowToTop((IntPtr)handle);

						// Click the raise box to ensure that we've got focus
						Win32.ClickButton(box.Handle);

						// Set the value
						Win32.SetText(box.Handle, betValue);

						// Add a 9 to the betvalue
						betValue += "9";

						Thread.Sleep(5);
					}

					// Sleep 25ms to make sure the amount get's a chance to be entered
					System.Threading.Thread.Sleep(10);

					// Push the raise button
					this.BetRaise();
				}));

				t.Start();
			}
		}

		/// <summary>
		/// Clicks the Fold button on the table
		/// </summary>
		public override void Fold()
		{
			// Update children
			UpdateChildren();

			ChildWindow foldButton = null;

			foreach (ChildWindow child in children.Values)
				if (child.IsVisible && child.ControlID == 1031)
				{
					foldButton = child;
					break;
				}

			if (foldButton != null)
				Win32.ClickButton(foldButton.Handle);
		}

		/// <summary>
		/// Clicks the Check / Call button on the table
		/// </summary>
		public override void CheckCall()
		{
			// Update children
			UpdateChildren();

			ChildWindow checkCallButton = null;

			foreach (ChildWindow child in children.Values)
			{
				string txt = child.Text.ToLower();

				if (child.ControlID == 1031)
					if (child.IsVisible)
					{
						checkCallButton = child;
						break;
					}
			}

			if (checkCallButton != null)
				Win32.ClickButton(checkCallButton.Handle);
		}

		/// <summary>
		/// Clicks the Sit Out button on the table
		/// </summary>
		public override void SitOut()
		{
			return;
		}

		/// <summary>
		/// Clicks the Post SB/BB button on the table
		/// </summary>
		public override void PostBlind()
		{
			return;
		}

		public override void SetRaiseValue(string value)
		{
			// Get the bet box
			ChildWindow box = getBetBox();

			// If we found the bet box, set it's value
			if (box != null)
			{
				// Make sure the window has focus, and it's the active window, otherwise the window might not recognize the text update
				/*
					Win32.ShowWindow(handle, (int)Win32.SW.SHOWNORMAL);
					Win32.SetForegroundWindow(handle);
					Win32.BringWindowToTop((IntPtr)handle);
				*/

				// Click the raise box to ensure that we've got focus
				Win32.ClickButton(box.Handle);

				// Set the value
				Win32.SetText(box.Handle, value);
			}
		}

		/// <summary>
		/// Returns the current raise amount of the table
		/// </summary>
		/// <returns></returns>
		public override string GetRaiseValue()
		{
			// Get the bet box
			ChildWindow box = getBetBox();

			// If we found the bet box, return it's value, otherwise just return an empty string
			if (box != null)
				return Win32.GetText(box.Handle);
			else
				return "";
		}

		/// <summary>
		/// Moves the cursor to the table
		/// </summary>
		public override void MoveCursorToTable()
		{
			Point p = GetPosition();

			Cursor.Position = new Point(p.X + Width / 2, p.Y + (int)((double)Height / 1.75));
		}

		/// <summary>
		/// Closes the window
		/// </summary>
		public override void CloseWindow()
		{
			Win32.PostMessage(this.Handle, (int)Win32.WM.SYSCOMMAND, (int)Win32.SC.CLOSE, 0);
		}

		// Kills the table gracefully
		public override void Die()
		{
			// Remove drawings
			InvalidateDrawings();

			// Stop hook
			if (wh != null)
			{
				wh.Enabled = false;
				wh.OnMessageHook -= new MessageHookEventHandler(wh_OnMessageHook);
			}

			// Stop hook
			if (kh != null)
			{
				kh.Enabled = false;
				kh.OnKeyDown -= new KeyDownHookEventHandler(kh_OnKeyDown);
			}
		}
	}
}