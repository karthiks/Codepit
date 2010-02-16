using System;

namespace TennisDojo.Core
{
    public class GameScore
    {
        private const int DEUCE_POINTS = 3;
        private const int WINNING_POINTS = 4;

        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool Player1HasAdvantage
        {
            get { return ScoreHasAdvantage(Player1Score); }
        }

        public bool Player2HasAdvantage
        {
            get { return ScoreHasAdvantage(Player2Score); }
        }

        public bool IsDeuce
        {
            get { return
                (
                    Player1Score == DEUCE_POINTS &&
                    Player2Score == DEUCE_POINTS
                );
            }
        }

        public bool Player1IsWinner
        {
            get { return Player1Score == WINNING_POINTS; }
        }

        public bool Player2IsWinner
        {
            get { return Player2Score == WINNING_POINTS; }
        }

        public void Player1Scored()
        {
            if (Player1Score == WINNING_POINTS)
                throw new InvalidOperationException(
                    "Player 1 Has Already One the Game");
            
            if (Player2Score == WINNING_POINTS)
                throw new InvalidOperationException(
                    "Player 2 Has Already One the Game");

            if (IsDeuce)
            {
                Player2Score--;
            }
            else
            {
                Player1Score++;
            }

            if (Player1Score == WINNING_POINTS)
                InvokeWinningPointScored();
        }

        public void Player2Scored()
        {
            if (Player1Score == WINNING_POINTS)
                throw new InvalidOperationException(
                    "Player 1 Has Already One the Game");

            if (Player2Score == WINNING_POINTS)
                throw new InvalidOperationException(
                    "Player 2 Has Already One the Game");

            if (IsDeuce)
            {
                Player1Score--;
            }
            else
            {
                Player2Score++;
            }

            if (Player2Score == WINNING_POINTS)
                InvokeWinningPointScored();
        }

        private bool ScoreHasAdvantage(int score)
        {
            if (IsDeuce)
                return false;
            return score == DEUCE_POINTS;
        }

        public event Action WinningPointScored;
        private void InvokeWinningPointScored()
        {
            Action scored = WinningPointScored;
            if (scored != null) scored();
        }
    }
}