using System;

namespace TennisDojo.Core
{
    public class GameScore
    {
        public int Player1Score { get; private set; }
        public int Player2Score;

        public void Player1Scored()
        {
            Player1Score++;
        }
    }
}