using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace MTH
{
	/// <summary>
	/// A class used for manipulating the PartyPoker lobby
	/// </summary>
	public class PartyLobby
	{
		private int handle;
		private int lobbyTreeviewHandle = 0;
		private int lobbyListviewHandle = 0;

		public static bool AbortAttempt = false;
		private bool totalAbort = false;
		private string totalAbortDescription = "An error has occurred";
		
		private ArrayList lastOpenedTables = new ArrayList();

		/// <summary>
		/// Constructor, takes the lobby window handle
		/// </summary>
		/// <param name="handle"></param>
		public PartyLobby(int handle)
		{
			// Set our handle
			this.handle = handle;

            // Create a WindowFinder
            WindowFinder wf = new WindowFinder();

            // Find the lobby treeview
            int tmpTreeviewHandle = wf.FindWindow(handle, "SysTreeView32", "Tree1", new Size(154, 403), true);

            int tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(422, 268), false);
            if(tmpListviewHandle == 0)
                tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(422, 157), false);
            if (tmpListviewHandle == 0)
                tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(422, 416), false);
            if (tmpListviewHandle == 0)
                tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(422, 305), false);
            if (tmpListviewHandle == 0)
                tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(585, 305), false);
            if (tmpListviewHandle == 0)
                tmpListviewHandle = wf.FindWindow(handle, "SysListView32", "List1", new Size(585, 416), false);

			// Did we find the treeview?
			if(tmpTreeviewHandle != 0)
				lobbyTreeviewHandle = tmpTreeviewHandle;
			else
			{
				totalAbort = true;
				totalAbortDescription = "The lobby treeview could not be found, please make sure it's open";
			}
			
			// Did we find the listview?
			if(tmpListviewHandle != 0)
				lobbyListviewHandle = tmpListviewHandle;
			else
			{
				totalAbort = true;
                totalAbortDescription = "The lobby listview could not be found, please make sure it's open";
			}
		}

		/// <summary>
		/// Minimizes the lobby window
		/// </summary>
		public void MinimizeWindow()
		{
			Win32.ShowWindowAsync((IntPtr)handle, (int)Win32.SW.MINIMIZE);
		}

		/// <summary>
		/// Opens the lobby window
		/// </summary>
		public void OpenWindow()
		{
			Win32.ShowWindowAsync((IntPtr)handle, (int)Win32.SW.SHOWNOACTIVATE);
		}

		/// <summary>
		/// Opens an SNG with the specified settings
		/// </summary>
		public string OpenSNG(string buyin, string gameDescription, bool speedSNG, bool bln6Max, bool selectBuyin)
		{
			// Check for total abort
			if(totalAbort)
			{
                AbortAttempt = true;
				MessageBox.Show(totalAbortDescription);
				return "";
			}

			if(lobbyTreeviewHandle != 0)
			{
				TreeviewManipulation tm = new TreeviewManipulation(lobbyTreeviewHandle);
                int buyinLevelItem = 0;

				// Find the buyin treeview item
                if (selectBuyin)
                {
                    buyinLevelItem = tm.GetItemByText(buyin);

                    // Select it
                    tm.SelectItem(buyinLevelItem);
                }

				// Now that we have the correct buyin selected, access the ListView
				ListviewManipulation lm = new ListviewManipulation(lobbyListviewHandle);

				// Loop indefinitely until aborted, seeing if we can find a suitable table
				while(true)
				{
					// Check for abortion flag
					if(AbortAttempt)
						return "";

					// Yield
					Application.DoEvents();

					// Loop through all istview items until we find the desired game, with at most 6 players
					for(int i=0; i<lm.GetItemCount(); i++)
					{
                        if (AbortAttempt)
                            return "";

						// Check gamedescription
                        if (lm.GetItemText(i, 1) == gameDescription)
                        {
							Application.DoEvents();
							if (AbortAttempt)
								return "";

                            // Check speed sng
                            if(!speedSNG && !lm.GetItemText(i, 0).Contains("Speed") || speedSNG && lm.GetItemText(i, 0).Contains("Speed"))
							{
								Application.DoEvents();
								if (AbortAttempt)
									return "";

                                // Check 6 max
                                if(bln6Max && lm.GetItemText(i, 3).EndsWith("/6") || !bln6Max && lm.GetItemText(i, 3).EndsWith("/10"))
								{
									Application.DoEvents();
									if (AbortAttempt)
										return "";

                                    // Check it's registering
                                    if (lm.GetItemText(i, 4) == "Registering")
									{
										Application.DoEvents();
										if (AbortAttempt)
											return "";

                                        // Check players is below 7
                                        if (Convert.ToInt32(lm.GetItemText(i, 3)[0].ToString()) <= 8)
										{
											Application.DoEvents();
											if (AbortAttempt)
												return "";

                                            // Check that we have not tried to open this table before
                                            if (!lastOpenedTables.Contains(lm.GetItemText(i, 0)))
                                            {
                                                // Get the table name
                                                string tableName = lm.GetItemText(i, 0);

                                                // Gamedescription matches, and the number of players is at most 3, select this row
                                                lm.SelectItem(i);

                                                // Add to recently opened tables list
                                                lastOpenedTables.Add(tableName);
                                                if (lastOpenedTables.Count > 12)
                                                    lastOpenedTables.RemoveAt(6);

                                                // Press the enter key to open the table
                                                Win32.PostMessage(lobbyListviewHandle, (int)Win32.WM.KEYDOWN, (int)Win32.VK.RETURN, 1);

                                                return tableName;
                                            }
                                        }
                                    }
                                }
                            }
                        }
					}

                    // Sleep 3 seconds
					for (int sleep = 0; sleep < 300; sleep++)
					{
						Application.DoEvents();
						System.Threading.Thread.Sleep(10);
					}
                    
                    if(buyinLevelItem == 0)
						buyinLevelItem = tm.GetItemByText(buyin);

                    tm.SelectItem(tm.GetNextItem(buyinLevelItem));

					System.Threading.Thread.Sleep(20);

					Application.DoEvents();

                    // Select it
					tm.SelectItem(buyinLevelItem);

					Application.DoEvents();
				}
			}
			else
			{
                AbortAttempt = true;
                MessageBox.Show("The lobby treeview could not be found, please make sure it's open");
			}

            return "";
		}
	}
}
