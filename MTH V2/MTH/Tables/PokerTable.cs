using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;

namespace MTH
{
	/// <summary>
	/// Summary description for Table.
	/// </summary>
	public class PokerTable
	{
		protected int handle;
		protected string name;
		protected string windowTitle;
		protected string className;
		protected TableFactory.Site site;
        public Dictionary<int, ChildWindow> children = new Dictionary<int, ChildWindow>();
		protected bool needsAction = false;
		protected Rectangle lastLocation = new Rectangle(0, 0, 0, 0);
		public int Quadrant = 0;
		protected DateTime lastRequiredAction = DateTime.Now;
		protected TableFactory.GameForm gameForm = TableFactory.GameForm.Unknown;
		protected TableFactory.GameLimit gameLimit = TableFactory.GameLimit.Unknown;
		protected TableFactory.GameType gameType = TableFactory.GameType.Unknown;
		protected string stakes = "N/A";
		protected string ownerProcessExe;
        protected int blindLevel = 0;
		protected BorderForm borderForm;
		public Color IdentificationColor = Color.Black;
		protected Stopwatch watch = new Stopwatch();
		protected double cumulativeResponseTime = 0;
		protected int actionCount;
		public bool IsSittingOut;
		public static Size MinTableSize;
		public static Size MaxTableSize;
		public static double TableSizeRatio;

		public event TableFactory.ClosedEventHandler Closed;
		public event TableFactory.RequiresActionEventHandler RequiresAction;
		public event TableFactory.NoLongerRequiresActionEventHandler NoLongerRequiresAction;
		public event TableFactory.SittingOutEventHandler SittingOut;

		[DllImport("User32.dll")]
		protected static extern Boolean EnumChildWindows(int hWndParent,PChildCallBack lpEnumFunc,int lParam);
		protected delegate bool PChildCallBack(int hWnd,int lParam);

		#region Accessors
		public double ART
		{
			get
			{
				return cumulativeResponseTime / actionCount / 1000;
			}
		}

		public string SiteName
		{
			get
			{
				switch(ownerProcessExe)
				{
					case "empirepoker":
						return "Empire";
					case "partygaming":
						return "Party";
					case "pokerstars":
						return "Stars";
					default:
						return "Unknown";
				}
			}
		}

        public int BlindLevel
        {
            get { return blindLevel; }
        }

		public string OwnerProcessExe
		{
			get { return ownerProcessExe; }
		}

		public string Stakes
		{
			get { return stakes; }
		}

		public TableFactory.GameForm GameForm
		{
			get { return gameForm; }
		}

		public TableFactory.GameLimit GameLimit
		{
			get { return gameLimit; }
		}

		public TableFactory.GameType GameType
		{
			get { return gameType; }
		}

		public int Handle
		{
			get { return handle; }
			set { handle = value; }
		}

