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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Desaware.SpyWorks;

namespace MTH.Framework
{
	public abstract class BasePokerTable : IPokerTable
	{
		public event Delegates.ClosedEventHandler Closed;
		public event Delegates.RequiresActionEventHandler RequiresAction;
		public event Delegates.NoLongerRequiresActionEventHandler NoLongerRequiresAction;
		public event Delegates.SittingOutEventHandler SittingOut;
		public event Delegates.SittingInEventHandler SittingIn;
		public event Delegates.SeatedEventHandler Seated;
		public event Delegates.UnSeatedEventHandler UnSeated;

		public override bool Equals(object obj)
		{
			return ((IPokerTable)obj).WindowHandle == WindowHandle;
		}

		public override int GetHashCode()
		{
			return WindowHandle;
		}

		protected bool isSittingOut = false;
		protected bool needsAction = false;
		protected bool isSeated = false;
		protected Dictionary<int, ChildWindow> children = new Dictionary<int, ChildWindow>();
		protected List<int> bannedChildren = new List<int>();
		public DateTime LastRequiredAction { get; set; }
		public ICore Core { get; set; }
		public int WindowHandle { get; set; }
		public string TableName { get; set; }
		protected Rectangle lastLocation;
		protected KeyHook keyHook;
		private string ownerProcessExe = null;
		private int quadrant = 0;
		private string windowClassName = null;

		public BasePokerTable() { }
		public BasePokerTable(int hwnd, ICore core)
		{
			Core = core;
			WindowHandle = hwnd;

			// Last required action is now
			LastRequiredAction = DateTime.Now;

			// Set keyhook to listen for keys
			keyHook = new KeyHook();
			keyHook.HwndParam = (IntPtr)WindowHandle;
			keyHook.IgnoreCapsLock = true;
			keyHook.KeyFilterList = new KeyList();
			keyHook.Messages = new WindowsMessageList();
			keyHook.Messages.AddMessage(KeyboardMessages.WM_CHAR);
			keyHook.Messages.AddMessage(KeyboardMessages.WM_KEYUP);
			keyHook.Messages.AddMessage(KeyboardMessages.WM_KEYDOWN);
			keyHook.Monitor = HookMonitor.HwndAndChildren;
			keyHook.OnKeyDown += new Desaware.SpyWorks.KeyDownHookEventHandler(keyHook_OnKeyDown);
			keyHook.HookType = HookTypes.Keyboard;

			// Add all decimal keys
			keyHook.KeyFilterList.AddKey((int)Keys.D0, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad0, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D1, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad1, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D2, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad2, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D3, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad3, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D4, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad4, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D5, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad5, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D6, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad6, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D7, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad7, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D8, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad8, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.D9, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.NumPad9, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.Decimal, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.OemPeriod, KeyFlags.None);
			keyHook.KeyFilterList.AddKey((int)Keys.Oemcomma, KeyFlags.None);

			// Start the hooker!
			keyHook.Enabled = true;
		}

		private void keyHook_OnKeyDown(object sender, KeyboardHookEventArgs e)
		{
			// If we're the active table, discard any keys sent to this table specifically, Core'll take care of things
			if (Settings.UseKeyboardControls && Core.ActiveTable == this)
				e.discard = true;
		}

		public string OwnerProcessExe
		{
			get
			{
				if (ownerProcessExe == null)
					ownerProcessExe = Process.GetProcessById(Win32.GetWindowProcessID(WindowHandle)).ProcessName.ToLower();

				return ownerProcessExe;
			}
		}

		protected void OnRequiresAction()
		{
			LastRequiredAction = DateTime.Now;

			if (RequiresAction != null)
				RequiresAction(this);
		}

		protected void OnNoLongerRequiresAction()
		{
			LastRequiredAction = DateTime.Now;

			if (NoLongerRequiresAction != null)
				NoLongerRequiresAction(this);
		}

