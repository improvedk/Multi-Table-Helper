using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using MTH.Framework;

namespace MTH.Core
{
	partial class Form1
	{
		/// <summary>
		/// Open the form again when we click the open item in the notifyicons context menu
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
		/// Saves preferences just before closing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Closing(object sender, CancelEventArgs e)
		{
			//TODO: Save form position & size
		}

		private IPokerTable activeTable;
		public IPokerTable ActiveTable
		{
			get { return activeTable; }
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
			}
		}

		#region Logging
		private Logger _logger;
		private Logger logger
		{
			get
			{
				if (_logger == null)
					_logger = new Logger();

				return _logger;
			}
		}

		public void Log(object msg)
		{
			Log(msg, Color.White);
		}

		public void Log(object msg, Color color)
		{
			logger.Show();

			ListViewItem lvi = new ListViewItem();
			lvi.Text = logger.Lst.Items.Count + ": " + msg.ToString();
			lvi.BackColor = color;
			lvi.ForeColor = Color.Black;

			logger.Lst.Items.Insert(0, lvi);
		}
		#endregion
	}
}