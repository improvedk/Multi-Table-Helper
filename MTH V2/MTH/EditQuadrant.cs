using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace MTH
{
    public partial class EditQuadrant : Form
    {
        public ListViewItem LVI;
        public bool NewQuad = false;
		private TableFactory.Site currentPokerSite = TableFactory.Site.Invalid;
		public bool IgnoreChanges = false;
		
        public EditQuadrant()
        {
            InitializeComponent();
        }

        private void EditQuadrant_Resize(object sender, EventArgs e)
        {

        }

        private void EditQuadrant_ResizeEnd(object sender, EventArgs e)
        {
            this.txtX.Text = this.Left.ToString();
            this.txtY.Text = this.Top.ToString();
            this.txtWidth.Text = this.Width.ToString();
            this.txtHeight.Text = this.Height.ToString();
        }

		double aspect_ratio(int width)
		{
			return PokerTable.GetAspectRatio(width, currentPokerSite);
		}

        const long WM_SIZING = 0x214;
        const int WMSZ_LEFT = 1;
        const int WMSZ_RIGHT = 2;
        const int WMSZ_TOP = 3;
        const int WMSZ_TOPLEFT = 4;
        const int WMSZ_TOPRIGHT = 5;
        const int WMSZ_BOTTOM = 6;
        const int WMSZ_BOTTOMLEFT = 7;
        const int WMSZ_BOTTOMRIGHT = 8;

        struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SIZING && m.HWnd.Equals(this.Handle))
            {
                Rect r = new Rect();
                r = (Rect)Marshal.PtrToStructure(m.LParam, r.GetType());
                
                double width = r.Right - r.Left;
                double height = r.Bottom - r.Top;

                if (height / width > aspect_ratio((int)width))
                    width = height / aspect_ratio((int)width);
                else
                    height = width * aspect_ratio((int)width);

                if (m.WParam.ToInt32() == WMSZ_TOP || m.WParam.ToInt32() == WMSZ_TOPLEFT || m.WParam.ToInt32() == WMSZ_TOPRIGHT)
                    r.Top = r.Bottom - (int)height;
                else
                    r.Bottom = r.Top + (int)height;

                if (m.WParam.ToInt32() == WMSZ_LEFT || m.WParam.ToInt32() == WMSZ_TOPLEFT || m.WParam.ToInt32() == WMSZ_BOTTOMLEFT)
                    r.Left = r.Right - (int)width;
                else
                    r.Right = r.Left + (int)width;

                Marshal.StructureToPtr(r, m.LParam, true);
            }

            base.WndProc(ref m);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LVI.SubItems[2].Text = this.Left.ToString();
            LVI.SubItems[3].Text = this.Top.ToString();
            LVI.SubItems[4].Text = this.Width.ToString();
            LVI.SubItems[5].Text = this.Height.ToString();

            LVI.Tag = null;
            this.Close();

            Preferences.FormReference.SaveQuadrants();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cs.utoronto.ca/~iheckman/allsnap/");
        }

        public void SetProperties()
        {
            this.txtName.Text = LVI.SubItems[1].Text;
            this.Left = Convert.ToInt32(LVI.SubItems[2].Text);
            this.Top = Convert.ToInt32(LVI.SubItems[3].Text);
            this.Width = Convert.ToInt32(LVI.SubItems[4].Text);
            this.Height = Convert.ToInt32(LVI.SubItems[5].Text);

			this.txtX.Text = this.Left.ToString();
			this.txtY.Text = this.Top.ToString();
			this.txtWidth.Text = this.Width.ToString();
			this.txtHeight.Text = this.Height.ToString();


			
			this.FormBorderStyle = FormBorderStyle.FixedDialog;

			switch (Settings.LastUsedPokerSiteEditQuadrant)
			{
				case "Party":
					cmbSite.SelectedIndex = cmbSite.Items.IndexOf("Party Poker");
					break;
				case "Stars":
					cmbSite.SelectedIndex = cmbSite.Items.IndexOf("PokerStars");
					break;
			}

			cmbSite_SelectedIndexChanged(this, new EventArgs());



            SetNumber();
        }

        public void SetNumber()
        {
            this.txtNumber.Text = LVI.SubItems[0].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LVI.Tag = null;

            if (NewQuad)
            {
                Preferences.FormReference.lstQuadrants.SelectedItems.Clear();
                LVI.Selected = true;
                Preferences.FormReference.btnDeleteQuadrant.PerformClick();
            }

            this.Close();
        }

        private void EditQuadrant_Shown(object sender, EventArgs e)
        {

        }

        private void EditQuadrant_Load(object sender, EventArgs e)
		{

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LVI.SubItems[1].Text = txtName.Text;
        }

        private void EditQuadrant_Move(object sender, EventArgs e)
        {
            EditQuadrant_Resize(sender, e);
        }

		private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cmbSite.SelectedItem.ToString())
			{
				case "":
					FormBorderStyle = FormBorderStyle.FixedDialog;
					currentPokerSite = TableFactory.Site.Invalid;
					break;
				case "Party Poker":
					FormBorderStyle = FormBorderStyle.Sizable;
					MinimumSize = PartyTable.SpecialMinTableSize;
					MaximumSize = PartyTable.SpecialMaxTableSize;
					currentPokerSite = TableFactory.Site.Party;
					Settings.LastUsedPokerSiteEditQuadrant = "Party";
					break;
				case "PokerStars":
					FormBorderStyle = FormBorderStyle.Sizable;
					MinimumSize = StarsTable.SpecialMinTableSize;
					MaximumSize = StarsTable.SpecialMaxTableSize;
					currentPokerSite = TableFactory.Site.Stars;
					Settings.LastUsedPokerSiteEditQuadrant = "Stars";
					break;
				case "FTP":
					FormBorderStyle = FormBorderStyle.FixedDialog;
					currentPokerSite = TableFactory.Site.FTP;
					MinimumSize = FTPTable.SpecialMinTableSize;
					MaximumSize = FTPTable.SpecialMaxTableSize;
					Settings.LastUsedPokerSiteEditQuadrant = "FTP";
					break;
			}

			if (Width > MaximumSize.Width)
				Width = MaximumSize.Width;
			else if (Width < MinimumSize.Width)
				Width = MinimumSize.Width;

			Height = Convert.ToInt32((double)Width * PokerTable.GetAspectRatio(Width, currentPokerSite));

			EditQuadrant_ResizeEnd(sender, e);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtWidth_TextChanged_1(object sender, EventArgs e)
		{
			if (!IgnoreChanges)
			{
				int width = this.Width;
				int initWidth = width;

				try
				{
					width = Convert.ToInt32(txtWidth.Text);
				}
				catch { }

				if (width >= this.MinimumSize.Width)
				{
					if (width > this.MaximumSize.Width)
						width = this.MaximumSize.Width;

					this.Width = width;
					this.Height = Convert.ToInt32((double)width * aspect_ratio(width));
					txtHeight.Text = this.Height.ToString();
					txtWidth.SelectionLength = 0;
					txtWidth.SelectionStart = txtWidth.Text.Length;

					if (initWidth != width)
					{
						txtWidth.Text = this.Width.ToString();
						txtHeight.Text = this.Height.ToString();
					}
				}
			}
		}

		private void txtX_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void button1_Click_2(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in LVI.ListView.Items)
			{
				if (lvi.Tag != null)
				{
					((EditQuadrant)lvi.Tag).btnSave.PerformClick();
				}
			}
		}

		private void txtHeight_TextChanged(object sender, EventArgs e)
		{
			if (!IgnoreChanges)
			{
				int height = this.Height;
				int initHeight = height;

				try
				{
					height = Convert.ToInt32(txtHeight.Text);
				}
				catch { }

				if (height >= this.MinimumSize.Height)
				{
					if (height > this.MaximumSize.Height)
						height = this.MaximumSize.Height;

					this.Height = height;
					this.Width = Convert.ToInt32((double)height / aspect_ratio(this.Width));
					txtWidth.Text = this.Width.ToString();
					txtHeight.SelectionLength = 0;
					txtHeight.SelectionStart = txtHeight.Text.Length;

					if (initHeight != height)
					{
						txtHeight.Text = this.Height.ToString();
						txtWidth.Text = this.Width.ToString();
					}
				}
			}
		}

		private void txtY_TextChanged(object sender, EventArgs e)
		{

		}
    }
}