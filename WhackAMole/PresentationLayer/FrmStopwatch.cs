/*
 * Keon Bushman
 * CST - 250
 * 06/21/2026
 * Whack-A-Mole
 * Activity 5
 * Activity 5 Guide
 */

using WhackAMole.Models;
using WhackAMole.Services.BusinessLogicLayer;

namespace WhackAMole
{
    public partial class FrmStopwatch : Form
    {
        // Class level variable to hold the timer's time
        private TimeSpan _timeElapsed = new TimeSpan();

        // Create a new Random object to generate numbers
        private Random _random = new Random();

        // Class level variable to hold the player's score
        private int _score = 0;

        // Class level variable to hold the player's lives
        private int _lives = 3;

        // Class level variable to hold the player's current level
        private int _level = 1;

        // Class level variable to track whether the game is over
        private bool _gameOver = false;

        // Class level variable to track whether the game has started
        private bool _gameStarted = false;

        // Class level variable to track when the target should move
        private int _millisecondsSinceMove = 0;

        // Class level variable to control how long the target stays visible
        private int _moveDelayMilliseconds = 3000;

        // Create the business logic object for high scores
        private GameScoreLogic _gameScoreLogic = new GameScoreLogic();

        public FrmStopwatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click Event Handler for btnStart.
        /// Starts the timer and begins the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Do not start the game again if it is already over
            if (_gameOver)
            {
                return;
            }

            // Set the game as started
            _gameStarted = true;

            // Start timer
            tmrStopwatch.Start();

            // Update the game status
            lblGameStatus.Text = "Game Status: Running";
        }

        /// <summary>
        /// Click Event Handler for btnStop.
        /// Stops the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop timer
            tmrStopwatch.Stop();

