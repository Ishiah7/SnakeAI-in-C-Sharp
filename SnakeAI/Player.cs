using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAI
{
    class Player
    {
        private const char DOWN_KEY = 's';
        private const char UP_KEY = 'w';
        private const char LEFT_KEY = 'a';
        private const char RIGHT_KEY = 'd';

        

        public void GetKeyPushed(Board GameBoard)
        {
            // Makes sure users only press correct keys.

            char keyPressed;

            while (true)
            {
                keyPressed = Console.ReadKey().KeyChar;

                if(keyPressed == DOWN_KEY || keyPressed == UP_KEY || keyPressed == LEFT_KEY || keyPressed == RIGHT_KEY)
                {
                    break;
                }
            }

            // switch case to call different methods for snake movement

            switch (keyPressed)
            {
                case DOWN_KEY:
                    //GameBoard.MoveSnake_Down();
                    GameBoard.MoveSnake(1, 0);
                    break;

                case UP_KEY:
                    //GameBoard.MoveSnake_Up();
                    GameBoard.MoveSnake(-1, 0);
                    break;

                case LEFT_KEY:
                    //GameBoard.MoveSnake_Left();
                    GameBoard.MoveSnake(0, -1);
                    break;

                case RIGHT_KEY:
                    //GameBoard.MoveSnake_Right();
                    GameBoard.MoveSnake(0, 1);
                    break;

                default:
                    break;
            }

            Console.WriteLine();
        }



        public void AIkeyPush(Board GameBoard)
        {
            // Makes sure users only press correct keys.

        char AIKeyPress;

            int snakeHeadPosition_Row;
            int snakeHeadPosition_Block;

            int snakeBackPosition_Row;
            int snakeBackPosition_Block;

            int applePosition_Row;
            int applePositon_Block;

            snakeHeadPosition_Row = GameBoard.CurrentSnakeHeadPosition()[0];
            snakeHeadPosition_Block = GameBoard.CurrentSnakeHeadPosition()[1];

            snakeBackPosition_Row = GameBoard.CurrentSnakeBackPosition()[0];
            snakeBackPosition_Block = GameBoard.CurrentSnakeBackPosition()[1];

            applePosition_Row = GameBoard.CurrentApplePosition()[0];
            applePositon_Block = GameBoard.CurrentApplePosition()[1];


            // A = 5
            // S = 3

            if(snakeHeadPosition_Row != applePosition_Row)
            {
                //int snakeAppleRowDistance;

                if(snakeHeadPosition_Row > applePosition_Row)
                {
                    //snakeAppleRowDistance = snakeHeadPosition_Row - applePosition_Row;
                    

                    if (snakeBackPosition_Row == snakeHeadPosition_Row - 1)
                    {
                        AIKeyPress = RIGHT_KEY;
                    }
                    else
                    {
                        AIKeyPress = UP_KEY;
                    }



                }
                else
                {
                    //snakeAppleRowDistance = applePosition_Row - snakeHeadPosition_Row;

                    if(snakeBackPosition_Row == snakeHeadPosition_Row + 1)
                    {
                        AIKeyPress = LEFT_KEY;
                    }
                    else
                    {
                        AIKeyPress = DOWN_KEY;
                    }
                    
                }
            }
            else
            {
                //int snakeAppleBlockDistance;

                if (snakeHeadPosition_Block > applePositon_Block)
                {
                    //snakeAppleBlockDistance = snakeHeadPosition_Block - applePositon_Block;
                    if(snakeBackPosition_Block == snakeHeadPosition_Block - 1)
                    {
                        AIKeyPress = UP_KEY;
                    }
                    else
                    {
                        AIKeyPress = LEFT_KEY;
                    }

                    
                }
                else
                {
                    //snakeAppleBlockDistance = applePositon_Block - snakeHeadPosition_Block;

                    if (snakeBackPosition_Block == snakeHeadPosition_Block + 1)
                    {
                        AIKeyPress = DOWN_KEY;
                    }
                    else
                    {
                        AIKeyPress = RIGHT_KEY;
                    }
                   
                }
            }


            // switch case to call different methods for snake movement

            switch (AIKeyPress)
            {
                case DOWN_KEY:
                    //GameBoard.MoveSnake_Down();
                    GameBoard.MoveSnake(1, 0);
                    break;

                case UP_KEY:
                    //GameBoard.MoveSnake_Up();
                    GameBoard.MoveSnake(-1, 0);
                    break;

                case LEFT_KEY:
                    //GameBoard.MoveSnake_Left();
                    GameBoard.MoveSnake(0, -1);
                    break;

                case RIGHT_KEY:
                    //GameBoard.MoveSnake_Right();
                    GameBoard.MoveSnake(0, 1);
                    break;

                default:
                    break;
            }

            Console.WriteLine();
        }

        public void ShowPlayerControls()
        {
            Console.WriteLine();
            Console.WriteLine("Controls Are Shown Below:");

            Console.Write("To Move Snake Down: " + DOWN_KEY);
            Console.WriteLine();

            Console.Write("To Move Snake Up: " + UP_KEY);
            Console.WriteLine();


            Console.Write("To Move Snake Left: " + LEFT_KEY);
            Console.WriteLine();

            Console.Write("To Move Snake Right: " + RIGHT_KEY);
            Console.WriteLine();
        }

    }
}
