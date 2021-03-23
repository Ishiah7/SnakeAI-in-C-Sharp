using System;

namespace SnakeAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gameBoard = new Board();
            Player gamePlayer = new Player();

            gameBoard.CreateBoard();

            char getModeChoice;


            Console.WriteLine("WELCOME TO SNAKE");
            Console.WriteLine("Enter 1 to play.");
            Console.WriteLine("Enter 2 to let AI play.");

            // Normal Game

            while (true)
            {
                getModeChoice = Console.ReadKey().KeyChar;

                if (getModeChoice == '1' || getModeChoice == '2')
                {
                    break;
                }
            }

            if (getModeChoice == '1')
            {
                Console.SetCursorPosition(0, 0);

                while (true)
                {
                    ShowScore(gameBoard);

                    Console.ForegroundColor = ConsoleColor.Green;

                    gameBoard.ShowBoard();

                    Console.ResetColor();

                    gamePlayer.ShowPlayerControls();

                    gamePlayer.GetKeyPushed(gameBoard);



                    if (gameBoard.IsGameOver())
                    {
                        GameOver(gameBoard);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                    }
                }
            }
            else
            {
                // AI 
                Console.SetCursorPosition(0, 0);

                while (true)
                {
                    ShowScore(gameBoard);

                    Console.ForegroundColor = ConsoleColor.Green;

                    gameBoard.ShowBoard();

                    Console.ResetColor();

                    gamePlayer.ShowPlayerControls();

                    gamePlayer.AIkeyPush(gameBoard);

                    System.Threading.Thread.Sleep(10);

                    if (gameBoard.IsGameOver())
                    {
                        GameOver(gameBoard);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                    }
                }
            }           
        }

        static void ShowScore(Board board)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("CURREMT GAME SCORE:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            board.CurrentScore();
            Console.ResetColor();
        }

        static void GameOver(Board board)
        {
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("GAME OVER!");

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("YOU HAD A SCORE OF - ");

            Console.ForegroundColor = ConsoleColor.Green;

            board.CurrentScore();

            Console.ResetColor();
            
        }
    }
}
