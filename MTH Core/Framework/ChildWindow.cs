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

using System.Drawing;

namespace MTH.Framework
{
	public class ChildWindow
	{
		private int? controlID;
		public int Handle { get; set; }
		public string ClassName { get; set; }

		public ChildWindow(int handle, string className)
		{
			this.Handle = handle;
			this.ClassName = className;
		}

		public ChildWindow(int handle)
		{
			this.Handle = handle;
		}

		public int ControlID
		{
			get
			{
				if (!controlID.HasValue)
					controlID = Win32.GetControlIDFromHwnd(Handle);

				return controlID.Value;
			}
		}

		public string Text
		{
			get
			{
				return Win32.GetText(Handle);
			}
		}

		public bool IsVisible
		{
			get
			{
				return Win32.IsWindowVisible(Handle);
			}
		}

		public int Width
		{
			get
			{
				Rectangle rect = new Rectangle();

				Win32.GetClientRect(Handle, ref rect);

				return rect.Width;
			}
		}

		public int Height
		{
			get
			{
				Rectangle rect = new Rectangle();

				Win32.GetClientRect(Handle, ref rect);

				return rect.Height;
			}
		}

		public double SizeRatio
		{
			get
			{
				Rectangle rect = new Rectangle();

				Win32.GetClientRect(Handle, ref rect);

				return (double)rect.Width / (double)rect.Height;
			}
		}
	}
}