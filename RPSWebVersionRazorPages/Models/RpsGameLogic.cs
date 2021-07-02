using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSWebVersionRazorPages.Models
{
    public class RpsGameLogic
    {
        public RpsGameLogic()
        {
            GenerateWinMatrix();
        }

        readonly Dictionary<string, string> WinMatrix = new();

        public string TurnResult(string playerOneMove, string playerTwoMove)
        {
            if (playerOneMove == playerTwoMove)
            {
                return "Draw!";
            }
            else if (WinMatrix[playerOneMove] == playerTwoMove)
            {
                return "Player 1 Wins!";
            }
            else
            {
                return "Player 2 Wins!";
            }
        }

        private void GenerateWinMatrix()
        {
            WinMatrix.Add("paper", "rock");
            WinMatrix.Add("rock", "scissors");
            WinMatrix.Add("scissors", "paper");
        }
    }
}
