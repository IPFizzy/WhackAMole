/*
 * Keon Bushman
 * CST - 250
 * 06/21/2026
 * Whack-A-Mole
 * Activity 5
 * Activity 5 Challenges
 */

namespace WhackAMole.Models
{
    public class GameScoreModel
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public DateTime DatePlayed { get; set; }

        public GameScoreModel()
        {
            PlayerName = "Player";
            Score = 0;
            Level = 1;
            DatePlayed = DateTime.Now;
        }

        public GameScoreModel(string playerName, int score, int level)
        {
            PlayerName = playerName;
            Score = score;
            Level = level;
            DatePlayed = DateTime.Now;
        }
    }
}
