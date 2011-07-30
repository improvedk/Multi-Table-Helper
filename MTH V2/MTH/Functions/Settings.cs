using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace MTH
{
	public class Settings
    {
        public static bool HasCheckedForRegistered = false;
        private static bool registered = false;
		private static Dictionary<string, string> cache = new Dictionary<string, string>();

        public static Rectangle OpenSNGWindowPosition
        {
            get
            {
                int width = Convert.ToInt32(GetSetting("OpenSNGWindowWidth", "576"));
                int height = Convert.ToInt32(GetSetting("OpenSNGWindowHeight", "200"));
                int x = Convert.ToInt32(GetSetting("OpenSNGWindowX", "0"));
                int y = Convert.ToInt32(GetSetting("OpenSNGWindowY", "0"));

                return new Rectangle(x, y, width, height);
            }
            set
            {
                SaveSetting("OpenSNGWindowHeight", value.Height);
                SaveSetting("OpenSNGWindowWidth", value.Width);
                SaveSetting("OpenSNGWindowX", value.X);
                SaveSetting("OpenSNGWindowY", value.Y);
            }
        }

		public static bool ShowNotification
		{
			get
			{
				return Convert.ToBoolean(GetSetting("ShowNotification", "true"));
			}
			set
			{
				SaveSetting("ShowNotification", value);
			}
		}

		public static string LastUsedPokerSiteEditQuadrant
		{
			get
			{
				return GetSetting("LastUsedPokerSiteEditQuadrant", "Party");
			}
			set
			{
				SaveSetting("LastUsedPokerSiteEditQuadrant", value);
			}
		}

		public static bool AutoWaitForBB
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoWaitForBB", "false"));
			}
			set
			{
				SaveSetting("AutoWaitForBB", value);
			}
		}

		public static bool AutoPostBlind
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoPostBlind", "false"));
			}
			set
			{
				SaveSetting("AutoPostBlind", value);
			}
		}

		public static bool AutoClickAutoPostBlind
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoClickAutoPostBlind", "false"));
			}
			set
			{
				SaveSetting("AutoClickAutoPostBlind", value);
			}
		}

		public static bool ClearBetBoxOnNLTables
		{
			get
			{
				return Convert.ToBoolean(GetSetting("ClearBetBoxOnNLTables", "true"));
			}
			set
			{
				SaveSetting("ClearBetBoxOnNLTables", value);
			}
		}

		public static bool EnableLogging
		{
			get
			{
				return Convert.ToBoolean(GetSetting("EnableLogging", "false"));
			}
			set
			{
				SaveSetting("EnableLogging", value);
			}
		}

        public static bool OpenSNG6Max
        {
            get
            {
                return Convert.ToBoolean(GetSetting("OpenSNG6Max", "false"));
            }
            set
            {
                SaveSetting("OpenSNG6Max", value);
            }
        }

        public static List<int> SNGSeatPreference
        {
            get
            {
                string input = GetSetting("SNGSeatPreference", "1,2,3,4,5,6,7,8,9,10,0");
                List<int> output = new List<int>();

                foreach (string s in input.Split(','))
                    output.Add(Convert.ToInt32(s));

                return output;
            }
            set
            {
                string output = "";

                foreach (int i in value)
                    if (output.Length == 0)
                        output += i.ToString();
                    else
                        output += "," + i.ToString();

                SaveSetting("SNGSeatPreference", output);
            }
        }

        public static bool OpenSNGSpeedSNG
        {
            get
            {
                return Convert.ToBoolean(GetSetting("OpenSNGSpeedSNG", "false"));
            }
            set
            {
                SaveSetting("OpenSNGSpeedSNG", value);
            }
        }

        public static bool OpenSNGAutoClose
        {
            get
            {
                return Convert.ToBoolean(GetSetting("OpenSNGAutoClose", "false"));
            }
            set
            {
                SaveSetting("OpenSNGAutoClose", value);
            }
        }

        public static bool AutoSNGBuyin
        {
            get
            {
                return Convert.ToBoolean(GetSetting("AutoSNGBuyin", "false"));
            }
            set
            {
                SaveSetting("AutoSNGBuyin", value);
            }
        }

		public static bool ForceActiveTableToBeTopmost
		{
			get
			{
				return Convert.ToBoolean(GetSetting("ForceActiveTableToBeTopmost", "false"));
			}
			set
			{
                SaveSetting("ForceActiveTableToBeTopmost", value);
			}
		}

		public static bool KeepLobbyMinimized
		{
			get
			{
				return Convert.ToBoolean(GetSetting("KeepLobbyMinimized", "false"));
			}
			set
			{
				SaveSetting("KeepLobbyMinimized", value);
			}
		}

		public static bool KeepLobbyOpened
		{
			get
			{
				return Convert.ToBoolean(GetSetting("KeepLobbyOpened", "false"));
			}
			set
			{
				SaveSetting("KeepLobbyOpened", value);
			}
		}

		public static int TableIdentificationCompleteBorderWidth
		{
			get
			{
				return Convert.ToInt32(GetSetting("TableIdentificationCompleteBorderWidth", "6"));
			}
			set
			{
				SaveSetting("TableIdentificationCompleteBorderWidth", value);
			}
        }

        public static bool SNGOpenerRequireShift
        {
            get
            {
                return Convert.ToBoolean(GetSetting("SNGOpenerRequireShift", "true"));
            }
            set
            {
                SaveSetting("SNGOpenerRequireShift", value);
            }
        }

        public static string SNGOpenerKey
        {
            get
            {
                return GetSetting("SNGOpenerKey", "O");
            }
            set
            {
                SaveSetting("SNGOpenerKey", value);
            }
        }

		public static bool RearrangeTablesRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("RearrangeTablesRequireShift", "true"));
			}
			set
			{
				SaveSetting("RearrangeTablesRequireShift", value);
			}
		}

		public static string RearrangeTablesKey
		{
			get
			{
				return GetSetting("RearrangeTablesKey", "R");
			}
			set
			{
				SaveSetting("RearrangeTablesKey", value);
			}
		}

		public static string ColorIdentificationSize
		{
			get
			{
				return GetSetting("ColorIdentificationSize", "small");
			}
			set
			{
				SaveSetting("ColorIdentificationSize", value);
			}
		}

		public static bool UseColorIdentification
		{
			get
			{
				return Convert.ToBoolean(GetSetting("UseColorIdentification", "false"));
			}
			set
			{
				SaveSetting("UseColorIdentification", value);
			}
		}

        /// <summary>
        /// Returns the blind level color
        /// </summary>
        public static Color BlindLevelColor(int blindLevel)
        {
            return Color.FromArgb(Convert.ToInt32(GetSetting("BlindLevel" + blindLevel + "Color", Color.Red.ToArgb().ToString())));
        }

		/// <summary>
		/// Returns the path to the folder in which MTH lies
		/// </summary>
		public static string ApplicationFolder
		{
			get
			{
				return Application.StartupPath + "\\";
			}
		}

		/// <summary>
		/// Returns the tick count since the os installation date
		/// </summary>
		public static long TicksSinceInstall
		{
			get
			{
				try
				{
					ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
					ManagementObjectCollection moc = mc.GetInstances();

					foreach (ManagementObject mo in moc)
					{
						DateTime d = System.Management.ManagementDateTimeConverter.ToDateTime(mo.Properties["InstallDate"].Value.ToString());

						return DateTime.Now.Ticks - d.Ticks;
					}
				}
				catch
				{
					return 0;
				}

				return 0;
			}
		}

		/// <summary>
		/// CheckForUpdatesOnStartup
		/// </summary>
		public static bool CheckForUpdatesOnStartup
		{
			get
			{
				return Convert.ToBoolean(GetSetting("CheckForUpdatesOnStartup", "true"));
			}
			set
			{
				SaveSetting("CheckForUpdatesOnStartup", value);
			}
		}

		/// <summary>
		/// Whether MTH requires caps lock to enable controls
		/// </summary>
		public static bool RequireCapsLock
		{
			get
			{
				return Convert.ToBoolean(GetSetting("RequireCapsLock", "false"));
			}
			set
			{
				SaveSetting("RequireCapsLock", value);
			}
		}

		/// <summary>
		/// Whether MTH requires num lock to enable controls
		/// </summary>
		public static bool RequireNumLock
		{
			get
			{
				return Convert.ToBoolean(GetSetting("RequireNumLock", "false"));
			}
			set
			{
				SaveSetting("RequireNumLock", value);
			}
		}

		/// <summary>
		/// LicenseCode
		/// </summary>
		public static string LicenseCode
		{
			get
			{
				return GetSetting("LicenseCode", "").Trim();
			}
			set
			{
				SaveSetting("LicenseCode", value);
			}
		}

        /// <summary>
        /// Returns the stored serial code
        /// </summary>
        public static string Serial
        {
            get
            {
                return GetSetting("Serial", " ");
            }
			set
			{
				SaveSetting("Serial", value);
			}
        }

        /// <summary>
        /// Checks whether the speech module has been installed
        /// </summary>
        public static bool SpeechEnabled
        {
            get
            {
                VoiceListener vl = new VoiceListener();

                try
                {
                    vl.Start();
                    vl.Stop();
                }
                catch
                {
                    vl = null;
                }

                if (vl == null)
                    return false;

                vl = null;

                return true;
            }
        }

        /// <summary>
        /// Returns whether a bet/raise will be allowed if no amount has been entered
        /// </summary>
        public static bool AllowNoAmountBetRaise
        {
            get
            {
                return Convert.ToBoolean(GetSetting("AllowNoAmountBetRaise", "false"));
            }
			set
			{
				SaveSetting("AllowNoAmountBetRaise", value);
			}
        }

        /// <summary>
        /// Returns an ArrayList with all the possible voice commands
        /// </summary>
        public static ArrayList VoiceCommandsList
        {
            get
            {
                ArrayList tmp = new ArrayList();

                tmp.Add("Call");
                tmp.Add("Bet");
                tmp.Add("Check");
                tmp.Add("Raise");
                tmp.Add("Fold");
                tmp.Add("One");
                tmp.Add("Two");
                tmp.Add("Three");
                tmp.Add("Four");
                tmp.Add("Five");
                tmp.Add("Six");
                tmp.Add("Seven");
                tmp.Add("Eight");
                tmp.Add("Nine");
                tmp.Add("Zero");
                tmp.Add("Oh");
                tmp.Add("Ten");
                tmp.Add("Twenty");
                tmp.Add("Thirty");
                tmp.Add("Fourty");
                tmp.Add("Fifty");
                tmp.Add("Sixty");
                tmp.Add("Seventy");
                tmp.Add("Eighty");
                tmp.Add("Ninety");
                tmp.Add("Hundred");
                tmp.Add("Thousand");
                tmp.Add("Point");
                tmp.Add("Clear");
                tmp.Add("Eleven");
                tmp.Add("Twelve");
                tmp.Add("Thirteen");
                tmp.Add("Fourteen");
                tmp.Add("Fifteen");
                tmp.Add("Sixteen");
                tmp.Add("Seventeen");
                tmp.Add("Eighteen");
                tmp.Add("Nineteen");
                tmp.Add("Push");

                return tmp;
            }
        }

        /// <summary>
        /// Returns the bet amount for VC Preset 3
        /// </summary>
        public static string VCPreset3Amount
        {
            get
            {
                return GetSetting("VCPreset3Amount", "0");
            }
        }
        /// <summary>
        /// Returns the bet amount for VC Preset 2
        /// </summary>
        public static string VCPreset2Amount
        {
            get
            {
                return GetSetting("VCPreset2Amount", "0");
            }
        }
        /// <summary>
        /// Returns the bet amount for VC Preset 1
        /// </summary>
        public static string VCPreset1Amount
        {
            get
            {
                return GetSetting("VCPreset1Amount", "0");
            }
        }

        /// <summary>
        /// Returns the VC for preset 3
        /// </summary>
        public static string VCPreset3
        {
            get
            {
                return GetSetting("VCPreset3", "tres");
            }
        }

        /// <summary>
        /// Returns the VC for preset 2
        /// </summary>
        public static string VCPreset2
        {
            get
            {
                return GetSetting("VCPreset2", "dos");
            }
        }

        /// <summary>
        /// Returns the VC for preset 1
        /// </summary>
        public static string VCPreset1
        {
            get
            {
                return GetSetting("VCPreset1", "uno");
            }
        }

        /// <summary>
        /// Returns whether we should use voice commands
        /// </summary>
        public static bool UseVoiceCommands
        {
            get
            {
                return Convert.ToBoolean(GetSetting("UseVoiceCommands", "false"));
            }
        }

		/// <summary>
		/// Returns the key to MoveCursorToActiveTable
		/// </summary>
		public static string MoveCursorToActiveTableKey
		{
			get
			{
				return GetSetting("MoveCursorToActiveTableKey", "m");
			}
		}

		/// <summary>
		/// Returns whether MoveCursorToActiveTable requires shift
		/// </summary>
		public static bool MoveCursorToActiveTableRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("MoveCursorToActiveTableRequireShift", "true"));
			}
		}

		/// <summary>
		/// Returns the width of the active table border
		/// </summary>
		public static int ActiveTableBorderWidth
		{
			get
			{
				return Convert.ToInt32(GetSetting("ActiveTableBorderWidth", "3"));
			}
		}

		/// <summary>
		/// Returns the main windows position and size
		/// </summary>
		public static Rectangle MainWindowPosition
		{
			get
			{
				int width = Convert.ToInt32(GetSetting("MainWindowWidth", "576"));
				int height = Convert.ToInt32(GetSetting("MainWindowHeight", "200"));
				int x = Convert.ToInt32(GetSetting("MainWindowX", "0"));
				int y = Convert.ToInt32(GetSetting("MainWindowY", "0"));

				return new Rectangle(x, y, width, height);
			}
			set
			{
				SaveSetting("MainWindowHeight", value.Height);
				SaveSetting("MainWindowWidth", value.Width);
				SaveSetting("MainWindowX", value.X);
				SaveSetting("MainWindowY", value.Y);
			}
		}

		/// <summary>
		/// Returns whether the cursor should be moved to the active table
		/// </summary>
		public static bool MoveCursorToActiveTable
		{
			get
			{
				return Convert.ToBoolean(GetSetting("MoveCursorToActiveTable", "false"));
			}
			set
			{
				SaveSetting("MoveCursorToActiveTable", value);
			}
		}

        /// <summary>
        /// Returns the desired quad, if it does not exist, top left is returned
        /// </summary>
        /// <param name="quad"></param>
        /// <returns></returns>
        public static Quadrant GetQuad(int quad)
        {
            string quadText = GetSetting("Quadrants", "Top left,0,0,796,579");

            Quadrant q = new Quadrant();

            if (!quadText.Contains(","))
            {
                q.X = 0;
                q.Y = 0;
                q.Width = 796;
                q.Height = 579;
                q.Name = "Default - top left";
                q.Number = quad;
            }
            else
            {
                string[] quads = quadText.Split(';');
                string[] quadData = quads[quad - 1].Split(',');

                q.X = Convert.ToInt32(quadData[1]);
                q.Y = Convert.ToInt32(quadData[2]);
                q.Width = Convert.ToInt32(quadData[3]);
                q.Height = Convert.ToInt32(quadData[4]);
                q.Name = quadData[0];
                q.Number = quad;
            }

            return q;
        }

		/// <summary>
		/// Returns the quadrant where the non seated tables should be placed
		/// </summary>
		public static int NonSeatedTableQuadrant
		{
            get
            {
                int quad = Convert.ToInt32(GetSetting("NonSeatedTableQuadrant", "1"));

                if (quad <= QuadrantCount)
                    return quad;
                else
                {
                    NonSeatedTableQuadrant = 1;
                    return 1;
                }
            }
			set
			{
				SaveSetting("NonSeatedTableQuadrant", value);
			}
		}

		/// <summary>
		/// Returns whether tables at which the player is not seated / sitting out should be placed at a special location
		/// </summary>
		public static bool PlaceUnseatedTablesAtSpecialLocation
		{
			get
			{
				return Convert.ToBoolean(GetSetting("PlaceUnseatedTablesAtSpecialLocation", "false"));
			}
		}

		/// <summary>
		/// Returns whether the "Wait for BB" key command requires the shift key
		/// </summary>
		public static bool WaitForBBRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("WaitForBBRequireShift", "true"));
			}
		}

		/// <summary>
		/// Returns whether the specified quadrant is enabled or not
		/// </summary>
		/// <param name="quad"></param>
		/// <returns></returns>
		public static bool IsQuadrantEnabled(int quad)
		{
			return Convert.ToBoolean(GetSetting("Quadrant" + quad + "Enabled", "true"));
		}

		/// <summary>
		/// Returns whether we should flash the active table
		/// </summary>
		public static bool FlashTable
		{
			get
			{
				return Convert.ToBoolean(GetSetting("FlashTable", "true"));
			}
		}

        public static string SNGOpenerKeyCode
        {
            get
            {
                if (SNGOpenerRequireShift)
                    return "shift+" + SNGOpenerKey.ToLower();
                else
                    return SNGOpenerKey.ToLower();
            }
        }

        public static string ForceActiveTableTopmostKeyCode
        {
            get
            {
                if (ToggleActiveTableTopmostRequireShift)
                    return "shift+" + ToggleActiveTableTopmostKey.ToLower();
                else
                    return ToggleActiveTableTopmostKey.ToLower();
            }
        }

		public static bool AutoUpdate
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoUpdate", "true"));
			}
			set
			{
				SaveSetting("AutoUpdate", value);
			}
		}

        public static bool ToggleActiveTableTopmostRequireShift
        {
            get
            {
                return Convert.ToBoolean(GetSetting("ToggleActiveTableTopmostRequireShift", "true"));
            }
        }

		public static bool ToggleLobbyRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("ToggleLobbyRequireShift", "true"));
			}
		}

		public static string ToggleLobbyKey
		{
			get
			{
				return GetSetting("ToggleLobbyKey", "F12");
			}
		}

        public static string ToggleActiveTableTopmostKey
        {
            get
            {
				return GetSetting("ToggleForceActiveTableTopmostKey", "T");
            }
        }

		public static string ToggleLobbyKeyCode
		{
			get
			{
				if (ToggleLobbyRequireShift)
					return "shift+" + ToggleLobbyKey.ToLower();
				else
					return ToggleLobbyKey.ToLower();
			}
		}

		/// <summary>
		/// Returns the keycode to rearrange tables
		/// </summary>
		public static string RearrangeTablesKeyCode
		{
			get
			{
				if (RearrangeTablesRequireShift)
					return "shift+" + RearrangeTablesKey.ToLower();
				else
					return RearrangeTablesKey.ToLower();
			}
		}

		/// <summary>
		/// Return the keyCode to fold
		/// </summary>
		public static string FoldKeyCode
		{
			get
			{
				if(FoldRequireShift)
					return "shift+" + FoldKey.ToLower();
				else
					return FoldKey.ToLower();
			}
		}

		public static string AutoPushKeyCode
		{
			get
			{
				if(AutoPushRequireShift)
					return "shift+" + AutoPushKey.ToLower();
				else
					return AutoPushKey.ToLower();
			}
		}

		/// <summary>
		/// Returns whether the auto push command requires the shift key
		/// </summary>
		public static bool AutoPushRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoPushRequireShift", "true"));
			}
		}

		/// <summary>
		/// Returns the keyCode to check / call
		/// </summary>
		public static string CheckCallKeyCode
		{
			get
			{
				if(CheckCallRequireShift)
					return "shift+" + CheckCallKey.ToLower();
				else
					return CheckCallKey.ToLower();
			}
		}

		/// <summary>
		/// Returns the keyCode to bet / raise
		/// </summary>
		public static string BetRaiseKeyCode
		{
			get
			{
				if(BetRaiseRequireShift)
					return "shift+" + BetRaiseKey.ToLower();
				else
					return BetRaiseKey.ToLower();
			}
		}

		/// <summary>
		/// Returns the keycode to move the mouse to the active table
		/// </summary>
		public static string MoveCursorToActiveTableKeyCode
		{
			get
			{
				if(MoveCursorToActiveTableRequireShift)
					return "shift+" + MoveCursorToActiveTableKey.ToLower();
				else
					return MoveCursorToActiveTableKey.ToLower();
			}
		}

		/// <summary>
		/// Returns the key to wait for bb
		/// </summary>
		public static string WaitForBBKey
		{
			get
			{
				return GetSetting("WaitForBBKey", "W");
			}
		}

		/// <summary>
		/// Returns the key to sit out
		/// </summary>
		public static string SitOutKey
		{
			get
			{
				return GetSetting("SitOutKey", "S");
			}
		}

		/// <summary>
		/// Returns the key to post bb
		/// </summary>
		public static string PostBlindKey
		{
			get
			{
				return GetSetting("PostBlindKey", "P");
			}
		}

		/// <summary>
		/// Returns the key to auto push
		/// </summary>
		public static string AutoPushKey
		{
			get
			{
				return GetSetting("AutoPushKey", "P");
			}
		}
		
		/// <summary>
		/// Return the key to fold
		/// </summary>
		public static string FoldKey
		{
			get
			{
				return GetSetting("FoldKey", "F");
			}
		}

		/// <summary>
		/// Returns the key to check / call
		/// </summary>
		public static string CheckCallKey
		{
			get
			{
				return GetSetting("CheckCallKey", "C");
			}
		}

		/// <summary>
		/// Returns the key to bet / raise
		/// </summary>
		public static string BetRaiseKey
		{
			get
			{
				return GetSetting("BetRaiseKey", "B");
			}
		}

		/// <summary>
		/// Does the shift key have to be depressed when folding using keyboard controls?
		/// </summary>
		public static bool FoldRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("FoldRequireShift", "true"));
			}
		}
		
		/// <summary>
		/// Does the shift key have to be depressed when betting/raising using keyboard controls?
		/// </summary>
		public static bool BetRaiseRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("BetRaiseRequireShift", "true"));
			}
		}

		/// <summary>
		/// Does the shift key have to be depressed when checking/calling using keyboard controls?
		/// </summary>
		public static bool CheckCallRequireShift
		{
			get
			{
				return Convert.ToBoolean(GetSetting("CheckCallRequireShift", "true"));
			}
		}

		/// <summary>
		/// Do we use keyboard controls?
		/// </summary>
		public static bool UseKeyboardControls
		{
			get
			{
				return Convert.ToBoolean(GetSetting("UseKeyboardControls", "false"));
			}
		}

		/// <summary>
		/// Should we move the active table?
		/// </summary>
		public static bool MoveActiveTable
		{
			get
			{
				return Convert.ToBoolean(GetSetting("MoveActiveTable", "true"));
			}
		}

		/// <summary>
		/// Returns whether whe should keep the active table in place until replaced, or not
		/// </summary>
		public static bool KeepActiveTable
		{
			get
			{
				return Convert.ToBoolean(GetSetting("KeepActiveTable", "true"));
			}
			set
			{
				SaveSetting("KeepActiveTable", value);
			}
		}

		/// <summary>
		/// Returns the amount of quadrants
		/// </summary>
		public static int QuadrantCount
		{
			get
			{
                return GetSetting("Quadrants", "Top left,0,0,796,579").Split(';').Length;
			}
		}

		/// <summary>
		/// Returns the active tables quadrant location
		/// </summary>
		public static int ActiveTableQuadrant
		{
            get
            {
                int quad = Convert.ToInt32(GetSetting("ActiveTableQuadrant", "1"));

                if (quad <= QuadrantCount)
                    return quad;
                else
                {
                    ActiveTableQuadrant = 1;
                    return 1;
                }
            }
            set
            {
                SaveSetting("ActiveTableQuadrant", value);
            }
		}

		/// <summary>
		/// Returns whether we should auto arrange tables or not
		/// </summary>
		public static bool AutoArrangeTables
		{
			get
			{
				return Convert.ToBoolean(GetSetting("AutoArrangeTables", "false"));
			}
		}

		/// <summary>
		/// Do we make a border around the active table?
		/// </summary>
		public static bool UseBorder
		{
			get
			{
				return Convert.ToBoolean(GetSetting("UseBorder", "false"));
			}
		}

		/// <summary>
		/// The color of the border color
		/// </summary>
		public static Color BorderColor
		{
			get
			{
				return Color.FromArgb(Convert.ToInt32(GetSetting("BorderColor", "Red")));
			}
			set
			{
				SaveSetting("BorderColor", value.ToArgb());
			}
		}

		/// <summary>
		/// Saves the specified setting
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void SaveSetting(string key, object saveValue)
		{
			Application.UserAppDataRegistry.SetValue(key, saveValue);

			if (cache.ContainsKey(key))
				cache[key] = saveValue.ToString();
			else
				if(!cache.ContainsKey(key))
					cache.Add(key, saveValue.ToString());
		}

        public static void ClearCache()
        {
            cache = new Dictionary<string, string>();
        }

		/// <summary>
		/// Gets the specified setting
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetSetting(string key, string defaultValue)
		{
			if (cache.ContainsKey(key))
				return cache[key];
			else
			{
				object result = Application.UserAppDataRegistry.GetValue(key);

				if (result == null)
				{
					SaveSetting(key, defaultValue);

					if(!cache.ContainsKey(key))
						cache.Add(key, defaultValue);

					return defaultValue;
				}
				else
				{
					if(!cache.ContainsKey(key))
						cache.Add(key, result.ToString());

					return cache[key];
				}
			}
		}
	}
}