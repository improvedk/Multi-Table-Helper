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
using System.Data.SQLite;

namespace MTH.Framework
{
	public class DB
	{
		public static DataTable GetDT(string sql)
		{
			using (SQLiteConnection conn = new SQLiteConnection("DataSource=DB.s3db"))
			{
				conn.Open();

				SQLiteCommand cmd = conn.CreateCommand();
				cmd.CommandText = sql;

				SQLiteDataReader reader = cmd.ExecuteReader();

				DataTable dt = new DataTable();
				dt.Load(reader);

				reader.Close();
				conn.Close();

				return dt;
			}
		}

		public static void Execute(string sql)
		{
			using (SQLiteConnection conn = new SQLiteConnection("DataSource=DB.s3db"))
			{
				conn.Open();

				SQLiteCommand cmd = conn.CreateCommand();
				cmd.CommandText = sql;

				cmd.ExecuteNonQuery();

				conn.Close();
			}
		}

		public static object GetScalar(string sql)
		{
			using (SQLiteConnection conn = new SQLiteConnection("DataSource=DB.s3db"))
			{
				conn.Open();

				SQLiteCommand cmd = conn.CreateCommand();
				cmd.CommandText = sql;
				object result = cmd.ExecuteScalar();

				conn.Close();

				return result;
			}
		}

		public static T GetScalar<T>(string sql)
		{
			return (T)Convert.ChangeType(GetScalar(sql), typeof(T));
		}
	}
}