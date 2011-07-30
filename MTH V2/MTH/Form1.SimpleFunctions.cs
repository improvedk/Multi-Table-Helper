using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Threading;

namespace MTH
{
	public partial class Form1
	{
		/// <summary>
		/// Returns a unique color used to ID tables with
		/// </summary>
		/// <returns></returns>
		private Color getVacantTableIDColor()
		{
			List<int> colors = new List<int>();

			colors.Add(-8388608);
			colors.Add(-65536);
			colors.Add(-256);
			colors.Add(-32640);
			colors.Add(-16777216);
			colors.Add(-8372224);
			colors.Add(-8355840);
			colors.Add(-16711936);
			colors.Add(-16760832);
			colors.Add(-8355712);
			colors.Add(-1);
			colors.Add(-16776961);
			colors.Add(-16744193);
			colors.Add(-65408);
			colors.Add(-12582784);
			colors.Add(-32768);

			foreach (PokerTable table in pokerTables.Values)
				colors.Remove(table.IdentificationColor.ToArgb());

			if (colors.Count > 0)
				return Color.FromArgb(colors[0]);
			else
				return Color.Black;
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

			foreach (PokerTable table in pokerTables.Values)
			{
				ListViewItem lvi = new ListViewItem();

				bool first = true;
				string txt = "";

				foreach (ColumnHeader ch in lstTables.Columns)
				{
					switch (ch.Text)
					{
						case "Table":
							txt = table.Name;

							if (txt == selectedTable)
								lvi.Selected = true;
							break;
						case "Site":
							txt = table.SiteName.ToString();
							break;
						case "Last action":
							txt = (table.TimeSinceLastAction().Minutes * 60 + table.TimeSinceLastAction().Seconds).ToString() + " Sec";
							break;
						case "Form":
							txt = table.GameForm.ToString();
							break;
						case "Limit":
							txt = table.GameLimit.ToString();
							break;
						case "Type":
							txt = table.GameType.ToString();
							break;
						case "Stakes":
							txt = table.Stakes.ToString();
							break;
						case "Blind level":
							if (table.GameForm == TableFactory.GameForm.SNG || table.GameForm == TableFactory.GameForm.MTT)
								if (table.BlindLevel == 0)
									txt = "-";
								else
									txt = table.BlindLevel.ToString();
							else
								txt = "N/A";
							break;
						case "ART":
							txt = Math.Round(table.ART, 2).ToString();
							break;
						case "Needs action":
							txt = (table.GetActionStatus() == TableFactory.ActionStatus.RequiresActionNormal).ToString();
							break;
						case "Sitting out":
							txt = table.IsSittingOut.ToString();
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

				lvi.Tag = table.Handle;
				lvi.Checked = !disabledTables.ContainsKey(table.Handle);

				lvic.Add(lvi);
			}

			lstTables.BeginUpdate();
			lstTables.Items.Clear();
			lstTables.Items.AddRange(lvic.ToArray());
			lstTables.EndUpdate();
		}

		/// <summary>
		/// Called during file downloads to update status
		/// </summary>
		/// <param name="bytesSoFar"></param>
		/// <param name="totalBytes"></param>
		private void DownloadProgressCallback(int bytesSoFar, int totalBytes)
		{
			if (totalBytes != -1)
			{
				SetDownloadStatus d = new SetDownloadStatus(SafeDownloadProgressCallback);
				this.Invoke(d, new object[] { bytesSoFar, totalBytes });
			}
		}

		/// <summary>
		/// A thread safe version of the DownloadProgressCallback function
		/// </summary>
		/// <param name="bytesSoFar"></param>
		/// <param name="totalBytes"></param>
		private void SafeDownloadProgressCallback(int bytesSoFar, int totalBytes)
		{
			if (lfTemp != null)
			{
				lfTemp.SetValueRange(0, totalBytes);
				lfTemp.SetProgress(bytesSoFar);
			}
		}

		/// <summary>
		/// A thread safe version of the DownloadCompleteCallback function
		/// </summary>
		/// <param name="dataDownloaded"></param>
		private void SafeDownloadCompleteCallback(byte[] dataDownloaded)
		{
			// Save the file
			FileStream fs = File.Create("MTH_Update.msi");
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write(dataDownloaded);
			bw.Flush();
			fs.Close();

			// Close the load dialog
			if (lfTemp != null)
			{
				lfTemp.Close();
				lfTemp = null;
			}
		}

		/// <summary>
		/// Called when a file download is complete
		/// </summary>
		/// <param name="dataDownloaded"></param>
		private void DownloadCompleteCallback(byte[] dataDownloaded)
		{
			SetDownloadComplete d = new SetDownloadComplete(SafeDownloadCompleteCallback);
			this.Invoke(d, new object[] { dataDownloaded });
		}

		/// <summary>
		/// Clears the tables list's column headers and loads new ones from the settings
		/// </summary>
		private void loadTableListColumnHeaders()
		{
			lstTables.Columns.Clear();

			foreach (MenuItem mnu in cmTableListColumns.MenuItems)
			{
				string defaultWidth, defaultVisible;

				if (mnu.Text.IndexOf("|") != -1)
				{
					// Get the default width from the contextMenu text
					defaultWidth = mnu.Text.Split('|')[0];

					// Get the default visible state
					defaultVisible = mnu.Text.Split('|')[1];

					// Remove the default width from the text
					mnu.Text = mnu.Text.Split('|')[2];
				}
				else
				{
					// The settings have already been loaded & saved, get them from settings
					defaultWidth = Settings.GetSetting("TableListColumn_" + mnu.Text.Replace(" ", "_") + "_Width", "10");
					defaultVisible = Settings.GetSetting("TableListColumn_" + mnu.Text.Replace(" ", "_") + "_Checked", "true");
				}

				// Add the column to the tables list if checked
				if (Convert.ToBoolean(Settings.GetSetting("TableListColumn_" + mnu.Text.Replace(" ", "_") + "_Checked", defaultVisible)))
				{
					mnu.Checked = true;

					ColumnHeader ch = new ColumnHeader();

					ch.Text = mnu.Text;
					ch.Width = Convert.ToInt32(Settings.GetSetting("TableListColumn_" + mnu.Text.Replace(" ", "_") + "_Width", defaultWidth));

					mnu.Checked = true;

					lstTables.Columns.Add(ch);
				}
				else
					mnu.Checked = false;
			}
		}

		/// <summary>
		/// Fixes any problems that might have arised in the preferences since the last startup of MTH
		/// </summary>
		private void fixPrefs()
		{
			// Check for uninitialized BlindLevel colors
			if (Settings.GetSetting("BlindLevel1Color", "0") == "0")
				Settings.SaveSetting("BlindLevel1Color", Color.Green.ToArgb());
			if (Settings.GetSetting("BlindLevel2Color", "0") == "0")
				Settings.SaveSetting("BlindLevel2Color", Color.Green.ToArgb());
			if (Settings.GetSetting("BlindLevel3Color", "0") == "0")
				Settings.SaveSetting("BlindLevel3Color", Color.Yellow.ToArgb());
			if (Settings.GetSetting("BlindLevel4Color", "0") == "0")
				Settings.SaveSetting("BlindLevel4Color", Color.Yellow.ToArgb());
			if (Settings.GetSetting("BlindLevel5Color", "0") == "0")
				Settings.SaveSetting("BlindLevel5Color", Color.Orange.ToArgb());
			if (Settings.GetSetting("BlindLevel6Color", "0") == "0")
				Settings.SaveSetting("BlindLevel6Color", Color.Orange.ToArgb());
			if (Settings.GetSetting("BlindLevel7Color", "0") == "0")
				Settings.SaveSetting("BlindLevel7Color", Color.Red.ToArgb());
			if (Settings.GetSetting("BlindLevel8Color", "0") == "0")
				Settings.SaveSetting("BlindLevel8Color", Color.Red.ToArgb());
			if (Settings.GetSetting("BlindLevel9Color", "0") == "0")
				Settings.SaveSetting("BlindLevel9Color", Color.Red.ToArgb());
			if (Settings.GetSetting("BlindLevel10Color", "0") == "0")
				Settings.SaveSetting("BlindLevel10Color", Color.DarkRed.ToArgb());

			// If serial exists and LicenseCode doesn't switch
			if (Settings.Serial.Length > 0 && Settings.LicenseCode.Length == 0)
				Settings.LicenseCode = Settings.Serial;

			// Check for older BorderColor value
			try
			{
				Color borderColor = Settings.BorderColor;
			}
			catch
			{
				Settings.BorderColor = Color.FromName(Settings.GetSetting("BorderColor", "Red"));
			}
		}

		/// <summary>
		/// Returns a keycode describing the provided combination of depressed keys
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string GetKeyCode(KeyEventArgs e)
		{
			string keyCode = "";

			// Check for modifiers
			if (e.Shift)
				keyCode = "shift+";

			// Add the key code
			switch (e.KeyCode)
			{
				case Keys.D1:
				case Keys.NumPad1:
					keyCode += "1";
					break;
				case Keys.D2:
				case Keys.NumPad2:
					keyCode += "2";
					break;
				case Keys.D3:
				case Keys.NumPad3:
					keyCode += "3";
					break;
				case Keys.D4:
				case Keys.NumPad4:
					keyCode += "4";
					break;
				case Keys.D5:
				case Keys.NumPad5:
					keyCode += "5";
					break;
				case Keys.D6:
				case Keys.NumPad6:
					keyCode += "6";
					break;
				case Keys.D7:
				case Keys.NumPad7:
					keyCode += "7";
					break;
				case Keys.D8:
				case Keys.NumPad8:
					keyCode += "8";
					break;
				case Keys.D9:
				case Keys.NumPad9:
					keyCode += "9";
					break;
				case Keys.D0:
				case Keys.NumPad0:
					keyCode += "0";
					break;
				case Keys.OemPeriod:
				case Keys.Decimal:
				case Keys.Oemcomma:
					keyCode += ".";
					break;
				default:
					keyCode += e.KeyCode;
					break;
			}

			return keyCode.ToLower();
		}

		/// <summary>
		/// Opens the About dialog box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			Form about = new About();

			about.ShowDialog();
		}

		/// <summary>
		/// Opens the preferences dialog box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
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
			System.Diagnostics.Process.Start("http://www.multitablehelper.com/donations.aspx");
		}

