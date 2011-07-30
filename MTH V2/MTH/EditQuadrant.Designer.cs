namespace MTH
{
    partial class EditQuadrant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuadrant));
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumber = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtY = new System.Windows.Forms.TextBox();
			this.txtX = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbSite = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(367, 292);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Close && Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Quadrant name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(12, 25);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(455, 20);
			this.txtName.TabIndex = 3;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(420, 34);
			this.label7.TabIndex = 24;
			this.label7.Text = "Place this window whereever you want the table to go, you can resize it as you ca" +
				"n with a Party table. You can optionally use the coordinates to fine tune the po" +
				"sition.";
			// 
			// txtNumber
			// 
			this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumber.Location = new System.Drawing.Point(12, 200);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(243, 50);
			this.txtNumber.TabIndex = 23;
			this.txtNumber.Text = "1";
			this.txtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(17, 165);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(408, 18);
			this.linkLabel1.TabIndex = 22;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Download AllSnap to make window snap to monitor edges and each other.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Tip:";
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(183, 73);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(71, 20);
			this.txtHeight.TabIndex = 20;
			this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(183, 51);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(71, 20);
			this.txtWidth.TabIndex = 19;
			this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged_1);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(139, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Height:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(139, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "Width:";
			// 
			// txtY
			// 
			this.txtY.Enabled = false;
			this.txtY.Location = new System.Drawing.Point(39, 73);
			this.txtY.Name = "txtY";
			this.txtY.Size = new System.Drawing.Size(71, 20);
			this.txtY.TabIndex = 16;
			this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
			// 
			// txtX
			// 
			this.txtX.Enabled = false;
			this.txtX.Location = new System.Drawing.Point(39, 51);
			this.txtX.Name = "txtX";
			this.txtX.Size = new System.Drawing.Size(71, 20);
			this.txtX.TabIndex = 15;
			this.txtX.TextChanged += new System.EventHandler(this.txtX_TextChanged_1);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Y:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "X:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(261, 292);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 27;
			this.button1.Text = "Close && Save All";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_2);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(180, 292);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 26;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(313, 51);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(33, 13);
			this.label8.TabIndex = 29;
			this.label8.Text = "Site:";
			// 
			// cmbSite
			// 
			this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSite.FormattingEnabled = true;
			this.cmbSite.Items.AddRange(new object[] {
            "",
            "Party Poker",
            "PokerStars",
            "FTP"});
			this.cmbSite.Location = new System.Drawing.Point(316, 67);
			this.cmbSite.Name = "cmbSite";
			this.cmbSite.Size = new System.Drawing.Size(121, 21);
			this.cmbSite.TabIndex = 30;
			this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
			// 
			// EditQuadrant
			// 
			this.AcceptButton = this.btnSave;
			this.ClientSize = new System.Drawing.Size(475, 327);
			this.Controls.Add(this.cmbSite);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtNumber);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtHeight);
			this.Controls.Add(this.txtWidth);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1338, 971);
			this.MinimizeBox = false;
			this.Name = "EditQuadrant";
			this.Text = "Edit Quadrant";
			this.TopMost = true;
			this.Resize += new System.EventHandler(this.EditQuadrant_Resize);
			this.Shown += new System.EventHandler(this.EditQuadrant_Shown);
			this.Move += new System.EventHandler(this.EditQuadrant_Move);
			this.ResizeEnd += new System.EventHandler(this.EditQuadrant_ResizeEnd);
			this.Load += new System.EventHandler(this.EditQuadrant_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label txtNumber;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtY;
		private System.Windows.Forms.TextBox txtX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbSite;
    }
}