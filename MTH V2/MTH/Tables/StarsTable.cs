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
	public class StarsTable : PokerTable
	{
		protected KeyHook kh;
		protected List<int> blockingKeys = new List<int>();
		protected bool actionButtonsVisible = false;
		System.Windows.Forms.Timer tCheckActionPixels = new System.Windows.Forms.Timer();
		System.Windows.Forms.Timer tRedrawTable = new System.Windows.Forms.Timer();
		public static Size SpecialMinTableSize = new Size(483, 357);
		public static Size SpecialMaxTableSize = new Size(1328, 940);

		/// <summary>
		/// Inherited constructor, takes care of site specific identification
		/// </summary>
		/// <param name="handle"></param>
		public StarsTable(int handle): base(handle)
		{
			// Set size restrictions
			MinTableSize = new Size(483, 357);
			MaxTableSize = new Size(1328, 940);
			TableSizeRatio = MaxTableSize.Width / MaxTableSize.Height;

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
			else if (name.IndexOf(" Stud") != -1)
				gameType = TableFactory.GameType.Stud;
			else if (name.IndexOf(" HORSE - ") != -1)
				gameType = TableFactory.GameType.HORSE;

			// Determine GameForm
			if (windowTitle.Contains("Tournament"))
				if (windowTitle.Contains("Table 1"))
					gameForm = TableFactory.GameForm.SNG;
				else
					gameForm = TableFactory.GameForm.MTT;
			else
				gameForm = TableFactory.GameForm.Cash;

			// Determine stakes
			Regex stakesRegex;
			Match m;
			switch (gameForm)
			{
				case TableFactory.GameForm.Cash:
					switch (gameLimit)
					{
						case TableFactory.GameLimit.NL:
						case TableFactory.GameLimit.PL:
						case TableFactory.GameLimit.FL:
							stakesRegex = new Regex(" (?<buyin>\\$?[0-9]+(\\.[0-9]+)?/\\$?[0-9]+(\\.[0-9]+)?) ");

							name = name.Split(' ')[0];

							m = stakesRegex.Match(windowTitle);

							if (m.Success)
								stakes = m.Groups["buyin"].Value;

							break;
					}
					break;
				
				case TableFactory.GameForm.SNG:
				case TableFactory.GameForm.MTT:
					switch (gameLimit)
					{
						default:
							name = name.Split(' ')[1];


							break;
					}
					break;
			}

			// Create our action check timer
			tCheckActionPixels.Interval = 800;
			tCheckActionPixels.Tick += new EventHandler(checkActionPixels);
			tCheckActionPixels.Enabled = true;
			tCheckActionPixels.Start();

			// Create our timer to force redraw of the poker window
			tRedrawTable.Interval = 2500;
			tRedrawTable.Tick += new EventHandler(tRedrawTable_Tick);
			tRedrawTable.Enabled = true;
			tRedrawTable.Start();

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

		private void tRedrawTable_Tick(object sender, EventArgs e)
		{
			this.ForceRedraw();
		}

		Rectangle getBetButtonLocation(BetButton btn)
		{
			Rectangle location = Location;

			location.Height = location.Height - SystemInformation.CaptionHeight - SystemInformation.Border3DSize.Height;
			location.Width = location.Width - SystemInformation.Border3DSize.Width * 2;
			location.Y = Convert.ToInt32((double)location.Height - (double)location.Height * (double)0.064841498);

			switch (btn)
			{
				case BetButton.Left:
					location.X = Convert.ToInt32((double)location.Width - (double)location.Width * (double)0.411530815);
					break;
				case BetButton.Center:
					location.X = Convert.ToInt32((double)location.Width - (double)location.Width * (double)0.249502982);
					break;
				case BetButton.Right:
					location.X = Convert.ToInt32((double)location.Width - (double)location.Width * (double)0.095427435);
					break;
			}

			return location;
		}

		bool isActionPixelColor(Color c)
		{
			// Hyper simple theme
			if (c.R == 178 && c.G == 195 && c.B == 205 && c.A == 255)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Checks if the action buttons are visible
		/// </summary>
		void checkActionPixels(object sender, EventArgs e)
		{
			int width = this.Width;
			int height = this.Height;

			if (width != 0 && height != 0)
			{
				IntPtr hDC = Win32.GetWindowDC((IntPtr)Handle);
				IntPtr hDCDest = Win32.CreateCompatibleDC(hDC);
				IntPtr hBitmap = Win32.CreateCompatibleBitmap(hDC, width, height);
				IntPtr hOld = Win32.SelectObject(hDCDest, hBitmap);
				Win32.PrintWindow((IntPtr)Handle, hDCDest, 0);
				Win32.SelectObject(hDCDest, hOld);
				Win32.DeleteDC(hDCDest);
				Win32.ReleaseDC((IntPtr)Handle, hDC);
				Bitmap screenshot = Bitmap.FromHbitmap(hBitmap);
				Win32.DeleteObject(hBitmap);
				
				int yCheck = Convert.ToInt32((double)screenshot.Height - (double)screenshot.Height * (double)0.064841498);
				int xCheckLeft = Convert.ToInt32((double)screenshot.Width * (double)0.53125);
				int xCheckCenter = Convert.ToInt32((double)screenshot.Width * (double)0.683168316);
				int xCheckRight = Convert.ToInt32((double)screenshot.Width * (double)0.846534653);

				Color c = screenshot.GetPixel(xCheckLeft, yCheck);
				if (!isActionPixelColor(c))
					c = screenshot.GetPixel(xCheckCenter, yCheck);
				if (!isActionPixelColor(c))
					c = screenshot.GetPixel(xCheckRight, yCheck);

				screenshot.Dispose();

				if (isActionPixelColor(c))
				{
					if (!needsAction)
					{
						needsAction = true;
						requiresAction();
						lastRequiredAction = DateTime.Now;

						ForceRedraw();

						watch.Reset();
						watch.Start();
					}
				}
				else
				{
					if (needsAction)
					{
					needsAction = false;
					noLongerRequiresAction();
					watch.Stop();
					cumulativeResponseTime += watch.ElapsedMilliseconds;
					actionCount++;

					lastRequiredAction = DateTime.Now;
					}
				}
			}
			else
			{
				tCheckActionPixels.Stop();
				tCheckActionPixels.Enabled = false;
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
		/// Checks the auto post blind checkbox
		/// </summary>
		public void CheckAutoPostBlind()
		{
			//TODO
			return;
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
			if (cls.ToLower().Trim() == "edit")
			{
				ChildWindow child = new ChildWindow(hwnd, cls);

				// Only save bet box
				if(child.SizeRatio > 2.2 && child.SizeRatio < 3.6)
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
				if (child.ControlID == 1000 && child.IsVisible)
					return child;

			return null;
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
		/// Clicks the Bet / Raise button on the table
		/// </summary>
		public override void BetRaise()
		{
			Rectangle betBox = getBetButtonLocation(BetButton.Right);
			Win32.PostLeftClick(betBox.X, betBox.Y, this.Handle);
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
			Rectangle betBox = getBetButtonLocation(BetButton.Left);

			Win32.PostLeftClick(betBox.X, betBox.Y, this.Handle);
		}

		/// <summary>
		/// Clicks the Check / Call button on the table
		/// </summary>
		public override void CheckCall()
		{
			Rectangle betBox = getBetButtonLocation(BetButton.Center);

			Win32.PostLeftClick(betBox.X, betBox.Y, this.Handle);
		}

		public override void SetRaiseValue(string value)
		{
			UpdateChildren();

			// Get the bet box
			ChildWindow box = getBetBox();

			// If we found the bet box, set it's value
			if (box != null)
			{
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
			UpdateChildren();

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
			Die();

			Win32.PostMessage(this.Handle, (int)Win32.WM.SYSCOMMAND, (int)Win32.SC.CLOSE, 0);
		}

		// Kills the table gracefully
		public override void Die()
		{
			// Remove drawings
			InvalidateDrawings();
			
			// Stop action pixel check
			if (tCheckActionPixels.Enabled)
			{
				tCheckActionPixels.Stop();
				tCheckActionPixels.Enabled = false;
			}
		}
	}
}