		/// <summary>
		/// Fires when the main form resizes, shows/removes the notifyicon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.ShowInTaskbar = false;
				this.Hide();
			}
			else
			{
				this.ShowInTaskbar = true;
				this.Show();

				// Save the form's position
				Rectangle newPosition = new Rectangle();
				Win32.GetWindowRect((int)this.Handle, ref newPosition);

				newPosition.Width = this.Width;
				newPosition.Height = this.Height;

				Settings.MainWindowPosition = newPosition;
			}
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
		/// Open the forma gain when we click the open item in the notifyicons context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		/// <summary>
		/// Close MTH when we click the exit item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
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
		/// Saves the tables list column settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			// Get the item
			MenuItem mnu = (MenuItem)sender;

			// Set checked state
			mnu.Checked = !mnu.Checked;

			// Save checked state
			Settings.SaveSetting("TableListColumn_" + mnu.Text.Replace(" ", "_") + "_Checked", mnu.Checked);

			// Load new column headers
			loadTableListColumnHeaders();
		}

		/// <summary>
		/// Opens the Make latte tool dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			MakeLatte ml = new MakeLatte();

			ml.ShowDialog();
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

		/// <summary>
		/// Sets the title
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void setTitleTimer_Tick(object sender, EventArgs e)
		{
			// Set title
			this.Text = "MTH " + Version.ToString().Replace(",", ".");

			setTitleTimer.Enabled = false;
		}

		/// <summary>
		/// Saves the current settings configuration to a file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem30_Click(object sender, EventArgs e)
		{
			if (dlgSaveFile.ShowDialog() == DialogResult.OK)
			{
				ArrayList bannedSettings = new ArrayList();

				bannedSettings.Add("LicenseCode");
				bannedSettings.Add("LicenseFileLength");
				bannedSettings.Add("LicenseHashLength");
				bannedSettings.Add("RSAKeyset");
				bannedSettings.Add("Serial");

				XmlTextWriter xtw = new XmlTextWriter(dlgSaveFile.FileName, null);

				xtw.WriteStartDocument();
				xtw.WriteStartElement("MTHSettings");

				foreach (String s in Application.UserAppDataRegistry.GetValueNames())
					if (!bannedSettings.Contains(s))
						xtw.WriteElementString(s, Settings.GetSetting(s, ""));

				xtw.WriteEndElement();
				xtw.WriteEndDocument();
				xtw.Close();
			}
		}

		/// <summary>
		/// Loads a configuration settings file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem28_Click(object sender, EventArgs e)
		{
			if (dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				XmlTextReader xtr = new XmlTextReader(dlgOpenFile.FileName);

				while (xtr.Read())
					if (xtr.NodeType == XmlNodeType.Element && xtr.Name != "MTHSettings")
					{
						try
						{
							Settings.SaveSetting(xtr.Name, xtr.ReadElementContentAsString());
						}
						catch { }
					}

				xtr.Close();
			}
		}
	}
}