		protected void OnSittingOut()
		{
			if (SittingOut != null)
				SittingOut(this);
		}

		protected void OnSittingIn()
		{
			if (SittingIn != null)
				SittingIn(this);
		}

		protected void OnClosed()
		{
			// Stop keyHook
			if (keyHook != null)
			{
				keyHook.Enabled = false;
				keyHook.OnKeyDown -= new Desaware.SpyWorks.KeyDownHookEventHandler(keyHook_OnKeyDown);
			}

			// Cleanup
			Die();

			if (Closed != null)
				Closed(this);
		}

		protected void OnSeated()
		{
			if (Seated != null)
				Seated(this);
		}

		protected void OnUnSeated()
		{
			if (UnSeated != null)
				UnSeated(this);
		}

		public bool IsSittingOut
		{
			get { return isSittingOut; }
		}

		public bool IsSeated
		{
			get { return isSeated; }
		}

		public string WindowTitle
		{
			get { return Win32.GetText(WindowHandle); }
		}

		public string WindowClassName
		{
			get
			{
				if (windowClassName == null)
				{
					StringBuilder sbc = new StringBuilder(256);

					Win32.GetClassName(WindowHandle, sbc, sbc.Capacity);

					windowClassName = sbc.ToString();
				}

				return windowClassName;
			}
		}

		public int WindowHeight
		{
			get
			{
				Rectangle rect = new Rectangle(0, 0, 0, 0);
				Win32.GetWindowRect(WindowHandle, ref rect);

				return rect.Height - rect.Y;
			}
		}

		public int WindowWidth
		{
			get
			{
				Rectangle rect = new Rectangle(0, 0, 0, 0);
				Win32.GetWindowRect(WindowHandle, ref rect);

				return rect.Width - rect.X;
			}
		}

		public void BringToFront()
		{
			Win32.BringWindowToTop(WindowHandle);
		}

		public virtual void Die()
		{
			// Remove the border in case it's there
			HideBorder();

			// Remove drawings
			if (Win32.IsWindow(WindowHandle))
				InvalidateDrawings();
		}

		public void InvalidateDrawings()
		{
			Rectangle size = WindowRectangle;
			Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);

			// InvalidateRect
			Win32.InvalidateRect(WindowHandle, ref rect, true);

			// UpdateWindow
			Win32.UpdateWindow(WindowHandle);

			// RedrawWindow
			Win32.RedrawWindow(WindowHandle, ref rect, 0, (uint)Win32.RDW.INVALIDATE | (uint)Win32.RDW.FRAME | (uint)Win32.RDW.UPDATENOW | (uint)Win32.RDW.ALLCHILDREN);
		}

		public void ForceRedraw()
		{
			Rectangle size = WindowRectangle;
			Rectangle winRect = new Rectangle(0, 0, size.Width, size.Height);

			Win32.RedrawWindow(WindowHandle, ref winRect, 0, (int)Win32.RDW.FRAME | (int)Win32.RDW.UPDATENOW | (int)Win32.RDW.INVALIDATE | (int)Win32.RDW.ERASENOW);
		}

		public void SetSize(Size size)
		{
			Point pos = WindowPosition;

			Win32.SetWindowPos(WindowHandle, (int)Win32.HWND.NOTOPMOST, pos.X, pos.Y, size.Width, size.Height, (uint)Win32.SWP.NOOWNERZORDER);
		}

		public bool IsActiveTable
		{
			get { return Core.ActiveTable == this; }
		}

		public void CloseWindow()
		{
			Win32.PostMessage(WindowHandle, (int)Win32.WM.SYSCOMMAND, (int)Win32.SC.CLOSE, 0);
		}

		public Rectangle WindowRectangle
		{
			get
			{
				Rectangle pos = new Rectangle();

				Win32.GetWindowRect(WindowHandle, ref pos);

				pos.Width = pos.Width - pos.X;
				pos.Height = pos.Height - pos.Y;

				return pos;
			}
		}

