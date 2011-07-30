using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace MTH.Core
{
	partial class Form1
	{
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ListView lstTables;
		private StatusBar statusBar;
		private NotifyIcon ni;
		private ContextMenu contextMenu1;
		private MenuItem menuItem8;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private ColumnHeader columnHeader1;
		private MenuItem menuItem24;
		private MenuItem menuItem26;
		private StatusBarPanel statusBarPanel1;
		private StatusBarPanel statusBarPanel2;
		private IContainer components;
		private MenuStrip menuStrip2;
		private ToolStripMenuItem mTHToolStripMenuItem;
		private ToolStripMenuItem quitToolStripMenuItem;
		private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem preferencesToolStripMenuItem;
		private ToolStripMenuItem rearrangeTablesToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem2;

		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				if (components != null)
					components.Dispose();

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
			this.lstTables = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.ni = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.mTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rearrangeTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstTables
			// 
			this.lstTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lstTables.FullRowSelect = true;
			this.lstTables.Location = new System.Drawing.Point(0, 26);
			this.lstTables.MultiSelect = false;
			this.lstTables.Name = "lstTables";
			this.lstTables.Size = new System.Drawing.Size(586, 152);
			this.lstTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstTables.TabIndex = 0;
			this.lstTables.UseCompatibleStateImageBehavior = false;
			this.lstTables.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Table";
			this.columnHeader2.Width = 275;
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
			// columnHeader4
			// 
			this.columnHeader4.Text = "Needs action";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Sitting out";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Seated";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 179);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
			this.statusBar.Size = new System.Drawing.Size(586, 16);
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
			// ni
			// 
			this.ni.ContextMenu = this.contextMenu1;
			this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
			this.ni.Text = "MTH - Multi Table Helper";
			this.ni.Visible = true;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
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
			this.menuItem26.Index = 1;
			this.menuItem26.Text = "Rearrange Tables";
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 2;
			this.menuItem24.Text = "-";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "Preferences";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "-";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 5;
			this.menuItem10.Text = "Exit";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuStrip2
			// 
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTHToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 0);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(586, 24);
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
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preferencesToolStripMenuItem.Image")));
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rearrangeTablesToolStripMenuItem,
            this.toolStripMenuItem2});
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
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(586, 195);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.lstTables);
			this.Controls.Add(this.menuStrip2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MTH Core";
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

		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		private ColumnHeader columnHeader6;
	}
}