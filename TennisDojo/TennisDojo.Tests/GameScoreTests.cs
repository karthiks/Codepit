using TennisDojo.Core;
using Xunit;

namespace TennisDojo.Tests
{
    public class GameScoreTests
    {
        static GameScore CreateGameScore()
        {
            return new GameScore();
        }

        [Fact]
        public void Ctor_NoPointsScored_BothPlayersHaveZeroPoints()
        {
            var score = CreateGameScore();
            Assert.Equal(0, score.Player1Score);
            Assert.Equal(0, score.Player2Score);
        }

        [Fact]
        public void Player1Score_Player1ScoresOnce_Returns1()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(1);
            Assert.Equal(1, score.Player1Score);
        }

        [Fact]
        public void Player2Score_Player1ScoresOnce_Returns0()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(1);
            Assert.Equal(0, score.Player2Score);
        }
    }


    public static class GameScoreExtensions
    {
        public static GameScore ScorePointsForPlayer1(this GameScore score, int points)
        {
            for (int i = 0; i < points; i++)
            {
                score.Player1Scored();
            }
            return score;
        }
    }
}