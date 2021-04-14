﻿using System;
using System.Collections.Generic;

namespace MJU20BreakoutClone
{
    abstract class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        #region MyRegion

        //TODO: En array med rektangelns alla egenskaper? används i Collision detection
        //TODO: EN tvådimentionel array av typen Rectangle som ritas på consolen'

        #endregion
        public Rectangle(int x , int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            
        }
        /*
        private Rectangle[] MakeRectangle()
        {

        }
        public void DrawRectangle(Rectangle[,] rect )
        {
            for (int i = 0; i < length; i++)
            {
                for (int i = 0; i < length; i++)
                {

                }
            }
        }
        */
        private bool IsCollisionDetected(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.X < rect2.X + rect2.Width &&
                rect1.X + rect1.Width > rect2.X &&
                rect1.Y < rect2.Y + rect2.Height &&
                rect2.Y + rect1.Height > rect2.Y)
            {
                return true;

            }
            return false;
        }
    }
}
