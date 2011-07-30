namespace Table_Tester
{
	partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtHandle = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblIsPokerTable = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblSiteName = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.lblRequiresAction = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.lblIsSeated = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblIsSittingOut = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.lblGetRaiseValue = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblGetActionStatus = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.txtRaiseAmount = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Handle:";
			// 
			// txtHandle
			// 
			this.txtHandle.Location = new System.Drawing.Point(62, 6);
			this.txtHandle.Name = "txtHandle";
			this.txtHandle.Size = new System.Drawing.Size(166, 20);
			this.txtHandle.TabIndex = 1;
			this.txtHandle.Text = "00440734";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(234, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Hook";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lblGetActionStatus);
			this.groupBox1.Controls.Add(this.lblGetRaiseValue);
			this.groupBox1.Controls.Add(this.lblIsSittingOut);
			this.groupBox1.Controls.Add(this.lblIsSeated);
			this.groupBox1.Controls.Add(this.lblRequiresAction);
			this.groupBox1.Controls.Add(this.lblSiteName);
			this.groupBox1.Controls.Add(this.lblTitle);
			this.groupBox1.Controls.Add(this.lblIsPokerTable);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(15, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(295, 391);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Not hooked";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 26);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label2.Size = new System.Drawing.Size(73, 21);
			this.label2.TabIndex = 0;
			this.label2.Text = "IsPokerTable:";
			// 
			// lblIsPokerTable
			// 
			this.lblIsPokerTable.AutoSize = true;
			this.lblIsPokerTable.Location = new System.Drawing.Point(113, 26);
			this.lblIsPokerTable.Name = "lblIsPokerTable";
			this.lblIsPokerTable.Size = new System.Drawing.Size(10, 13);
			this.lblIsPokerTable.TabIndex = 1;
			this.lblIsPokerTable.Text = "-";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(316, 32);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(117, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "UpdateData";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 47);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label3.Size = new System.Drawing.Size(65, 21);
			this.label3.TabIndex = 0;
			this.label3.Text = "TableName:";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(113, 47);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(10, 13);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "-";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 68);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label4.Size = new System.Drawing.Size(56, 21);
			this.label4.TabIndex = 0;
			this.label4.Text = "SiteName:";
			// 
			// lblSiteName
			// 
			this.lblSiteName.AutoSize = true;
			this.lblSiteName.Location = new System.Drawing.Point(113, 68);
			this.lblSiteName.Name = "lblSiteName";
			this.lblSiteName.Size = new System.Drawing.Size(10, 13);
			this.lblSiteName.TabIndex = 1;
			this.lblSiteName.Text = "-";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(316, 61);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(117, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "MoveCursorToTable";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 89);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label5.Size = new System.Drawing.Size(82, 21);
			this.label5.TabIndex = 0;
			this.label5.Text = "RequiresAction:";
			// 
			// lblRequiresAction
			// 
			this.lblRequiresAction.AutoSize = true;
			this.lblRequiresAction.Location = new System.Drawing.Point(113, 89);
			this.lblRequiresAction.Name = "lblRequiresAction";
			this.lblRequiresAction.Size = new System.Drawing.Size(10, 13);
			this.lblRequiresAction.TabIndex = 1;
			this.lblRequiresAction.Text = "-";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(316, 90);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(117, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "InvokeActionTick";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 110);
			this.label6.Name = "label6";
			this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label6.Size = new System.Drawing.Size(52, 21);
			this.label6.TabIndex = 0;
			this.label6.Text = "IsSeated:";
			// 
			// lblIsSeated
			// 
			this.lblIsSeated.AutoSize = true;
			this.lblIsSeated.Location = new System.Drawing.Point(113, 110);
			this.lblIsSeated.Name = "lblIsSeated";
			this.lblIsSeated.Size = new System.Drawing.Size(10, 13);
			this.lblIsSeated.TabIndex = 1;
			this.lblIsSeated.Text = "-";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 131);
			this.label7.Name = "label7";
			this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label7.Size = new System.Drawing.Size(64, 21);
			this.label7.TabIndex = 0;
			this.label7.Text = "IsSittingOut:";
			// 
			// lblIsSittingOut
			// 
			this.lblIsSittingOut.AutoSize = true;
			this.lblIsSittingOut.Location = new System.Drawing.Point(113, 131);
			this.lblIsSittingOut.Name = "lblIsSittingOut";
			this.lblIsSittingOut.Size = new System.Drawing.Size(10, 13);
			this.lblIsSittingOut.TabIndex = 1;
			this.lblIsSittingOut.Text = "-";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(316, 119);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(117, 23);
			this.button5.TabIndex = 6;
			this.button5.Text = "Fold";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(316, 148);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(117, 23);
			this.button6.TabIndex = 6;
			this.button6.Text = "Check/Call";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(316, 177);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(117, 23);
			this.button7.TabIndex = 6;
			this.button7.Text = "Bet/Raise";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(20, 152);
			this.label8.Name = "label8";
			this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label8.Size = new System.Drawing.Size(81, 21);
			this.label8.TabIndex = 0;
			this.label8.Text = "GetRaiseValue:";
			// 
			// lblGetRaiseValue
			// 
			this.lblGetRaiseValue.AutoSize = true;
			this.lblGetRaiseValue.Location = new System.Drawing.Point(113, 152);
			this.lblGetRaiseValue.Name = "lblGetRaiseValue";
			this.lblGetRaiseValue.Size = new System.Drawing.Size(10, 13);
			this.lblGetRaiseValue.TabIndex = 1;
			this.lblGetRaiseValue.Text = "-";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(20, 173);
			this.label9.Name = "label9";
			this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.label9.Size = new System.Drawing.Size(87, 21);
			this.label9.TabIndex = 0;
			this.label9.Text = "GetActionStatus:";
			// 
			// lblGetActionStatus
			// 
			this.lblGetActionStatus.AutoSize = true;
			this.lblGetActionStatus.Location = new System.Drawing.Point(113, 173);
			this.lblGetActionStatus.Name = "lblGetActionStatus";
			this.lblGetActionStatus.Size = new System.Drawing.Size(10, 13);
			this.lblGetActionStatus.TabIndex = 1;
			this.lblGetActionStatus.Text = "-";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(316, 206);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(117, 23);
			this.button8.TabIndex = 7;
			this.button8.Text = "AutoPush";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click_1);
			// 
			// txtRaiseAmount
			// 
			this.txtRaiseAmount.Location = new System.Drawing.Point(316, 269);
			this.txtRaiseAmount.Name = "txtRaiseAmount";
			this.txtRaiseAmount.Size = new System.Drawing.Size(117, 20);
			this.txtRaiseAmount.TabIndex = 8;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(316, 240);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(117, 23);
			this.button9.TabIndex = 9;
			this.button9.Text = "SetRaiseValue:";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 435);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.txtRaiseAmount);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtHandle);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtHandle;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblIsPokerTable;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblSiteName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label lblRequiresAction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label lblIsSeated;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblIsSittingOut;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label lblGetRaiseValue;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblGetActionStatus;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox txtRaiseAmount;
		private System.Windows.Forms.Button button9;
	}
}