            // Update the game status
            lblGameStatus.Text = "Game Status: Paused";
        }

        /// <summary>
        /// Click Event Handler for btnReset.
        /// Resets the timer and related game variables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();

            // Reset game values
            _timeElapsed = new TimeSpan();
            _score = 0;
            _lives = 3;
            _level = 1;
            _gameOver = false;
            _gameStarted = false;
            _millisecondsSinceMove = 0;
            _moveDelayMilliseconds = 3000;

            // Keep the timer consistent
            tmrStopwatch.Interval = 250;

            // Show the reset values on the form
            lblTimeElapsed.Text = _timeElapsed.ToString(@"hh\:mm\:ss");
            lblScore.Text = "Score: " + _score;
            lblLives.Text = "Lives: " + _lives;
            lblLevel.Text = "Level: " + _level;
            lblGameStatus.Text = "Game Status: Ready";

            // Reset the buttons to their starting size
            btnTarget.Visible = true;
            btnDecoy.Visible = true;
            btnTarget.Width = 120;
            btnTarget.Height = 55;
            btnDecoy.Width = 120;
            btnDecoy.Height = 55;

            // Reposition controls
            MoveGameButtons();
            PositionBottomControls();
        }

        /// <summary>
        /// Tick Event Handler for tmrStopwatch.
        /// Updates the timer, checks levels, penalizes missed targets, and moves game buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the interval from tmrStopwatch
            int interval = tmrStopwatch.Interval;

            // Add the timer's interval to timeElapsed
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(interval));

            // Add the timer's interval to the movement counter
            _millisecondsSinceMove += interval;

            // Show the timeElapsed on the label
            lblTimeElapsed.Text = _timeElapsed.ToString(@"hh\:mm\:ss");

            // Update the level and difficulty
            UpdateLevel();

            // Check if it is time to move the game buttons
            if (_millisecondsSinceMove >= _moveDelayMilliseconds)
            {
                // Penalize the player if the target was not clicked in time
                if (btnTarget.Visible)
                {
                    LoseLife();
                }

                // Stop moving buttons if the missed target ended the game
                if (_gameOver)
                {
                    return;
                }

                // Move the target and decoy buttons
                MoveGameButtons();

                // Reset the movement counter
                _millisecondsSinceMove = 0;
            }
        } // End of TmrStopwatchTickEH

        /// <summary>
        /// Click Event Handler for btnTarget.
        /// Adds points and hides the target button when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            // Stop clicks from counting before the game starts or after the game ends
            if (!_gameStarted || _gameOver)
            {
                return;
            }

            // Add one point to the score
            _score++;

            // Update the score label
            lblScore.Text = "Score: " + _score;

            // Hide the target
            btnTarget.Visible = false;
        }

        /// <summary>
        /// Click Event Handler for btnDecoy.
        /// Removes a life when the player clicks the decoy button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecoyClickEH(object sender, EventArgs e)
        {
            // Stop clicks from counting before the game starts or after the game ends
            if (!_gameStarted || _gameOver)
            {
                return;
            }

            // Remove one life
            LoseLife();

            // Hide the decoy after it is clicked
            btnDecoy.Visible = false;
        }

        /// <summary>
        /// Click Event Handler for FrmStopwatch.
        /// Penalizes the player for clicking the form instead of the target.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStopwatchClickEH(object sender, EventArgs e)
        {
            // Stop clicks from counting before the game starts or after the game ends
            if (!_gameStarted || _gameOver)
            {
                return;
            }

            // Remove one life for a missed click
            LoseLife();
        }

        /// <summary>
        /// Resize Event Handler for FrmStopwatch.
        /// Keeps the controls positioned correctly when the form changes size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStopwatchResizeEH(object sender, EventArgs e)
        {
            // Keep the bottom controls near the bottom of the form
            PositionBottomControls();
        }

        /// <summary>
        /// Updates the level and increases the game difficulty.
        /// </summary>
        private void UpdateLevel()
        {
            // Increase the level every five points with a maximum level of ten
            int newLevel = Math.Min(10, (_score / 5) + 1);

            // Only update difficulty when the level changes
            if (newLevel != _level)
            {
                _level = newLevel;

                // Make the buttons move faster at an equal rate each level
                _moveDelayMilliseconds = 3000 - ((_level - 1) * 250);

                // Make the buttons shrink at an equal rate each level
                int buttonWidth = 120 - ((_level - 1) * 5);
                int buttonHeight = 55 - ((_level - 1) * 2);

                // Set a minimum size so the buttons stay readable
                btnTarget.Width = Math.Max(75, buttonWidth);
                btnTarget.Height = Math.Max(37, buttonHeight);
                btnDecoy.Width = Math.Max(75, buttonWidth);
                btnDecoy.Height = Math.Max(37, buttonHeight);
            }

            // Update the level label
            lblLevel.Text = "Level: " + _level;
        }

        /// <summary>
        /// Moves the target and decoy buttons to random locations.
        /// </summary>
        private void MoveGameButtons()
        {
            // Create safe movement boundaries
            int minTop = 100;
            int maxTop = Math.Max(minTop + 1, this.ClientSize.Height - btnTarget.Height - 130);
            int maxLeft = Math.Max(21, this.ClientSize.Width - btnTarget.Width - 20);

            // Create new rectangles for the target and decoy
            Rectangle targetRectangle = GetRandomButtonRectangle(btnTarget.Width, btnTarget.Height, minTop, maxTop, maxLeft);
            Rectangle decoyRectangle = GetRandomButtonRectangle(btnDecoy.Width, btnDecoy.Height, minTop, maxTop, maxLeft);

            // Keep trying new decoy locations until it does not overlap the target
            int attempts = 0;

            while (targetRectangle.IntersectsWith(decoyRectangle) && attempts < 50)
            {
                decoyRectangle = GetRandomButtonRectangle(btnDecoy.Width, btnDecoy.Height, minTop, maxTop, maxLeft);
                attempts++;
            }

            // Move the target button
            btnTarget.Top = targetRectangle.Top;
            btnTarget.Left = targetRectangle.Left;
            btnTarget.BackColor = Color.FromArgb(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));
            btnTarget.Visible = true;

            // Move the decoy button
            btnDecoy.Top = decoyRectangle.Top;
            btnDecoy.Left = decoyRectangle.Left;
            btnDecoy.BackColor = Color.Red;
            btnDecoy.Visible = true;
        }

        /// <summary>
        /// Creates a random rectangle for a button location.
        /// </summary>
        /// <param name="buttonWidth"></param>
        /// <param name="buttonHeight"></param>
        /// <param name="minTop"></param>
        /// <param name="maxTop"></param>
        /// <param name="maxLeft"></param>
        /// <returns></returns>
        private Rectangle GetRandomButtonRectangle(int buttonWidth, int buttonHeight, int minTop, int maxTop, int maxLeft)
        {
            // Create a random location
            int left = _random.Next(20, maxLeft);
            int top = _random.Next(minTop, maxTop);

            // Return a rectangle based on the random location and button size
            return new Rectangle(left, top, buttonWidth, buttonHeight);
        }

        /// <summary>
        /// Removes one life from the player and ends the game if no lives remain.
        /// </summary>
        private void LoseLife()
        {
            // Remove one life
            _lives--;

            // Update the lives label
            lblLives.Text = "Lives: " + _lives;

            // End the game if the player has no lives left
            if (_lives <= 0)
            {
                EndGame("No Lives Left");
            }
        }

        /// <summary>
        /// Positions the stopwatch controls near the bottom of the form.
        /// </summary>
        private void PositionBottomControls()
        {
            // Create a bottom position for the controls
            int bottomPosition = this.ClientSize.Height - 50;

            // Keep the controls on the form
            if (bottomPosition < 10)
            {
                bottomPosition = 10;
            }

            // Position stopwatch controls
            btnStart.Top = bottomPosition;
            btnStop.Top = bottomPosition;
            btnReset.Top = bottomPosition;
            lblTimeElapsed.Top = bottomPosition + 5;
            lblScore.Top = bottomPosition - 30;
            lblLives.Top = bottomPosition - 30;
            lblLevel.Top = bottomPosition - 30;
            lblGameStatus.Top = bottomPosition - 30;
        }

        /// <summary>
        /// Ends the game, saves the score, and displays the high scores.
        /// </summary>
        /// <param name="reason"></param>
        private void EndGame(string reason)
        {
            // Stop the game
            tmrStopwatch.Stop();
            _gameOver = true;
            _gameStarted = false;

            // Hide game buttons
            btnTarget.Visible = false;
            btnDecoy.Visible = false;

            // Update the game status
            lblGameStatus.Text = "Game Status: " + reason;

            // Get the player name
            string playerName = txtPlayerName.Text.Trim();

            // Use a default player name if no name was entered
            if (playerName == "")
            {
                playerName = "Player";
            }

            // Create a score object
            GameScoreModel gameScore = new GameScoreModel(playerName, _score, _level);

            // Save the score through the business layer
            _gameScoreLogic.SaveScore(gameScore);

            // Show the high scores
            ShowHighScores();
        }

        /// <summary>
        /// Displays the top saved high scores.
        /// </summary>
        private void ShowHighScores()
        {
            // Get the top scores from the business layer
            List<GameScoreModel> scores = _gameScoreLogic.GetTopScores();

            // Build the message for the player
            string message = lblGameStatus.Text + "\n\nTop Scores:\n";

            foreach (GameScoreModel score in scores)
            {
                message += $"{score.PlayerName}: {score.Score} points, Level {score.Level}\n";
            }

            // Show the message
            MessageBox.Show(message, "High Scores");
        }
    }
}
