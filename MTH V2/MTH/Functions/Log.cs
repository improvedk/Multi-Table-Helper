using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Configuration;

namespace MTH
{
	public class Log
	{
		private static FileStream fsr;
		private static StreamWriter sw;
		private static bool hasInitialized = false;

		/// <summary>
		/// Checks if we need to initialize, and gets the calling method
		/// </summary>
		/// <param name="msg"></param>
		public static void Write(string msg)
		{
			if (Settings.EnableLogging)
			{
				if (!hasInitialized)
					initialize();

				write(msg, new StackTrace().GetFrame(1).GetMethod().ReflectedType.FullName + "." + new StackTrace().GetFrame(1).GetMethod().Name);
			}
		}

		/// <summary>
		/// Initializes the logging class by creating a text file on the users desktop, and saving a reference to this
		/// </summary>
		private static void initialize()
		{
			// Create logging file
			fsr = new FileStream(Application.StartupPath + "\\LOG.txt", FileMode.Create, FileAccess.Write);
			sw = new StreamWriter(fsr);

			hasInitialized = true;
		}

		/// <summary>
		/// Overload
		/// </summary>
		/// <param name="msg"></param>
		private static void write(string msg)
		{
			write(msg, "");
		}

		/// <summary>
		/// Writes the message to the logging file
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="function"></param>
		private static void write(string msg, string function)
		{
			string time;

			time = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.ffff");

			if(function.Length == 0)
				sw.WriteLine(time + "\t" + msg);
			else
				sw.WriteLine(time + "\t" + function + "\t" + msg);
		
			sw.Flush();
		}
	}
}
