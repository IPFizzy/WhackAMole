/*
 * Keon Bushman
 * CST - 250
 * 06/21/2026
 * Whack-A-Mole
 * Activity 5
 * Activity 5 Guide
 */

using System.Net.Http.Headers;

namespace WhackAMole
{
    public partial class FrmStopwatch : Form
    {
        // Class level variable to hold the timers time
        TimeSpan timeElapsed = new TimeSpan();

        public FrmStopwatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click Event Handler for btnStart
        /// Starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click Event Handler for btnStop
        /// Stops the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop timer
            tmrStopwatch.Stop();
        }

        /// <summary>
        /// Click Event Handler for btnReset
        /// Reset the timer and related variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();
            // Reset elapsedTime
            timeElapsed = new TimeSpan();
            // Show the reset time on the label
            lblTimeElapsed.Text = timeElapsed.ToString();
        }

        /// <summary>
        /// Tick Event Handler for tmrStopwatch
        /// Updates the timeElapsed variable and the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the interval from trmStopwatch
            int interval = tmrStopwatch.Interval;
            // Add the timers interval to timeElapsed
            timeElapsed = timeElapsed.Add(TimeSpan.FromMilliseconds(interval));
            // Show the timeElapsed on the label
            lblTimeElapsed.Text = timeElapsed.ToString();
        }
    }
}
