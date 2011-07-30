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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MTH.Framework;
using System.Collections;

namespace MTH.Core
{
	public partial class Form1 : Form, ICore
	{
		// Pokersite plugins
		public List<IPokerTable> SitePlugins = new List<IPokerTable>();

		// Timings
		int timeBetweenTablePolls = 5000;
		int timeBetweenTableListUpdates = 2000;

		// List of hwnds that have been identified as non-related
		Dictionary<int, int> bannedHwnds = new Dictionary<int, int>();

		// List of pokertables in action, the int represents the handle of the window
		List<IPokerTable> pokerTables = new List<IPokerTable>();

		// The queue of tables needing action, FIFO based
		List<IPokerTable> actionQueue = new List<IPokerTable>();

		/// <summary>
		/// Clean up when closing MTH
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Kill tables gracefully when closing
			foreach (IPokerTable table in pokerTables)
				table.Die();
		}

		/// <summary>
		/// Make sure to poll tables when the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Load poker site plugins
			foreach (string file in Directory.GetFiles(Application.StartupPath + "\\Plugins\\Sites", "*.dll"))
			{
				IPokerTable sitePlugin = PluginHandler.LoadPlugin<IPokerTable>(file);

				if (sitePlugin != null)
				{
					sitePlugin.Core = this;
					SitePlugins.Add(sitePlugin);
				}
			}

			// Start thread that polls for new table windows
			Thread tablePoller = new Thread(new ThreadStart(delegate()
			{
				// Poll tables right away
				pollTables();

				// Sleep preset time between table polls
				Thread.Sleep(timeBetweenTablePolls);
			}));
			tablePoller.Start();

			//TODO: Load form size & position

