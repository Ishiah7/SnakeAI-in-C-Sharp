using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAI
{
    // This is a Linked List Node Class. The snake will be similar to a Linked List.
    class SnakeNode
    {
        public int snakeRowPosition;
        public int snakeBlockPosition;
        public SnakeNode next = null;

        public SnakeNode(int snakeRowPosition, int snakeBlockPosition)
        {
            this.snakeRowPosition = snakeRowPosition;
            this.snakeBlockPosition = snakeBlockPosition;
        }
        
        public SnakeNode() { }
    }


    // This is the class that can be used to initialize a new snake object.

    class Snake
    {
        public SnakeNode snakeHead = null;

        // Creates the snake by creating a new SnakeNode. The snakeHead variable points to this new Node.

        public void CreateSnake(int startingRowPosition, int startingBlockPosition)
        {
            SnakeNode newSnake = new SnakeNode(startingRowPosition, startingBlockPosition);

            snakeHead = newSnake;

            SnakeNode defaultSnakeBody_1 = new SnakeNode(startingRowPosition + 1, startingBlockPosition);
            SnakeNode defaultSnakeBody_2 = new SnakeNode(startingRowPosition + 2, startingBlockPosition);

            snakeHead.next = defaultSnakeBody_1;
            snakeHead.next.next = defaultSnakeBody_2;

        }

        public void AddSnakeLength(SnakeNode newSnakeBody)
        {
            newSnakeBody = snakeHead.next;

            snakeHead.next = newSnakeBody;

        }

        // The two methods below return the snakes head position. Using methods to return the values so the snakeHead variable stays private.

        public int SnakeHead_RowPosition()
        {
            return this.snakeHead.snakeRowPosition;
        }
        
        public int SnakeHead_BlockPosition()
        {
            return this.snakeHead.snakeBlockPosition;
        }
     
    }
}
