using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSWebVersionRazorPages.Models
{
    public class RpsGameLoop
    {
        public RpsGameLoop(int numPlayers, RpsGameLogger gameLog)
        {
            GameRound = 1;
            NumPlayers = numPlayers;
            GameLogic = new RpsGameLogic();
            GameLog = gameLog;
        }

        public int GameRound { get; private set; }
        private int NumPlayers { get; set; }
        private RpsGameLogic GameLogic { get; set; }
        private RpsGameLogger GameLog { get; set; }

        public void GameLoop()
        {
            bool continuePlay = true;
            do
            {
                string pOneChoice = null;
                string pTwoChoice = null;

                do
                {
                    Console.WriteLine("Player 1 Move - Player 2 look away!");
                    pOneChoice = PlayerMove();
                } while (pOneChoice == null);

                if (NumPlayers == 2)
                {
                    try
                    {
                        Console.Clear();
                    }
                    catch
                    {
                        // Ignore error and continue program - this catcher is here because of the test framework.
                    }

                    Console.WriteLine("Player 2 Move - Player 1 look away!");
                    pTwoChoice = PlayerMove();
                }
                else
                {
                    pTwoChoice = RandomMoveGenerator();
                }

                Console.WriteLine($"Player 1: {pOneChoice}\nPlayer 2: {pTwoChoice}\n\n");

                string result = GameLogic.TurnResult(pOneChoice, pTwoChoice);

                Console.WriteLine(result);

                GameLog.IncrementScore(result);

                Console.WriteLine("\n\nEnd Game? Enter `n` to stop, any other key continues the game.");
                string endGameChoice = Console.ReadLine();
                if (endGameChoice == "n") continuePlay = false;

            } while (continuePlay);
        }

        private string GetPlayerMove(Func<string> inputMethod)
        {
            return inputMethod();
        }

        private string MoveSelector(int choiceNum)
        {
            switch (choiceNum)
            {
                case 1:
                    return "paper";
                case 2:
                    return "rock";
                case 3:
                    return "scissors";
                default:
                    return null;
            }
        }

        private string RandomMoveGenerator()
        {
            Random random = new();
            return MoveSelector(random.Next(1, 4));
        }

        private string PlayerMove()
        {
            Console.WriteLine("Please choose a move (enter number):\n1. paper\n2. rock\n3. scissors");
            string playerEntry = GetPlayerMove(UserInput.GetMove);
            int playerNumChoice = 0;
            try
            {
                playerNumChoice = Convert.ToInt32(playerEntry);
            }
            catch
            {
                Console.WriteLine("Please enter 1, 2 or 3 only.");
            }
            return MoveSelector(playerNumChoice);
        }

    }
}
