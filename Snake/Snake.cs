using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    class Snake
    {

        int snakeXSpeed;
        int snakeYSpeed;
        Direction currentDirection;

        List<Box> Boxes;

        public Snake(int initialSize)
        {
            Boxes = new List<Box>();

            for (int i = 0; i < initialSize; i += 1)
            {
                // add a box here to the list
                // Boxes.Add(new Box(...))
                Boxes.Add(new Box(Brushes.Green, Constants.BOX_X, Constants.BOX_Y, Constants.BOX_SIZE));

            }

        }

        public void addToSnake()
        {
            Boxes.Add(new Box(Brushes.Green, Boxes[Boxes.Count - 1].boxX, Boxes[Boxes.Count - 1].boxY, Constants.BOX_SIZE));
        }

        public void removeFromSnake() 
        {
            for (int i = Boxes.Count - 1; i > 0; i--)
            {
                Boxes.Remove(Boxes[i]);
            }

        }

        public Rectangle FirstHitbox
        {
            get
            {
                return Boxes[0].BoxHitBox;
            }
        }


        public bool SnakeIntersectsSelf()
        {
            if (Boxes.Count < 3)
            {
                return false;
            }
            for (int i = 2; i < Boxes.Count; i++)
            {
                if (Boxes[i].boxX == Boxes[0].boxX)
                {
                    if (Boxes[i].boxY == Boxes[0].boxY)
                    { 
                        return true;
                    }      
                }
            }
            return false;
        }
        public void DrawSnake(Graphics graphics)
        {
            for (int i = 0; i < Boxes.Count; i++)
            {
                Boxes[i].DrawBox(graphics);
            }
        }


        public void DirectSnake(Direction nextDirection)
        {

            if (nextDirection == Direction.North && currentDirection != Direction.South)
            {
                snakeXSpeed = 0;
                snakeYSpeed = -(Constants.BOX_SIZE);
                currentDirection = Direction.North;
            }
            else if (nextDirection == Direction.South && currentDirection != Direction.North)
            {
                snakeXSpeed = 0;
                snakeYSpeed = (Constants.BOX_SIZE);
                currentDirection = Direction.South;
            }

            if (nextDirection == Direction.East && currentDirection != Direction.West)
            {
                snakeXSpeed = Constants.BOX_SIZE;
                snakeYSpeed = 0;
                currentDirection = Direction.East;
            }
            else if (nextDirection == Direction.West && currentDirection != Direction.East)
            {
                snakeXSpeed = -(Constants.BOX_SIZE);
                snakeYSpeed = 0;
                currentDirection = Direction.West; 
            }
        }

        public void MoveSnake(int ClientSizeX, int ClientSizeY)
        {

            for (int i = Boxes.Count - 1; i >= 1; i--)
            {

                Boxes[i].boxX = Boxes[i - 1].boxX;
                Boxes[i].boxY = Boxes[i - 1].boxY;

            }
            Boxes[0].boxX += snakeXSpeed;
            Boxes[0].boxY += snakeYSpeed;
            int x = ClientSizeX % 20;
            int y = ClientSizeY % 20; 
            if (Boxes[0].boxX > ClientSizeX - x)
            {
                Boxes[0].boxX = 0;
            }
            else if (Boxes[0].boxX < 1)
            {
                Boxes[0].boxX = ClientSizeX - x;
            }
            if (Boxes[0].boxY > ClientSizeY - y)
            {
                Boxes[0].boxY = 0;
            }    
            else if (Boxes[0].boxY < 1)
            {
                Boxes[0].boxY = ClientSizeY - y;
            }




        }

    }
}
