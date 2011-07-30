using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MTH
{
    public partial class VoiceTest : Form
    {
        private VoiceListener vl;

        private Random rnd = new Random();

        private int commandCount = 0, correctCount = 0, wrongCount = 0;

        private string currentCommand = "", lastCommand = "";

        public VoiceTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts / stops the test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (btnTest.Text == "Start Test")
            {
                // Start the text
                btnTest.Text = "Cancel";
                this.Height = 469;

                // Create the voicelistener
                vl = new VoiceListener();

                // Add the test commands
                foreach(string s in Settings.VoiceCommandsList)
                    vl.AddCommand(s);

                vl.CommandReceived += new VoiceListener.CommandReceivedEventHandler(commandRecognized);

                // Reset the counters
                correctCount = 0;
                wrongCount = 0;
                commandCount = 0;

                // Set the first test
                lblVC.Text = vl.Commands[rnd.Next(0, vl.Commands.Count)].ToString();
                currentCommand = lblVC.Text;

                // Set status
                lblStatus.Text = "Waiting for voice command...";
                lblStatus.ForeColor = Color.Green;

                // Start the listener
                vl.Start();
            }
            else
            {
                // Stop the text
                this.Height = 219;
                btnTest.Text = "Start Test";

                // Stop the voicelistener
                vl.Stop();
                vl = null;
            }
        }

        /// <summary>
        /// Fires when a voicecommand has been recognized
        /// </summary>
        /// <param name="command"></param>
        private void commandRecognized(string command)
        {
            commandCount++;

            if (command == currentCommand)
            {
                // Correct command recognized
                correctCount++;

                lblStatus.Text = "Command recognized";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                // Wrong command recognized
                wrongCount++;

                lblStatus.Text = "Expected '" + currentCommand + "', recognized " + command;
                lblStatus.ForeColor = Color.Red;
            }

            // Get new test command
            lastCommand = currentCommand;

            lblVC.Text = vl.Commands[rnd.Next(0, vl.Commands.Count)].ToString();
            currentCommand = lblVC.Text;

            // Update success rate
            double successRate = (((double)correctCount / (double)commandCount) * 100);
            lblSuccessRate.Text = Math.Round(successRate, 2).ToString() + "%";
            lblCommandCount.Text = commandCount.ToString();
            lblCorrectCount.Text = correctCount.ToString();
            lblWrongCount.Text = wrongCount.ToString();

            // Set success rate color
            if (successRate >= 95)
                lblSuccessRate.ForeColor = Color.Green;
            else if (successRate >= 90)
                lblSuccessRate.ForeColor = Color.Yellow;
            else
                lblSuccessRate.ForeColor = Color.Red;
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Make sure to stop the voice listener
            if (vl != null)
            {
                vl.Stop();
                vl = null;
            }
            
            // Close form
            this.Close();
        }

        /// <summary>
        /// Set our height to the normal size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoiceTest_Load(object sender, EventArgs e)
        {
            this.Height = 219;
        }

        /// <summary>
        /// Speaks the current command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            if (vl != null)
                vl.Speak(currentCommand);
        }

        /// <summary>
        /// Speaks the last command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatus_Click(object sender, EventArgs e)
        {
            if (lastCommand.Length > 0)
                if (vl != null)
                    vl.Speak(lastCommand);
        }
    }
}