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
using System.IO;
using System.Windows.Forms;
using MTH.Framework;

namespace MTH.Core
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Load & run startup plugins
			foreach (string file in Directory.GetFiles(Application.StartupPath + "\\Plugins\\Startup", "*.dll"))
			{
				IStartupPlugin startupPlugin = PluginHandler.LoadPlugin<IStartupPlugin>(file);

				if (startupPlugin != null)
					startupPlugin.Run();
			}

			Application.Run(new Form1());
		}
	}
}