using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake
{
    class Apple
    {
        int appleX;
        int appleY;
        int appleSize;
        Brush appleColor;

        public Apple(int AppleX, int AppleY, int AppleSize, Brush AppleColor)
        {
            appleX = AppleX;
            appleY = AppleY;
            appleSize = AppleSize;
            appleColor = AppleColor;
        }

        public Rectangle AppleHitBox

        { 
            get
            {
                return new Rectangle(appleX, appleY, appleSize, appleSize);
            }
        }
        
        public bool Intersects(Snake snake)
        {
            if (AppleHitBox.IntersectsWith(snake.FirstHitbox))
            {
                return true;
            }
            return false;
        }

        public void DrawApple(Graphics graphics)
        {
            graphics.FillRectangle(appleColor, appleX, appleY, appleSize, appleSize);
            
        }
    }
}
