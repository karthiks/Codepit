using System;
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
        public void Ctor_NoPointsScored_BothPlayersDoNotHaveAdvantage()
        {
            var score = CreateGameScore();
            Assert.False(score.Player1HasAdvantage);
            Assert.False(score.Player2HasAdvantage);
        }

        [Fact]
        public void Ctor_NoPointsScore_IsDeuceIsFalse()
        {
            var score = CreateGameScore();
            Assert.False(score.IsDeuce);
        }

        [Fact]
        public void Player1IsWinner_Ctor_ReturnsFalse()
        {
            var score = CreateGameScore();
            Assert.False(score.Player1IsWinner);
        }

        [Fact]
        public void Player2IsWinner_Ctor_ReturnsFalse()
        {
            var score = CreateGameScore();
            Assert.False(score.Player2IsWinner);
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

        [Fact]
        public void Player2Score_Player2ScoresOnce_Returns1()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(1);
            Assert.Equal(1, score.Player2Score);
        }

        [Fact]
        public void Player1Score_Player2ScoresOnce_Returns0()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(1);
            Assert.Equal(0, score.Player1Score);
        }

        [Fact]
        public void Player1Score_BothPlayersScoreOnce_Returns1()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(1)
                .ScorePointsForPlayer2(1);
            Assert.Equal(1, score.Player1Score);
        }

        [Fact]
        public void Player2Score_BothPlayersScoreOnce_Returns1()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(1)
                .ScorePointsForPlayer2(1);
            Assert.Equal(1, score.Player2Score);
        }

        [Fact]
        public void Player1Score_BothPlayersScoreTwice_Returns2()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(2)
                .ScorePointsForPlayer2(2);
            Assert.Equal(2, score.Player1Score);
        }

        [Fact]
        public void Player2Score_BothPlayersScoreTwice_Returns2()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(2)
                .ScorePointsForPlayer2(2);
            Assert.Equal(2, score.Player2Score);
        }

        [Fact]
        public void Player1HasAdvantage_Player1Scores3xPlayer20_ReturnsTrue()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(3);
            Assert.True(score.Player1HasAdvantage);
        }

        [Fact]
        public void Player2HasAdvantage_Player2Scores3xPlayer10_ReturnsTrue()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(3);
            Assert.True(score.Player2HasAdvantage);
        }

        [Fact]
        public void Player1HasAdvantage_InDeuce_ReturnsFalse()
        {
            var score = CreateGameScore()
                .SetDuece();
            Assert.False(score.Player1HasAdvantage);
        }

        [Fact]
        public void Player2HasAdvantage_InDeuce_ReturnsFalse()
        {
            var score = CreateGameScore()
                .SetDuece();
            Assert.False(score.Player2HasAdvantage);
        }

        [Fact]
        public void IsDeuce_BothPlayersScored3x_ReturnsTrue()
        {
            var score = CreateGameScore()
                .SetDuece();
            Assert.True(score.IsDeuce);
        }

        [Fact]
        public void Player1Score_FromDuecePlayer1Scores_Returns3()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer1(1);
            Assert.Equal(3, score.Player1Score);
        }

        [Fact]
        public void Player2Score_FromDuecePlayer1Scores_Returns2()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer1(1);
            Assert.Equal(2, score.Player2Score);
        }

        [Fact]
        public void Player1HasAdvantage_FromDuecePlayer1Scores_ReturnsTrue()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer1(1);
            Assert.True(score.Player1HasAdvantage);
        }

        [Fact]
        public void Player2Score_FromDuecePlayer2Scores_Returns3()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer2(1);
            Assert.Equal(3, score.Player2Score);
        }

        [Fact]
        public void Player1Score_FromDuecePlayer2Scores_Returns2()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer2(1);
            Assert.Equal(2, score.Player1Score);
        }

        [Fact]
        public void Player2HasAdvantage_FromDuecePlayer2Scores_ReturnsTrue()
        {
            var score = CreateGameScore()
                .SetDuece()
                .ScorePointsForPlayer2(1);
            Assert.True(score.Player2HasAdvantage);
        }

        [Fact]
        public void Player1IsWinner_Player1Scores4Points_ReturnsTrue()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(4);
            Assert.True(score.Player1IsWinner);
        }

        [Fact]
        public void Player2IsWinner_Player1Scores4Points_ReturnsFalse()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(4);
            Assert.False(score.Player2IsWinner);
        }

        [Fact]
        public void Player2IsWinner_Player2Scores4Points_ReturnsTrue()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(4);
            Assert.True(score.Player2IsWinner);
        }

        [Fact]
        public void Player1IsWinner_Player2Scores4Points_ReturnsFalse()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(4);
            Assert.False(score.Player1IsWinner);
        }

        [Fact]
        public void Player1Scored_Player1HasScored4Points_ThrowsInvOpEx()
        {
            var score = CreateGameScore()
                .ScoreWinningPointForPlayer1();
            Assert.Throws<InvalidOperationException>(
                () => score.Player1Scored());
        }

        [Fact]
        public void Player2Scored_Player1HasScored4Points_ThrowsInvOpEx()
        {
            var score = CreateGameScore()
                .ScoreWinningPointForPlayer1();
            Assert.Throws<InvalidOperationException>(
                () => score.Player2Scored());
        }

        [Fact]
        public void Player1Scored_Player2HasScored4Points_ThrowsInvOpEx()
        {
            var score = CreateGameScore()
                .ScoreWinningPointForPlayer2();
            Assert.Throws<InvalidOperationException>(
                () => score.Player1Scored());
        }

        [Fact]
        public void Player2Scored_Player2HasScored4Points_ThrowsInvOpEx()
        {
            var score = CreateGameScore()
                .ScoreWinningPointForPlayer2();
            Assert.Throws<InvalidOperationException>(
                () => score.Player2Scored());
        }

        [Fact]
        public void Player1Scored_WhenScoringWinningPoint_RaisesWinningPointScoredEvent()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer1(3);
            Assert.True(score.RaisesWinningPointScoredEvent(
                s => s.Player1Scored()));
        }

        [Fact]
        public void Player1Scored_WhenNotScoringWinningPoints_DoesNotRaiseWinningPointScoredEvent()
        {
            var score = CreateGameScore();
            Assert.False(score.RaisesWinningPointScoredEvent(
                s => s.Player1Scored()));
        }

        [Fact]
        public void Player2Scored_WhenScoringWinningPoint_RaisesWinningPointScoredEvent()
        {
            var score = CreateGameScore()
                .ScorePointsForPlayer2(3);
            Assert.True(score.RaisesWinningPointScoredEvent(
                s => s.Player2Scored()));
        }

        [Fact]
        public void Player2Scored_WhenNotScoringWinningPoints_DoesNotRaiseWinningPointScoredEvent()
        {
            var score = CreateGameScore();
            Assert.False(score.RaisesWinningPointScoredEvent(
                s => s.Player2Scored()));
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

        public static GameScore ScorePointsForPlayer2(this GameScore score, int points)
        {
            for (int i = 0; i < points; i++)
            {
                score.Player2Scored();
            }
            return score;
        }

        public static GameScore SetDuece(this GameScore score)
        {
            return score
                .ScorePointsForPlayer1(3)
                .ScorePointsForPlayer2(3);
        }

        public static GameScore ScoreWinningPointForPlayer1(this GameScore score)
        {
            return score.ScorePointsForPlayer1(4);
        }

        public static GameScore ScoreWinningPointForPlayer2(this GameScore score)
        {
            return score.ScorePointsForPlayer2(4);
        }

        public static bool RaisesWinningPointScoredEvent(this GameScore score, Action<GameScore> action)
        {
            var raised = false;
            score.WinningPointScored += () => raised = true;
            action(score);
            return raised;
        }
    }
}