			//TODO: Set global key hook listener
			// Set the global key hook
			//actHook = new UserActivityHook();
			//actHook.KeyDown += new KeyEventHandler(myKeyDown);
		}

		private void updateTableList()
		{
			//TODO: Update the table list gui
		}

		private void pollTables()
		{
			Win32.EnumWindows(enumCallback, 0);
		}

		private void tableSittingOut(IPokerTable table)
		{
			// If we should move sitting out tables to a special location, do so
			if (Settings.PlaceUnseatedTablesAtSpecialLocation)
				table.MoveToQuadrant(Settings.GetQuad(Settings.NonSeatedTableQuadrant), false);

			// Update list of tables
			updateTableList();
		}

		private void tableSeated(IPokerTable table)
		{
			// Update list of tables
			updateTableList();
		}

		void tableSittingIn(IPokerTable table)
		{
			//TODO: Move table to free quadrant

			// Update list of tables
			updateTableList();
		}
		
		private bool enumCallback(int hwnd, int lParam)
		{
			// Ignore already tested handles
			if (bannedHwnds.ContainsKey(hwnd))
				return true;

			// Ignore current tables
			if (pokerTables.Where(table => table.WindowHandle == hwnd).Count() > 0)
				return true;

			// Ignore hidden windows
			if (!Win32.IsWindowVisible(hwnd))
				return true;

			// For each site plugin, test if the plugin deems the handle a poker table
			foreach (IPokerTable tableType in SitePlugins)
			{
				if (tableType.IsPokerTable(hwnd))
				{
					// It's a poker table, create an instance and set event handlers
					IPokerTable table = tableType.Create(hwnd);
					table.Closed += tableClosed;
					table.RequiresAction += tableRequiresAction;
					table.NoLongerRequiresAction += tableNoLongerRequiresAction;
					table.SittingOut += tableSittingOut;
					table.SittingIn += tableSittingIn;
					table.Seated += new Delegates.SeatedEventHandler(table_Seated);
					table.UnSeated += new Delegates.UnSeatedEventHandler(table_UnSeated);

					// Add the table to the pokerTables table
					pokerTables.Add(table);

					// Update table list
					updateTableList();

					return true;
				}
			}

			// Ban this handle so we don't retest it
			bannedHwnds.Add(hwnd, 0);

			return true;
		}

		private void tableNoLongerRequiresAction(IPokerTable table)
		{
			// Remove the border
			table.HideBorder();

			// If it was the active table, remove if not KeepActiveTable
			if (ActiveTable == table)
			{
				// Reset activeTable
				activeTable = null;

				// Move to free spot if we don't want to keep the active table
				if (!Settings.KeepActiveTable && Settings.MoveActiveTable)
					if (Settings.AutoArrangeTables)
						moveTableToFreeQuadrant(table, 0);
					else
						table.MoveToLastLocation();

				// Remove from the queue
				actionQueue.RemoveAll(tbl => tbl == table);
			}

			// Update list of tables
			updateTableList();
		}

		private void tableRequiresAction(IPokerTable table)
		{
			// Add the table to the action queue
			actionQueue.RemoveAll(tbl => tbl == table);

			// Update the list of tables
			updateTableList();
		}

		private void tableClosed(IPokerTable table)
		{
			// Remove table from queue in case it's there
			actionQueue.RemoveAll(tbl => tbl == table);

			// Remove table from tables collection in case it's there
			pokerTables.RemoveAll(tbl => tbl == table);

			// Update the list of tables
			updateTableList();
		}

		/*
		// Vars

		private List<int> actionQueue = new List<int>();

		public List<IPokerTable> SitePlugins = new List<IPokerTable>();

		public static bool SuspendMovement = false;

		private int activeTable = 0;

		private List<int> bannedHwnds = new List<int>();

		private static Dictionary<int, IPokerTable> pokerTables = new Dictionary<int, IPokerTable>();
		
		private UserActivityHook actHook;

		private Logger logger;

        // Reference var
        public static Form1 FormReference = null;

		/// <summary>
		/// Returns the least used quadrant on the screen
		/// </summary>
		/// <returns></returns>
		public static int GetLeastUsedQuadrant(int quadrantToSpare)
		{
            int[] quadrantCount = new int[Settings.QuadrantCount + 1];

			foreach(IPokerTable table in pokerTables.Values.Where(tbl => tbl.Quadrant < quadrantCount.Length))
				quadrantCount[table.Quadrant]++;

            if(quadrantToSpare < quadrantCount.Length)
                quadrantCount[quadrantToSpare]--;

            // Make sure no tables are placed in the active quadrant - though only if we're moving the active table!
            if (Settings.MoveActiveTable)
                quadrantCount[Settings.ActiveTableQuadrant] = 999;

            int min = 999;
            int minQuad = 1;

            for (int i = 1; i < quadrantCount.Length; i++)
                if (quadrantCount[i] == 0)
                    return i;
                else
                {
                    if (quadrantCount[i] < min)
                    {
                        min = quadrantCount[i];
                        minQuad = i;
                    }
                }

            return minQuad;
		}

		/// <summary>
		/// Moves the table to the least used quadrant
		/// </summary>
		/// <param name="handle"></param>
        private void moveTableToFreeQuadrant(int handle, int quadrantToSpare)
        {
            int freeQuadrant = GetLeastUsedQuadrant(quadrantToSpare);

            pokerTables[handle].MoveToQuadrant(Settings.GetQuad(freeQuadrant), false);
        }
		
		// Fires when a key has been pressed, used in conjunction with keyboard controls
		private void myKeyDown(object sender, KeyEventArgs e)
		{
			if (Settings.RequireNumLock)
				if (!Win32.NumLock())
					return;

			if (Settings.RequireCapsLock)
				if (!Win32.CapsLock())
					return;

			if(Settings.UseKeyboardControls)
			{
				// Make the keycode
				string keyCode = "";

				// Add the actual key code
				switch (e.KeyCode)
				{
					case Keys.D1:
					case Keys.NumPad1:
						keyCode = "1";
						break;
					case Keys.D2:
					case Keys.NumPad2:
						keyCode = "2";
						break;
					case Keys.D3:
					case Keys.NumPad3:
						keyCode = "3";
						break;
					case Keys.D4:
					case Keys.NumPad4:
						keyCode = "4";
						break;
					case Keys.D5:
					case Keys.NumPad5:
						keyCode = "5";
						break;
					case Keys.D6:
					case Keys.NumPad6:
						keyCode = "6";
						break;
					case Keys.D7:
					case Keys.NumPad7:
						keyCode = "7";
						break;
					case Keys.D8:
					case Keys.NumPad8:
						keyCode = "8";
						break;
					case Keys.D9:
					case Keys.NumPad9:
						keyCode = "9";
						break;
					case Keys.D0:
					case Keys.NumPad0:
						keyCode = "0";
						break;
					case Keys.OemPeriod:
					case Keys.Decimal:
					case Keys.Oemcomma:
						keyCode = ".";
						break;
					default:
						if (e.Shift)
							keyCode = "shift+" + e.KeyCode.ToString().ToLower();
						else
							keyCode = e.KeyCode.ToString().ToLower();
						break;
				}

				// Do we have an active table?
				if (pokerTables.ContainsKey(activeTable))
				{
					IPokerTable table = pokerTables[activeTable];

					switch (keyCode)
					{
						case "back":
							string txt = table.GetRaiseValue();

							if (txt.Length > 0)
								table.SetRaiseValue(txt.Substring(0, txt.Length - 1));
							break;

						case "0":
						case "1":
						case "2":
						case "3":
						case "4":
						case "5":
						case "6":
						case "7":
						case "8":
						case "9":
						case ".":
							table.SetRaiseValue(table.GetRaiseValue() + keyCode);
							break;
					}

					// Check / call
					if (keyCode == Settings.CheckCallKeyCode)
						table.CheckCall();

					// Bet / raise
					if (keyCode == Settings.BetRaiseKeyCode)
						table.BetRaise();

					// Fold
					if (keyCode == Settings.FoldKeyCode)
						table.Fold();

					// Auto push
					if (keyCode == Settings.AutoPushKeyCode)
						table.AutoPush();

					// Move cursor to active table
					if (keyCode == Settings.MoveCursorToActiveTableKeyCode)
						table.MoveCursorToTable();
				}
				
				// Generic keyboard control functions
				// Rearrange tables
				if (keyCode == Settings.RearrangeTablesKeyCode)
					rearrangeTables();
			}
		}

		/// <summary>
		/// Removes any tables from the active quadrant
		/// </summary>
		private void removeTableFromActiveQuadrant(int quadrantToSpare)
		{
			foreach(IPokerTable table in pokerTables.Values)
			{
				if(table.Quadrant == Settings.ActiveTableQuadrant)
				{
					if(Settings.AutoArrangeTables)
						moveTableToFreeQuadrant(table.WindowHandle, quadrantToSpare);
					else
						table.MoveToLastLocation();
				}
			}
		}

		/// <summary>
		/// Checks if a new table should be moved to the active spot
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void moveTables_Tick(object sender, System.EventArgs e)
		{
			// Check if any tables are unpositioned, and if autoarrange is on
			if(Settings.AutoArrangeTables)
			{
				foreach(IPokerTable table in pokerTables.Values)
					if (table.Quadrant == 0 || (table.IsSittingOut && table.Quadrant != Settings.NonSeatedTableQuadrant && Settings.PlaceUnseatedTablesAtSpecialLocation) || (!table.IsSittingOut && table.Quadrant == Settings.NonSeatedTableQuadrant && Settings.PlaceUnseatedTablesAtSpecialLocation))
					{
						// Don't arrange tables while SNG Opener is open
						if(!SuspendMovement)
						{
							if ((!table.IsSeated || table.IsSittingOut) && Settings.PlaceUnseatedTablesAtSpecialLocation)
								table.MoveToQuadrant(Settings.GetQuad(Settings.NonSeatedTableQuadrant), false);
							else
								moveTableToFreeQuadrant(table.WindowHandle, 0);
						}
					}
			}

			// If there isn't an active table righ now
			if(!pokerTables.ContainsKey(activeTable) && actionQueue.Count > 0)
			{
				// Get the first in line table
				IPokerTable table = pokerTables[actionQueue[0]];

				// Move any tables currently occupying the active location, unless it's the table that's now active
				if(Settings.MoveActiveTable && table.Quadrant != Settings.ActiveTableQuadrant)
					removeTableFromActiveQuadrant(table.Quadrant);

				// Remove it from the queue
				if(actionQueue.Count > 0)
					actionQueue.RemoveAt(0);

				// Move it to the active quadrant
				if(Settings.MoveActiveTable)
					table.MoveToQuadrant(Settings.GetQuad(Settings.ActiveTableQuadrant), true);

				// Update activeTable
				activeTable = table.WindowHandle;

				// Clear bet box if wanted
				if (Settings.ClearBetBoxOnNLTables)
					table.SetRaiseValue("");

				// Move mouse to table if wanted
				if(Settings.MoveCursorToActiveTable)
				{
					// Get the current table position
					Point pos = table.WindowPosition;
					
					// Only move the mouse if it's outside the table area
					if(Cursor.Position.X < pos.X || Cursor.Position.X > pos.X + table.WindowWidth || Cursor.Position.Y < pos.Y || Cursor.Position.Y > pos.Y + table.WindowHeight)
						table.MoveCursorToTable();
				}

				// Show the borderform
				if (Settings.UseBorder)
					table.ShowBorder(Settings.BorderColor);
			}
		}

		/// <summary>
		/// Rearranges tables
		/// </summary>
		private void rearrangeTables()
		{
			if (Settings.AutoArrangeTables)
				foreach (IPokerTable table in pokerTables.Values.Where(tbl => tbl.Quadrant != Settings.ActiveTableQuadrant || (tbl.Quadrant == Settings.ActiveTableQuadrant && activeTable != tbl.WindowHandle)))
					table.Quadrant = 0;
		}

		/// <summary>
		/// Brings the clicked table to front
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstTables_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lstTables.SelectedItems.Count > 0)
				if (pokerTables.ContainsKey(Convert.ToInt32(lstTables.SelectedItems[0].Tag)))
				{
					int hwnd = Convert.ToInt32(lstTables.SelectedItems[0].Tag);
					pokerTables[hwnd].BringToFront();
				}
		}

		public int TableCount
		{
			get
			{
				return pokerTables.Count;
			}
		}

		/// <summary>
		/// Exits the application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Updates the table list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void updateTables()
		{
			string selectedTable = "";
			if (lstTables.SelectedItems.Count > 0)
				selectedTable = lstTables.SelectedItems[0].Text;

			List<ListViewItem> lvic = new List<ListViewItem>();
			statusBar.Text = pokerTables.Keys.Count.ToString() + " tables";

			foreach (IPokerTable table in pokerTables.Values)
			{
				ListViewItem lvi = new ListViewItem();

				bool first = true;
				string txt = "";

				foreach (ColumnHeader ch in lstTables.Columns)
				{
					switch (ch.Text)
					{
						case "Table":
							txt = table.TableName;

							if (txt == selectedTable)
								lvi.Selected = true;
							break;
						case "Site":
							txt = table.SiteName.ToString();
							break;
						case "Needs action":
							txt = (table.GetActionStatus() == ActionStatus.RequiresActionNormal).ToString();
							break;
						case "Sitting out":
							txt = table.IsSittingOut.ToString();
							break;
						case "Seated":
							txt = table.IsSeated.ToString();
							break;
						default:
							txt = "";
							break;
					}

					if (first)
					{
						lvi.Text = txt;
						first = false;
					}
					else
						lvi.SubItems.Add(txt);
				}

				lvi.Tag = table.WindowHandle;
				lvic.Add(lvi);
			}

			lstTables.BeginUpdate();
			lstTables.Items.Clear();
			lstTables.Items.AddRange(lvic.ToArray());
			lstTables.EndUpdate();
		}

		/// <summary>
		/// Opens the preferences dialog box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Thread t = new Thread(new ThreadStart(delegate()
			{
				Form preferences = new Preferences();

				preferences.ShowDialog();
			}
			));

			t.Start();
		}

		/// <summary>
		/// Opens the donation dialog box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://www.multitablehelper.com/donations.aspx");
		}

		/// <summary>
		/// Open the form again when we doubleclick the notifyicon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ni_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		/// <summary>
		/// Shows the preferences dialog box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			Preferences prefs = new Preferences();

			prefs.Show();
		}

		/// <summary>
		/// Rearranges tables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem26_Click(object sender, EventArgs e)
		{
			rearrangeTables();
		}

		/// <summary>
		/// Rearranges tables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem27_Click(object sender, EventArgs e)
		{
			rearrangeTables();
		}

		private void invokeActionTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				foreach (IPokerTable table in pokerTables.Values)
					table.InvokeActionTick();
			}
			catch (InvalidOperationException)
			{ }
		}
		*/
	}
}