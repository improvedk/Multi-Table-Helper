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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MTH
{
	public class BorderForm : System.Windows.Forms.Form
	{
		public BorderForm()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "BorderForm";
			this.ShowInTaskbar = false;
			this.Text = "BorderForm";
			this.ResumeLayout(false);
		}
	}
}