		public Point WindowPosition
		{
			get
			{
				Rectangle pos = new Rectangle();

				Win32.GetWindowRect(WindowHandle, ref pos);

				return new Point(pos.X, pos.Y);
			}
		}

		public bool NeedsAction
		{
			get { return needsAction; }
		}

		public void MoveToQuadrant(Quadrant quad, bool activeQuad)
		{
			//TODO: Move to quadrant
			/*
			int x = quad.X;
			int y = quad.Y;
			int width = quad.Width;
			int height = quad.Height;

			// Make sure table ratio & size doesn't exeed quadrant dimenzions
			if (width > MaxTableSize.Width)
				width = MaxTableSize.Width;
			else if (width < MinTableSize.Width)
				width = MinTableSize.Width;

			height = Convert.ToInt32((double)width * GetAspectRatio((int)width));

			// Save the previous location
			if (Quadrant != Settings.ActiveTableQuadrant)
				Win32.GetWindowRect(WindowHandle, ref lastLocation);

			// Move the window
			Win32.SetWindowPos(WindowHandle, (int)Win32.HWND.NOTOPMOST, x, y, width, height, (uint)Win32.SWP.NOOWNERZORDER);

			// Set the tables quad location
			Quadrant = quad.Number;
			*/
		}

		public int Quadrant
		{
			get { return quadrant; }
			set { quadrant = value; }
		}

		public void HideBorder()
		{
			//TODO: Hide border
			//if (borderForm != null)
			//	borderForm.Hide();
		}

		//private BorderForm borderForm = null;
		public void ShowBorder(Color color)
		{
			//TODO: Show border
			/*Rectangle size = WindowRectangle;
			
			if (borderForm == null || borderForm.Width != size.Width)
			{
				if (borderForm != null)
					borderForm.Dispose();

				Bitmap b = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
				Graphics g = Graphics.FromImage(b);
				g.FillRectangle(new SolidBrush(color), 0, 0, b.Width, b.Height);
				int activeTableBorderWidth = Settings.ActiveTableBorderWidth;
				g.FillRectangle(new SolidBrush(Color.Black), activeTableBorderWidth, activeTableBorderWidth, b.Width - activeTableBorderWidth * 2, b.Height - activeTableBorderWidth * 2);
				g.Save();
				b.MakeTransparent(Color.Black);

				borderForm = new BorderForm();
				borderForm.Width = size.Width;
				borderForm.Height = size.Height;
				borderForm.BackgroundImage = b;
				borderForm.TransparencyKey = Color.Black;
				borderForm.TopMost = true;
			}

			Rectangle rect = new Rectangle();
			Win32.GetWindowRect(windowHandle, ref rect);
			Win32.SetWindowPos((int)borderForm.Handle, 0, rect.Left, rect.Top, 0, 0, 0x201);
			borderForm.Show();
			*/
		}

		public void UpdateChildren()
		{
			Win32.EnumChildWindows(WindowHandle, new Win32.PChildCallBack(EnumChildWindowCallBack), 0);
		}

		public void MoveToLastLocation()
		{
			//TODO: Move table to last location
		}

		public abstract bool EnumChildWindowCallBack(int hWnd, int lParam);
		public abstract Size MinTableSize { get; }
		public abstract Size MaxTableSize { get; }
		public abstract bool IsResizable { get; }
		public abstract string SiteName { get; }
		public abstract IPokerTable Create(int hwnd);
		public abstract bool IsPokerTable(int hwnd);
		public abstract void InvokeActionTick();
		public abstract double GetAspectRatio(int width);
		public abstract void MoveCursorToTable();
		public abstract void AutoPush();
		public abstract string GetRaiseValue();
		public abstract void CheckCall();
		public abstract void Fold();
		public abstract void BetRaise();
		public abstract void SetRaiseValue(string raiseValue);
	}
}