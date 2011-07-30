using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MTH
{
	/// <summary>
	/// Summary description for MakeLatte.
	/// </summary>
	public class MakeLatte : System.Windows.Forms.Form
	{
		#region Auto code
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MakeLatte()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakeLatte));
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(136, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 24);
			this.label1.TabIndex = 5;
			this.label1.Text = "MTH - Multi Table Helper";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(136, 56);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(168, 16);
			this.lblVersion.TabIndex = 6;
			this.lblVersion.Text = "Steps:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(256, 32);
			this.label2.TabIndex = 7;
			this.label2.Text = "1. Make a shot of espresso equaling between 1 and 1 ½ oz.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(136, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "2. Steam 10 oz. milk";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(136, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(256, 40);
			this.label4.TabIndex = 9;
			this.label4.Text = "3. Steam another 2 oz. milk in a separate glass to create foam. Continue to apply" +
				" steam until the milk completely foams.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(136, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(248, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "4. Pour hot milk in a 12-oz. glass until 3/4 full.";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(136, 229);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(248, 19);
			this.label6.TabIndex = 11;
			this.label6.Text = "5. Spoon a small amount of foam onto the top.";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(136, 256);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(248, 32);
			this.label7.TabIndex = 12;
			this.label7.Text = "6. Gently pour espresso into the top and middle of foam";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(136, 296);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(248, 32);
			this.label8.TabIndex = 13;
			this.label8.Text = "7. Spoon a little more foam on top and dust with ground chocolate, cinnamon or nu" +
				"tmeg.";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 136);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 14;
			this.label9.Text = "Source:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(16, 160);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(96, 16);
			this.linkLabel1.TabIndex = 15;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.ehow.com";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(304, 352);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 16;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MakeLatte
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(410, 396);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MakeLatte";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Make Latte";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		/// <summary>
		/// Opens the source website, www.ehow.com
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.ehow.com");
		}

		/// <summary>
		/// Closes the dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
