using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSWebVersionRazorPages.Models
{
    public class RpsGameLogger
    {
        public RpsGameLogger()
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            Draws = 0;
        }

        public int PlayerOneScore { get; private set; }
        public int PlayerTwoScore { get; private set; }
        public int Draws { get; private set; }


        public void IncrementScore(string roundResult)
        {
            switch (roundResult)
            {
                case "Player 1 Wins!":
                    PlayerOneScore++;
                    break;
                case "Player 2 Wins!":
                    PlayerTwoScore++;
                    break;
                case "Draw!":
                    Draws++;
                    break;
                default:
                    break;
            }

        }

        public string DetermineWinner()
        {
            if (PlayerOneScore == PlayerTwoScore)
            {
                return "Its a Draw!"
;
            }
            else if (PlayerOneScore > PlayerTwoScore)
            {
                return "Player 1 is the Winner!";
            }
            else
            {
                return "Player 2 is the Winner!";
            }
        }
    }
}
