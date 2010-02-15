using System;

namespace TennisDojo.Core
{
    public class GameScore
    {
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool Player1HasAdvantage
        {
            get { return Player1Score == 3; }
        }

        public bool Player2HasAdvantage
        {
            get { return Player2Score == 3; }
        }

        public void Player1Scored()
        {
            Player1Score++;
        }

        public void Player2Scored()
        {
            Player2Score++;
        }
    }
}