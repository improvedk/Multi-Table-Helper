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
using System.Diagnostics;

namespace MTH
{
    public class PartyTournamentResultWindow
    {
		/// <summary>
		/// Child collection
		/// </summary>
		public Hashtable children = new Hashtable();

		private int handle;

		[DllImport("User32.dll")]
		static extern Boolean EnumChildWindows(int hWndParent,PChildCallBack lpEnumFunc,int lParam);
		delegate bool PChildCallBack(int hWnd,int lParam);

		/// <summary>
		/// Constructor, makes sure to get children
		/// </summary>
        public PartyTournamentResultWindow(int handle)
		{
			// Set handle
			this.handle = handle;

			// Get children
			getChildren();
		}

		/// <summary>
		/// Gets all the children for this window
		/// </summary>
		private void getChildren()
		{
			EnumChildWindows(handle, new PChildCallBack(EnumChildWindowCallBack), 0);
		}

        /// <summary>
        /// Clicks the yes button and closes the poker table
        /// </summary>
        public void ClickYes()
        {
            foreach (ChildWindow child in children.Values)
                if (child.Text == "Yes")
                    Win32.ClickButton(child.Handle);
        }

        /// <summary>
        /// Clicks the no button and closes the poker table
        /// </summary>
        public void ClickNo()
        {
            foreach (ChildWindow child in children.Values)
                if (child.Text == "No")
                    Win32.ClickButton(child.Handle);
        }

		/// <summary>
		/// The callback function which saves a child window in case it's relevant
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		protected bool EnumChildWindowCallBack(int hwnd, int lParam)
		{
			StringBuilder sbc = new StringBuilder(256);

			Win32.GetClassName(hwnd, sbc, sbc.Capacity);

			string cls = sbc.ToString();

			// Only save this child if it's relevant
			if(cls == "Button")
			{
				StringBuilder sb = new StringBuilder(256);

				Win32.GetWindowText(hwnd, sb, sb.Capacity);

				ChildWindow child = new ChildWindow(hwnd, cls);

				string txt = sb.ToString();

				if(!children.ContainsKey(hwnd) && child.IsVisible)
					children.Add(hwnd, child);
			}

			return true;
		}
    }
}