		public TableFactory.Site Site
		{
			get { return site; }
			set { site = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string WindowTitle
		{
			get
			{
				StringBuilder sb = new StringBuilder(1024);
				Win32.GetWindowText(handle, sb, sb.Capacity);

				return sb.ToString();
			}
			set { windowTitle = value; }
		}

		public string ClassName
		{
			get { return className; }
			set { className = value; }
		}

		public int Height
		{
			get
            {
                Rectangle rect = new Rectangle(0, 0, 0, 0);
                Win32.GetWindowRect(handle, ref rect);

                return rect.Height - rect.Y;
            }
		}

		public int Width
		{
			get
            {
                Rectangle rect = new Rectangle(0, 0, 0, 0);
                Win32.GetWindowRect(handle, ref rect);

                return rect.Width - rect.X;
            }
		}
		#endregion

        protected enum BetButton
        {
            Left,
            Center,
            Right
        }

		/// <summary>
		/// Event proxy
		/// </summary>
		protected void requiresAction()
		{
			if(RequiresAction != null)
				RequiresAction(handle);
		}

		/// <summary>
		/// Event proxy
		/// </summary>
		protected void noLongerRequiresAction()
		{
			if(NoLongerRequiresAction != null)
				NoLongerRequiresAction(handle);
		}

		/// <summary>
		/// Event proxy
		/// </summary>
		protected void sittingOut()
		{
			if (SittingOut != null)
				SittingOut(handle);
		}

		/// <summary>
		/// Initializes the table, gets info about the window
		/// </summary>
		/// <param name="handle"></param>
		public PokerTable(int handle)
		{
			this.handle = handle;
			
			// Get the window class & title
			StringBuilder sb = new StringBuilder(1024);
			StringBuilder sbc = new StringBuilder(256);
			
			Win32.GetClassName(handle, sbc, sbc.Capacity);
			Win32.GetWindowText(handle, sb, sb.Capacity);

			windowTitle = sb.ToString();
			className = sbc.ToString();
			name = windowTitle;

			// Get the owner process exe
			ownerProcessExe = Process.GetProcessById(Win32.GetWindowProcessID(handle)).ProcessName.ToLower();

			// Get children
			UpdateChildren();
		}

		/// <summary>
		/// Brings the table window to front
		/// </summary>
		public void BringToFront()
		{
			Win32.BringWindowToTop((IntPtr)handle);
		}

		/// <summary>
		/// Invalidates any drawings
		/// </summary>
		public void HideBorder()
		{
			if (borderForm != null)
				borderForm.Hide();
		}

		/// <summary>
		/// Invalidates any drawings that have been made on the canvas
		/// </summary>
		public void InvalidateDrawings()
		{
			Rectangle rect = new Rectangle(0, 0, Width, Height);

			// InvalidateRect
			Win32.InvalidateRect((int)handle, ref rect, true);

			// UpdateWindow
			Win32.UpdateWindow((IntPtr)handle);

			// RedrawWindow
			Win32.RedrawWindow((IntPtr)handle, ref rect, IntPtr.Zero, (uint)Win32.RDW.INVALIDATE | (uint)Win32.RDW.FRAME | (uint)Win32.RDW.UPDATENOW | (uint)Win32.RDW.ALLCHILDREN);
		}

		/// <summary>
		/// Starts the borderTimer
		/// </summary>
		/// <param name="color"></param>
		public void ShowBorder(Color color)
		{
			BorderForm bf;

			if (borderForm == null || borderForm.Width != Width)
			{
				Bitmap b = TableFactory.GetBorderBitmap(color, site, Width, Height);
				bf = TableFactory.MakeBorderForm(Width, Height, b, color);
				bf.TopMost = true;
				borderForm = bf;
			}
			else
				bf = borderForm;

			Rectangle rect = new Rectangle();
			Win32.GetWindowRect(handle, ref rect);
			Win32.SetWindowPos((int)bf.Handle, 0, rect.Left, rect.Top, 0, 0, 0x201);
			bf.Show();

			if (Settings.FlashTable)
				bf.Flash();
			else
				bf.NoFlash();
		}

		/// <summary>
		/// Fires when the table has been activated
		/// </summary>
		public void HasBeenActivated()
		{
			ChildWindow box = null;

			// Clear the bet box
			if (Settings.ClearBetBoxOnNLTables)
			{
				box = getBetBox();
				if (box != null)
					SetRaiseValue("");
			}

			// Shall we show a border?
			if (Settings.UseBorder)
			{
				// If we're a tourney, show special tourney blind level color
				if (GameForm == TableFactory.GameForm.MTT || GameForm == TableFactory.GameForm.SNG)
				{
					if (blindLevel >= 1 && blindLevel <= 10)
						ShowBorder(Settings.BlindLevelColor(blindLevel));
					else
						ShowBorder(Settings.BorderColor);
				}
				else
					ShowBorder(Settings.BorderColor);
			}

			// Clear the bet box
			if (Settings.ClearBetBoxOnNLTables)
			{
				if (box == null)
				{
					box = getBetBox();
					if (box != null)
						SetRaiseValue("");
				}
			}
		}

		/// <summary>
		/// Moves the table back to where it was previously moved from
		/// </summary>
		public void MoveToLastLocation()
		{
			// Since it's a specific location, our quadrant is unknown
			Quadrant = 0;

			// Check for out of bounds location
			if(lastLocation.X < -1000 || lastLocation.Y < -1000)
			{
				lastLocation.X = 0;
				lastLocation.Y = 0;
			}

			// Move the window
			Win32.SetWindowPos(handle, (int)Win32.HWND.NOTOPMOST, lastLocation.X, lastLocation.Y, 0, 0, (uint)Win32.SWP.NOSIZE | (uint)Win32.SWP.NOOWNERZORDER);
		}

		public void ForceRedraw()
		{
			Rectangle winRect = new Rectangle(0, 0, Width, Height);
			Win32.RedrawWindow((IntPtr)handle, ref winRect, IntPtr.Zero, (int)Win32.RDW.FRAME | (int)Win32.RDW.UPDATENOW | (int)Win32.RDW.INVALIDATE | (int)Win32.RDW.ERASENOW);
		}

		/// <summary>
		/// Moves the table window to the specific quadrant
		/// </summary>
		/// <param name="quad"></param>
		public void MoveToQuadrant(Quadrant quad, bool activeQuad)
		{
			int x = quad.X;
			int y = quad.Y;
			int width = quad.Width;
			int height = quad.Height;

			// Make sure table ratio & size doesn't exeed quadrant dimenzions
			if (width > MaxTableSize.Width)
				width = MaxTableSize.Width;
			else if (width < MinTableSize.Width)
				width = MinTableSize.Width;

			height = Convert.ToInt32((double)width * GetAspectRatio((int)width, this.Site));

			// Save the previous location
			if(this.Quadrant != Settings.ActiveTableQuadrant)
				Win32.GetWindowRect(handle, ref lastLocation);

			// Move the window
			Win32.SetWindowPos(handle, (int)Win32.HWND.NOTOPMOST, x, y, width, height, (uint)Win32.SWP.NOOWNERZORDER);

			// Force redraw for stars tables
			if (this.GetType() == typeof(StarsTable))
			{
				Win32.SendMessage(Handle, (int)Win32.WM.ENTERSIZEMOVE, 0, 0);
				Win32.SendMessage(Handle, (int)Win32.WM.SIZE, (int)Win32.SIZE.RESTORED, width + height << 16);
				
				//Rectangle rect = new Rectangle();
				//Win32.GetWindowRect(Handle, ref rect);

				//Win32.SendMessage((IntPtr)Handle, (int)Win32.WM.SIZING, (int)Win32.WMSZ.BOTTOM, ref rect);
				
				//Win32.SendMessage((IntPtr)Handle, (int)Win32.WM.NCCALCSIZE, false, ref rect);

				Win32.SendMessage(Handle, (int)Win32.WM.EXITSIZEMOVE, 0, 0);
				Win32.SendMessage(Handle, (int)Win32.WM.KILLFOCUS, 0, 0);
			}

			// Set the tables quad location
			Quadrant = quad.Number;
		}

		/// <summary>
		/// Returns the tables position on the screen
		/// </summary>
		/// <returns></returns>
		public Point GetPosition()
		{
			Rectangle pos = new Rectangle();

			Win32.GetWindowRect(handle, ref pos);

			return new Point(pos.X, pos.Y);
		}

        /// <summary>
        /// Resizes the table to the given size
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(Size size)
        {
            Point pos = GetPosition();
            Win32.SetWindowPos(handle, (int)Win32.HWND.NOTOPMOST, pos.X, pos.Y, size.Width, size.Height, (uint)Win32.SWP.NOOWNERZORDER);
        }

		/// <summary>
		/// Gets all the children for this table
		/// </summary>
		public void UpdateChildren()
		{
			EnumChildWindows(handle, new PChildCallBack(EnumChildWindowCallBack), 0);
		}

		/// <summary>
		/// Returns a TimeSpan object with the time since this table last required action
		/// </summary>
		/// <returns></returns>
		public TimeSpan TimeSinceLastAction()
		{
			return DateTime.Now.Subtract(lastRequiredAction);
		}

		/// <summary>
		/// Paints the identfiication on the table
		/// </summary>
		protected virtual void identifyTable()
		{
			// Get DC
			IntPtr wndDC = Win32.GetWindowDC((IntPtr)handle);

			// Get graphics
			Graphics g = Graphics.FromHdc(wndDC);

			Brush brush = new SolidBrush(IdentificationColor);

			if (Settings.UseColorIdentification)
			{
				// Paint color identification
				switch (Settings.ColorIdentificationSize)
				{
					case "small":
						g.FillRectangle(brush, new Rectangle(0, 0, 22, 22));
						break;
					case "medium":
						g.FillRectangle(brush, new Rectangle(Width - 260, 0, 190, 22));
						break;
					case "large":
						g.FillRectangle(brush, new Rectangle(0, 0, Width, 22));
						break;
					case "complete":
						int borderWidth = Settings.TableIdentificationCompleteBorderWidth;
						g.FillRectangle(brush, 0, 0, Width, borderWidth);
						g.FillRectangle(brush, 0, 0, borderWidth, Height);
						g.FillRectangle(brush, Width - borderWidth, 0, borderWidth, Height);
						g.FillRectangle(brush, 0, Height - borderWidth, Width, borderWidth);
						break;
				}
			}

			// Cleanup
			g.Dispose();
			Win32.ReleaseDC((IntPtr)handle, wndDC);
		}

		/// <summary>
		/// Invokes the actionTick event
		/// </summary>
		public void InvokeActionTick()
		{
			actionTick(this, new EventArgs());
		}

		/// <summary>
		/// Ticks every 300 ms, updates table status
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void actionTick(object sender, EventArgs e)
		{
			// Is this table still open?
			if(!Win32.IsWindowVisible(handle))
			{
				// Close the border
				if (borderForm != null)
				{
					borderForm.Close();
					borderForm.Dispose();
				}

				// Fire closed event
				if(Closed != null)
					Closed(handle);

				// If we're closed, just return now
				return;
			}

			// Make identification if wanted
			if (Settings.UseColorIdentification)
				identifyTable();
		}

		/// <summary>
		/// Returns the location of the table
		/// </summary>
		public Rectangle Location
		{
			get
			{
				Rectangle rect = new Rectangle();
				Win32.GetWindowRect(this.Handle, ref rect);

				rect.Width = rect.Width - rect.X;
				rect.Height = rect.Height - rect.Y;

				return rect;
			}
		}

		/// <summary>
		/// Returns whether this table is the active one
		/// </summary>
		public bool IsActiveTable
		{
			get
			{
				return Form1.FormReference.activeTable == handle;
			}
		}

		/// <summary>
		/// Returns the aspect ratio based upon
		/// </summary>
		/// <param name="width"></param>
		/// <param name="currentPokerSite"></param>
		/// <returns></returns>
		public static double GetAspectRatio(int width, TableFactory.Site currentPokerSite)
		{
			switch (currentPokerSite)
			{
				case TableFactory.Site.Party:
					return (double)PartyTable.SpecialMaxTableSize.Height / (double)PartyTable.SpecialMaxTableSize.Width;
				case TableFactory.Site.Stars:
					// Calculate the ratio difference
					double minRatio = (double)StarsTable.SpecialMaxTableSize.Height / (double)StarsTable.SpecialMaxTableSize.Width;
					double maxRatio = (double)StarsTable.SpecialMinTableSize.Height / (double)StarsTable.SpecialMinTableSize.Width;
					double ratioDiff = maxRatio - minRatio;

					// Calculate the 
					double sizeDiff = (double)StarsTable.SpecialMaxTableSize.Width - (double)StarsTable.SpecialMinTableSize.Width;
					double curSizeDiff = (double)StarsTable.SpecialMaxTableSize.Width - (double)width;
					double diffRatio = curSizeDiff / sizeDiff;

					return minRatio + diffRatio * ratioDiff;
			}

			return 0;
		}

		public virtual void SetRaiseValue(string raiseValue) { MessageBox.Show("SetRaiseValue not overridden"); }
		public virtual TableFactory.ActionStatus GetActionStatus() { MessageBox.Show("GetActionStatus not overridden"); return TableFactory.ActionStatus.None; }
		protected virtual bool EnumChildWindowCallBack(int hwnd, int lParam) { MessageBox.Show("EnumChildWindowCallBack not overridden"); return true; }
		public virtual void BetRaise() { MessageBox.Show("BetRaise not overridden"); }
		public virtual void Fold() { MessageBox.Show("Fold not overridden"); }
		public virtual void CheckCall() { MessageBox.Show("CheckCall not overridden"); }
		public virtual string GetRaiseValue() { MessageBox.Show("GetRaiseValue not overridden"); return ""; }
		public virtual void SitOut() { MessageBox.Show("SitOut not overridden"); }
		public virtual void PostBlind() { MessageBox.Show("PostBlind not overridden"); }
		public virtual bool IsSeated() { MessageBox.Show("IsSeated not overridden"); return false; }
		protected virtual void delayedSetRaiseValue(object sender, EventArgs e) {}
		public virtual void AutoPush() { MessageBox.Show("AutoPush not overridden"); }
		public virtual void MoveCursorToTable() { MessageBox.Show("MoveCursorToTable not overridden"); }
		public virtual void CloseWindow() { MessageBox.Show("CloseWindow not overridden"); }
        protected virtual int getBlindLevel() { MessageBox.Show("GetBlindLevel not overridden"); return 0; }
		protected virtual ChildWindow getBetBox() { MessageBox.Show("getBetBox not overridden"); return null; }
        public virtual bool TakeSeat(int seat) { MessageBox.Show("TakeSeat not overridden"); return false; }
		public virtual void Die() { MessageBox.Show("Die not overridden"); }
	}
}
