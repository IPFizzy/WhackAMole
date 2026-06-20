/*
 * Keon Bushman
 * CST - 250
 * 06/21/2026
 * Whack-A-Mole
 * Activity 5
 * Activity 5 Challenges
 */

using WhackAMole.Models;

namespace WhackAMole.Services.DataAccessLayer
{
    public class GameScoreDAO
    {
        private readonly string _filePath = "highscores.txt";

        /// <summary>
        /// Saves a game score to the high score file.
        /// </summary>
        /// <param name="gameScore"></param>
        public void SaveScore(GameScoreModel gameScore)
        {
            // Build one line of score data
            string scoreLine = $"{gameScore.PlayerName},{gameScore.Score},{gameScore.Level},{gameScore.DatePlayed}";

            // Add the score to the file
            File.AppendAllText(_filePath, scoreLine + Environment.NewLine);
        }

        /// <summary>
        /// Reads all saved game scores from the high score file.
        /// </summary>
        /// <returns></returns>
        public List<GameScoreModel> GetScores()
        {
            // Create a list to hold the scores
            List<GameScoreModel> scores = new List<GameScoreModel>();

            // Return the empty list if the file does not exist yet
            if (!File.Exists(_filePath))
            {
                return scores;
            }

            // Read each line from the file
            string[] lines = File.ReadAllLines(_filePath);

            // Convert each valid line into a GameScoreModel object
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    GameScoreModel gameScore = new GameScoreModel
                    {
                        PlayerName = parts[0],
                        Score = int.Parse(parts[1]),
                        Level = int.Parse(parts[2]),
                        DatePlayed = DateTime.Parse(parts[3])
                    };

                    scores.Add(gameScore);
                }
            }

            return scores;
        }
    }
}
