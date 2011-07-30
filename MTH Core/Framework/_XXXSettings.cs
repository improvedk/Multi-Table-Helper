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
using System.Drawing;
using System.Windows.Forms;

namespace MTH.Framework
{
	public class _XXXSettings
    {
		private static Dictionary<string, string> cache = new Dictionary<string, string>();

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
				return Convert.ToInt32(GetSetting("ActiveTableBorderWidth", DefaultValues.ActiveTableBorderWidth));
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
            string quadText = GetSetting("Quadrants", "0,0,796,579");

            Quadrant q = new Quadrant();

            if (!quadText.Contains(","))
            {
                q.X = 0;
                q.Y = 0;
                q.Width = 796;
                q.Height = 579;
                q.Number = quad;
            }
            else
            {
                string[] quads = quadText.Split(';');
                string[] quadData = quads[quad - 1].Split(',');

                q.X = Convert.ToInt32(quadData[0]);
                q.Y = Convert.ToInt32(quadData[1]);
                q.Width = Convert.ToInt32(quadData[2]);
                q.Height = Convert.ToInt32(quadData[3]);
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
                return GetSetting("Quadrants", "0,0,796,579").Split(';').Length;
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
				return Color.FromArgb(Convert.ToInt32(GetSetting("BorderColor", Color.FromArgb(255, 0, 0).ToArgb().ToString())));
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

		public static int GetSetting(string key, int defaultValue)
		{
			return Convert.ToInt32(GetSetting(key, defaultValue.ToString()));
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
