using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake
{
    class Box
    {
        public int boxX { get; set; }
        public int boxY { get; set; }

        int boxSize;
        Brush boxColor;

        // c# properties, read-only property
        public Rectangle BoxHitBox
        {
            get
            {
                return new Rectangle(boxX, boxY, boxSize, boxSize);
            }
        }



        public Box(Brush BoxColor, int BoxX, int BoxY, int BoxSize)
        {
            boxX = BoxX;
            boxY = BoxY;
            boxSize = BoxSize;
            boxColor = BoxColor;
        }

        public void DrawBox(Graphics graphics)
        {
            graphics.FillRectangle(boxColor, boxX, boxY, boxSize, boxSize);
        }

        //public vod GetBoxX()
        //{ 
            
        //}
        //public void SetBoxX(int newBoxX)
        //{
        //    boxX = newBoxX;
        //}
    }
    
}
