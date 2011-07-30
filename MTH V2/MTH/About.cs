using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MTH
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		#region Auto code
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lblVersion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(136, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "MTH - Multi Table Helper";
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(136, 56);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(168, 16);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "Version 2.0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(136, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(240, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Copyright © 2006 Mark S. Rasmussen - www.improve.dk (Orca)";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(280, 136);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(136, 104);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(232, 16);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "support@multitablehelper.com";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(384, 173);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About MTH";
			this.Load += new System.EventHandler(this.About_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		/// <summary>
		/// Closes the about dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Opens the email adddress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            System.Diagnostics.Process.Start("mailto:support@multitablehelper.com");
		}

		/// <summary>
		/// Updates the version text
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void About_Load(object sender, System.EventArgs e)
		{
			lblVersion.Text = "Version " + Form1.Version.ToString().Replace(",",".");
		}

        private void lblProductCode_Click(object sender, EventArgs e)
        {

        }
	}
}
