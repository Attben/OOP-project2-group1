using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    class DestructibleTile : Tile
    {
        private int explosionAnimationTimer = 0;
        public event TileCallback destructionCallback;
        
        public DestructibleTile(double x, double y, GamePlane gp) : base("D", x, y)
        {
            destructionCallback += new TileCallback(gp.DestroyTile);
        }
        
        public void Destroy()
        {
            ++explosionAnimationTimer;
            graphicalRepresentation = "X";
        }
        
        public override void Render()
        {
            Console.SetCursorPosition(70,0);
            Console.Write(explosionAnimationTimer);
            if(explosionAnimationTimer > 0)
            {
                ++explosionAnimationTimer;
                if(explosionAnimationTimer > 8)
                {
                    destructionCallback(this);
                    graphicalRepresentation = " ";
                }
                else if(explosionAnimationTimer > 4)
                {
                    graphicalRepresentation = "*";
                }
            }
            base.Render();
        }
        
        public override bool CollidesWith(Rectangle other)
        {
            bool collided = base.CollidesWith(other);
            if(collided)
            {
                this.Destroy();
            }
            return collided;
        }
    }
}
