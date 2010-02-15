using TennisDojo.Core;
using Xunit;

namespace TennisDojo.Tests
{
    public class GameScoreTests
    {
        [Fact]
        public void Ctor_NoPointsScored_BothPlayersHaveZeroPoints()
        {
            var score = new GameScore();
            Assert.Equal(0, score.Player1Score);
            Assert.Equal(0, score.Player2Score);
        }
    }
}