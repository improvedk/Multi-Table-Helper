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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MTH.Framework;
using MTH.Plugins.Sites;

namespace Table_Tester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		int hwnd;
		IPokerTable table;
		bool isHooked = false;

		private void button1_Click(object sender, EventArgs e)
		{
			hwnd = int.Parse(txtHandle.Text, NumberStyles.HexNumber);

			hook();
		}

		private void hook()
		{
			if (hwnd != 0)
			{
			/*	MTHCrypto c = new MTHCrypto();

				if (c.IsPokerTable(hwnd))
				{
					lblIsPokerTable.Text = "True";
					groupBox1.Text = "Hooked";
					isHooked = true;

					table = c.Create(hwnd);

					table.RequiresAction += new Delegates.RequiresActionEventHandler(table_RequiresAction);
					table.NoLongerRequiresAction += new Delegates.NoLongerRequiresActionEventHandler(table_NoLongerRequiresAction);
				}
				else
				{
					lblIsPokerTable.Text = "False";
					groupBox1.Text = "Not hooked";
					isHooked = false;

					table = null;
				}

				updateData();*/
			}
			else
				MessageBox.Show("Must provide handle to hook.");
		}

		void table_NoLongerRequiresAction(int handle)
		{
			lblRequiresAction.Text = "False";
		}

		void table_RequiresAction(int handle)
		{
			lblRequiresAction.Text = "True";
		}

		private void updateData()
		{
			if (isHooked)
			{
				lblTitle.Text = table.TableName;
				lblSiteName.Text = table.SiteName;
				lblRequiresAction.Text = "False";
				lblIsSeated.Text = table.IsSeated.ToString();
				lblIsSittingOut.Text = table.IsSittingOut.ToString();
				lblGetRaiseValue.Text = table.GetRaiseValue();
				lblGetActionStatus.Text = table.GetActionStatus().ToString();
			}
			else
			{
				lblTitle.Text = "-";
				lblSiteName.Text = "-";
				lblRequiresAction.Text = "-";
				lblIsSeated.Text = "-";
				lblIsSittingOut.Text = "-";
				lblGetRaiseValue.Text = "-";
				lblGetActionStatus.Text = "-";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateData();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.MoveCursorToTable();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.InvokeActionTick();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.Fold();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.CheckCall();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.BetRaise();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (table != null)
				lblGetRaiseValue.Text = table.GetRaiseValue();
		}

		private void button8_Click_1(object sender, EventArgs e)
		{
			if (table != null)
				table.AutoPush();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (table != null)
				table.SetRaiseValue(txtRaiseAmount.Text);
		}
	}
}