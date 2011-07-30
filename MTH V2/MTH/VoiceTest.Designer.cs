namespace MTH
{
    partial class VoiceTest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceTest));
			this.label1 = new System.Windows.Forms.Label();
			this.btnTest = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblVC = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblSuccessRate = new System.Windows.Forms.Label();
			this.lblWrongCount = new System.Windows.Forms.Label();
			this.lblCorrectCount = new System.Windows.Forms.Label();
			this.lblCommandCount = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(371, 42);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// btnTest
			// 
			this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTest.Location = new System.Drawing.Point(15, 151);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(291, 34);
			this.btnTest.TabIndex = 1;
			this.btnTest.Text = "Start Test";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.lblVC);
			this.groupBox1.Location = new System.Drawing.Point(15, 197);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(364, 75);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Read this command";
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.panel1.Location = new System.Drawing.Point(308, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(38, 36);
			this.panel1.TabIndex = 1;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// lblVC
			// 
			this.lblVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVC.Location = new System.Drawing.Point(25, 16);
			this.lblVC.Name = "lblVC";
			this.lblVC.Size = new System.Drawing.Size(266, 48);
			this.lblVC.TabIndex = 0;
			this.lblVC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblSuccessRate);
			this.groupBox2.Controls.Add(this.lblWrongCount);
			this.groupBox2.Controls.Add(this.lblCorrectCount);
			this.groupBox2.Controls.Add(this.lblCommandCount);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(15, 285);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(364, 129);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Results";
			// 
			// lblSuccessRate
			// 
			this.lblSuccessRate.AutoSize = true;
			this.lblSuccessRate.Location = new System.Drawing.Point(183, 100);
			this.lblSuccessRate.Name = "lblSuccessRate";
			this.lblSuccessRate.Size = new System.Drawing.Size(13, 13);
			this.lblSuccessRate.TabIndex = 7;
			this.lblSuccessRate.Text = "0";
			// 
			// lblWrongCount
			// 
			this.lblWrongCount.AutoSize = true;
			this.lblWrongCount.Location = new System.Drawing.Point(183, 75);
			this.lblWrongCount.Name = "lblWrongCount";
			this.lblWrongCount.Size = new System.Drawing.Size(13, 13);
			this.lblWrongCount.TabIndex = 6;
			this.lblWrongCount.Text = "0";
			// 
			// lblCorrectCount
			// 
			this.lblCorrectCount.AutoSize = true;
			this.lblCorrectCount.Location = new System.Drawing.Point(183, 50);
			this.lblCorrectCount.Name = "lblCorrectCount";
			this.lblCorrectCount.Size = new System.Drawing.Size(13, 13);
			this.lblCorrectCount.TabIndex = 5;
			this.lblCorrectCount.Text = "0";
			// 
			// lblCommandCount
			// 
			this.lblCommandCount.AutoSize = true;
			this.lblCommandCount.Location = new System.Drawing.Point(183, 25);
			this.lblCommandCount.Name = "lblCommandCount";
			this.lblCommandCount.Size = new System.Drawing.Size(13, 13);
			this.lblCommandCount.TabIndex = 4;
			this.lblCommandCount.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(18, 100);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Success rate:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Wrong recognitions:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Correct recognitions:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Voice commands recognized:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(367, 29);
			this.label2.TabIndex = 4;
			this.label2.Text = "If nothing happens, no voice commands are being recognized at all, please check y" +
				"our microphone then.";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(323, 151);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(60, 34);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(15, 422);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(364, 13);
			this.lblStatus.TabIndex = 6;
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(15, 102);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(367, 43);
			this.label7.TabIndex = 7;
			this.label7.Text = "Click the speaker to have MTH read aloud the current exepected voice command. Cli" +
				"ck the status text in the bottom to have MTH speak aloud the last expected comma" +
				"nd.";
			// 
			// VoiceTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(391, 441);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VoiceTest";
			this.Text = "VoiceTest";
			this.Load += new System.EventHandler(this.VoiceTest_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCommandCount;
        private System.Windows.Forms.Label lblSuccessRate;
        private System.Windows.Forms.Label lblWrongCount;
        private System.Windows.Forms.Label lblCorrectCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}