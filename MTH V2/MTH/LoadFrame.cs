using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MTH
{
    public partial class LoadFrame : Form
    {
        public LoadFrame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the progress bar value
        /// </summary>
        /// <param name="percent"></param>
        public void SetProgress(int percent)
        {
            progress.Value = percent;
        }

        /// <summary>
        /// Sets the progress min and max values
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetValueRange(int min, int max)
        {
            progress.Minimum = min;
            progress.Maximum = max;
        }

        private void LoadFrame_Load(object sender, EventArgs e)
        {

        }
    }
}