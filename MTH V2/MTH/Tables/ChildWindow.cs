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
	/// Summary description for ChildWindow.
	/// </summary>
	public class ChildWindow
	{
		private int handle;
		private string className;
		private int? controlID;

		public ChildWindow(int handle, string className)
		{
			this.handle = handle;
			this.className = className;
		}

		public ChildWindow(int handle)
		{
			this.handle = handle;
		}

		public int ControlID
		{
			get
			{
				if (!controlID.HasValue)
					controlID = Win32.GetControlIDFromHwnd(handle);

				return controlID.Value;
			}
		}

		public string Text
		{
			get
			{
				return Win32.GetText(handle);
			}
		}

		public bool IsVisible
		{
			get
			{
				return Win32.IsWindowVisible(handle);
			}
		}

		public int Width
		{
			get
			{
				Rectangle rect = new Rectangle();

				Win32.GetClientRect(handle, ref rect);

				return rect.Width;
			}
		}

		public int Height
		{
			get
			{
				Rectangle rect = new Rectangle();

				Win32.GetClientRect(handle, ref rect);

				return rect.Height;
			}
		}

        public double SizeRatio
        {
            get
            {
                Rectangle rect = new Rectangle();

                Win32.GetClientRect(handle, ref rect);

                return (double)rect.Width / (double)rect.Height;
            }
        }

		public int Handle
		{
			get { return handle; }
			set { handle = value; }
		}

		public string ClassName
		{
			get { return className; }
			set { className = value; }
		}
	}
}
