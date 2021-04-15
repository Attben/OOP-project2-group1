using System;
using System.Collections.Generic;

namespace MJU20BreakoutClone
{
    abstract class Rectangle
    {
        public double xPos { get; set; }
        public double yPos { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        #region MyRegion

        //TODO: En array med rektangelns alla egenskaper? används i Collision detection
        //TODO: EN tvådimentionel array av typen Rectangle som ritas på consolen'

        #endregion
        public Rectangle(double x , double y, uint width, uint height)
        {
            this.xPos = x;
            this.yPos = y;
            this.Width = width;
            this.Height = height;
            
        }
        
        public bool CollidesWith(Rectangle rect2)
        {
            if(rect2 == null)
            {
                return false; //Can't collide with nothing.
            }
            if (this.xPos < rect2.xPos + rect2.Width &&
                this.xPos + this.Width > rect2.xPos &&
                this.yPos < rect2.yPos + rect2.Height &&
                rect2.yPos + this.Height > rect2.yPos)
            {
                return true;
            }
            return false;
        }
    }
}
