using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAI
{
    class Board
    {
        // These are the class Constants.

        private string BOARD_BORDER = "+";
        private string BOARD_SPACE = " ";
        private string APPLE = "O";
        private string SNAKEBODY = "#";
        private string SNAKEHEAD = "X";

        private int score = 0;
        private bool isGameOver = false;

        // The Below variables initiailize arrays. MATRIX is the board.  APPLE_COORDINATES is the array holding the current apple coordinates.

        private string[,] MATRIX = new string[20, 50];       
        private int[] APPLE_COORDINATES = new int[2];
        
        // This initializes a new Random object to use for the apple location. 

        Random random = new Random();

        // Creates Snake Object.

        private Snake mainSnake = new Snake();

        // CreateBoard() creates the actual Board and loads the snake and apple. The method fills the 2d array with either the border or spaces and will load the snake and apple at their positions.

        public void CreateBoard()
        {
            for (int row = 0; row < MATRIX.GetLength(0); row++)
            {
                for(int block = 0; block < MATRIX.GetLength(1); block++)
                {
                    if (row == 0 || row == MATRIX.GetLength(0) - 1)
                    {
                        MATRIX[row, block] = BOARD_BORDER;
                    }

                    else if(block == 0 || block == MATRIX.GetLength(1) - 1)
                    {
                        MATRIX[row, block] = BOARD_BORDER;
                    }

                    else
                    {
                        MATRIX[row, block] = BOARD_SPACE;
                    }
                }
            }

            GenerateApplePosition();
            GenerateSnake();

        }


        // GenerateApplePosition() generates the apple on the board and will be called everytime the apple needs to change locations.

        private void GenerateApplePosition()
        {
            int rowValue = random.Next(1, MATRIX.GetLength(0) - 1);
            int blockValue = random.Next(1, MATRIX.GetLength(1) - 1);

            MATRIX[rowValue, blockValue] = APPLE;

            APPLE_COORDINATES[0] = rowValue;
            APPLE_COORDINATES[1] = blockValue;
        }


        // GenerateSnake() creates the snake object.  

        private void GenerateSnake()
        {
            int rowValue = MATRIX.GetLength(0) / 2;
            int blockValue = MATRIX.GetLength(1) / 2;

            mainSnake.CreateSnake(rowValue, blockValue);

            SnakeNode TEMP_snakePointer = mainSnake.snakeHead;

            MATRIX[TEMP_snakePointer.snakeRowPosition, TEMP_snakePointer.snakeBlockPosition] = SNAKEHEAD;

            while (TEMP_snakePointer.next != null)
            {
               // MATRIX[TEMP_snakePointer.snakeRowPosition, TEMP_snakePointer.snakeBlockPosition] = SNAKEBODY;
                TEMP_snakePointer = TEMP_snakePointer.next;
                MATRIX[TEMP_snakePointer.snakeRowPosition, TEMP_snakePointer.snakeBlockPosition] = SNAKEBODY;
            }

            MATRIX[TEMP_snakePointer.snakeRowPosition, TEMP_snakePointer.snakeBlockPosition] = SNAKEBODY;
        }


        public void MoveSnake(int rowMovement, int blockMovement)
        {           
            int snakeHead_RowPosition = mainSnake.snakeHead.snakeRowPosition;
            int snakeHead_BlockPosition = mainSnake.snakeHead.snakeBlockPosition;

            SnakeNode newSnakeHead = new SnakeNode(snakeHead_RowPosition + (rowMovement), snakeHead_BlockPosition + (blockMovement));

            if (newSnakeHead.snakeRowPosition == mainSnake.snakeHead.next.snakeRowPosition && newSnakeHead.snakeBlockPosition == mainSnake.snakeHead.next.snakeBlockPosition)
            {
                return;
            }

            if (newSnakeHead.snakeRowPosition == 0 || newSnakeHead.snakeRowPosition == MATRIX.GetLength(0) - 1 || newSnakeHead.snakeBlockPosition == 0 || newSnakeHead.snakeBlockPosition == MATRIX.GetLength(1) - 1)
            {
                isGameOver = true;
            }

            newSnakeHead.next = mainSnake.snakeHead;

            mainSnake.snakeHead = newSnakeHead;

            MATRIX[mainSnake.snakeHead.snakeRowPosition, mainSnake.snakeHead.snakeBlockPosition] = SNAKEHEAD;

            MATRIX[mainSnake.snakeHead.next.snakeRowPosition, mainSnake.snakeHead.next.snakeBlockPosition] = SNAKEBODY;

            SnakeNode TEMP_snakePointer = mainSnake.snakeHead;
            SnakeNode PREV_TEMP_snakePointer = null;

            while (TEMP_snakePointer.next != null)
            {
                PREV_TEMP_snakePointer = TEMP_snakePointer;
                TEMP_snakePointer = TEMP_snakePointer.next;

                if (mainSnake.snakeHead.snakeRowPosition == TEMP_snakePointer.snakeRowPosition && mainSnake.snakeHead.snakeBlockPosition == TEMP_snakePointer.snakeBlockPosition)
                {
                    isGameOver = true;
                    return;
                }
            }

            if (mainSnake.snakeHead.snakeRowPosition == TEMP_snakePointer.snakeRowPosition && mainSnake.snakeHead.snakeBlockPosition == TEMP_snakePointer.snakeBlockPosition)
            {
                isGameOver = true;
            }

            if (mainSnake.snakeHead.snakeRowPosition == APPLE_COORDINATES[0] && mainSnake.snakeHead.snakeBlockPosition == APPLE_COORDINATES[1])
            {
                GenerateApplePosition();
                score++;
            }
            else
            {
                MATRIX[TEMP_snakePointer.snakeRowPosition, TEMP_snakePointer.snakeBlockPosition] = BOARD_SPACE;

                PREV_TEMP_snakePointer.next = null;
            }
        }


        // Apple position stored in array as [x,y]. x - Row Number, y - position in x row. Can make a get/set method, refactor

        public int[] CurrentApplePosition()
        {
            int[] applePosition = this.APPLE_COORDINATES;

            return applePosition;
        }

        public int[] CurrentSnakeHeadPosition()
        {
            int[] snakeHeadPosition = new int[2] { mainSnake.snakeHead.snakeRowPosition, mainSnake.snakeHead.snakeBlockPosition };

            return snakeHeadPosition;
        }

        public int[] CurrentSnakeBackPosition()
        {
            int[] snakeBackPosition = new int[2] { mainSnake.snakeHead.next.snakeRowPosition, mainSnake.snakeHead.next.snakeBlockPosition };

            return snakeBackPosition;
        }

        public void CurrentScore()
        {
            Console.WriteLine(score);
            Console.WriteLine();
        }

        public bool IsGameOver()
        {
            return isGameOver;
        } 


        // ShowBoard() shows the current state of the board when called.

        public void ShowBoard()
        {
            for (int row = 0; row < MATRIX.GetLength(0); row++)
            {
                for (int block = 0; block < MATRIX.GetLength(1); block++)
                {
                    Console.Write(MATRIX[row, block]);
                }
                Console.WriteLine();
            }
        }
    }
}
