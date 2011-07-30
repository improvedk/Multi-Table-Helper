using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MTH
{
	/// <summary>
	/// Summary description for BorderForm.
	/// </summary>
	public class BorderForm : System.Windows.Forms.Form
	{
		public Color FlashColor = Color.Black;

		#region Auto code


		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		public BorderForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 65;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BorderForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BorderForm";
            this.ShowInTaskbar = false;
            this.Text = "BorderForm";
            this.Load += new System.EventHandler(this.BorderForm_Load);
            this.ResumeLayout(false);

		}
		#endregion
		#endregion

		/// <summary>
		/// Flashes the table shortly with the designated FlashColor()
		/// </summary>
		public void Flash()
		{
			// Enable the timer that slowly decreases our opacity
			timer1.Interval = 65;
			timer1.Enabled = true;
		}

		public void NoFlash()
		{
			timer1.Enabled = false;
			Opacity = 1;
		}

		/// <summary>
		/// Switches our opacity on and off to cause flicker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(!Settings.FlashTable || !Visible)
			{
				Opacity = 1;

				timer1.Enabled = false;
			}

			if(Opacity == 1)
				Opacity = 0;
			else
				Opacity = 1;

			timer1.Interval += 3;
		}

		private void BorderForm_Load(object sender, System.EventArgs e)
		{

		}
	}
}