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
using SpeechLib;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace MTH
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class Form1 : System.Windows.Forms.Form
    {
        private Timer pollTables;

		// Version
		public static double Version = 2.030;

		// Vars
		[DllImport("user32.Dll")]
		static extern bool EnumWindows(PCallBack x, int y);

		private List<int> actionQueue = new List<int>();

		public static bool SuspendMovement = false;

		private delegate bool PCallBack(int hwnd, int lParam);
		private delegate bool PChildCallBack(int hWnd,int lParam);

		public int activeTable = 0;

        private static Dictionary<int, PokerTable> pokerTables = new Dictionary<int, PokerTable>();
		private static Dictionary<int, PartyLobby> pokerLobbies = new Dictionary<int, PartyLobby>();
		
		private UserActivityHook actHook;

		private Hashtable disabledTables = new Hashtable();

        private LoadFrame lfTemp;

        delegate void SetDownloadStatus(int bytesSoFar, int totalBytes);
        delegate void SetDownloadComplete( byte[] data );

        // Reference var
        public static Form1 FormReference = null;

        // Voice listener
        private VoiceListener vl = null;

		/// <summary>
		/// Retrieves the found windows and saves them in pokerWindows arraylist
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		private bool EnumWindowCallBack(int hwnd, int lParam) 
		{
            int windowHandle = hwnd;

			StringBuilder sbc = new StringBuilder(256);
			Win32.GetClassName(hwnd,sbc,sbc.Capacity);

			string wndClass = sbc.ToString();

			// Ugly Party & Stars check
            if(wndClass != "#32770" && !wndClass.StartsWith("Afx:400000:b:") && wndClass != "FTC_TableViewFull")
                return true;

			StringBuilder sb = new StringBuilder(512);
			Win32.GetWindowText(windowHandle, sb, sb.Capacity);

			string wndTitle = sb.ToString();

			// Is this a poker table?
			if (!pokerTables.ContainsKey(hwnd))
			{
				if (TableFactory.IsPokerTable(wndClass, wndTitle, hwnd))
				{
					// Create the table object
					PokerTable table = TableFactory.MakePokerTable(hwnd);

					// Set the identification color
					table.IdentificationColor = getVacantTableIDColor();

					// Set event handlers
					table.Closed += new TableFactory.ClosedEventHandler(tableClosed);
					table.RequiresAction += new TableFactory.RequiresActionEventHandler(tableRequiresAction);
					table.NoLongerRequiresAction += new TableFactory.NoLongerRequiresActionEventHandler(tableNoLongerRequiresAction);
					table.SittingOut += new TableFactory.SittingOutEventHandler(tableSittingOut);

					// Add the table to the pokerTables table
					pokerTables.Add(hwnd, table);

					// Update table list
					updateTables();
				}
				else
				{
					// Look for lobby
					if (wndTitle.StartsWith("PartyPoker.com: Poker Lobby") && !pokerLobbies.ContainsKey(hwnd))
						pokerLobbies.Add(hwnd, new PartyLobby(hwnd));
				}
            }

			return true;
		}

		/// <summary>
		/// Returns the least used quadrant on the screen
		/// </summary>
		/// <returns></returns>
		public static int GetLeastUsedQuadrant(int quadrantToSpare)
		{
            int[] quadrantCount = new int[Settings.QuadrantCount + 1];

            foreach (PokerTable table in pokerTables.Values)
            {
                if(table.Quadrant < quadrantCount.Length)
                    quadrantCount[table.Quadrant]++;
            }

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

		/// <summary>
		/// Fires when a table is sitting out
		/// </summary>
		/// <param name="handle"></param>
		private void tableSittingOut(int handle)
		{
			// Only act if table is not disabled
			if(!disabledTables.ContainsKey(handle))
			{
				// Show notification if wanted
				if (Settings.ShowNotification && pokerTables.ContainsKey(handle))
				{
					// Show icon
					ni.ShowBalloonTip(500, "Sitting out", "You're now sitting out at table: " + pokerTables[handle].Name, ToolTipIcon.Info);
				}

				// If we should move sitting out tables to a special location, do so
				if(Settings.PlaceUnseatedTablesAtSpecialLocation)
				{
					pokerTables[handle].MoveToQuadrant(Settings.GetQuad(Settings.NonSeatedTableQuadrant), false);
				}
			}
		}

		/// <summary>
		/// Fires when a table has required action, but no longer needs action
		/// </summary>
		/// <param name="handle"></param>
		private void tableNoLongerRequiresAction(int handle)
		{
			// Only act if table is not disabled
			if(!disabledTables.ContainsKey(handle) || activeTable == handle)
			{
				// If it was the active table, remove if not KeepActiveTable
				if(activeTable == handle)
				{
					// Remove the border
					pokerTables[handle].HideBorder();

					// Reset activeTable
					activeTable = 0;

					// Stop the tableOnTopTimer
					tableOnTopTimer.Enabled = false;

					// Move to free spot if we don't want to keep the active table
					if(!Settings.KeepActiveTable && Settings.MoveActiveTable)
						if(Settings.AutoArrangeTables)
							moveTableToFreeQuadrant(handle, 0);
						else
							pokerTables[handle].MoveToLastLocation();
				}

				// Remove from the queue
				actionQueue.Remove(handle);
			}
		}

		/// <summary>
		/// Fires when a table requires action
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="actionStatus"></param>
		private void tableRequiresAction(int handle)
		{
			// Only act if table is not disabled
			if(!disabledTables.ContainsKey(handle))
			{
				// Normal priority, just add it to the end of the queue
				actionQueue.Add(handle);
			}
		}

		/// <summary>
		/// Fires when a table has been closed
		/// </summary>
		/// <param name="handle"></param>
		private void tableClosed(int handle)
		{
			// Remove from the action queue
			actionQueue.Remove(handle);

			if(pokerTables.ContainsKey(handle))
			{
				// Hide the border
				pokerTables[handle].HideBorder();

				// Remove from pokerTables collection
				pokerTables.Remove(handle);

				// Remove from the disabledTables collection
				if(disabledTables.ContainsKey(handle))
					disabledTables.Remove(handle);
			}

			updateTables();
		}

		/// <summary>
		/// Polls tables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pollTables_Tick(object sender, System.EventArgs e)
		{
			// Update table list
			updateTables();

			// Stop timer
			pollTables.Enabled = false;

			// Enumerate windows to look for new tables
			EnumWindows(new PCallBack (EnumWindowCallBack), 0);

			// Reenable timer
			pollTables.Enabled = true;
		}

		/// <summary>
		/// Make sure to poll tables when the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Startup
			Log.Write("Startup");
		
			// Register autoit
			Process.Start("regsvr32", "/s \"" + Application.StartupPath + "\\AutoItX3.dll\"");

			// Fix preferences
			fixPrefs();
            
            // Show loadframe
            LoadFrame lf = new LoadFrame();
            lf.Show();

            // Set our position and size
            lf.SetProgress(35);
			Rectangle pos = Settings.MainWindowPosition;
			
			Win32.SetWindowPos((int)this.Handle, (int)Win32.HWND.NOTOPMOST, pos.X, pos.Y, 0, 0, (uint)Win32.SWP.NOSIZE | (uint)Win32.SWP.NOOWNERZORDER);
			this.Height = pos.Height;
			this.Width = pos.Width;

            // Load the table list column options
            lf.SetProgress(40);
			loadTableListColumnHeaders();

            // Poll for initial tables
            lf.SetProgress(60);
			pollTables_Tick(sender, e);

            // Set the global key hook
            lf.SetProgress(80);
			actHook = new UserActivityHook();
			actHook.KeyDown += new KeyEventHandler(MyKeyDown);

            // Set reference
            lf.SetProgress(90);
            FormReference = this;

            // Start voice listener
            lf.SetProgress(100);
            InitializeVoiceCommands();

            // Close the load frame
            lf.Close();
            lf.Dispose();

            setTitleTimer.Enabled = true;
		}

        /// <summary>
        /// Initializes the VC engine
        /// </summary>
        public void InitializeVoiceCommands()
        {
            if (Settings.SpeechEnabled && Settings.UseVoiceCommands)
            {
                vl = new VoiceListener();

                foreach (string s in Settings.VoiceCommandsList)
                    vl.AddCommand(s);

                if (Settings.VCPreset1 != "")
                    vl.AddCommand(Settings.VCPreset1);
                if (Settings.VCPreset2 != "")
                    vl.AddCommand(Settings.VCPreset2);
                if (Settings.VCPreset3 != "")
                    vl.AddCommand(Settings.VCPreset3);

                vl.CommandReceived += new VoiceListener.CommandReceivedEventHandler(commandReceived);

                try
                {
                    vl.Start();
                }
                catch (Exception e)
                {
                    Settings.SaveSetting("UseVoiceCommands", false);

                    MessageBox.Show("Voice commands have been turned off:\n\n" + e.ToString());

                    vl.Stop();
                    vl = null;
                }
            }
            else
            {
                if(vl != null)
                    vl.Stop();
                
                vl = null;
            }
        }

        /// <summary>
        /// Stops listening for voice commands
        /// </summary>
        public void StopVoiceCommands()
        {
            if(vl != null)
                vl.Stop();
            
            vl = null;
        }

        /// <summary>
        /// Fires when a voice command has been received
        /// </summary>
        /// <param name="StreamNumber"></param>
        /// <param name="StreamPosition"></param>
        /// <param name="RecognitionType"></param>
        /// <param name="Result"></param>
        private void commandReceived(string command)
		{
			if (Settings.RequireNumLock)
				if (!Win32.NumLock())
					return;

			if (Settings.RequireCapsLock)
				if (!Win32.CapsLock())
					return;

		    // Do we have an active table?
            if (pokerTables.ContainsKey(activeTable))
            {
                PokerTable table = pokerTables[activeTable];
                
                if (Settings.UseVoiceCommands)
                {
                    switch (command)
                    {
                        case "Bet":
                        case "Raise":
                            table.BetRaise();
                            break;
                        case "Call":
                        case "Check":
                            table.CheckCall();
                            break;
                        case "Fold":
                            table.Fold();
                            break;
                        case "Zero":
                            table.SetRaiseValue(table.GetRaiseValue() + "0");
                            break;
                        case "One":
							table.SetRaiseValue(table.GetRaiseValue() + "1");
                            break;
                        case "Two":
							table.SetRaiseValue(table.GetRaiseValue() + "2");
                            break;
                        case "Three":
							table.SetRaiseValue(table.GetRaiseValue() + "3");
                            break;
                        case "Four":
							table.SetRaiseValue(table.GetRaiseValue() + "4");
                            break;
                        case "Five":
							table.SetRaiseValue(table.GetRaiseValue() + "5");
                            break;
                        case "Six":
							table.SetRaiseValue(table.GetRaiseValue() + "6");
                            break;
                        case "Seven":
							table.SetRaiseValue(table.GetRaiseValue() + "7");
                            break;
                        case "Eight":
							table.SetRaiseValue(table.GetRaiseValue() + "8");
                            break;
                        case "Nine":
							table.SetRaiseValue(table.GetRaiseValue() + "9");
                            break;
                        case "Ten":
							table.SetRaiseValue(table.GetRaiseValue() + "10");
                            break;
                        case "Twenty":
							table.SetRaiseValue(table.GetRaiseValue() + "20");
                            break;
                        case "Thirty":
							table.SetRaiseValue(table.GetRaiseValue() + "30");
                            break;
                        case "Fourty":
							table.SetRaiseValue(table.GetRaiseValue() + "40");
                            break;
                        case "Fifty":
							table.SetRaiseValue(table.GetRaiseValue() + "50");
                            break;
                        case "Sixty":
							table.SetRaiseValue(table.GetRaiseValue() + "60");
                            break;
                        case "Seventy":
							table.SetRaiseValue(table.GetRaiseValue() + "70");
                            break;
                        case "Eighty":
							table.SetRaiseValue(table.GetRaiseValue() + "80");
                            break;
                        case "Ninety":
							table.SetRaiseValue(table.GetRaiseValue() + "90");
                            break;
                        case "Hundred":
							table.SetRaiseValue(table.GetRaiseValue() + "00");
                            break;
                        case "Thousand":
							table.SetRaiseValue(table.GetRaiseValue() + "000");
                            break;
                        case "Point":
							table.SetRaiseValue(table.GetRaiseValue() + ".");
                            break;
                        case "Clear":
							table.SetRaiseValue("");
                            break;
                        case "Eleven":
                            table.SetRaiseValue(table.GetRaiseValue() + "11");
                            break;
                        case "Twelve":
                            table.SetRaiseValue(table.GetRaiseValue() + "12");
                            break;
                        case "Thirteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "13");
                            break;
                        case "Fourteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "14");
                            break;
                        case "Fifteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "15");
                            break;
                        case "Sixteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "16");
                            break;
                        case "Seventeen":
                            table.SetRaiseValue(table.GetRaiseValue() + "17");
                            break;
                        case "Eighteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "18");
                            break;
                        case "Nineteen":
                            table.SetRaiseValue(table.GetRaiseValue() + "19");
                            break;
                        case "Push":
                            table.AutoPush();
                            break;
                    }

                    // Presets
                    if(command == Settings.VCPreset1)
                    {
                        table.SetRaiseValue(Settings.VCPreset1Amount);
                        return;
                    }
                    if (command == Settings.VCPreset2)
                    {
                        table.SetRaiseValue(Settings.VCPreset2Amount);
                        return;
                    }
                    if (command == Settings.VCPreset3)
                    {
                        table.SetRaiseValue(Settings.VCPreset3Amount);
                        return;
                    }
                }
            }
        }
		
		// Fires when a key has been pressed, used in conjunction with keyboard controls
		private void MyKeyDown(object sender, KeyEventArgs e)
		{
			if (Settings.RequireNumLock)
				if (!Win32.NumLock())
					return;

			if (Settings.RequireCapsLock)
				if (!Win32.CapsLock())
					return;

			if(Settings.UseKeyboardControls)
			{
				string keyCode = GetKeyCode(e);

				// Do we have an active table?
				if (pokerTables.ContainsKey(activeTable))
				{
					PokerTable table = (PokerTable)pokerTables[activeTable];

					switch (keyCode)
					{
						case "back":
							string txt = table.GetRaiseValue();

							if (txt.Length > 0)
								table.SetRaiseValue(txt.Substring(0, txt.Length - 1));
							break;

						case "0":
							table.SetRaiseValue(table.GetRaiseValue() + "0");
							break;

						case "1":
							table.SetRaiseValue(table.GetRaiseValue() + "1");
							break;

						case "2":
							table.SetRaiseValue(table.GetRaiseValue() + "2");
							break;

						case "3":
							table.SetRaiseValue(table.GetRaiseValue() + "3");
							break;

						case "4":
							table.SetRaiseValue(table.GetRaiseValue() + "4");
							break;

						case "5":
							table.SetRaiseValue(table.GetRaiseValue() + "5");
							break;

						case "6":
							table.SetRaiseValue(table.GetRaiseValue() + "6");
							break;

						case "7":
							table.SetRaiseValue(table.GetRaiseValue() + "7");
							break;

						case "8":
							table.SetRaiseValue(table.GetRaiseValue() + "8");
							break;

						case "9":
							table.SetRaiseValue(table.GetRaiseValue() + "9");
							break;

						case ".":
							table.SetRaiseValue(table.GetRaiseValue() + ".");
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

                // Toggle force table to top
                if (keyCode == Settings.ForceActiveTableTopmostKeyCode)
                    Settings.ForceActiveTableToBeTopmost = !Settings.ForceActiveTableToBeTopmost;

				// Toggle lobby opened/minimized
				if (keyCode == Settings.ToggleLobbyKeyCode)
				{
					if (Settings.KeepLobbyMinimized || (!Settings.KeepLobbyOpened))
					{
						Settings.KeepLobbyMinimized = false;
						Settings.KeepLobbyOpened = true;
					}
					else if (Settings.KeepLobbyOpened)
					{
						Settings.KeepLobbyMinimized = true;
						Settings.KeepLobbyOpened = false;
					}
				}
			}
		}

		/// <summary>
		/// Removes any tables from the active quadrant
		/// </summary>
		private void removeTableFromActiveQuadrant(int quadrantToSpare)
		{
			foreach(PokerTable table in pokerTables.Values)
			{
				if(table.Quadrant == Settings.ActiveTableQuadrant)
				{
					if(Settings.AutoArrangeTables)
						moveTableToFreeQuadrant(table.Handle, quadrantToSpare);
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
			// Check for lobby minimizing
			if (Settings.KeepLobbyMinimized)
			{
				foreach (PartyLobby lobby in pokerLobbies.Values)
					lobby.MinimizeWindow();
			}

			// Check for lobby opening
			if (Settings.KeepLobbyOpened)
			{
				foreach (PartyLobby lobby in pokerLobbies.Values)
					lobby.OpenWindow();
			}

			// Update tables
			try
			{
				foreach (PokerTable table in pokerTables.Values)
					table.InvokeActionTick();
			}
			catch
			{

			}

			// Check if any tables are unpositioned, and if autoarrange is on
			if(Settings.AutoArrangeTables)
			{
				foreach(PokerTable table in pokerTables.Values)
					if (!disabledTables.ContainsKey(table.Handle))
					{
						if (table.Quadrant == 0 || (table.IsSittingOut && table.Quadrant != Settings.NonSeatedTableQuadrant && Settings.PlaceUnseatedTablesAtSpecialLocation) || (!table.IsSittingOut && table.Quadrant == Settings.NonSeatedTableQuadrant && Settings.PlaceUnseatedTablesAtSpecialLocation))
						{
							// Don't arrange tables while SNG Opener is open
							if(!SuspendMovement)
							{
								if ((!table.IsSeated() || table.IsSittingOut) && Settings.PlaceUnseatedTablesAtSpecialLocation)
									table.MoveToQuadrant(Settings.GetQuad(Settings.NonSeatedTableQuadrant), false);
								else
									moveTableToFreeQuadrant(table.Handle, 0);
							}
						}
					}
			}

			// If there isn't an active table righ now
			if(!pokerTables.ContainsKey(activeTable) && actionQueue.Count > 0)
			{
				// Get the first in line table
				PokerTable table = pokerTables[actionQueue[0]];

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
				activeTable = table.Handle;

                // Log table activation
                Log.Write(table.Name);

				// Start forceActivation timer
				if(Settings.ForceActiveTableToBeTopmost)
					tableOnTopTimer.Enabled = true;

				// Move mouse to table if wanted
				if(Settings.MoveCursorToActiveTable)
				{
					// Get the current table position
					Point pos = table.GetPosition();
					
					// Only move the mouse if it's outside the table area
					if(Cursor.Position.X < pos.X || Cursor.Position.X > pos.X + table.Width || Cursor.Position.Y < pos.Y || Cursor.Position.Y > pos.Y + table.Height)
						table.MoveCursorToTable();
				}

				// Notify the table that it's been activated
				table.HasBeenActivated();
			}
		}

		/// <summary>
		/// Updates the disabledTables collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstTables_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			// Get the listviewitem that's been checked
			ListViewItem lvi = lstTables.Items[e.Index];

			// Only check table if it still exists
			if(pokerTables.ContainsKey(Convert.ToInt32(lvi.Tag)))
			{
				if(!lvi.Checked)
				{
					// If it's checked, make sure the table isn't in the disabledTables collection
					if(disabledTables.ContainsKey(lvi.Tag))
						disabledTables.Remove(lvi.Tag);
				}
				else
				{
					// If it isn't checked, make sure it's in the disabledTables collection
					if(!disabledTables.ContainsKey(lvi.Tag))
					{
						disabledTables.Add(lvi.Tag, "");

						// Reset the tables quadrant as the table can now be moved around without us knowing
						pokerTables[Convert.ToInt32(lvi.Tag)].Quadrant = 0;
					}
				}
			}
		}

		/// <summary>
		/// Saves preferences just before closing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Save column widths
			foreach(ColumnHeader ch in lstTables.Columns)
				Settings.SaveSetting("TableListColumn_" + ch.Text.Replace(" ", "_") + "_Width", ch.Width.ToString());

			// Save the form's position
			Rectangle newPosition = new Rectangle();
			Win32.GetWindowRect((int)this.Handle, ref newPosition);

			newPosition.Width = this.Width;
			newPosition.Height = this.Height;

			Settings.MainWindowPosition = newPosition;
		}

		/// <summary>
		/// Clean up when closing MTH
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            // Kill tables gracefully when closing
            foreach (PokerTable table in pokerTables.Values)
				table.Die();
        }

		/// <summary>
		/// Rearranges tables
		/// </summary>
		private void rearrangeTables()
		{
			if (Settings.AutoArrangeTables)
			{
				foreach (PokerTable table in pokerTables.Values)
					if (table.Quadrant != Settings.ActiveTableQuadrant || (table.Quadrant == Settings.ActiveTableQuadrant && activeTable != table.Handle))
						table.Quadrant = 0;
			}
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

					lstTables.SelectedItems[0].Checked = !lstTables.SelectedItems[0].Checked;
					pokerTables[hwnd].BringToFront();
				}
		}

        private void tableOnTopTimer_Tick_1(object sender, EventArgs e)
        {
            if (Settings.ForceActiveTableToBeTopmost)
            {
                Win32.SetForegroundWindow(activeTable);
                Win32.BringWindowToTop((IntPtr)activeTable);
                Win32.ShowWindow(activeTable, (int)Win32.SW.SHOWNA);
            }
        }

		private void button1_Click_1(object sender, EventArgs e)
		{
			foreach (PokerTable table in pokerTables.Values)
			{
				AutoItX3Lib.AutoItX3Class ai = new AutoItX3Lib.AutoItX3Class();

				ai.ControlClick(table.WindowTitle, "", "1031", "left", 1);
			}
		}
	}
}