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

namespace MTH
{
	/// <summary>
	/// Summary description for PartyTable.
	/// </summary>
	public class PartyTable : PokerTable
	{
		protected WinHook wh;
		protected KeyHook kh;
		protected List<int> blockingKeys = new List<int>();
		protected bool actionButtonsVisible = false;
		public static Size SpecialMinTableSize = new Size(486, 367);
		public static Size SpecialMaxTableSize = new Size(796, 579);

		/// <summary>
		/// Inherited constructor, takes care of site specific identification
		/// </summary>
		/// <param name="handle"></param>
		public PartyTable(int handle) : base(handle)
		{
			// Set size restrictions
			MinTableSize = new Size(486, 367);
			MaxTableSize = new Size(796, 579);
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
			if (name.IndexOf(" - NL ") != -1)
				gameLimit = TableFactory.GameLimit.NL;
			else if (name.IndexOf(" - PL ") != -1)
				gameLimit = TableFactory.GameLimit.PL;
			else
				gameLimit = TableFactory.GameLimit.FL;

			// Determine GameType
			if (name.IndexOf(" Hold'em") != -1)
				gameType = TableFactory.GameType.Holdem;
			else if (name.IndexOf(" Omaha") != -1)
				gameType = TableFactory.GameType.Omaha;
			else if (name.IndexOf(" Stud") != -1)
				gameType = TableFactory.GameType.Stud;

			// Determine GameForm
			Regex regexSNG = new Regex(" \\$[0-9]{1,5} Buy-in[ ]*");
			Regex regexMTT = new Regex(" Table #[0-9]{1,4} - ");

			if (regexSNG.IsMatch(name))
				gameForm = TableFactory.GameForm.SNG;
			else if (regexMTT.IsMatch(name))
				gameForm = TableFactory.GameForm.MTT;
			else
				gameForm = TableFactory.GameForm.Cash;

			// Set name
			if (windowTitle.IndexOf(" - ") > -1)
				name = windowTitle.Substring(0, windowTitle.IndexOf(" - "));
			else
				name = windowTitle;

			// Determine stakes
			Regex stakesRegex;
			Match m;
			switch (gameForm)
			{
				case TableFactory.GameForm.SNG:
					stakesRegex = new Regex(" \\$(?<buyin>[0-9]{1,5}) Buy-in[ ]*\\.");

					m = stakesRegex.Match(windowTitle);

					if (m.Success)
						stakes = "$" + m.Groups["buyin"] + " + $" + m.Groups["fee"];

					break;
				case TableFactory.GameForm.MTT:
					break;
				case TableFactory.GameForm.Cash:
					switch (gameLimit)
					{
						case TableFactory.GameLimit.NL:
						case TableFactory.GameLimit.PL:
							stakesRegex = new Regex(" \\$(?<buyin>[0-9]{1,6})");

							m = stakesRegex.Match(windowTitle);

							if (m.Success)
								stakes = "$" + m.Groups["buyin"];

							break;
						case TableFactory.GameLimit.FL:
							stakesRegex = new Regex(" \\$(?<sb>[0-9]{1,5})/\\$(?<bb>[0-9]{1,5})");

							m = stakesRegex.Match(windowTitle);

							if (m.Success)
								stakes = "$" + m.Groups["sb"] + "/$" + m.Groups["bb"];

							break;
					}
					break;
			}

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
					string txt = Win32.GetText((int)e.hwnd).ToLower();

					if (txt.Length == 0)
						return;

					Log.Write("WinHooker: WM_SHOWWINDOW - '" + txt + "', visibility: " + e.wp);

					ChildWindow child = new ChildWindow((int)e.hwnd);

					if ((txt.StartsWith("raise") || txt.StartsWith("bet") || txt.StartsWith("all") || txt.StartsWith("fold") || txt.StartsWith("wait") || txt.StartsWith("call") || txt.StartsWith("check") || txt.StartsWith("post") || txt.StartsWith("sit out")) && !txt.Contains("respond"))
					{
						Log.Write("Window is action text");
						if (child.SizeRatio < 4)
						{
							Log.Write("Window has correct size ratio, wp is: " + e.wp + ", needsAction is: " + needsAction);
							if (Convert.ToBoolean(e.wp) && !needsAction)
							{
								Log.Write("Needs action now");

								// Update children
								UpdateChildren();

								// We need action now, we didn't before
								needsAction = true;

								// If it's a tourney, check the blind level
								if (GameForm == TableFactory.GameForm.SNG)
								{
									// Get blind level
									int newBlindLevel = getBlindLevel();

									// Save the blind level and destroy the border form
									if (blindLevel != newBlindLevel)
									{
										if (borderForm != null && !borderForm.Visible)
										{
											borderForm.Dispose();
											borderForm = null;
										}

										blindLevel = newBlindLevel;
									}
								}

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

							// Check if it's wait for bb button
							if (txt == "wait for bb" && Settings.AutoWaitForBB && Convert.ToBoolean(e.wp))
							{
								Log.Write("Wait for BB detected, autowait enabled, clicking button");

								Win32.ClickButton((int)e.hwnd);

								if (Settings.AutoClickAutoPostBlind)
								{
									Log.Write("We've clicked wait for bb button, now click auto post blind");

									CheckAutoPostBlind();
								}

								return;
							}

							// Check if it's post sb/bb button
							if ((txt.StartsWith("post bb") || txt.StartsWith("post sb")) && Settings.AutoPostBlind && Convert.ToBoolean(e.wp))
							{
								Log.Write("Post sb/bb detected");

								if (!Settings.AutoWaitForBB)
								{
									Log.Write("We're not waiting for bb, clicking post button");

									Win32.ClickButton((int)e.hwnd);

									if (Settings.AutoClickAutoPostBlind)
									{
										Log.Write("We've posted a blind, and we're auto clicking auto post blind");

										CheckAutoPostBlind();
									}
								}
								else
								{
									Log.Write("We're waiting for bb, launching delayed click of wait for sb button");

									System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

									t.Interval = 80;
									t.Tag = e.hwnd.ToString();

									t.Tick += new EventHandler(delegate(object tSender, EventArgs eArgs)
									{
										int hwnd = Convert.ToInt32(((System.Windows.Forms.Timer)tSender).Tag);

										Log.Write("Delayed post blind timer tick");

										if (Win32.IsWindowVisible(hwnd))
											if (Win32.GetText(hwnd).ToLower().StartsWith("post "))
											{
												Log.Write("Post blind button still available, clicking");
												
												Win32.ClickButton(hwnd);

												if (Settings.AutoClickAutoPostBlind)
												{
													Log.Write("We've posted a blind, and we're auto clicking auto post blind");

													CheckAutoPostBlind();
												}
											}

										t.Enabled = false;

									});

									t.Enabled = true;
								}
							}
						}
					}
					else if (txt.StartsWith("i am back") && child.SizeRatio < 4)
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
		/// Checks the auto post blind checkbox
		/// </summary>
		public void CheckAutoPostBlind()
		{
			AutoItX3Lib.AutoItX3Class ai = new AutoItX3Lib.AutoItX3Class();

			ai.ControlCommand(windowTitle, "", "441", "Check", "");
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
			if(cls != "ComboBox" && cls != "RICHEDIT")
			{
				StringBuilder sb = new StringBuilder(256);
				Win32.GetWindowText(hwnd, sb, sb.Capacity);

				ChildWindow child = new ChildWindow(hwnd, cls);

				string txt = sb.ToString();

				if(child.IsVisible && !(cls == "static" && txt == ""))
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

			foreach(ChildWindow child in children.Values)
				if (child.ClassName.ToLower().Trim() == "edit" && child.SizeRatio < 3)
					return child;

			return null;
		}

		/// <summary>
		/// Returns whether we're seated or not
		/// </summary>
		/// <returns></returns>
		public override bool IsSeated()
		{
			try
			{
				foreach (ChildWindow child in children.Values)
					if (child.Text.ToLower() == "auto post blind" && child.IsVisible)
						return true;
			}
			catch
			{
				return false;
			}

			return false;
		}

		/// <summary>
		/// Returns whether we're seated or not
		/// </summary>
		/// <returns></returns>
		public bool IsSittingOutVisible()
		{
			foreach (ChildWindow child in children.Values)
				if (child.Text.ToLower() == "i am back" && child.IsVisible)
					return true;

			return false;
		}

        /// <summary>
        /// Returns the current blind level of a SNG
        /// </summary>
        /// <returns></returns>
        protected override int getBlindLevel()
        {
            foreach (ChildWindow child in children.Values)
                if (child.Text.ToLower().StartsWith("trny:"))
                {
                    Regex regex = new Regex("Level:(?<level>[0-9]{1,2})");

                    Match m = regex.Match(child.Text);

                    if (m.Success)
                        return Convert.ToInt32(m.Groups["level"].Value);
                    else
                        return 0;
                }

            return 0;
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
                string txt = child.Text.ToLower();

                if (child.SizeRatio < 4 && (txt.StartsWith("raise") || txt.StartsWith("bet") || (txt.StartsWith("all") && hasCallButton())))
                    if(child.IsVisible)
                        betRaiseButton = child;
            }

			// If we found the raise button, raise
			if(betRaiseButton != null)
			{
				ChildWindow betBox = getBetBox();

				// If it's NL, check that the user has entered a raise amount before raising, otherwise, just raise
				if(betBox != null)
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
			if(box != null)
			{
				Thread t = new Thread(new ThreadStart(delegate()
				{
					string betValue = "99";

					for(int i=0; i<=5; i++)
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
			{
				if (child.SizeRatio < 4 && child.IsVisible && child.Text.ToLower().StartsWith("fold"))
				{
					foldButton = child;
					break;
				}
			}

			if(foldButton != null)
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

				if (child.SizeRatio < 4 && (txt.StartsWith("check") || txt.StartsWith("call") || (txt.StartsWith("all") && !hasCallButton() && !hasCheckButton())))
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
			ChildWindow sitOutButton = null;

			foreach(ChildWindow child in children.Values)
                if (child.SizeRatio < 4 && child.IsVisible && child.Text.ToLower().StartsWith("sit"))
				{
					sitOutButton = child;
					break;
				}

			if(sitOutButton != null)
				Win32.ClickButton(sitOutButton.Handle);
		}

		/// <summary>
		/// Clicks the Post SB/BB button on the table
		/// </summary>
		public override void PostBlind()
        {
			ChildWindow postBlindButton = null;

			foreach(ChildWindow child in children.Values)
                if (child.SizeRatio < 4 && child.IsVisible && child.Text.ToLower().StartsWith("post"))
				{
					postBlindButton = child;
					break;
				}

			if(postBlindButton != null)
				Win32.ClickButton(postBlindButton.Handle);
		}

		/// <summary>
		/// Returns whether there currently is a call action button
		/// </summary>
		/// <returns></returns>
		private bool hasCallButton()
        {
			foreach(ChildWindow child in children.Values)
                if (child.SizeRatio < 4 && child.IsVisible && child.Text.ToLower().StartsWith("call"))
					return true;

			return false;
		}

		/// <summary>
		/// Returns whether there currently is a check action button
		/// </summary>
		/// <returns></returns>
		private bool hasCheckButton()
		{
			foreach (ChildWindow child in children.Values)
				if (child.SizeRatio < 4 && child.IsVisible && child.Text.ToLower().StartsWith("check"))
					return true;

			return false;
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
        /// Debug method to print children
        /// </summary>
        /// <returns></returns>
        public string PrintChildren()
        {
            string result = "";

            foreach (ChildWindow child in children.Values)
            {
                result += child.ClassName + " (" + child.Width + "x" + child.Height + "): " + child.Text + "\n";
            }

            return result;
        }

        /// <summary>
        /// Tries to take a seat at the table
        /// </summary>
        public override bool TakeSeat(int seatNumber)
        {
			Rectangle tableRect = new Rectangle(0, 0, 0, 0);
            Win32.GetWindowRect(this.handle, ref tableRect);

            foreach (ChildWindow child in children.Values)
            {
                if (child.ClassName == "AfxWnd42")
                {
                    // We've found a seat, now determine what seat it is
                    Rectangle seatRect = new Rectangle(0, 0, 0, 0);
                    Win32.GetWindowRect(child.Handle, ref seatRect);

                    if (child.Width == 77 && child.Height == 20)
                    {
                        int seatX = seatRect.X - tableRect.X;
                        int seatY = seatRect.Y - tableRect.Y;
                        
                        // Check if this is the desired seat
                        if (getSeatNumberFromCoords(seatX, seatY) == seatNumber)
                        {
                            // Take the seat
                            Win32.ClickButton(child.Handle);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines what seat number a specific coordinate set is
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int getSeatNumberFromCoords(int x, int y)
        {
            // Check for seat 1
            if (x >= 479 && x <= 499 && y >= 65 && y <= 85)
                return 1;

            // Check for seat 2
            if (x >= 621 && x <= 641 && y >= 102 && y <= 122)
                return 2;

            // Check for seat 3
            if (x >= 698 && x <= 718 && y >= 220 && y <= 240)
                return 3;

            // Check for seat 4
            if (x >= 624 && x <= 644 && y >= 347 && y <= 367)
                return 4;

            // Check for seat 5
            if (x >= 451 && x <= 571 && y >= 382 && y <= 402)
                return 5;

            // Check for seat 6
            if (x >= 223 && x <= 243 && y >= 382 && y <= 402)
                return 6;

            // Check for seat 7
            if (x >= 68 && x <= 88 && y >= 347 && y <= 367)
                return 7;

            // Check for seat 8
            if (x >= 10 && x <= 30 && y >= 216 && y <= 236)
                return 8;

            // Check for seat 9
            if (x >= 89 && x <= 109 && y >= 102 && y <= 122)
                return 9;

            // Check for seat 10
            if (x >= 224 && x <= 244 && y >= 65 && y <= 85)
                return 10;

            // Return unknown seat 0
            return 0;
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