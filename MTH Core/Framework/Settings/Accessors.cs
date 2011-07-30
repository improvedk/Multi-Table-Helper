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
using System.Linq;
using System.Text;

namespace MTH.Framework
{
	public partial class Settings
	{
		public static int QuadrantCount
		{
			get { return DB.GetScalar<int>("SELECT COUNT(1) FROM tblQuadrants"); }
		}

		public static bool PlaceUnseatedTablesAtSpecialLocation
		{
			get { return Get<bool>("PlaceUnseatedTablesAtSpecialLocation", DefaultValues.PlaceUnseatedTablesAtSpecialLocation); }
			set { Set<bool>("PlaceUnseatedTablesAtSpecialLocation", value); }
		}
		
		public static bool MoveActiveTable
		{
			get { return Get<bool>("MoveActiveTable", DefaultValues.MoveActiveTable); }
			set { Set<bool>("MoveActiveTable", value); }
		}

		public static bool MoveCursorToActiveTable
		{
			get { return Get<bool>("MoveCursorToActiveTable", DefaultValues.MoveCursorToActiveTable); }
			set { Set<bool>("MoveCursorToActiveTable", value); }
		}

		public static bool UseBorder
		{
			get { return Get<bool>("UseBorder", DefaultValues.UseBorder); }
			set { Set<bool>("UseBorder", value); }
		}

		public static bool ClearBetBoxOnNLTables
		{
			get { return Get<bool>("ClearBetBoxOnNLTables", DefaultValues.ClearBetBoxOnNLTables); }
			set { Set<bool>("ClearBetBoxOnNLTables", value); }
		}

		public static bool KeepActiveTable
		{
			get { return Get<bool>("KeepActiveTable", DefaultValues.KeepActiveTable); }
			set { Set<bool>("KeepActiveTable", value); }
		}

		public static bool MoveCursorToActiveTableRequireShift
		{
			get { return Get<bool>("MoveCursorToActiveTableRequireShift", DefaultValues.MoveCursorToActiveTableRequireShift); }
			set { Set<bool>("MoveCursorToActiveTableRequireShift", value); }
		}

		public static bool RequireCapsLock
		{
			get { return Get<bool>("RequireCapsLock", DefaultValues.RequireCapsLock); }
			set { Set<bool>("RequireCapsLock", value); }
		}

		public static bool RequireNumLock
		{
			get { return Get<bool>("RequireNumLock", DefaultValues.RequireNumLock); }
			set { Set<bool>("RequireNumLock", value); }
		}
		
		public static bool UseKeyboardControls
		{
			get { return Get<bool>("UseKeyboardControls", DefaultValues.UseKeyboardControls); }
			set { Set<bool>("UseKeyboardControls", value); }
		}

		public static bool AutoArrangeTables
		{
			get { return Get<bool>("AutoArrangeTables", DefaultValues.AutoArrangeTables); }
			set { Set<bool>("AutoArrangeTables", value); }
		}

		public static int ActiveTableQuadrant
		{
			get { return Get<int>("ActiveTableQuadrant", DefaultValues.ActiveTableQuadrant); }
			set { Set<int>("ActiveTableQuadrant", value); }
		}

		public static int ActiveTableBorderWidth
		{
			get { return Get<int>("ActiveTableBorderWidth", DefaultValues.ActiveTableBorderWidth); }
			set { Set<int>("ActiveTableBorderWidth", value); }
		}
	}
}