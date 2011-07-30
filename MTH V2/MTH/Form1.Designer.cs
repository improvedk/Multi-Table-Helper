using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MTH
{
	partial class Form1
	{
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView lstTables;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Timer moveTables;
		private System.Windows.Forms.NotifyIcon ni;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.ContextMenu cmTableListColumns;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private MenuItem menuItem23;
		private MenuItem menuItem24;
		private MenuItem menuItem25;
		private MenuItem menuItem26;
		private Timer setTitleTimer;
		private MenuItem menuItem29;
		private StatusBarPanel statusBarPanel1;
		private StatusBarPanel statusBarPanel2;
		private OpenFileDialog dlgOpenFile;
		private SaveFileDialog dlgSaveFile;
		private System.ComponentModel.IContainer components;

		public Form1()
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
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pollTables = new System.Windows.Forms.Timer(this.components);
			this.lstTables = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.cmTableListColumns = new System.Windows.Forms.ContextMenu();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.moveTables = new System.Windows.Forms.Timer(this.components);
			this.ni = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.setTitleTimer = new System.Windows.Forms.Timer(this.components);
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.mTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rearrangeTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.makeLatteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.donatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableOnTopTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pollTables
			// 
			this.pollTables.Enabled = true;
			this.pollTables.Interval = 5000;
			this.pollTables.Tick += new System.EventHandler(this.pollTables_Tick);
			// 
			// lstTables
			// 
			this.lstTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstTables.CheckBoxes = true;
			this.lstTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
			this.lstTables.ContextMenu = this.cmTableListColumns;
			this.lstTables.FullRowSelect = true;
			this.lstTables.Location = new System.Drawing.Point(0, 26);
			this.lstTables.MultiSelect = false;
			this.lstTables.Name = "lstTables";
			this.lstTables.Size = new System.Drawing.Size(568, 105);
			this.lstTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstTables.TabIndex = 0;
			this.lstTables.UseCompatibleStateImageBehavior = false;
			this.lstTables.View = System.Windows.Forms.View.Details;
			this.lstTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTables_MouseDoubleClick);
			this.lstTables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstTables_ItemCheck);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Table";
			this.columnHeader2.Width = 439;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Last action";
			this.columnHeader1.Width = 65;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Site";
			// 
			// cmTableListColumns
			// 
			this.cmTableListColumns.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem13,
            this.menuItem14,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19,
            this.menuItem20,
            this.menuItem25,
            this.menuItem29,
            this.menuItem32,
            this.menuItem33});
			// 
			// menuItem12
			// 
			this.menuItem12.Checked = true;
			this.menuItem12.Index = 0;
			this.menuItem12.Text = "400|true|Table";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Checked = true;
			this.menuItem13.Index = 1;
			this.menuItem13.Text = "80|true|Last action";
			this.menuItem13.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Checked = true;
			this.menuItem14.Index = 2;
			this.menuItem14.Text = "60|true|Site";
			this.menuItem14.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 3;
			this.menuItem17.Text = "100|false|Form";
			this.menuItem17.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 4;
			this.menuItem18.Text = "100|false|Limit";
			this.menuItem18.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 5;
			this.menuItem19.Text = "100|false|Type";
			this.menuItem19.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 6;
			this.menuItem20.Text = "100|false|Stakes";
			this.menuItem20.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 7;
			this.menuItem25.Text = "100|false|Blind level";
			this.menuItem25.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 8;
			this.menuItem29.Text = "100|false|ART";
			this.menuItem29.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 9;
			this.menuItem32.Text = "100|false|Needs action";
			this.menuItem32.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 10;
			this.menuItem33.Text = "100|false|Sitting out";
			this.menuItem33.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 137);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
			this.statusBar.Size = new System.Drawing.Size(568, 16);
			this.statusBar.TabIndex = 1;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Name = "statusBarPanel1";
			this.statusBarPanel1.Text = "statusBarPanel1";
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Name = "statusBarPanel2";
			this.statusBarPanel2.Text = "statusBarPanel2";
			// 
			// moveTables
			// 
			this.moveTables.Enabled = true;
			this.moveTables.Interval = 500;
			this.moveTables.Tick += new System.EventHandler(this.moveTables_Tick);
			// 
			// ni
			// 
			this.ni.ContextMenu = this.contextMenu1;
			this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
			this.ni.Text = "MTH - Multi Table Helper";
			this.ni.Visible = true;
			this.ni.DoubleClick += new System.EventHandler(this.ni_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem23,
            this.menuItem26,
            this.menuItem24,
            this.menuItem11,
            this.menuItem9,
            this.menuItem10});
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "Open MTH";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 2;
			this.menuItem26.Text = "Rearrange Tables";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 3;
			this.menuItem24.Text = "-";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 4;
			this.menuItem11.Text = "Preferences";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 5;
			this.menuItem9.Text = "-";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 6;
			this.menuItem10.Text = "Exit";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// setTitleTimer
			// 
			this.setTitleTimer.Interval = 500;
			this.setTitleTimer.Tick += new System.EventHandler(this.setTitleTimer_Tick);
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.FileName = "*.xml";
			this.dlgOpenFile.Filter = "Configuration Files|*.xml";
			// 
			// dlgSaveFile
			// 
			this.dlgSaveFile.DefaultExt = "xml";
			this.dlgSaveFile.FileName = "Settings.xml";
			this.dlgSaveFile.Filter = "Configuration Files|*.xml";
			// 
			// menuStrip2
			// 
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTHToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 0);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(568, 24);
			this.menuStrip2.TabIndex = 3;
			this.menuStrip2.Text = "Menu";
			// 
			// mTHToolStripMenuItem
			// 
			this.mTHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
			this.mTHToolStripMenuItem.Name = "mTHToolStripMenuItem";
			this.mTHToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.mTHToolStripMenuItem.Text = "MTH";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preferencesToolStripMenuItem.Image")));
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
			// 
			// loadConfigurationToolStripMenuItem
			// 
			this.loadConfigurationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadConfigurationToolStripMenuItem.Image")));
			this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
			this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.loadConfigurationToolStripMenuItem.Text = "Load configuration";
			this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// saveConfigurationToolStripMenuItem
			// 
			this.saveConfigurationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveConfigurationToolStripMenuItem.Image")));
			this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
			this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.saveConfigurationToolStripMenuItem.Text = "Save configuration";
			this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rearrangeTablesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.makeLatteToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// rearrangeTablesToolStripMenuItem
			// 
			this.rearrangeTablesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rearrangeTablesToolStripMenuItem.Image")));
			this.rearrangeTablesToolStripMenuItem.Name = "rearrangeTablesToolStripMenuItem";
			this.rearrangeTablesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.rearrangeTablesToolStripMenuItem.Text = "Rearrange tables";
			this.rearrangeTablesToolStripMenuItem.Click += new System.EventHandler(this.menuItem27_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
			// 
			// makeLatteToolStripMenuItem
			// 
			this.makeLatteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("makeLatteToolStripMenuItem.Image")));
			this.makeLatteToolStripMenuItem.Name = "makeLatteToolStripMenuItem";
			this.makeLatteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.makeLatteToolStripMenuItem.Text = "Make latte";
			this.makeLatteToolStripMenuItem.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donatingToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// donatingToolStripMenuItem
			// 
			this.donatingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donatingToolStripMenuItem.Image")));
			this.donatingToolStripMenuItem.Name = "donatingToolStripMenuItem";
			this.donatingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.donatingToolStripMenuItem.Text = "Donating";
			this.donatingToolStripMenuItem.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// tableOnTopTimer
			// 
			this.tableOnTopTimer.Interval = 150;
			this.tableOnTopTimer.Tick += new System.EventHandler(this.tableOnTopTimer_Tick_1);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 153);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.lstTables);
			this.Controls.Add(this.menuStrip2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MTH";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Check to make sure that there aren't any instances of MTH already running
			Process thisProcess = Process.GetCurrentProcess();

			Process[] allProcesses = Process.GetProcessesByName(thisProcess.ProcessName);

			if (allProcesses.Length > 1)
			{
				MessageBox.Show(thisProcess.ProcessName + " is already running", thisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);

				Application.Exit();
			}
			else
			{
				Application.Run(new Form1());
			}
	}

		private MenuItem menuItem32;
		private MenuItem menuItem33;
		private MenuStrip menuStrip2;
		private ToolStripMenuItem mTHToolStripMenuItem;
		private ToolStripMenuItem quitToolStripMenuItem;
		private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem preferencesToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripMenuItem loadConfigurationToolStripMenuItem;
		private ToolStripMenuItem saveConfigurationToolStripMenuItem;
		private ToolStripMenuItem rearrangeTablesToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem makeLatteToolStripMenuItem;
		private ToolStripMenuItem donatingToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Timer tableOnTopTimer;
	}
}