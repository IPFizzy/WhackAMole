/*
 * Keon Bushman
 * CST - 250
 * 06/21/2026
 * Whack-A-Mole
 * Activity 5
 * Activity 5 Challenges
 */

using WhackAMole.Models;
using WhackAMole.Services.DataAccessLayer;

namespace WhackAMole.Services.BusinessLogicLayer
{
    public class GameScoreLogic
    {
        private readonly GameScoreDAO _gameScoreDAO = new GameScoreDAO();

        /// <summary>
        /// Saves the completed game score.
        /// </summary>
        /// <param name="gameScore"></param>
        public void SaveScore(GameScoreModel gameScore)
        {
            // Send the score to the data access layer
            _gameScoreDAO.SaveScore(gameScore);
        }

        /// <summary>
        /// Gets the top saved scores.
        /// </summary>
        /// <returns></returns>
        public List<GameScoreModel> GetTopScores()
        {
            // Get scores and return them from highest to lowest
            return _gameScoreDAO.GetScores()
                .OrderByDescending(score => score.Score)
                .Take(5)
                .ToList();
        }
    }
}
