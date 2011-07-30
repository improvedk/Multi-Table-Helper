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
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MTH.Framework;

namespace MTH.Plugins.Startup
{
	public class MTHStartupPlugin : IPlugin, IStartupPlugin
	{
		public string Name
		{
			get { return "Default"; }
		}

		public string Description
		{
			get { return "Default MTH startup plugin"; }
		}

		public string Creator
		{
			get { return "Mark S. Rasmussen - www.improve.dk"; }
		}

		public void Run()
		{
			// Check to make sure that there aren't any instances of MTH already running
			if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
			{
				MessageBox.Show("MTH is already running", "MTH", MessageBoxButtons.OK, MessageBoxIcon.Error);

				Application.Exit();
			}
		}
	}
}