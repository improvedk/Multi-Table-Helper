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
using System.Data;

namespace MTH.Framework
{
	public partial class Settings
	{
		static bool hasLoadedCache = false;
		static Dictionary<string, string> cache;

		private static void loadCache()
		{
			if (!hasLoadedCache)
			{
				cache = new Dictionary<string, string>();

				foreach (DataRow dr in DB.GetDT("SELECT * FROM tblSettings").Rows)
					cache.Add(dr["Name"].ToString(), dr["Value"].ToString());

				hasLoadedCache = true;
			}
		}

		public static T Get<T>(string name, T defaultValue)
		{
			loadCache();

			if (cache.ContainsKey(name))
				return (T)Convert.ChangeType(cache[name], typeof(T));
			else
			{
				Set(name, defaultValue);
				return Get<T>(name, defaultValue);
			}
		}

		public static void Set<T>(string name, T value)
		{
			if (cache.ContainsKey(name))
				cache[name] = value.ToString();
			else
				cache.Add(name, value.ToString());

			if (DB.GetScalar<int>("SELECT COUNT(1) FROM tblSettings WHERE Name = '" + name.Replace("'", "''") + "'") > 0)
				DB.Execute("UPDATE tblSettings SET Value = '" + value.ToString().Replace("'", "''") + "' WHERE Name = '" + name.Replace("'", "''") + "'");
			else
				DB.Execute("INSERT INTO tblSettings (Name, Value) VALUES ('" + name.Replace("'", "''") + "', '" + value.ToString().Replace("'", "''") + "')");
		}

		public static void ClearCache()
		{
			lock (cache)
			{
				hasLoadedCache = false;
				cache = null;
			}
		}
	}
}