using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MTH
{
	/// <summary>
	/// Summary description for Preferences.
	/// </summary>
	public class Preferences : System.Windows.Forms.Form
	{
        bool loading = false;

        // Reference var
        public static Preferences FormReference = null;

		#region Autocode

		private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMoveActiveTable;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox chkAutoArrangeTables;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkUseKeyboardControls;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.GroupBox grpActiveTable;
		private System.Windows.Forms.NumericUpDown numActiveTableQuadrant;
		private System.Windows.Forms.CheckBox chkKeepActiveTable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkPlaceUnseatedTablesAtSpecialLocation;
		private System.Windows.Forms.NumericUpDown numNonSeatedTableQuadrant;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox grpNonSeatedTable;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.CheckBox chkMoveCursorToActiveTable;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox chkBetRaiseRequireShift;
		private System.Windows.Forms.ComboBox lstBetRaiseKey;
		private System.Windows.Forms.CheckBox chkCheckCallRequireShift;
		private System.Windows.Forms.ComboBox lstCheckCallKey;
		private System.Windows.Forms.CheckBox chkFoldRequireShift;
        private System.Windows.Forms.ComboBox lstFoldKey;
		private System.Windows.Forms.GroupBox grpKeyControls;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox checkBox17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.CheckBox chkAutoPushRequireShift;
        private System.Windows.Forms.ComboBox lstAutoPushKey;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.CheckBox chkMoveCursorToActiveTableRequireShift;
		private System.Windows.Forms.ComboBox lstMoveCursorToActiveTableKey;
        private CheckBox chkUseVoiceCommands;
        private TabPage tabPage8;
        private Label label22;
        private Label label23;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label32;
        private Label label33;
        private TextBox txtPreset3Amount;
        private TextBox txtPreset3;
        private TextBox txtPreset2Amount;
        private TextBox txtPreset2;
        private TextBox txtPreset1Amount;
        private TextBox txtPreset1;
        private Label label35;
        private Label label34;
        private Button button2;
        private LinkLabel linkLabel1;
        private LinkLabel btnDownloadSpeech;
        private TabPage tabPage10;
        private GroupBox groupBox1;
        private Label label20;
        private NumericUpDown nmActiveTableBorderWidth;
        private Label label17;
		private CheckBox chkFlashTable;
        private Label label1;
        private CheckBox chkUseBorder;
        private GroupBox groupBox6;
        private CheckBox chkAllowNoAmountBetRaise;
        private GroupBox grpBorderColors;
        private Label label45;
        private Label label44;
        private Label label43;
        private Label label42;
        private Label label41;
        private Label label40;
        private Label label39;
        private Label label38;
        private Label label37;
        private Label label36;
        private ColorDialog colorDialog1;
        private PictureBox blindLevel9Color;
        private PictureBox blindLevel8Color;
        private PictureBox blindLevel7Color;
        private PictureBox blindLevel6Color;
        private PictureBox blindLevel5Color;
        private PictureBox blindLevel4Color;
        private PictureBox blindLevel3Color;
        private PictureBox blindLevel2Color;
        private PictureBox blindLevel1Color;
        private PictureBox blindLevel10Color;
        private Label label46;
		private TabPage tabPage9;
		private CheckBox chkRequireNumLock;
		private CheckBox chkRequireCapsLock;
		private PictureBox pbBorderColor;
		private TabPage tabPage11;
		private Label label48;
		private GroupBox groupBox10;
		private Label label49;
		private CheckBox chkUseColorIdentification;
		private RadioButton rdbColorIdentificationMedium;
		private RadioButton rdbColorIdentificationLarge;
		private RadioButton rdbColorIdentificationSmall;
		private RadioButton rdbColorIdentificationCompleteBorder;
		private Label label50;
		private NumericUpDown numTableIdentificationCompleteBorderWidth;
		private Label label51;
		private CheckBox chkRearrangeTablesRequireShift;
		private Label label52;
        private ComboBox lstRearrangeTablesKey;
		private TabPage tabPage12;
		private GroupBox groupBox11;
		private CheckBox chkKeepLobbyOpened;
		private CheckBox chkKeepLobbyMinimized;
        private CheckBox chkForceActiveTableToBeTopmost;
        public ListView lstQuadrants;
        private Label label3;
        private ColumnHeader number;
        private ColumnHeader name;
        private ColumnHeader x;
        private ColumnHeader y;
        private ColumnHeader width;
        private ColumnHeader height;
        private Button btnDown;
        private Button btnUp;
        private Button btnAddQuadrant;
        public Button btnDeleteQuadrant;
        private Button btnShowQuadrant;
        private Button btnShowAllQuadrants;
        private GroupBox groupBox9;
        private Button button4;
        private Button button3;
        private ListView lstSeatPreferences;
        private ColumnHeader columnHeader1;
        private Label label47;
        private CheckBox chkSNGOpenerRequireShift;
        private Label label4;
        private ComboBox lstSNGOpenerKey;
		private CheckBox chkToggleLobbyRequireShift;
		private ComboBox lstToggleLobbyKey;
		private Label label9;
		private TabPage tabPage4;
		private CheckBox chkAutoUpdate;
		private CheckBox chkShowNotification;
		private CheckBox chkAutoWaitForBB;
		private CheckBox chkAutoPostBlind;
		private CheckBox chkAutoClickAutoPostBlind;
		private CheckBox chkEnableLogging;
		private CheckBox chkClearBetBoxNL;
        private CheckBox chkToggleActiveTableTopmostRequireShift;
        private ComboBox lstToggleForceActiveTableTopmostKey;
		private Label label10;
		private System.ComponentModel.IContainer components;

		public Preferences()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
			System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Seat 1");
			System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Seat 2");
			System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Seat 3");
			System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Seat 4");
			System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Seat 5");
			System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Seat 6");
			System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Seat 7");
			System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Seat 8");
			System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("Seat 9");
			System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("Seat 10");
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.chkForceActiveTableToBeTopmost = new System.Windows.Forms.CheckBox();
			this.chkAllowNoAmountBetRaise = new System.Windows.Forms.CheckBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.chkMoveCursorToActiveTable = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkRequireNumLock = new System.Windows.Forms.CheckBox();
			this.chkRequireCapsLock = new System.Windows.Forms.CheckBox();
			this.btnDownloadSpeech = new System.Windows.Forms.LinkLabel();
			this.chkUseVoiceCommands = new System.Windows.Forms.CheckBox();
			this.chkUseKeyboardControls = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkPlaceUnseatedTablesAtSpecialLocation = new System.Windows.Forms.CheckBox();
			this.chkKeepActiveTable = new System.Windows.Forms.CheckBox();
			this.chkAutoArrangeTables = new System.Windows.Forms.CheckBox();
			this.chkMoveActiveTable = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpNonSeatedTable = new System.Windows.Forms.GroupBox();
			this.numNonSeatedTableQuadrant = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnShowAllQuadrants = new System.Windows.Forms.Button();
			this.btnDeleteQuadrant = new System.Windows.Forms.Button();
			this.btnShowQuadrant = new System.Windows.Forms.Button();
			this.btnAddQuadrant = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.lstQuadrants = new System.Windows.Forms.ListView();
			this.number = new System.Windows.Forms.ColumnHeader();
			this.name = new System.Windows.Forms.ColumnHeader();
			this.x = new System.Windows.Forms.ColumnHeader();
			this.y = new System.Windows.Forms.ColumnHeader();
			this.width = new System.Windows.Forms.ColumnHeader();
			this.height = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.grpActiveTable = new System.Windows.Forms.GroupBox();
			this.numActiveTableQuadrant = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.grpKeyControls = new System.Windows.Forms.GroupBox();
			this.chkToggleActiveTableTopmostRequireShift = new System.Windows.Forms.CheckBox();
			this.lstToggleForceActiveTableTopmostKey = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkToggleLobbyRequireShift = new System.Windows.Forms.CheckBox();
			this.lstToggleLobbyKey = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lstSNGOpenerKey = new System.Windows.Forms.ComboBox();
			this.chkSNGOpenerRequireShift = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lstRearrangeTablesKey = new System.Windows.Forms.ComboBox();
			this.chkRearrangeTablesRequireShift = new System.Windows.Forms.CheckBox();
			this.label52 = new System.Windows.Forms.Label();
			this.lstMoveCursorToActiveTableKey = new System.Windows.Forms.ComboBox();
			this.chkMoveCursorToActiveTableRequireShift = new System.Windows.Forms.CheckBox();
			this.label21 = new System.Windows.Forms.Label();
			this.lstAutoPushKey = new System.Windows.Forms.ComboBox();
			this.chkAutoPushRequireShift = new System.Windows.Forms.CheckBox();
			this.label16 = new System.Windows.Forms.Label();
			this.checkBox17 = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lstFoldKey = new System.Windows.Forms.ComboBox();
			this.chkFoldRequireShift = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.lstCheckCallKey = new System.Windows.Forms.ComboBox();
			this.chkCheckCallRequireShift = new System.Windows.Forms.CheckBox();
			this.label18 = new System.Windows.Forms.Label();
			this.lstBetRaiseKey = new System.Windows.Forms.ComboBox();
			this.chkBetRaiseRequireShift = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button2 = new System.Windows.Forms.Button();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.txtPreset3Amount = new System.Windows.Forms.TextBox();
			this.txtPreset3 = new System.Windows.Forms.TextBox();
			this.txtPreset2Amount = new System.Windows.Forms.TextBox();
			this.txtPreset2 = new System.Windows.Forms.TextBox();
			this.txtPreset1Amount = new System.Windows.Forms.TextBox();
			this.txtPreset1 = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.grpBorderColors = new System.Windows.Forms.GroupBox();
			this.blindLevel10Color = new System.Windows.Forms.PictureBox();
			this.label46 = new System.Windows.Forms.Label();
			this.blindLevel9Color = new System.Windows.Forms.PictureBox();
			this.blindLevel8Color = new System.Windows.Forms.PictureBox();
			this.blindLevel7Color = new System.Windows.Forms.PictureBox();
			this.blindLevel6Color = new System.Windows.Forms.PictureBox();
			this.blindLevel5Color = new System.Windows.Forms.PictureBox();
			this.blindLevel4Color = new System.Windows.Forms.PictureBox();
			this.blindLevel3Color = new System.Windows.Forms.PictureBox();
			this.blindLevel2Color = new System.Windows.Forms.PictureBox();
			this.blindLevel1Color = new System.Windows.Forms.PictureBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pbBorderColor = new System.Windows.Forms.PictureBox();
			this.label20 = new System.Windows.Forms.Label();
			this.nmActiveTableBorderWidth = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.chkFlashTable = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkUseBorder = new System.Windows.Forms.CheckBox();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.lstSeatPreferences = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.label47 = new System.Windows.Forms.Label();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label50 = new System.Windows.Forms.Label();
			this.numTableIdentificationCompleteBorderWidth = new System.Windows.Forms.NumericUpDown();
			this.label51 = new System.Windows.Forms.Label();
			this.rdbColorIdentificationCompleteBorder = new System.Windows.Forms.RadioButton();
			this.chkUseColorIdentification = new System.Windows.Forms.CheckBox();
			this.rdbColorIdentificationMedium = new System.Windows.Forms.RadioButton();
			this.rdbColorIdentificationLarge = new System.Windows.Forms.RadioButton();
			this.rdbColorIdentificationSmall = new System.Windows.Forms.RadioButton();
			this.label49 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.tabPage12 = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.chkKeepLobbyOpened = new System.Windows.Forms.CheckBox();
			this.chkKeepLobbyMinimized = new System.Windows.Forms.CheckBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.chkClearBetBoxNL = new System.Windows.Forms.CheckBox();
			this.chkEnableLogging = new System.Windows.Forms.CheckBox();
			this.chkAutoClickAutoPostBlind = new System.Windows.Forms.CheckBox();
			this.chkAutoPostBlind = new System.Windows.Forms.CheckBox();
			this.chkAutoWaitForBB = new System.Windows.Forms.CheckBox();
			this.chkShowNotification = new System.Windows.Forms.CheckBox();
			this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.tabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpNonSeatedTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numNonSeatedTableQuadrant)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.grpActiveTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numActiveTableQuadrant)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.grpKeyControls.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.grpBorderColors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel10Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel9Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel8Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel7Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel6Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel5Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel4Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel3Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel2Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel1Color)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBorderColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmActiveTableBorderWidth)).BeginInit();
			this.tabPage9.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTableIdentificationCompleteBorderWidth)).BeginInit();
			this.tabPage12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tabPage1);
			this.tabs.Controls.Add(this.tabPage2);
			this.tabs.Controls.Add(this.tabPage3);
			this.tabs.Controls.Add(this.tabPage8);
			this.tabs.Controls.Add(this.tabPage10);
			this.tabs.Controls.Add(this.tabPage9);
			this.tabs.Controls.Add(this.tabPage11);
			this.tabs.Controls.Add(this.tabPage12);
			this.tabs.Controls.Add(this.tabPage4);
			this.tabs.HotTrack = true;
			this.tabs.Location = new System.Drawing.Point(8, 8);
			this.tabs.Multiline = true;
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(448, 477);
			this.tabs.TabIndex = 0;
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.groupBox8);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(440, 433);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Behavior";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.chkForceActiveTableToBeTopmost);
			this.groupBox6.Controls.Add(this.chkAllowNoAmountBetRaise);
			this.groupBox6.Location = new System.Drawing.Point(16, 322);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(408, 88);
			this.groupBox6.TabIndex = 6;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Miscellaneous options";
			// 
			// chkForceActiveTableToBeTopmost
			// 
			this.chkForceActiveTableToBeTopmost.AutoSize = true;
			this.chkForceActiveTableToBeTopmost.Location = new System.Drawing.Point(24, 51);
			this.chkForceActiveTableToBeTopmost.Name = "chkForceActiveTableToBeTopmost";
			this.chkForceActiveTableToBeTopmost.Size = new System.Drawing.Size(196, 17);
			this.chkForceActiveTableToBeTopmost.TabIndex = 1;
			this.chkForceActiveTableToBeTopmost.Text = "Force the active table to be topmost";
			this.toolTip1.SetToolTip(this.chkForceActiveTableToBeTopmost, "If checked, the active table will be forced to be topmost. This greatly helps whe" +
					"n overlapping, but it also steals focus from other windows.");
			this.chkForceActiveTableToBeTopmost.UseVisualStyleBackColor = true;
			this.chkForceActiveTableToBeTopmost.CheckedChanged += new System.EventHandler(this.chkForceActiveTableToBeTopmost_CheckedChanged);
			// 
			// chkAllowNoAmountBetRaise
			// 
			this.chkAllowNoAmountBetRaise.AutoSize = true;
			this.chkAllowNoAmountBetRaise.Location = new System.Drawing.Point(24, 28);
			this.chkAllowNoAmountBetRaise.Name = "chkAllowNoAmountBetRaise";
			this.chkAllowNoAmountBetRaise.Size = new System.Drawing.Size(270, 17);
			this.chkAllowNoAmountBetRaise.TabIndex = 0;
			this.chkAllowNoAmountBetRaise.Text = "Allow bet / raise when no amount has been entered";
			this.chkAllowNoAmountBetRaise.UseVisualStyleBackColor = true;
			this.chkAllowNoAmountBetRaise.CheckedChanged += new System.EventHandler(this.chkAllowNoAmountBetRaise_CheckedChanged);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.chkMoveCursorToActiveTable);
			this.groupBox8.Location = new System.Drawing.Point(16, 141);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(408, 56);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Mouse";
			// 
			// chkMoveCursorToActiveTable
			// 
			this.chkMoveCursorToActiveTable.Location = new System.Drawing.Point(24, 24);
			this.chkMoveCursorToActiveTable.Name = "chkMoveCursorToActiveTable";
			this.chkMoveCursorToActiveTable.Size = new System.Drawing.Size(216, 16);
			this.chkMoveCursorToActiveTable.TabIndex = 0;
			this.chkMoveCursorToActiveTable.Text = "Move the cursor to the active table";
			this.toolTip1.SetToolTip(this.chkMoveCursorToActiveTable, "If checked, the cursor will be moved to the active table when it activates");
			this.chkMoveCursorToActiveTable.CheckedChanged += new System.EventHandler(this.chkMoveCursorToActiveTable_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkRequireNumLock);
			this.groupBox4.Controls.Add(this.chkRequireCapsLock);
			this.groupBox4.Controls.Add(this.btnDownloadSpeech);
			this.groupBox4.Controls.Add(this.chkUseVoiceCommands);
			this.groupBox4.Controls.Add(this.chkUseKeyboardControls);
			this.groupBox4.Location = new System.Drawing.Point(16, 205);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(408, 111);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Control";
			// 
			// chkRequireNumLock
			// 
			this.chkRequireNumLock.AutoSize = true;
			this.chkRequireNumLock.Location = new System.Drawing.Point(24, 86);
			this.chkRequireNumLock.Name = "chkRequireNumLock";
			this.chkRequireNumLock.Size = new System.Drawing.Size(115, 17);
			this.chkRequireNumLock.TabIndex = 4;
			this.chkRequireNumLock.Text = "Require Num Lock";
			this.toolTip1.SetToolTip(this.chkRequireNumLock, "If checked, MTH will only process key commands in Num Lock is on");
			this.chkRequireNumLock.UseVisualStyleBackColor = true;
			this.chkRequireNumLock.CheckedChanged += new System.EventHandler(this.chkRequireNumLock_CheckedChanged);
			// 
			// chkRequireCapsLock
			// 
			this.chkRequireCapsLock.AutoSize = true;
			this.chkRequireCapsLock.Location = new System.Drawing.Point(24, 66);
			this.chkRequireCapsLock.Name = "chkRequireCapsLock";
			this.chkRequireCapsLock.Size = new System.Drawing.Size(117, 17);
			this.chkRequireCapsLock.TabIndex = 3;
			this.chkRequireCapsLock.Text = "Require Caps Lock";
			this.toolTip1.SetToolTip(this.chkRequireCapsLock, "If checked, MTH will only process key commands if Caps Lock is on");
			this.chkRequireCapsLock.UseVisualStyleBackColor = true;
			this.chkRequireCapsLock.CheckedChanged += new System.EventHandler(this.chkRequireCapsLock_CheckedChanged);
			// 
			// btnDownloadSpeech
			// 
			this.btnDownloadSpeech.AutoSize = true;
			this.btnDownloadSpeech.Location = new System.Drawing.Point(275, 47);
			this.btnDownloadSpeech.Name = "btnDownloadSpeech";
			this.btnDownloadSpeech.Size = new System.Drawing.Size(117, 13);
			this.btnDownloadSpeech.TabIndex = 2;
			this.btnDownloadSpeech.TabStop = true;
			this.btnDownloadSpeech.Text = "Download voice addon";
			this.btnDownloadSpeech.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDownloadSpeech_LinkClicked);
			// 
			// chkUseVoiceCommands
			// 
			this.chkUseVoiceCommands.AutoSize = true;
			this.chkUseVoiceCommands.Location = new System.Drawing.Point(24, 46);
			this.chkUseVoiceCommands.Name = "chkUseVoiceCommands";
			this.chkUseVoiceCommands.Size = new System.Drawing.Size(142, 17);
			this.chkUseVoiceCommands.TabIndex = 1;
			this.chkUseVoiceCommands.Text = "Enable voice commands";
			this.toolTip1.SetToolTip(this.chkUseVoiceCommands, "If checked, MTH enables you to control the poker client with your voice, see the " +
					"\"Voice Commands\" tab for further options");
			this.chkUseVoiceCommands.UseVisualStyleBackColor = true;
			this.chkUseVoiceCommands.CheckedChanged += new System.EventHandler(this.chkUseVoiceCommands_CheckedChanged);
			// 
			// chkUseKeyboardControls
			// 
			this.chkUseKeyboardControls.Location = new System.Drawing.Point(24, 24);
			this.chkUseKeyboardControls.Name = "chkUseKeyboardControls";
			this.chkUseKeyboardControls.Size = new System.Drawing.Size(152, 16);
			this.chkUseKeyboardControls.TabIndex = 0;
			this.chkUseKeyboardControls.Text = "Enable keyboard controls";
			this.toolTip1.SetToolTip(this.chkUseKeyboardControls, "If checked, MTH enables you to control the poker client with your keyboard, see t" +
					"he \"Keyboard Controls\" tab for further options");
			this.chkUseKeyboardControls.CheckedChanged += new System.EventHandler(this.chkUseKeyboardControls_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkPlaceUnseatedTablesAtSpecialLocation);
			this.groupBox2.Controls.Add(this.chkKeepActiveTable);
			this.groupBox2.Controls.Add(this.chkAutoArrangeTables);
			this.groupBox2.Controls.Add(this.chkMoveActiveTable);
			this.groupBox2.Location = new System.Drawing.Point(16, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(408, 119);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Table arrangement";
			// 
			// chkPlaceUnseatedTablesAtSpecialLocation
			// 
			this.chkPlaceUnseatedTablesAtSpecialLocation.Location = new System.Drawing.Point(24, 94);
			this.chkPlaceUnseatedTablesAtSpecialLocation.Name = "chkPlaceUnseatedTablesAtSpecialLocation";
			this.chkPlaceUnseatedTablesAtSpecialLocation.Size = new System.Drawing.Size(368, 16);
			this.chkPlaceUnseatedTablesAtSpecialLocation.TabIndex = 12;
			this.chkPlaceUnseatedTablesAtSpecialLocation.Text = "Place tables at which i\'m not seated / sitting out in a special location";
			this.toolTip1.SetToolTip(this.chkPlaceUnseatedTablesAtSpecialLocation, "If checked, tables at which you\'re either sitting out, or haven\'t taken a seat ye" +
					"t, will be placed at the location you define under the \"Areas\" tab");
			this.chkPlaceUnseatedTablesAtSpecialLocation.CheckedChanged += new System.EventHandler(this.chkPlaceUnseatedTablesAtSpecialLocation_CheckedChanged);
			// 
			// chkKeepActiveTable
			// 
			this.chkKeepActiveTable.Location = new System.Drawing.Point(24, 48);
			this.chkKeepActiveTable.Name = "chkKeepActiveTable";
			this.chkKeepActiveTable.Size = new System.Drawing.Size(232, 16);
			this.chkKeepActiveTable.TabIndex = 10;
			this.chkKeepActiveTable.Text = "Keep active table in place, until replaced";
			this.toolTip1.SetToolTip(this.chkKeepActiveTable, "If checked, the last active table will remain in the active table location until " +
					"it\'s replaced by a new active table");
			this.chkKeepActiveTable.CheckedChanged += new System.EventHandler(this.chkKeepActiveTable_CheckedChanged);
			// 
			// chkAutoArrangeTables
			// 
			this.chkAutoArrangeTables.Location = new System.Drawing.Point(24, 70);
			this.chkAutoArrangeTables.Name = "chkAutoArrangeTables";
			this.chkAutoArrangeTables.Size = new System.Drawing.Size(128, 16);
			this.chkAutoArrangeTables.TabIndex = 9;
			this.chkAutoArrangeTables.Text = "Auto arrange tables";
			this.toolTip1.SetToolTip(this.chkAutoArrangeTables, resources.GetString("chkAutoArrangeTables.ToolTip"));
			this.chkAutoArrangeTables.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// chkMoveActiveTable
			// 
			this.chkMoveActiveTable.Location = new System.Drawing.Point(24, 27);
			this.chkMoveActiveTable.Name = "chkMoveActiveTable";
			this.chkMoveActiveTable.Size = new System.Drawing.Size(112, 16);
			this.chkMoveActiveTable.TabIndex = 1;
			this.chkMoveActiveTable.Text = "Move active table";
			this.toolTip1.SetToolTip(this.chkMoveActiveTable, "If checked, the active table will be moved to the active location that you define" +
					" under the \"Areas\" tab, if not, the active table will remain in it\'s position");
			this.chkMoveActiveTable.CheckedChanged += new System.EventHandler(this.chkMoveActiveTable_CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpNonSeatedTable);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.grpActiveTable);
			this.tabPage2.Location = new System.Drawing.Point(4, 40);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(440, 433);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Areas";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// grpNonSeatedTable
			// 
			this.grpNonSeatedTable.Controls.Add(this.numNonSeatedTableQuadrant);
			this.grpNonSeatedTable.Controls.Add(this.label8);
			this.grpNonSeatedTable.Location = new System.Drawing.Point(16, 78);
			this.grpNonSeatedTable.Name = "grpNonSeatedTable";
			this.grpNonSeatedTable.Size = new System.Drawing.Size(408, 56);
			this.grpNonSeatedTable.TabIndex = 4;
			this.grpNonSeatedTable.TabStop = false;
			this.grpNonSeatedTable.Text = "Tables where i\'m not seated / sitting out";
			// 
			// numNonSeatedTableQuadrant
			// 
			this.numNonSeatedTableQuadrant.Location = new System.Drawing.Point(86, 25);
			this.numNonSeatedTableQuadrant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numNonSeatedTableQuadrant.Name = "numNonSeatedTableQuadrant";
			this.numNonSeatedTableQuadrant.ReadOnly = true;
			this.numNonSeatedTableQuadrant.Size = new System.Drawing.Size(40, 20);
			this.numNonSeatedTableQuadrant.TabIndex = 14;
			this.numNonSeatedTableQuadrant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.numNonSeatedTableQuadrant, "The monitor at which the table will be placed");
			this.numNonSeatedTableQuadrant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numNonSeatedTableQuadrant.ValueChanged += new System.EventHandler(this.numNonSeatedTableMonitor_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 21);
			this.label8.TabIndex = 12;
			this.label8.Text = "Quadrant:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnShowAllQuadrants);
			this.groupBox3.Controls.Add(this.btnDeleteQuadrant);
			this.groupBox3.Controls.Add(this.btnShowQuadrant);
			this.groupBox3.Controls.Add(this.btnAddQuadrant);
			this.groupBox3.Controls.Add(this.btnDown);
			this.groupBox3.Controls.Add(this.btnUp);
			this.groupBox3.Controls.Add(this.lstQuadrants);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(16, 140);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(408, 277);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Quadrants";
			// 
			// btnShowAllQuadrants
			// 
			this.btnShowAllQuadrants.Location = new System.Drawing.Point(236, 239);
			this.btnShowAllQuadrants.Name = "btnShowAllQuadrants";
			this.btnShowAllQuadrants.Size = new System.Drawing.Size(116, 23);
			this.btnShowAllQuadrants.TabIndex = 8;
			this.btnShowAllQuadrants.Text = "Show All Quadrants";
			this.btnShowAllQuadrants.UseVisualStyleBackColor = true;
			this.btnShowAllQuadrants.Click += new System.EventHandler(this.btnShowAllQuadrants_Click);
			// 
			// btnDeleteQuadrant
			// 
			this.btnDeleteQuadrant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteQuadrant.BackgroundImage")));
			this.btnDeleteQuadrant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnDeleteQuadrant.Enabled = false;
			this.btnDeleteQuadrant.Location = new System.Drawing.Point(356, 210);
			this.btnDeleteQuadrant.Name = "btnDeleteQuadrant";
			this.btnDeleteQuadrant.Size = new System.Drawing.Size(44, 23);
			this.btnDeleteQuadrant.TabIndex = 7;
			this.btnDeleteQuadrant.UseVisualStyleBackColor = true;
			this.btnDeleteQuadrant.Click += new System.EventHandler(this.btnDeleteQuadrant_Click);
			// 
			// btnShowQuadrant
			// 
			this.btnShowQuadrant.Enabled = false;
			this.btnShowQuadrant.Location = new System.Drawing.Point(132, 239);
			this.btnShowQuadrant.Name = "btnShowQuadrant";
			this.btnShowQuadrant.Size = new System.Drawing.Size(98, 23);
			this.btnShowQuadrant.TabIndex = 6;
			this.btnShowQuadrant.Text = "Show Quadrant";
			this.btnShowQuadrant.UseVisualStyleBackColor = true;
			this.btnShowQuadrant.Click += new System.EventHandler(this.btnShowQuadrant_Click);
			// 
			// btnAddQuadrant
			// 
			this.btnAddQuadrant.Location = new System.Drawing.Point(27, 239);
			this.btnAddQuadrant.Name = "btnAddQuadrant";
			this.btnAddQuadrant.Size = new System.Drawing.Size(99, 23);
			this.btnAddQuadrant.TabIndex = 4;
			this.btnAddQuadrant.Text = "Add Quadrant";
			this.btnAddQuadrant.UseVisualStyleBackColor = true;
			this.btnAddQuadrant.Click += new System.EventHandler(this.btnAddQuadrant_Click);
			// 
			// btnDown
			// 
			this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
			this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnDown.Enabled = false;
			this.btnDown.Location = new System.Drawing.Point(356, 88);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(44, 23);
			this.btnDown.TabIndex = 3;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
			this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnUp.Enabled = false;
			this.btnUp.Location = new System.Drawing.Point(356, 59);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(44, 23);
			this.btnUp.TabIndex = 2;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// lstQuadrants
			// 
			this.lstQuadrants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.name,
            this.x,
            this.y,
            this.width,
            this.height});
			this.lstQuadrants.FullRowSelect = true;
			this.lstQuadrants.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstQuadrants.HideSelection = false;
			this.lstQuadrants.Location = new System.Drawing.Point(27, 42);
			this.lstQuadrants.MultiSelect = false;
			this.lstQuadrants.Name = "lstQuadrants";
			this.lstQuadrants.Size = new System.Drawing.Size(325, 191);
			this.lstQuadrants.TabIndex = 1;
			this.lstQuadrants.UseCompatibleStateImageBehavior = false;
			this.lstQuadrants.View = System.Windows.Forms.View.Details;
			this.lstQuadrants.DoubleClick += new System.EventHandler(this.lstQuadrants_DoubleClick);
			this.lstQuadrants.SelectedIndexChanged += new System.EventHandler(this.lstQuadrants_SelectedIndexChanged);
			// 
			// number
			// 
			this.number.Text = "Number";
			this.number.Width = 49;
			// 
			// name
			// 
			this.name.Text = "Name";
			this.name.Width = 91;
			// 
			// x
			// 
			this.x.Text = "X";
			this.x.Width = 40;
			// 
			// y
			// 
			this.y.Text = "Y";
			this.y.Width = 40;
			// 
			// width
			// 
			this.width.Text = "Width";
			this.width.Width = 50;
			// 
			// height
			// 
			this.height.Text = "Height";
			this.height.Width = 50;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Quadrants:";
			// 
			// grpActiveTable
			// 
			this.grpActiveTable.Controls.Add(this.numActiveTableQuadrant);
			this.grpActiveTable.Controls.Add(this.label2);
			this.grpActiveTable.Location = new System.Drawing.Point(16, 16);
			this.grpActiveTable.Name = "grpActiveTable";
			this.grpActiveTable.Size = new System.Drawing.Size(408, 56);
			this.grpActiveTable.TabIndex = 0;
			this.grpActiveTable.TabStop = false;
			this.grpActiveTable.Text = "Active table";
			// 
			// numActiveTableQuadrant
			// 
			this.numActiveTableQuadrant.Location = new System.Drawing.Point(86, 25);
			this.numActiveTableQuadrant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numActiveTableQuadrant.Name = "numActiveTableQuadrant";
			this.numActiveTableQuadrant.ReadOnly = true;
			this.numActiveTableQuadrant.Size = new System.Drawing.Size(40, 20);
			this.numActiveTableQuadrant.TabIndex = 10;
			this.numActiveTableQuadrant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.numActiveTableQuadrant, "The monitor at which the active table will be placed");
			this.numActiveTableQuadrant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numActiveTableQuadrant.ValueChanged += new System.EventHandler(this.numActiveTableQuadrant_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Quadrant:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.grpKeyControls);
			this.tabPage3.Location = new System.Drawing.Point(4, 40);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(440, 433);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Keyboard Controls";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// grpKeyControls
			// 
			this.grpKeyControls.Controls.Add(this.chkToggleActiveTableTopmostRequireShift);
			this.grpKeyControls.Controls.Add(this.lstToggleForceActiveTableTopmostKey);
			this.grpKeyControls.Controls.Add(this.label10);
			this.grpKeyControls.Controls.Add(this.chkToggleLobbyRequireShift);
			this.grpKeyControls.Controls.Add(this.lstToggleLobbyKey);
			this.grpKeyControls.Controls.Add(this.label9);
			this.grpKeyControls.Controls.Add(this.lstSNGOpenerKey);
			this.grpKeyControls.Controls.Add(this.chkSNGOpenerRequireShift);
			this.grpKeyControls.Controls.Add(this.label4);
			this.grpKeyControls.Controls.Add(this.lstRearrangeTablesKey);
			this.grpKeyControls.Controls.Add(this.chkRearrangeTablesRequireShift);
			this.grpKeyControls.Controls.Add(this.label52);
			this.grpKeyControls.Controls.Add(this.lstMoveCursorToActiveTableKey);
			this.grpKeyControls.Controls.Add(this.chkMoveCursorToActiveTableRequireShift);
			this.grpKeyControls.Controls.Add(this.label21);
			this.grpKeyControls.Controls.Add(this.lstAutoPushKey);
			this.grpKeyControls.Controls.Add(this.chkAutoPushRequireShift);
			this.grpKeyControls.Controls.Add(this.label16);
			this.grpKeyControls.Controls.Add(this.checkBox17);
			this.grpKeyControls.Controls.Add(this.label7);
			this.grpKeyControls.Controls.Add(this.lstFoldKey);
			this.grpKeyControls.Controls.Add(this.chkFoldRequireShift);
			this.grpKeyControls.Controls.Add(this.label19);
			this.grpKeyControls.Controls.Add(this.lstCheckCallKey);
			this.grpKeyControls.Controls.Add(this.chkCheckCallRequireShift);
			this.grpKeyControls.Controls.Add(this.label18);
			this.grpKeyControls.Controls.Add(this.lstBetRaiseKey);
			this.grpKeyControls.Controls.Add(this.chkBetRaiseRequireShift);
			this.grpKeyControls.Controls.Add(this.label14);
			this.grpKeyControls.Controls.Add(this.label11);
			this.grpKeyControls.Controls.Add(this.label6);
			this.grpKeyControls.Controls.Add(this.label5);
			this.grpKeyControls.Location = new System.Drawing.Point(16, 16);
			this.grpKeyControls.Name = "grpKeyControls";
			this.grpKeyControls.Size = new System.Drawing.Size(408, 314);
			this.grpKeyControls.TabIndex = 6;
			this.grpKeyControls.TabStop = false;
			this.grpKeyControls.Text = "Define controls";
			this.grpKeyControls.Enter += new System.EventHandler(this.grpKeyControls_Enter);
			// 
			// chkToggleActiveTableTopmostRequireShift
			// 
			this.chkToggleActiveTableTopmostRequireShift.Location = new System.Drawing.Point(215, 273);
			this.chkToggleActiveTableTopmostRequireShift.Name = "chkToggleActiveTableTopmostRequireShift";
			this.chkToggleActiveTableTopmostRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkToggleActiveTableTopmostRequireShift.TabIndex = 33;
			this.chkToggleActiveTableTopmostRequireShift.Tag = "ToggleActiveTableTopmostRequireShift";
			this.chkToggleActiveTableTopmostRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// lstToggleForceActiveTableTopmostKey
			// 
			this.lstToggleForceActiveTableTopmostKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstToggleForceActiveTableTopmostKey.Location = new System.Drawing.Point(296, 271);
			this.lstToggleForceActiveTableTopmostKey.Name = "lstToggleForceActiveTableTopmostKey";
			this.lstToggleForceActiveTableTopmostKey.Size = new System.Drawing.Size(96, 21);
			this.lstToggleForceActiveTableTopmostKey.TabIndex = 34;
			this.lstToggleForceActiveTableTopmostKey.Tag = "ToggleForceActiveTableTopmostKey";
			this.lstToggleForceActiveTableTopmostKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(24, 273);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(185, 16);
			this.label10.TabIndex = 32;
			this.label10.Text = "Force the active table to be topmost";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkToggleLobbyRequireShift
			// 
			this.chkToggleLobbyRequireShift.Location = new System.Drawing.Point(215, 249);
			this.chkToggleLobbyRequireShift.Name = "chkToggleLobbyRequireShift";
			this.chkToggleLobbyRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkToggleLobbyRequireShift.TabIndex = 30;
			this.chkToggleLobbyRequireShift.Tag = "ToggleLobbyRequireShift";
			this.chkToggleLobbyRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// lstToggleLobbyKey
			// 
			this.lstToggleLobbyKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstToggleLobbyKey.Location = new System.Drawing.Point(296, 247);
			this.lstToggleLobbyKey.Name = "lstToggleLobbyKey";
			this.lstToggleLobbyKey.Size = new System.Drawing.Size(96, 21);
			this.lstToggleLobbyKey.TabIndex = 31;
			this.lstToggleLobbyKey.Tag = "ToggleLobbyKey";
			this.lstToggleLobbyKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(24, 249);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(232, 16);
			this.label9.TabIndex = 29;
			this.label9.Text = "Toggle keep lobby minimized/open";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label9, "Clicks the \"Wait for BB\" button");
			// 
			// lstSNGOpenerKey
			// 
			this.lstSNGOpenerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstSNGOpenerKey.Location = new System.Drawing.Point(296, 224);
			this.lstSNGOpenerKey.Name = "lstSNGOpenerKey";
			this.lstSNGOpenerKey.Size = new System.Drawing.Size(96, 21);
			this.lstSNGOpenerKey.TabIndex = 28;
			this.lstSNGOpenerKey.Tag = "SNGOpenerKey";
			this.lstSNGOpenerKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkSNGOpenerRequireShift
			// 
			this.chkSNGOpenerRequireShift.Location = new System.Drawing.Point(215, 225);
			this.chkSNGOpenerRequireShift.Name = "chkSNGOpenerRequireShift";
			this.chkSNGOpenerRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkSNGOpenerRequireShift.TabIndex = 27;
			this.chkSNGOpenerRequireShift.Tag = "SNGOpenerRequireShift";
			this.chkSNGOpenerRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(24, 225);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(144, 16);
			this.label4.TabIndex = 26;
			this.label4.Text = "SNG Opener";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label4, "Clicks the \"Wait for BB\" button");
			// 
			// lstRearrangeTablesKey
			// 
			this.lstRearrangeTablesKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstRearrangeTablesKey.Location = new System.Drawing.Point(296, 200);
			this.lstRearrangeTablesKey.Name = "lstRearrangeTablesKey";
			this.lstRearrangeTablesKey.Size = new System.Drawing.Size(96, 21);
			this.lstRearrangeTablesKey.TabIndex = 25;
			this.lstRearrangeTablesKey.Tag = "RearrangeTablesKey";
			this.lstRearrangeTablesKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkRearrangeTablesRequireShift
			// 
			this.chkRearrangeTablesRequireShift.Location = new System.Drawing.Point(215, 202);
			this.chkRearrangeTablesRequireShift.Name = "chkRearrangeTablesRequireShift";
			this.chkRearrangeTablesRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkRearrangeTablesRequireShift.TabIndex = 24;
			this.chkRearrangeTablesRequireShift.Tag = "RearrangeTablesRequireShift";
			this.chkRearrangeTablesRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label52
			// 
			this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label52.Location = new System.Drawing.Point(24, 201);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(144, 16);
			this.label52.TabIndex = 23;
			this.label52.Text = "Rearrange tables";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label52, "Clicks the \"Wait for BB\" button");
			// 
			// lstMoveCursorToActiveTableKey
			// 
			this.lstMoveCursorToActiveTableKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstMoveCursorToActiveTableKey.Location = new System.Drawing.Point(296, 176);
			this.lstMoveCursorToActiveTableKey.Name = "lstMoveCursorToActiveTableKey";
			this.lstMoveCursorToActiveTableKey.Size = new System.Drawing.Size(96, 21);
			this.lstMoveCursorToActiveTableKey.TabIndex = 22;
			this.lstMoveCursorToActiveTableKey.Tag = "MoveCursorToActiveTableKey";
			this.lstMoveCursorToActiveTableKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkMoveCursorToActiveTableRequireShift
			// 
			this.chkMoveCursorToActiveTableRequireShift.Location = new System.Drawing.Point(215, 176);
			this.chkMoveCursorToActiveTableRequireShift.Name = "chkMoveCursorToActiveTableRequireShift";
			this.chkMoveCursorToActiveTableRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkMoveCursorToActiveTableRequireShift.TabIndex = 21;
			this.chkMoveCursorToActiveTableRequireShift.Tag = "MoveCursorToActiveTableRequireShift";
			this.chkMoveCursorToActiveTableRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.Location = new System.Drawing.Point(24, 176);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(144, 16);
			this.label21.TabIndex = 20;
			this.label21.Text = "Move cursor to active table";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label21, "Automatically bets an amount of \"9.999.999\" and then clicks the \"Raise\" button");
			// 
			// lstAutoPushKey
			// 
			this.lstAutoPushKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstAutoPushKey.Location = new System.Drawing.Point(296, 152);
			this.lstAutoPushKey.Name = "lstAutoPushKey";
			this.lstAutoPushKey.Size = new System.Drawing.Size(96, 21);
			this.lstAutoPushKey.TabIndex = 19;
			this.lstAutoPushKey.Tag = "AutoPushKey";
			this.lstAutoPushKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkAutoPushRequireShift
			// 
			this.chkAutoPushRequireShift.Location = new System.Drawing.Point(215, 152);
			this.chkAutoPushRequireShift.Name = "chkAutoPushRequireShift";
			this.chkAutoPushRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkAutoPushRequireShift.TabIndex = 18;
			this.chkAutoPushRequireShift.Tag = "AutoPushRequireShift";
			this.chkAutoPushRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(24, 152);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(144, 16);
			this.label16.TabIndex = 17;
			this.label16.Text = "Push all-in";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label16, "Automatically bets an amount of \"9.999.999\" and then clicks the \"Raise\" button");
			// 
			// checkBox17
			// 
			this.checkBox17.Location = new System.Drawing.Point(215, 48);
			this.checkBox17.Name = "checkBox17";
			this.checkBox17.Size = new System.Drawing.Size(16, 16);
			this.checkBox17.TabIndex = 16;
			this.checkBox17.Tag = "BetRaiseRequireShift";
			this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(24, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(144, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "All";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstFoldKey
			// 
			this.lstFoldKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstFoldKey.Location = new System.Drawing.Point(296, 128);
			this.lstFoldKey.Name = "lstFoldKey";
			this.lstFoldKey.Size = new System.Drawing.Size(96, 21);
			this.lstFoldKey.TabIndex = 11;
			this.lstFoldKey.Tag = "FoldKey";
			this.lstFoldKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkFoldRequireShift
			// 
			this.chkFoldRequireShift.Location = new System.Drawing.Point(215, 128);
			this.chkFoldRequireShift.Name = "chkFoldRequireShift";
			this.chkFoldRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkFoldRequireShift.TabIndex = 10;
			this.chkFoldRequireShift.Tag = "FoldRequireShift";
			this.chkFoldRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(24, 128);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(144, 16);
			this.label19.TabIndex = 9;
			this.label19.Text = "Left button";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label19, "Clicks the \"Fold\" button");
			// 
			// lstCheckCallKey
			// 
			this.lstCheckCallKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstCheckCallKey.Location = new System.Drawing.Point(296, 104);
			this.lstCheckCallKey.Name = "lstCheckCallKey";
			this.lstCheckCallKey.Size = new System.Drawing.Size(96, 21);
			this.lstCheckCallKey.TabIndex = 8;
			this.lstCheckCallKey.Tag = "CheckCallKey";
			this.lstCheckCallKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkCheckCallRequireShift
			// 
			this.chkCheckCallRequireShift.Location = new System.Drawing.Point(215, 104);
			this.chkCheckCallRequireShift.Name = "chkCheckCallRequireShift";
			this.chkCheckCallRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkCheckCallRequireShift.TabIndex = 7;
			this.chkCheckCallRequireShift.Tag = "CheckCallRequireShift";
			this.chkCheckCallRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(24, 104);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(144, 16);
			this.label18.TabIndex = 6;
			this.label18.Text = "Center button";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label18, "Clicks the \"Check\" / \"Call\" button");
			// 
			// lstBetRaiseKey
			// 
			this.lstBetRaiseKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstBetRaiseKey.Location = new System.Drawing.Point(296, 80);
			this.lstBetRaiseKey.Name = "lstBetRaiseKey";
			this.lstBetRaiseKey.Size = new System.Drawing.Size(96, 21);
			this.lstBetRaiseKey.TabIndex = 5;
			this.lstBetRaiseKey.Tag = "BetRaiseKey";
			this.lstBetRaiseKey.SelectedIndexChanged += new System.EventHandler(this.lstBetRaiseKey_SelectedIndexChanged_1);
			// 
			// chkBetRaiseRequireShift
			// 
			this.chkBetRaiseRequireShift.Location = new System.Drawing.Point(215, 80);
			this.chkBetRaiseRequireShift.Name = "chkBetRaiseRequireShift";
			this.chkBetRaiseRequireShift.Size = new System.Drawing.Size(16, 16);
			this.chkBetRaiseRequireShift.TabIndex = 4;
			this.chkBetRaiseRequireShift.Tag = "BetRaiseRequireShift";
			this.chkBetRaiseRequireShift.CheckedChanged += new System.EventHandler(this.chkBetRaiseRequireShift_CheckedChanged_1);
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.Black;
			this.label14.Location = new System.Drawing.Point(24, 80);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(144, 16);
			this.label14.TabIndex = 3;
			this.label14.Text = "Right button";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.label14, "Clicks the \"Bet\" / \"Raise\" button");
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(296, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "Key";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(191, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Require shift";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(24, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Command";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.linkLabel1);
			this.tabPage8.Controls.Add(this.button2);
			this.tabPage8.Controls.Add(this.label35);
			this.tabPage8.Controls.Add(this.label34);
			this.tabPage8.Controls.Add(this.txtPreset3Amount);
			this.tabPage8.Controls.Add(this.txtPreset3);
			this.tabPage8.Controls.Add(this.txtPreset2Amount);
			this.tabPage8.Controls.Add(this.txtPreset2);
			this.tabPage8.Controls.Add(this.txtPreset1Amount);
			this.tabPage8.Controls.Add(this.txtPreset1);
			this.tabPage8.Controls.Add(this.label32);
			this.tabPage8.Controls.Add(this.label33);
			this.tabPage8.Controls.Add(this.label31);
			this.tabPage8.Controls.Add(this.label30);
			this.tabPage8.Controls.Add(this.label29);
			this.tabPage8.Controls.Add(this.label28);
			this.tabPage8.Controls.Add(this.label27);
			this.tabPage8.Controls.Add(this.label26);
			this.tabPage8.Controls.Add(this.label25);
			this.tabPage8.Controls.Add(this.label24);
			this.tabPage8.Controls.Add(this.label23);
			this.tabPage8.Controls.Add(this.label22);
			this.tabPage8.Location = new System.Drawing.Point(4, 40);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(440, 433);
			this.tabPage8.TabIndex = 3;
			this.tabPage8.Text = "Voice Commands";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(12, 87);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(412, 29);
			this.linkLabel1.TabIndex = 22;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "It is highly recommended that you run the Speech Training in the Speech Control p" +
				"anel. Training this way makes the system much more accurate in recognizing your " +
				"voice commands.";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(15, 388);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(409, 26);
			this.button2.TabIndex = 21;
			this.button2.Text = "Click here to start a test of the voice command recognition";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(174, 225);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(132, 13);
			this.label35.TabIndex = 19;
			this.label35.Text = "Clears the bet amount field";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(12, 225);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(31, 13);
			this.label34.TabIndex = 18;
			this.label34.Text = "Clear";
			// 
			// txtPreset3Amount
			// 
			this.txtPreset3Amount.Location = new System.Drawing.Point(177, 344);
			this.txtPreset3Amount.Name = "txtPreset3Amount";
			this.txtPreset3Amount.Size = new System.Drawing.Size(100, 20);
			this.txtPreset3Amount.TabIndex = 17;
			this.txtPreset3Amount.TextChanged += new System.EventHandler(this.txtPreset3Amount_TextChanged);
			// 
			// txtPreset3
			// 
			this.txtPreset3.Location = new System.Drawing.Point(15, 344);
			this.txtPreset3.Name = "txtPreset3";
			this.txtPreset3.Size = new System.Drawing.Size(121, 20);
			this.txtPreset3.TabIndex = 16;
			this.txtPreset3.TextChanged += new System.EventHandler(this.txtPreset3_TextChanged);
			// 
			// txtPreset2Amount
			// 
			this.txtPreset2Amount.Location = new System.Drawing.Point(177, 318);
			this.txtPreset2Amount.Name = "txtPreset2Amount";
			this.txtPreset2Amount.Size = new System.Drawing.Size(100, 20);
			this.txtPreset2Amount.TabIndex = 15;
			this.txtPreset2Amount.TextChanged += new System.EventHandler(this.txtPreset2Amount_TextChanged);
			// 
			// txtPreset2
			// 
			this.txtPreset2.Location = new System.Drawing.Point(15, 318);
			this.txtPreset2.Name = "txtPreset2";
			this.txtPreset2.Size = new System.Drawing.Size(121, 20);
			this.txtPreset2.TabIndex = 14;
			this.txtPreset2.TextChanged += new System.EventHandler(this.txtPreset2_TextChanged);
			// 
			// txtPreset1Amount
			// 
			this.txtPreset1Amount.Location = new System.Drawing.Point(177, 292);
			this.txtPreset1Amount.Name = "txtPreset1Amount";
			this.txtPreset1Amount.Size = new System.Drawing.Size(100, 20);
			this.txtPreset1Amount.TabIndex = 13;
			this.txtPreset1Amount.TextChanged += new System.EventHandler(this.txtPreset1Amount_TextChanged);
			// 
			// txtPreset1
			// 
			this.txtPreset1.Location = new System.Drawing.Point(15, 292);
			this.txtPreset1.Name = "txtPreset1";
			this.txtPreset1.Size = new System.Drawing.Size(121, 20);
			this.txtPreset1.TabIndex = 12;
			this.txtPreset1.TextChanged += new System.EventHandler(this.txtPreset1_TextChanged);
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.Location = new System.Drawing.Point(174, 263);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(82, 17);
			this.label32.TabIndex = 11;
			this.label32.Text = "Bet Amount";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.Location = new System.Drawing.Point(12, 263);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(103, 17);
			this.label33.TabIndex = 10;
			this.label33.Text = "Preset Command";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(174, 175);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(106, 13);
			this.label31.TabIndex = 9;
			this.label31.Text = "Clicks the fold button";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(174, 200);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(146, 13);
			this.label30.TabIndex = 8;
			this.label30.Text = "Clicks the check / call button";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(174, 150);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(137, 13);
			this.label29.TabIndex = 7;
			this.label29.Text = "Clicks the bet / raise button";
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.Location = new System.Drawing.Point(174, 124);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(82, 16);
			this.label28.TabIndex = 6;
			this.label28.Text = "Description";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(12, 175);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(27, 13);
			this.label27.TabIndex = 5;
			this.label27.Text = "Fold";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(12, 200);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(66, 13);
			this.label26.TabIndex = 4;
			this.label26.Text = "Check / Call";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(12, 150);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(61, 13);
			this.label25.TabIndex = 3;
			this.label25.Text = "Bet / Raise";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.Location = new System.Drawing.Point(12, 124);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 2;
			this.label24.Text = "Command";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(12, 42);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(412, 43);
			this.label23.TabIndex = 1;
			this.label23.Text = resources.GetString("label23.Text");
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(12, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(188, 13);
			this.label22.TabIndex = 0;
			this.label22.Text = "How do Voice Commands work?";
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.grpBorderColors);
			this.tabPage10.Controls.Add(this.groupBox1);
			this.tabPage10.Location = new System.Drawing.Point(4, 40);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(440, 433);
			this.tabPage10.TabIndex = 5;
			this.tabPage10.Text = "Border";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// grpBorderColors
			// 
			this.grpBorderColors.Controls.Add(this.blindLevel10Color);
			this.grpBorderColors.Controls.Add(this.label46);
			this.grpBorderColors.Controls.Add(this.blindLevel9Color);
			this.grpBorderColors.Controls.Add(this.blindLevel8Color);
			this.grpBorderColors.Controls.Add(this.blindLevel7Color);
			this.grpBorderColors.Controls.Add(this.blindLevel6Color);
			this.grpBorderColors.Controls.Add(this.blindLevel5Color);
			this.grpBorderColors.Controls.Add(this.blindLevel4Color);
			this.grpBorderColors.Controls.Add(this.blindLevel3Color);
			this.grpBorderColors.Controls.Add(this.blindLevel2Color);
			this.grpBorderColors.Controls.Add(this.blindLevel1Color);
			this.grpBorderColors.Controls.Add(this.label45);
			this.grpBorderColors.Controls.Add(this.label44);
			this.grpBorderColors.Controls.Add(this.label43);
			this.grpBorderColors.Controls.Add(this.label42);
			this.grpBorderColors.Controls.Add(this.label41);
			this.grpBorderColors.Controls.Add(this.label40);
			this.grpBorderColors.Controls.Add(this.label39);
			this.grpBorderColors.Controls.Add(this.label38);
			this.grpBorderColors.Controls.Add(this.label37);
			this.grpBorderColors.Controls.Add(this.label36);
			this.grpBorderColors.Location = new System.Drawing.Point(16, 110);
			this.grpBorderColors.Name = "grpBorderColors";
			this.grpBorderColors.Size = new System.Drawing.Size(408, 305);
			this.grpBorderColors.TabIndex = 2;
			this.grpBorderColors.TabStop = false;
			this.grpBorderColors.Text = "Colors";
			// 
			// blindLevel10Color
			// 
			this.blindLevel10Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel10Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel10Color.Location = new System.Drawing.Point(92, 277);
			this.blindLevel10Color.Name = "blindLevel10Color";
			this.blindLevel10Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel10Color.TabIndex = 30;
			this.blindLevel10Color.TabStop = false;
			this.blindLevel10Color.Tag = "BlindLevel10Color";
			this.blindLevel10Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(21, 277);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(51, 13);
			this.label46.TabIndex = 29;
			this.label46.Text = "Level 10:";
			// 
			// blindLevel9Color
			// 
			this.blindLevel9Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel9Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel9Color.Location = new System.Drawing.Point(92, 255);
			this.blindLevel9Color.Name = "blindLevel9Color";
			this.blindLevel9Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel9Color.TabIndex = 28;
			this.blindLevel9Color.TabStop = false;
			this.blindLevel9Color.Tag = "BlindLevel9Color";
			this.blindLevel9Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel8Color
			// 
			this.blindLevel8Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel8Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel8Color.Location = new System.Drawing.Point(92, 233);
			this.blindLevel8Color.Name = "blindLevel8Color";
			this.blindLevel8Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel8Color.TabIndex = 27;
			this.blindLevel8Color.TabStop = false;
			this.blindLevel8Color.Tag = "BlindLevel8Color";
			this.blindLevel8Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel7Color
			// 
			this.blindLevel7Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel7Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel7Color.Location = new System.Drawing.Point(92, 211);
			this.blindLevel7Color.Name = "blindLevel7Color";
			this.blindLevel7Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel7Color.TabIndex = 26;
			this.blindLevel7Color.TabStop = false;
			this.blindLevel7Color.Tag = "BlindLevel7Color";
			this.blindLevel7Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel6Color
			// 
			this.blindLevel6Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel6Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel6Color.Location = new System.Drawing.Point(92, 189);
			this.blindLevel6Color.Name = "blindLevel6Color";
			this.blindLevel6Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel6Color.TabIndex = 25;
			this.blindLevel6Color.TabStop = false;
			this.blindLevel6Color.Tag = "BlindLevel6Color";
			this.blindLevel6Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel5Color
			// 
			this.blindLevel5Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel5Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel5Color.Location = new System.Drawing.Point(92, 167);
			this.blindLevel5Color.Name = "blindLevel5Color";
			this.blindLevel5Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel5Color.TabIndex = 24;
			this.blindLevel5Color.TabStop = false;
			this.blindLevel5Color.Tag = "BlindLevel5Color";
			this.blindLevel5Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel4Color
			// 
			this.blindLevel4Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel4Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel4Color.Location = new System.Drawing.Point(92, 145);
			this.blindLevel4Color.Name = "blindLevel4Color";
			this.blindLevel4Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel4Color.TabIndex = 23;
			this.blindLevel4Color.TabStop = false;
			this.blindLevel4Color.Tag = "BlindLevel4Color";
			this.blindLevel4Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel3Color
			// 
			this.blindLevel3Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel3Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel3Color.Location = new System.Drawing.Point(92, 123);
			this.blindLevel3Color.Name = "blindLevel3Color";
			this.blindLevel3Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel3Color.TabIndex = 22;
			this.blindLevel3Color.TabStop = false;
			this.blindLevel3Color.Tag = "BlindLevel3Color";
			this.blindLevel3Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel2Color
			// 
			this.blindLevel2Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel2Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel2Color.Location = new System.Drawing.Point(92, 101);
			this.blindLevel2Color.Name = "blindLevel2Color";
			this.blindLevel2Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel2Color.TabIndex = 21;
			this.blindLevel2Color.TabStop = false;
			this.blindLevel2Color.Tag = "BlindLevel2Color";
			this.blindLevel2Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// blindLevel1Color
			// 
			this.blindLevel1Color.BackColor = System.Drawing.SystemColors.Control;
			this.blindLevel1Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.blindLevel1Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blindLevel1Color.Location = new System.Drawing.Point(92, 80);
			this.blindLevel1Color.Name = "blindLevel1Color";
			this.blindLevel1Color.Size = new System.Drawing.Size(100, 13);
			this.blindLevel1Color.TabIndex = 20;
			this.blindLevel1Color.TabStop = false;
			this.blindLevel1Color.Tag = "BlindLevel1Color";
			this.blindLevel1Color.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(21, 255);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(45, 13);
			this.label45.TabIndex = 9;
			this.label45.Text = "Level 9:";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(21, 233);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(45, 13);
			this.label44.TabIndex = 8;
			this.label44.Text = "Level 8:";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(21, 211);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(45, 13);
			this.label43.TabIndex = 7;
			this.label43.Text = "Level 7:";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(21, 189);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(45, 13);
			this.label42.TabIndex = 6;
			this.label42.Text = "Level 6:";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(21, 167);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(45, 13);
			this.label41.TabIndex = 5;
			this.label41.Text = "Level 5:";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(21, 145);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(45, 13);
			this.label40.TabIndex = 4;
			this.label40.Text = "Level 4:";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(21, 123);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(45, 13);
			this.label39.TabIndex = 3;
			this.label39.Text = "Level 3:";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(21, 101);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(45, 13);
			this.label38.TabIndex = 2;
			this.label38.Text = "Level 2:";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(21, 80);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(45, 13);
			this.label37.TabIndex = 1;
			this.label37.Text = "Level 1:";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(21, 25);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(371, 44);
			this.label36.TabIndex = 0;
			this.label36.Text = "For SNG\'s and MTT\'s, MTH can make a border color depending on the blind level, yo" +
				"u can define those colors here. For cash games, MTH will use the default color i" +
				"n the top of this dialog.";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pbBorderColor);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.nmActiveTableBorderWidth);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.chkFlashTable);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.chkUseBorder);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 88);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Border";
			// 
			// pbBorderColor
			// 
			this.pbBorderColor.BackColor = System.Drawing.SystemColors.Control;
			this.pbBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbBorderColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbBorderColor.Location = new System.Drawing.Point(278, 24);
			this.pbBorderColor.Name = "pbBorderColor";
			this.pbBorderColor.Size = new System.Drawing.Size(100, 20);
			this.pbBorderColor.TabIndex = 31;
			this.pbBorderColor.TabStop = false;
			this.pbBorderColor.Tag = "BlindLevel1Color";
			this.toolTip1.SetToolTip(this.pbBorderColor, "Click to select the standard border color");
			this.pbBorderColor.Click += new System.EventHandler(this.pictureBox1_Click_1);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(328, 56);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(40, 21);
			this.label20.TabIndex = 6;
			this.label20.Text = "px";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nmActiveTableBorderWidth
			// 
			this.nmActiveTableBorderWidth.Location = new System.Drawing.Point(280, 56);
			this.nmActiveTableBorderWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nmActiveTableBorderWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nmActiveTableBorderWidth.Name = "nmActiveTableBorderWidth";
			this.nmActiveTableBorderWidth.ReadOnly = true;
			this.nmActiveTableBorderWidth.Size = new System.Drawing.Size(40, 20);
			this.nmActiveTableBorderWidth.TabIndex = 5;
			this.nmActiveTableBorderWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.nmActiveTableBorderWidth, "The width on the active table border");
			this.nmActiveTableBorderWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nmActiveTableBorderWidth.ValueChanged += new System.EventHandler(this.nmActiveTableBorderWidth_ValueChanged);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(232, 56);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(40, 21);
			this.label17.TabIndex = 4;
			this.label17.Text = "Width:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkFlashTable
			// 
			this.chkFlashTable.Location = new System.Drawing.Point(24, 56);
			this.chkFlashTable.Name = "chkFlashTable";
			this.chkFlashTable.Size = new System.Drawing.Size(168, 16);
			this.chkFlashTable.TabIndex = 3;
			this.chkFlashTable.Text = "Flash table when it activates";
			this.toolTip1.SetToolTip(this.chkFlashTable, "If checked, MTH will flash the border of the active table, making it easier to sp" +
					"ot");
			this.chkFlashTable.CheckedChanged += new System.EventHandler(this.chkFlashTable_CheckedChanged_1);
			// 
			// label1
			// 
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(232, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Color:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkUseBorder
			// 
			this.chkUseBorder.Location = new System.Drawing.Point(24, 28);
			this.chkUseBorder.Name = "chkUseBorder";
			this.chkUseBorder.Size = new System.Drawing.Size(168, 16);
			this.chkUseBorder.TabIndex = 0;
			this.chkUseBorder.Text = "Mark active table with border";
			this.toolTip1.SetToolTip(this.chkUseBorder, "If checked, the active table will be marked by a colored border");
			this.chkUseBorder.CheckedChanged += new System.EventHandler(this.chkUseBorder_CheckedChanged_1);
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.groupBox9);
			this.tabPage9.Location = new System.Drawing.Point(4, 40);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(440, 433);
			this.tabPage9.TabIndex = 6;
			this.tabPage9.Text = "SNG";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.button4);
			this.groupBox9.Controls.Add(this.button3);
			this.groupBox9.Controls.Add(this.lstSeatPreferences);
			this.groupBox9.Controls.Add(this.label47);
			this.groupBox9.Location = new System.Drawing.Point(15, 13);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(408, 261);
			this.groupBox9.TabIndex = 2;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Seat preferences";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(20, 132);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 50);
			this.button4.TabIndex = 3;
			this.button4.Text = "Down";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(20, 77);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 49);
			this.button3.TabIndex = 2;
			this.button3.Text = "Up";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// lstSeatPreferences
			// 
			this.lstSeatPreferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lstSeatPreferences.FullRowSelect = true;
			this.lstSeatPreferences.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstSeatPreferences.HideSelection = false;
			this.lstSeatPreferences.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
			this.lstSeatPreferences.Location = new System.Drawing.Point(101, 58);
			this.lstSeatPreferences.MultiSelect = false;
			this.lstSeatPreferences.Name = "lstSeatPreferences";
			this.lstSeatPreferences.Size = new System.Drawing.Size(271, 186);
			this.lstSeatPreferences.TabIndex = 1;
			this.lstSeatPreferences.UseCompatibleStateImageBehavior = false;
			this.lstSeatPreferences.View = System.Windows.Forms.View.Details;
			this.lstSeatPreferences.SelectedIndexChanged += new System.EventHandler(this.lstSeatPreferences_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Seat";
			this.columnHeader1.Width = 267;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(17, 27);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(385, 28);
			this.label47.TabIndex = 0;
			this.label47.Text = "When using the SNG Opener, MTH will attempt to take seats in the order specified " +
				"below.";
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.groupBox10);
			this.tabPage11.Controls.Add(this.label48);
			this.tabPage11.Location = new System.Drawing.Point(4, 40);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new System.Drawing.Size(440, 433);
			this.tabPage11.TabIndex = 7;
			this.tabPage11.Text = "Table Identification";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.label50);
			this.groupBox10.Controls.Add(this.numTableIdentificationCompleteBorderWidth);
			this.groupBox10.Controls.Add(this.label51);
			this.groupBox10.Controls.Add(this.rdbColorIdentificationCompleteBorder);
			this.groupBox10.Controls.Add(this.chkUseColorIdentification);
			this.groupBox10.Controls.Add(this.rdbColorIdentificationMedium);
			this.groupBox10.Controls.Add(this.rdbColorIdentificationLarge);
			this.groupBox10.Controls.Add(this.rdbColorIdentificationSmall);
			this.groupBox10.Controls.Add(this.label49);
			this.groupBox10.Location = new System.Drawing.Point(15, 61);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(409, 127);
			this.groupBox10.TabIndex = 5;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Color";
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(373, 100);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(27, 21);
			this.label50.TabIndex = 9;
			this.label50.Text = "px";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTableIdentificationCompleteBorderWidth
			// 
			this.numTableIdentificationCompleteBorderWidth.Location = new System.Drawing.Point(325, 100);
			this.numTableIdentificationCompleteBorderWidth.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.numTableIdentificationCompleteBorderWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numTableIdentificationCompleteBorderWidth.Name = "numTableIdentificationCompleteBorderWidth";
			this.numTableIdentificationCompleteBorderWidth.ReadOnly = true;
			this.numTableIdentificationCompleteBorderWidth.Size = new System.Drawing.Size(40, 20);
			this.numTableIdentificationCompleteBorderWidth.TabIndex = 8;
			this.numTableIdentificationCompleteBorderWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.numTableIdentificationCompleteBorderWidth, "The width on the active table border");
			this.numTableIdentificationCompleteBorderWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numTableIdentificationCompleteBorderWidth.ValueChanged += new System.EventHandler(this.numTableIdentificationCompleteBorderWidth_ValueChanged);
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(277, 100);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(40, 21);
			this.label51.TabIndex = 7;
			this.label51.Text = "Width:";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rdbColorIdentificationCompleteBorder
			// 
			this.rdbColorIdentificationCompleteBorder.AutoSize = true;
			this.rdbColorIdentificationCompleteBorder.Location = new System.Drawing.Point(158, 102);
			this.rdbColorIdentificationCompleteBorder.Name = "rdbColorIdentificationCompleteBorder";
			this.rdbColorIdentificationCompleteBorder.Size = new System.Drawing.Size(102, 17);
			this.rdbColorIdentificationCompleteBorder.TabIndex = 6;
			this.rdbColorIdentificationCompleteBorder.TabStop = true;
			this.rdbColorIdentificationCompleteBorder.Text = "Complete border";
			this.toolTip1.SetToolTip(this.rdbColorIdentificationCompleteBorder, "Will make a border around the window in a unique color");
			this.rdbColorIdentificationCompleteBorder.UseVisualStyleBackColor = true;
			this.rdbColorIdentificationCompleteBorder.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
			// 
			// chkUseColorIdentification
			// 
			this.chkUseColorIdentification.AutoSize = true;
			this.chkUseColorIdentification.Location = new System.Drawing.Point(19, 68);
			this.chkUseColorIdentification.Name = "chkUseColorIdentification";
			this.chkUseColorIdentification.Size = new System.Drawing.Size(133, 17);
			this.chkUseColorIdentification.TabIndex = 5;
			this.chkUseColorIdentification.Text = "Use color identification";
			this.toolTip1.SetToolTip(this.chkUseColorIdentification, "If checked, the title bar will be covered with a colored box");
			this.chkUseColorIdentification.UseVisualStyleBackColor = true;
			this.chkUseColorIdentification.CheckedChanged += new System.EventHandler(this.chkUseColorIdentification_CheckedChanged);
			// 
			// rdbColorIdentificationMedium
			// 
			this.rdbColorIdentificationMedium.AutoSize = true;
			this.rdbColorIdentificationMedium.Location = new System.Drawing.Point(158, 70);
			this.rdbColorIdentificationMedium.Name = "rdbColorIdentificationMedium";
			this.rdbColorIdentificationMedium.Size = new System.Drawing.Size(62, 17);
			this.rdbColorIdentificationMedium.TabIndex = 4;
			this.rdbColorIdentificationMedium.TabStop = true;
			this.rdbColorIdentificationMedium.Text = "Medium";
			this.toolTip1.SetToolTip(this.rdbColorIdentificationMedium, "Will cover the left part of the title bar, about 100 pixels wide");
			this.rdbColorIdentificationMedium.UseVisualStyleBackColor = true;
			this.rdbColorIdentificationMedium.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// rdbColorIdentificationLarge
			// 
			this.rdbColorIdentificationLarge.AutoSize = true;
			this.rdbColorIdentificationLarge.Location = new System.Drawing.Point(158, 86);
			this.rdbColorIdentificationLarge.Name = "rdbColorIdentificationLarge";
			this.rdbColorIdentificationLarge.Size = new System.Drawing.Size(52, 17);
			this.rdbColorIdentificationLarge.TabIndex = 3;
			this.rdbColorIdentificationLarge.TabStop = true;
			this.rdbColorIdentificationLarge.Text = "Large";
			this.toolTip1.SetToolTip(this.rdbColorIdentificationLarge, "Will cover the whole title bar, you will still be able to move the window");
			this.rdbColorIdentificationLarge.UseVisualStyleBackColor = true;
			this.rdbColorIdentificationLarge.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// rdbColorIdentificationSmall
			// 
			this.rdbColorIdentificationSmall.AutoSize = true;
			this.rdbColorIdentificationSmall.Location = new System.Drawing.Point(158, 53);
			this.rdbColorIdentificationSmall.Name = "rdbColorIdentificationSmall";
			this.rdbColorIdentificationSmall.Size = new System.Drawing.Size(50, 17);
			this.rdbColorIdentificationSmall.TabIndex = 2;
			this.rdbColorIdentificationSmall.TabStop = true;
			this.rdbColorIdentificationSmall.Text = "Small";
			this.toolTip1.SetToolTip(this.rdbColorIdentificationSmall, "If selected, the colored box will only cover the left most icon area of the title" +
					" bar");
			this.rdbColorIdentificationSmall.UseVisualStyleBackColor = true;
			this.rdbColorIdentificationSmall.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(14, 21);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(376, 29);
			this.label49.TabIndex = 0;
			this.label49.Text = "Color identification will put a uniquely colored box in the title bar of the poke" +
				"r table";
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(12, 13);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(422, 32);
			this.label48.TabIndex = 0;
			this.label48.Text = "To make identification of poker tables easier, MTH can identify the tables with a" +
				" color / number / letter code.";
			// 
			// tabPage12
			// 
			this.tabPage12.Controls.Add(this.groupBox11);
			this.tabPage12.Location = new System.Drawing.Point(4, 40);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Size = new System.Drawing.Size(440, 433);
			this.tabPage12.TabIndex = 8;
			this.tabPage12.Text = "Lobby";
			this.tabPage12.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.chkKeepLobbyOpened);
			this.groupBox11.Controls.Add(this.chkKeepLobbyMinimized);
			this.groupBox11.Location = new System.Drawing.Point(16, 16);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(408, 78);
			this.groupBox11.TabIndex = 0;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Lobby";
			// 
			// chkKeepLobbyOpened
			// 
			this.chkKeepLobbyOpened.AutoSize = true;
			this.chkKeepLobbyOpened.Location = new System.Drawing.Point(21, 47);
			this.chkKeepLobbyOpened.Name = "chkKeepLobbyOpened";
			this.chkKeepLobbyOpened.Size = new System.Drawing.Size(170, 17);
			this.chkKeepLobbyOpened.TabIndex = 1;
			this.chkKeepLobbyOpened.Text = "Keep lobby opened at all times";
			this.chkKeepLobbyOpened.UseVisualStyleBackColor = true;
			this.chkKeepLobbyOpened.CheckedChanged += new System.EventHandler(this.chkKeepLobbyOpened_CheckedChanged);
			// 
			// chkKeepLobbyMinimized
			// 
			this.chkKeepLobbyMinimized.AutoSize = true;
			this.chkKeepLobbyMinimized.Location = new System.Drawing.Point(21, 24);
			this.chkKeepLobbyMinimized.Name = "chkKeepLobbyMinimized";
			this.chkKeepLobbyMinimized.Size = new System.Drawing.Size(179, 17);
			this.chkKeepLobbyMinimized.TabIndex = 0;
			this.chkKeepLobbyMinimized.Text = "Keep lobby minimized at all times";
			this.chkKeepLobbyMinimized.UseVisualStyleBackColor = true;
			this.chkKeepLobbyMinimized.CheckedChanged += new System.EventHandler(this.chkKeepLobbyMinimized_CheckedChanged);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.chkClearBetBoxNL);
			this.tabPage4.Controls.Add(this.chkEnableLogging);
			this.tabPage4.Controls.Add(this.chkAutoClickAutoPostBlind);
			this.tabPage4.Controls.Add(this.chkAutoPostBlind);
			this.tabPage4.Controls.Add(this.chkAutoWaitForBB);
			this.tabPage4.Controls.Add(this.chkShowNotification);
			this.tabPage4.Controls.Add(this.chkAutoUpdate);
			this.tabPage4.Location = new System.Drawing.Point(4, 40);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(440, 433);
			this.tabPage4.TabIndex = 9;
			this.tabPage4.Text = "Miscellaneous";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// chkClearBetBoxNL
			// 
			this.chkClearBetBoxNL.AutoSize = true;
			this.chkClearBetBoxNL.Location = new System.Drawing.Point(25, 157);
			this.chkClearBetBoxNL.Name = "chkClearBetBoxNL";
			this.chkClearBetBoxNL.Size = new System.Drawing.Size(239, 17);
			this.chkClearBetBoxNL.TabIndex = 6;
			this.chkClearBetBoxNL.Text = "Clear bet box on NL tables when it\'s your turn";
			this.chkClearBetBoxNL.UseVisualStyleBackColor = true;
			this.chkClearBetBoxNL.CheckedChanged += new System.EventHandler(this.chkClearBetBoxNL_CheckedChanged);
			// 
			// chkEnableLogging
			// 
			this.chkEnableLogging.AutoSize = true;
			this.chkEnableLogging.Location = new System.Drawing.Point(25, 134);
			this.chkEnableLogging.Name = "chkEnableLogging";
			this.chkEnableLogging.Size = new System.Drawing.Size(96, 17);
			this.chkEnableLogging.TabIndex = 5;
			this.chkEnableLogging.Text = "Enable logging";
			this.chkEnableLogging.UseVisualStyleBackColor = true;
			this.chkEnableLogging.CheckedChanged += new System.EventHandler(this.chkEnableLogging_CheckedChanged);
			// 
			// chkAutoClickAutoPostBlind
			// 
			this.chkAutoClickAutoPostBlind.AutoSize = true;
			this.chkAutoClickAutoPostBlind.Location = new System.Drawing.Point(25, 111);
			this.chkAutoClickAutoPostBlind.Name = "chkAutoClickAutoPostBlind";
			this.chkAutoClickAutoPostBlind.Size = new System.Drawing.Size(345, 17);
			this.chkAutoClickAutoPostBlind.TabIndex = 4;
			this.chkAutoClickAutoPostBlind.Text = "Automatically click \'Auto post blind\' when posting blind automatically";
			this.chkAutoClickAutoPostBlind.UseVisualStyleBackColor = true;
			this.chkAutoClickAutoPostBlind.CheckedChanged += new System.EventHandler(this.chkAutoClickAutoPostBlind_CheckedChanged);
			// 
			// chkAutoPostBlind
			// 
			this.chkAutoPostBlind.AutoSize = true;
			this.chkAutoPostBlind.Location = new System.Drawing.Point(25, 88);
			this.chkAutoPostBlind.Name = "chkAutoPostBlind";
			this.chkAutoPostBlind.Size = new System.Drawing.Size(167, 17);
			this.chkAutoPostBlind.TabIndex = 3;
			this.chkAutoPostBlind.Text = "Automatically click \'Post Blind\'";
			this.chkAutoPostBlind.UseVisualStyleBackColor = true;
			this.chkAutoPostBlind.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
			// 
			// chkAutoWaitForBB
			// 
			this.chkAutoWaitForBB.AutoSize = true;
			this.chkAutoWaitForBB.Location = new System.Drawing.Point(25, 65);
			this.chkAutoWaitForBB.Name = "chkAutoWaitForBB";
			this.chkAutoWaitForBB.Size = new System.Drawing.Size(174, 17);
			this.chkAutoWaitForBB.TabIndex = 2;
			this.chkAutoWaitForBB.Text = "Automatically click \'Wait for BB\'";
			this.chkAutoWaitForBB.UseVisualStyleBackColor = true;
			this.chkAutoWaitForBB.CheckedChanged += new System.EventHandler(this.chkAutoWaitForBB_CheckedChanged);
			// 
			// chkShowNotification
			// 
			this.chkShowNotification.AutoSize = true;
			this.chkShowNotification.Location = new System.Drawing.Point(25, 42);
			this.chkShowNotification.Name = "chkShowNotification";
			this.chkShowNotification.Size = new System.Drawing.Size(234, 17);
			this.chkShowNotification.TabIndex = 1;
			this.chkShowNotification.Text = "Show notification when sitting out on a table";
			this.chkShowNotification.UseVisualStyleBackColor = true;
			this.chkShowNotification.CheckedChanged += new System.EventHandler(this.chkShowNotification_CheckedChanged);
			// 
			// chkAutoUpdate
			// 
			this.chkAutoUpdate.AutoSize = true;
			this.chkAutoUpdate.Location = new System.Drawing.Point(25, 19);
			this.chkAutoUpdate.Name = "chkAutoUpdate";
			this.chkAutoUpdate.Size = new System.Drawing.Size(227, 17);
			this.chkAutoUpdate.TabIndex = 0;
			this.chkAutoUpdate.Text = "Automatically check for updates on startup";
			this.chkAutoUpdate.UseVisualStyleBackColor = true;
			this.chkAutoUpdate.CheckedChanged += new System.EventHandler(this.chkAutoUpdate_CheckedChanged);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(384, 501);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.button1_Click);
			// 
			// label13
			// 
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.Location = new System.Drawing.Point(24, 502);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(320, 16);
			this.label13.TabIndex = 2;
			this.label13.Text = "NOTE: Some changes requires a restart of MTH to take effect";
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 300;
			this.toolTip1.AutoPopDelay = 4500;
			this.toolTip1.InitialDelay = 300;
			this.toolTip1.ReshowDelay = 60;
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			this.colorDialog1.FullOpen = true;
			this.colorDialog1.SolidColorOnly = true;
			// 
			// Preferences
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(466, 533);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.tabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Preferences";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferences";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Preferences_Load);
			this.tabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.grpNonSeatedTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numNonSeatedTableQuadrant)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grpActiveTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numActiveTableQuadrant)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.grpKeyControls.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			this.tabPage10.ResumeLayout(false);
			this.grpBorderColors.ResumeLayout(false);
			this.grpBorderColors.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel10Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel9Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel8Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel7Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel6Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel5Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel4Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel3Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel2Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blindLevel1Color)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbBorderColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmActiveTableBorderWidth)).EndInit();
			this.tabPage9.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTableIdentificationCompleteBorderWidth)).EndInit();
			this.tabPage12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		/// <summary>
		/// Closes the preferences window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

		/// <summary>
		/// When the form opens, load settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Preferences_Load(object sender, System.EventArgs e)
		{
            FormReference = this;
            
            string[] keyItems = new string[] {"A", "Add", "B", "C", "D", "Decimal", "Divide", "Down", "E", "End", "Enter", "F", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "G", "H", "Home", "I", "Insert", "J", "K", "L", "Left", "M", "Multiply", "N", "O", "P", "PageDown", "PageUp", "PrintScreen", "Q", "R", "Right", "S", "Space", "Subtract", "T", "U", "Up", "V", "W", "X", "Y", "Z"};

			// Set combobox values
            lstBetRaiseKey.Items.AddRange(keyItems);
			lstCheckCallKey.Items.AddRange(keyItems);
			lstFoldKey.Items.AddRange(keyItems);

			lstAutoPushKey.Items.AddRange(keyItems);
			lstAutoPushKey.Items.Remove("Decimal");

			lstMoveCursorToActiveTableKey.Items.AddRange(keyItems);
            lstRearrangeTablesKey.Items.AddRange(keyItems);
            lstSNGOpenerKey.Items.AddRange(keyItems);
			lstToggleLobbyKey.Items.AddRange(keyItems);
            lstToggleForceActiveTableTopmostKey.Items.AddRange(keyItems);

			// Load settings
			loadSettings("behavior");
		}

		/// <summary>
		/// Loads all settings
		/// </summary>
		private void loadSettings(string tabName)
		{
			if(!loading)
            {
				loading = true;

                switch (tabName.ToLower())
                {
					case "lobby":
						chkKeepLobbyMinimized.Checked = Settings.KeepLobbyMinimized;
						chkKeepLobbyOpened.Checked = Settings.KeepLobbyOpened;
						break;



					case "miscellaneous":
						chkAutoUpdate.Checked = Settings.AutoUpdate;
						chkShowNotification.Checked = Settings.ShowNotification;
						chkAutoWaitForBB.Checked = Settings.AutoWaitForBB;
						chkAutoPostBlind.Checked = Settings.AutoPostBlind;
						chkAutoClickAutoPostBlind.Checked = Settings.AutoClickAutoPostBlind;
						chkEnableLogging.Checked = Settings.EnableLogging;
						chkClearBetBoxNL.Checked = Settings.ClearBetBoxOnNLTables;
						break;



					case "table identification":
						chkUseColorIdentification.Checked = Settings.UseColorIdentification;

						numTableIdentificationCompleteBorderWidth.Value = Settings.TableIdentificationCompleteBorderWidth;

						rdbColorIdentificationLarge.Checked = false;
						rdbColorIdentificationMedium.Checked = false;
						rdbColorIdentificationSmall.Checked = false;
						rdbColorIdentificationCompleteBorder.Checked = false;

						switch (Settings.ColorIdentificationSize)
						{
							case "small":
								rdbColorIdentificationSmall.Checked = true;
								break;
							case "medium":
								rdbColorIdentificationMedium.Checked = true;
								break;
							case "large":
								rdbColorIdentificationLarge.Checked = true;
								break;
							case "complete":
								rdbColorIdentificationCompleteBorder.Checked = true;
								break;
						}
						break;



                    case "sng":
                        lstSeatPreferences.BeginUpdate();
                        lstSeatPreferences.Items.Clear();
                        foreach (int i in Settings.SNGSeatPreference)
                        {
                            if (i == 0)
                                lstSeatPreferences.Items.Add("Seats below this line will be ignored");
                            else
                                lstSeatPreferences.Items.Add("Seat " + i);
                        }
                        lstSeatPreferences.EndUpdate();
                        break;



                    case "border":
                        // UseBorder
                        chkUseBorder.Checked = Settings.UseBorder;
                        label1.Enabled = Settings.UseBorder;

                        // BorderColor
						pbBorderColor.BackColor = Settings.BorderColor;
                       
                        // FlashTable
                        chkFlashTable.Checked = Settings.FlashTable;

                        // ActiveTableBorderWidth
                        nmActiveTableBorderWidth.Value = Settings.ActiveTableBorderWidth;

                        blindLevel1Color.BackColor = Settings.BlindLevelColor(1);
                        blindLevel2Color.BackColor = Settings.BlindLevelColor(2);
                        blindLevel3Color.BackColor = Settings.BlindLevelColor(3);
                        blindLevel4Color.BackColor = Settings.BlindLevelColor(4);
                        blindLevel5Color.BackColor = Settings.BlindLevelColor(5);
                        blindLevel6Color.BackColor = Settings.BlindLevelColor(6);
                        blindLevel7Color.BackColor = Settings.BlindLevelColor(7);
                        blindLevel8Color.BackColor = Settings.BlindLevelColor(8);
                        blindLevel9Color.BackColor = Settings.BlindLevelColor(9);
						blindLevel10Color.BackColor = Settings.BlindLevelColor(10);
                        break;



                    case "behavior":

						chkForceActiveTableToBeTopmost.Checked = Settings.ForceActiveTableToBeTopmost;
						chkRequireNumLock.Checked = Settings.RequireNumLock;
						chkRequireCapsLock.Checked = Settings.RequireCapsLock;

                        // MoveActiveTable
                        chkMoveActiveTable.Checked = Settings.MoveActiveTable;
                        grpActiveTable.Enabled = Settings.MoveActiveTable;

                        // AutoArrangeTables
                        chkAutoArrangeTables.Checked = Settings.AutoArrangeTables;

                        // UseKeyboardControls
                        chkUseKeyboardControls.Checked = Settings.UseKeyboardControls;
                        grpKeyControls.Enabled = Settings.UseKeyboardControls;

                        // KeepActiveTable
                        chkKeepActiveTable.Checked = Convert.ToBoolean(Settings.GetSetting("KeepActiveTable", "true"));

                        // MoveCursorToActiveTable
                        chkMoveCursorToActiveTableRequireShift.Checked = Settings.MoveCursorToActiveTableRequireShift;

                        // PlaceUnseatedTablesAtSpecialLocation
                        chkPlaceUnseatedTablesAtSpecialLocation.Checked = Settings.PlaceUnseatedTablesAtSpecialLocation;
                        grpNonSeatedTable.Enabled = Settings.PlaceUnseatedTablesAtSpecialLocation;

                        // MoveCursorToActiveTable
                        chkMoveCursorToActiveTable.Checked = Settings.MoveCursorToActiveTable;

                        // UseVoiceCommands
                        bool speechEnabled = Settings.SpeechEnabled;
                        chkUseVoiceCommands.Checked = Settings.UseVoiceCommands;
                        chkUseVoiceCommands.Enabled = speechEnabled;
                        txtPreset1.Enabled = speechEnabled;
                        txtPreset1Amount.Enabled = speechEnabled;
                        txtPreset2.Enabled = speechEnabled;
                        txtPreset2Amount.Enabled = speechEnabled;
                        txtPreset3.Enabled = speechEnabled;
                        txtPreset3Amount.Enabled = speechEnabled;
                        button2.Enabled = speechEnabled;
                        btnDownloadSpeech.Visible = !speechEnabled;
                        if (!speechEnabled)
                            toolTip1.SetToolTip(chkUseVoiceCommands, "To enable voice commands, please download the MTH Speech addon.");
                    
                        // AllowNoAmountBetRaise
                        chkAllowNoAmountBetRaise.Checked = Settings.AllowNoAmountBetRaise;
                        break;



                    case "areas":
                        numActiveTableQuadrant.Maximum = Settings.QuadrantCount;
                        numActiveTableQuadrant.Value = Settings.ActiveTableQuadrant;

                        numNonSeatedTableQuadrant.Maximum = Settings.QuadrantCount;
                        numNonSeatedTableQuadrant.Value = Settings.NonSeatedTableQuadrant;


                        lstQuadrants.BeginUpdate();
                        lstQuadrants.Items.Clear();
                        for (int i = 1; i <= Settings.QuadrantCount; i++)
                        {
                            Quadrant q = Settings.GetQuad(i);

                            ListViewItem lvi = new ListViewItem(q.Number.ToString());
                            lvi.SubItems.Add(q.Name);
                            lvi.SubItems.Add(q.X.ToString());
                            lvi.SubItems.Add(q.Y.ToString());
                            lvi.SubItems.Add(q.Width.ToString());
                            lvi.SubItems.Add(q.Height.ToString());

                            lstQuadrants.Items.Add(lvi);
                        }
                        lstQuadrants.EndUpdate();
                        break;



                    case "keyboard controls":
                        // BetRaiseRequireShift
                        chkBetRaiseRequireShift.Checked = Settings.BetRaiseRequireShift;
                        chkSNGOpenerRequireShift.Checked = Settings.SNGOpenerRequireShift;

                        // CheckCallRequireShift
                        chkCheckCallRequireShift.Checked = Settings.CheckCallRequireShift;

                        // FoldRequireShift
                        chkFoldRequireShift.Checked = Settings.FoldRequireShift;

                        // AutoPushRequireShift
                        chkAutoPushRequireShift.Checked = Settings.AutoPushRequireShift;

                        // BetRaiseKey
                        lstBetRaiseKey.SelectedIndex = lstBetRaiseKey.FindString(Settings.BetRaiseKey);

                        // CheckCallKey
                        lstCheckCallKey.SelectedIndex = lstCheckCallKey.FindString(Settings.CheckCallKey);

                        // FoldKey
                        lstFoldKey.SelectedIndex = lstFoldKey.FindString(Settings.FoldKey);

                        // WaitForBBKey
                        lstSNGOpenerKey.SelectedIndex = lstSNGOpenerKey.FindString(Settings.SNGOpenerKey);

                        lstToggleForceActiveTableTopmostKey.SelectedIndex = lstToggleForceActiveTableTopmostKey.FindString(Settings.ToggleActiveTableTopmostKey);
                        chkToggleActiveTableTopmostRequireShift.Checked = Settings.ToggleActiveTableTopmostRequireShift;

						lstToggleLobbyKey.SelectedIndex = lstToggleLobbyKey.FindString(Settings.ToggleLobbyKey);
						chkToggleLobbyRequireShift.Checked = Settings.ToggleLobbyRequireShift;

                        // AutoPushKey
                        lstAutoPushKey.SelectedIndex = lstAutoPushKey.FindString(Settings.AutoPushKey);

                        // MoveCursorToActiveTableKey
                        lstMoveCursorToActiveTableKey.SelectedIndex = lstMoveCursorToActiveTableKey.FindString(Settings.MoveCursorToActiveTableKey);

						chkRearrangeTablesRequireShift.Checked = Settings.RearrangeTablesRequireShift;
						lstRearrangeTablesKey.SelectedIndex = lstRearrangeTablesKey.FindString(Settings.RearrangeTablesKey);
                        break;



                    case "voice commands":
                        // Voice presets
                        txtPreset1.Text = Settings.VCPreset1;
                        txtPreset2.Text = Settings.VCPreset2;
                        txtPreset3.Text = Settings.VCPreset3;
                        txtPreset1Amount.Text = Settings.VCPreset1Amount;
                        txtPreset2Amount.Text = Settings.VCPreset2Amount;
                        txtPreset3Amount.Text = Settings.VCPreset3Amount;
                        break;
                }

				loading = false;
			}
		}

		/// <summary>
		/// Saves the specified setting and loads settings afterwards
		/// </summary>
		/// <param name="setting"></param>
		/// <param name="saveValue"></param>
		private void saveSetting(string setting, object saveValue)
		{
			Settings.SaveSetting(setting, saveValue);

			loadSettings(tabs.SelectedTab.Text);
		}

		/// <summary>
		/// saveSetting that doesn't load values
		/// </summary>
		/// <param name="setting"></param>
		/// <param name="saveValue"></param>
		/// <param name="update"></param>
		private void saveSetting(string setting, object saveValue, bool update)
		{
			Settings.SaveSetting(setting, saveValue);
		}

		/// <summary>
		/// Saves UseBorder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkUseBorder_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("UseBorder", chkUseBorder.Checked);
		}

		/// <summary>
		/// Saves MoveActiveTable
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkMoveActiveTable_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("MoveActiveTable", chkMoveActiveTable.Checked);
		}

		/// <summary>
		/// When a new tab is selected, load settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadSettings(tabs.SelectedTab.Text);
		}

		/// <summary>
		/// Saves AutoArrangeTables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("AutoArrangeTables", chkAutoArrangeTables.Checked);
		}

		/// <summary>
		/// Saves UseKeyboardControls
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkUseKeyboardControls_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("UseKeyboardControls", chkUseKeyboardControls.Checked);
		}

		/// <summary>
		/// Checks whether a string is an integer
		/// </summary>
		/// <param name="theValue"></param>
		/// <returns></returns>
		private static bool isInteger(string theValue)
		{
			Regex isNumber = new Regex(@"^\d+$");

			Match m = isNumber.Match(theValue);

			return m.Success;
		}

		/// <summary>
		/// Saves KeepActiveTable
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkKeepActiveTable_CheckedChanged(object sender, System.EventArgs e)
		{
			Settings.KeepActiveTable = chkKeepActiveTable.Checked;
		}

		/// <summary>
		/// Saves BetRaiseRequireShift
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkBetRaiseRequireShift_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("BetRaiseRequireShift", chkBetRaiseRequireShift.Checked);
		}

		/// <summary>
		/// Saves CheckCallRequireShift
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkCheckCallRequireShift_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("CheckCallRequireShift", chkCheckCallRequireShift.Checked);
		}

		/// <summary>
		/// Saves FoldRequireShift
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkFoldRequireShift_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("FoldRequireShift", chkFoldRequireShift.Checked);
		}

		/// <summary>
		/// Saves BetRaiseKey
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstBetRaiseKey_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstBetRaiseKey.SelectedItem.ToString() != "")
				saveSetting("BetRaiseKey", lstBetRaiseKey.SelectedItem.ToString());
		}

		/// <summary>
		/// Saves CheckCallKey
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstCheckCallKey_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstCheckCallKey.SelectedItem.ToString() != "")
				saveSetting("CheckCallKey", lstCheckCallKey.SelectedItem.ToString());
		}

		/// <summary>
		/// Saves FoldKey
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstFoldKey_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstFoldKey.SelectedItem.ToString() != "")
				saveSetting("FoldKey", lstFoldKey.SelectedItem.ToString());
		}

		/// <summary>
		/// Saves FlashTable
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkFlashTable_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("FlashTable", chkFlashTable.Checked);
		}

		/// <summary>
		/// Sets the quadrant enabled status
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox9_CheckedChanged(object sender, System.EventArgs e)
		{
			TabPage tab = (TabPage)((CheckBox)sender).Parent;

			int monitorOffset = Convert.ToInt32(tab.Tag) * 4;

			saveSetting("Quadrant" + (monitorOffset + Convert.ToInt32(((CheckBox)sender).Tag)) + "Enabled", ((CheckBox)sender).Checked, false);
		}

		/// <summary>
		/// Saves PlaceUnseatedTablesAtSpecialLocation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkPlaceUnseatedTablesAtSpecialLocation_CheckedChanged(object sender, System.EventArgs e)
		{
			saveSetting("PlaceUnseatedTablesAtSpecialLocation", chkPlaceUnseatedTablesAtSpecialLocation.Checked);
		}

		/// <summary>
		/// Saves NonSeatedTableMonitor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numNonSeatedTableMonitor_ValueChanged(object sender, System.EventArgs e)
		{
            Settings.NonSeatedTableQuadrant = (int)numNonSeatedTableQuadrant.Value;
		}

		/// <summary>
		/// Saves MoveCursorToActiveTable
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkMoveCursorToActiveTable_CheckedChanged(object sender, System.EventArgs e)
		{
			Settings.MoveCursorToActiveTable = chkMoveCursorToActiveTable.Checked;
		}

		/// <summary>
		/// Saves the RequiresShift key command settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkBetRaiseRequireShift_CheckedChanged_1(object sender, System.EventArgs e)
		{
			saveSetting(((CheckBox)sender).Tag.ToString(), ((CheckBox)sender).Checked, false);
		}

		/// <summary>
		/// Saves the Key key command settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstBetRaiseKey_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if(((ComboBox)sender).SelectedItem != null)
				saveSetting(((ComboBox)sender).Tag.ToString(), ((ComboBox)sender).SelectedItem.ToString(), false);
		}

		/// <summary>
		/// Checks / unchecks all keyboard command require shift checkboxes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox17_CheckedChanged(object sender, System.EventArgs e)
		{
            loading = true;

            chkBetRaiseRequireShift.Checked = checkBox17.Checked;
			chkCheckCallRequireShift.Checked = checkBox17.Checked;
			chkFoldRequireShift.Checked = checkBox17.Checked;
			chkAutoPushRequireShift.Checked = checkBox17.Checked;
			chkMoveCursorToActiveTableRequireShift.Checked = checkBox17.Checked;
            chkRearrangeTablesRequireShift.Checked = checkBox17.Checked;
            
            loading = false;
        }

		/// <summary>
		/// Saves the ActiveTableBorderWidth
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			saveSetting("ActiveTableBorderWidth", nmActiveTableBorderWidth.Value);
		}

        /// <summary>
        /// Saves UseVoiceCommands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkUseVoiceCommands_CheckedChanged(object sender, EventArgs e)
        {
            if(!loading)
                Form1.FormReference.InitializeVoiceCommands();

            saveSetting("UseVoiceCommands", chkUseVoiceCommands.Checked);
        }

        /// <summary>
        /// Saves VCPreset1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset1_TextChanged(object sender, EventArgs e)
        {
            saveSetting("VCPreset1", txtPreset1.Text, false);
        }

        /// <summary>
        /// Saves VCPreset2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset2_TextChanged(object sender, EventArgs e)
        {
			saveSetting("VCPreset2", txtPreset2.Text, false);
        }

        /// <summary>
        /// Saves VCPreset3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset3_TextChanged(object sender, EventArgs e)
        {
			saveSetting("VCPreset3", txtPreset3.Text, false);
        }

        /// <summary>
        /// Saves VCPreset1Amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset1Amount_TextChanged(object sender, EventArgs e)
        {
			saveSetting("VCPreset1Amount", txtPreset1Amount.Text, false);
        }

        /// <summary>
        /// Saves VCPreset2Amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset2Amount_TextChanged(object sender, EventArgs e)
        {
			saveSetting("VCPreset2Amount", txtPreset2Amount.Text, false);
        }

        /// <summary>
        /// Saves VCPreset3Amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreset3Amount_TextChanged(object sender, EventArgs e)
        {
			saveSetting("VCPreset3Amount", txtPreset3Amount.Text, false);
        }

        /// <summary>
        /// Stars the VoiceTest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("While running the voice recognition test, no voice commands will be processed on the tables, do you want to continue?", "Voice recognition test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    VoiceTest vt = new VoiceTest();

                    // Stop the VC processing
                    Form1.FormReference.StopVoiceCommands();

                    // Show the test
                    vt.ShowDialog();

                    // Restart the VC processing
                    Form1.FormReference.InitializeVoiceCommands();
                }
                catch
                {
                    MessageBox.Show("Please download and install the Microsoft Speech SDK to use voice commands.");
                    
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Opens the speech control panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\Microsoft Shared\\Speech\\sapi.cpl");
        }

        /// <summary>
        /// Saves AllowNoAmountBetRaise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            saveSetting("AllowNoAmountBetRaise", chkAllowNoAmountBetRaise.Checked);
        }

        /// <summary>
        /// Download the speech addon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownloadSpeech_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://hidden.multitablehelper.com/MTHSpeech.msi");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ((PictureBox)sender).BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox pb = (PictureBox)sender;

                pb.BackColor = colorDialog1.Color;

				saveSetting(pb.Tag.ToString(), pb.BackColor.ToArgb(), false);
            }
        }

        private void chkUseBorder_CheckedChanged_1(object sender, EventArgs e)
        {
            saveSetting("UseBorder", chkUseBorder.Checked);
        }

        private void chkFlashTable_CheckedChanged_1(object sender, EventArgs e)
        {
			saveSetting("FlashTable", chkFlashTable.Checked, false);
        }

        private void nmActiveTableBorderWidth_ValueChanged(object sender, EventArgs e)
        {
			saveSetting("ActiveTableBorderWidth", nmActiveTableBorderWidth.Value, false);
        }

		private void chkRequireCapsLock_CheckedChanged(object sender, EventArgs e)
		{
			Settings.RequireCapsLock = chkRequireCapsLock.Checked;
		}

		private void chkRequireNumLock_CheckedChanged(object sender, EventArgs e)
		{
			Settings.RequireNumLock = chkRequireNumLock.Checked;
		}

		private void chkAllowNoAmountBetRaise_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AllowNoAmountBetRaise = chkAllowNoAmountBetRaise.Checked;
		}

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{
			colorDialog1.Color = ((PictureBox)sender).BackColor;

			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				PictureBox pb = (PictureBox)sender;

				pb.BackColor = colorDialog1.Color;

				Settings.BorderColor = colorDialog1.Color;
			}
		}

		private void chkUseColorIdentification_CheckedChanged(object sender, EventArgs e)
		{
			Settings.UseColorIdentification = chkUseColorIdentification.Checked;
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ColorIdentificationSize = "small";
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ColorIdentificationSize = "medium";
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ColorIdentificationSize = "large";
		}

		private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
		{
			Settings.ColorIdentificationSize = "complete";
		}

		private void numTableIdentificationCompleteBorderWidth_ValueChanged(object sender, EventArgs e)
		{
			Settings.TableIdentificationCompleteBorderWidth = (int)numTableIdentificationCompleteBorderWidth.Value;
		}

		private void chkKeepLobbyMinimized_CheckedChanged(object sender, EventArgs e)
		{
			if (chkKeepLobbyMinimized.Checked)
			{
				Settings.KeepLobbyMinimized = true;
				Settings.KeepLobbyOpened = false;
				chkKeepLobbyOpened.Checked = false;
			}
			else
				Settings.KeepLobbyMinimized = false;
		}

		private void chkKeepLobbyOpened_CheckedChanged(object sender, EventArgs e)
		{
			if (chkKeepLobbyOpened.Checked)
			{
				Settings.KeepLobbyOpened = true;
				Settings.KeepLobbyMinimized = false;
				chkKeepLobbyMinimized.Checked = false;
			}
			else
				Settings.KeepLobbyOpened = false;
		}

		private void chkForceActiveTableToBeTopmost_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ForceActiveTableToBeTopmost = chkForceActiveTableToBeTopmost.Checked;
		}

        private void numActiveTableQuadrant_ValueChanged(object sender, EventArgs e)
        {
            Settings.ActiveTableQuadrant = (int)numActiveTableQuadrant.Value;
        }

        private void lstQuadrants_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled = lstQuadrants.SelectedItems.Count > 0;

            btnUp.Enabled = enabled;
            btnDown.Enabled = enabled;
            btnDeleteQuadrant.Enabled = enabled;
            btnShowQuadrant.Enabled = enabled;
        }

        private void btnShowQuadrant_Click(object sender, EventArgs e)
        {
            showQuadrant(lstQuadrants.SelectedItems[0]);
        }

        private void showQuadrant(ListViewItem lvi)
        {
            showQuadrant(lvi, false);
        }

        private void showQuadrant(ListViewItem lvi, bool newQuad)
        {
            EditQuadrant eq;

            if (lvi.Tag != null && !((EditQuadrant)lvi.Tag).IsDisposed)
                eq = (EditQuadrant)lvi.Tag;
            else
            {
                lvi.Tag = new EditQuadrant();
                eq = (EditQuadrant)lvi.Tag;
                eq.LVI = lvi;
            }

			eq.IgnoreChanges = true;
			eq.NewQuad = newQuad;
			eq.Show();
			eq.SetProperties();

			eq.IgnoreChanges = false;
        }

        private void lstQuadrants_DoubleClick(object sender, EventArgs e)
        {
            if (lstQuadrants.SelectedItems.Count > 0)
                btnShowQuadrant_Click(sender, e);
        }

        private void btnShowAllQuadrants_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will open up all quadrants, they may block ongoing tables and other windows, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                foreach (ListViewItem lvi in lstQuadrants.Items)
                    showQuadrant(lvi);
        }

        private void btnAddQuadrant_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            lvi.Text = (lstQuadrants.Items.Count + 1).ToString();
            lvi.SubItems.Add("New quadrant");
            lvi.SubItems.Add("0");
            lvi.SubItems.Add("0");
            lvi.SubItems.Add("796");
            lvi.SubItems.Add("579");

            lstQuadrants.Items.Add(lvi);

            showQuadrant(lvi, true);

            SaveQuadrants();
        }

        private void btnDeleteQuadrant_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lstQuadrants.SelectedItems[0];

            if (lvi.Tag != null)
            {
                EditQuadrant eq = (EditQuadrant)lvi.Tag;

                if (eq.Visible)
                    eq.Close();

                eq.Dispose();
                lvi.Tag = null;
            }

            for (int i = lvi.Index + 1; i < lstQuadrants.Items.Count; i++)
            {
                ListViewItem lviSub = lstQuadrants.Items[i];
                lviSub.SubItems[0].Text = (Convert.ToInt32(lstQuadrants.Items[i].SubItems[0].Text) - 1).ToString();

                if (lviSub.Tag != null)
                    ((EditQuadrant)lviSub.Tag).SetNumber();
            }

            lvi.Remove();

            SaveQuadrants();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lstQuadrants.SelectedItems[0];
            int index = lvi.Index;

            if (lvi.Index > 0)
            {
                lvi.SubItems[0].Text = (Convert.ToInt32(lvi.SubItems[0].Text) - 1).ToString();
                lstQuadrants.Items[lvi.Index - 1].SubItems[0].Text = (Convert.ToInt32(lvi.SubItems[0].Text) + 1).ToString();

                if (lvi.Tag != null)
                    ((EditQuadrant)lvi.Tag).SetNumber();
                if (lstQuadrants.Items[lvi.Index - 1].Tag != null)
                    ((EditQuadrant)lstQuadrants.Items[lvi.Index - 1].Tag).SetNumber();

                lvi.Remove();
                lstQuadrants.Items.Insert(index - 1, lvi);

                SaveQuadrants();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lstQuadrants.SelectedItems[0];
            int index = lvi.Index;

            if (lvi.Index < lstQuadrants.Items.Count - 1)
            {
                lvi.SubItems[0].Text = (Convert.ToInt32(lvi.SubItems[0].Text) + 1).ToString();
                lstQuadrants.Items[lvi.Index + 1].SubItems[0].Text = (Convert.ToInt32(lvi.SubItems[0].Text) - 1).ToString();

                if (lvi.Tag != null)
                    ((EditQuadrant)lvi.Tag).SetNumber();
                if (lstQuadrants.Items[lvi.Index + 1].Tag != null)
                    ((EditQuadrant)lstQuadrants.Items[lvi.Index + 1].Tag).SetNumber();

                lvi.Remove();
                lstQuadrants.Items.Insert(index + 1, lvi);

                SaveQuadrants();
            }
        }

        public void SaveQuadrants()
        {
            string quadrants = "";

            foreach (ListViewItem lvi in lstQuadrants.Items)
            {
                if (quadrants.Length > 0)
                    quadrants += ";";

                quadrants += lvi.SubItems[1].Text + ","; // Name
                quadrants += lvi.SubItems[2].Text + ","; // X
                quadrants += lvi.SubItems[3].Text + ","; // Y
                quadrants += lvi.SubItems[4].Text + ","; // Width
                quadrants += lvi.SubItems[5].Text; // Height
            }

            Settings.SaveSetting("Quadrants", quadrants);
            Settings.ClearCache();

            numActiveTableQuadrant.Maximum = Settings.QuadrantCount;
            numActiveTableQuadrant.Value = Settings.ActiveTableQuadrant;

            numNonSeatedTableQuadrant.Maximum = Settings.QuadrantCount;
            numNonSeatedTableQuadrant.Value = Settings.NonSeatedTableQuadrant;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstSeatPreferences.SelectedItems.Count > 0)
                if (lstSeatPreferences.SelectedItems[0].Index > 0)
                {
                    lstSeatPreferences.BeginUpdate();

                    int index = lstSeatPreferences.SelectedItems[0].Index;
                    string text = lstSeatPreferences.SelectedItems[0].Text;

                    lstSeatPreferences.Items.RemoveAt(index);
                    lstSeatPreferences.Items.Insert(index - 1, text).Selected = true;

                    lstSeatPreferences.EndUpdate();
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lstSeatPreferences.SelectedItems.Count > 0)
            {
                if (lstSeatPreferences.SelectedItems[0].Index < 10)
                {
                    lstSeatPreferences.BeginUpdate();

                    int index = lstSeatPreferences.SelectedItems[0].Index;
                    string text = lstSeatPreferences.SelectedItems[0].Text;

                    lstSeatPreferences.Items.RemoveAt(index);
                    lstSeatPreferences.Items.Insert(index + 1, text).Selected = true;

                    lstSeatPreferences.EndUpdate();
                }
            }
        }

        private void lstSeatPreferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> seats = new List<int>();

            foreach (ListViewItem lvi in lstSeatPreferences.Items)
            {
                if (!lvi.Text.StartsWith("Seats"))
                    seats.Add(Convert.ToInt32(lvi.Text.Replace("Seat ", "")));
                else
                    seats.Add(0);
            }

            Settings.SNGSeatPreference = seats;
        }

		private void grpKeyControls_Enter(object sender, EventArgs e)
		{

		}

		private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AutoUpdate = chkAutoUpdate.Checked;
		}

		private void chkShowNotification_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ShowNotification = chkShowNotification.Checked;
		}

		private void chkAutoWaitForBB_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AutoWaitForBB = chkAutoWaitForBB.Checked;
		}

		private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
		{
			Settings.AutoPostBlind = chkAutoPostBlind.Checked;
		}

		private void chkAutoClickAutoPostBlind_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AutoClickAutoPostBlind = chkAutoClickAutoPostBlind.Checked;
		}

		private void chkEnableLogging_CheckedChanged(object sender, EventArgs e)
		{
			Settings.EnableLogging = chkEnableLogging.Checked;
		}

		private void chkClearBetBoxNL_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ClearBetBoxOnNLTables = chkClearBetBoxNL.Checked;
		}
    }
}