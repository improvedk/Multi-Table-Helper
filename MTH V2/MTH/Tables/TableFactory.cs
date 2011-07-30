using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;

namespace MTH
{
	/// <summary>
	/// Summary description for TableFactory.
	/// </summary>
	public class TableFactory
	{
		public delegate void ClosedEventHandler(int handle);
		public delegate void RequiresActionEventHandler(int handle);
		public delegate void NoLongerRequiresActionEventHandler(int handle);
		public delegate void SittingOutEventHandler(int handle);

		/// <summary>
		/// An enumeration containing all the sites
		/// </summary>
		public enum Site
		{
			Party,
			Stars,
			Crypto,
			Prima,
			FTP,
			Invalid
		}

		/// <summary>
		/// An enumeration containing all the game forms
		/// </summary>
		public enum GameForm
		{
			Cash,
			SNG,
			MTT,
			Unknown
		}

		/// <summary>
		/// An enumeration containing all the limit types
		/// </summary>
		public enum GameLimit
		{
			NL,
			FL,
			PL,
			Unknown
		}

		/// <summary>
		/// An enumeration containing all the game types
		/// </summary>
		public enum GameType : int
		{
			Holdem,
			Omaha,
			Stud,
			HORSE,
			HOSE,
			Unknown
		}

		/// <summary>
		/// An enumeration containing all possible action states a poker table could have
		/// </summary>
		public enum ActionStatus
		{
			None,
			RequiresActionNormal
		}

		/// <summary>
		/// Creates a border form to be used on poker tables
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="b"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		public static BorderForm MakeBorderForm(int width, int height, Bitmap b, Color color)
		{
			BorderForm f = new BorderForm();

			f.Width = width;
			f.Height = height;

            b.MakeTransparent(Color.Black);

			f.BackgroundImage = b;
			
			f.TransparencyKey = Color.Black;
			f.FlashColor = color;

			return f;
		}

		/// <summary>
		/// Loads a site specific border bitmap file and returns the bitmap object
		/// </summary>
		/// <param name="color"></param>
		/// <param name="site"></param>
		/// <returns></returns>
		public static Bitmap GetBorderBitmap(Color color, Site site, int width, int height)
		{
			Bitmap b = null;

			switch(site)
			{
				case Site.Party:
					b = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

					Graphics g = Graphics.FromImage(b);
					
					g.FillRectangle(new SolidBrush(color), 0, 0, b.Width, b.Height);
					g.FillRectangle(new SolidBrush(Color.Black), Settings.ActiveTableBorderWidth, Settings.ActiveTableBorderWidth, b.Width - (Settings.ActiveTableBorderWidth * 2), b.Height - (Settings.ActiveTableBorderWidth * 2));

                    g.Save();

					return b;
			}

			if(b == null)
				throw new Exception("Tried to get border with unknown color: " + color.ToString());

			return b;
		}

		/// <summary>
		/// Determines whether if it's a poker table or not
		/// </summary>
		/// <param name="className"></param>
		/// <param name="windowTitle"></param>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static bool IsPokerTable(string className, string windowTitle, int handle)
		{
			if(DetermineSite(className, windowTitle, handle) != Site.Invalid)
				return true;

			return false;
		}

		/// <summary>
		/// Creates a poker table
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static PokerTable MakePokerTable(int handle)
		{
			PokerTable result = null;

			switch(DetermineSite(handle))
			{
				case Site.Party:
					return new PartyTable(handle);
				case Site.Stars:
					return new StarsTable(handle);
				case Site.FTP:
					return new FTPTable(handle);
			}

			return result;
		}

		/// <summary>
		/// Determines what site a given window belongs to
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static Site DetermineSite(string className, string windowTitle, int handle)
		{
            // Get size
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            Win32.GetClientRect(handle, ref rect);

            int width = rect.Width - rect.X;
            int height = rect.Height - rect.Y;

			// Test for Party
            if (className == "#32770")
            {
                // Is title OK?
                if (windowTitle.IndexOf("Good Luck") > 1 && !windowTitle.Contains("PartyPoker.com:") && !windowTitle.Contains("EmpirePoker: Poker Lobby") && !windowTitle.Contains("EmpirePoker Lobby") && !windowTitle.Contains("Tournament lobby"))
                    return Site.Party;
            }

			// Test for Stars
			if (className.StartsWith("Afx:400000:b:"))
			{
				// Is title OK?
				if (!windowTitle.Contains("Lobby"))
					return Site.Stars;
			}

			// Test for FTP
			if (className == "FTC_TableViewFull")
			{
				return Site.FTP;
			}

			return Site.Invalid;
		}

		/// <summary>
		/// Overload
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static Site DetermineSite(int handle)
		{
			// Get the window class & title
			StringBuilder sb = new StringBuilder(1024);
			StringBuilder sbc = new StringBuilder(256);
			
			Win32.GetClassName(handle, sbc, sbc.Capacity);
			Win32.GetWindowText(handle, sb, sb.Capacity);

			string className = sbc.ToString();
			string windowTitle = sb.ToString();

			return DetermineSite(className, windowTitle, handle);
		}
	}
}
