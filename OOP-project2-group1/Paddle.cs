using System;

namespace MJU20BreakoutClone
{
    class Paddle : IndestructibleTile, IMobile
    {
        public double xSpeed { get; set; }
        public double ySpeed { get; set; }
        public double maxXspeed {get; private set;}
        public double maxYspeed {get; private set;}
        
        public Paddle(
            double x, double y,
            double xs = 0, double ys = 0,
            double maxXs = 14, double maxYs = 14)
            : base("————————", x, y, 8)
        {
            this.xSpeed = xs;
            this.ySpeed = ys;
            this.maxXspeed = maxXs;
            this.maxYspeed = maxYs;
        }
        
        public void MoveX(double deltatime)
        {
            this.xPos += this.xSpeed * deltatime;
        }
        
        public void MoveY(double deltatime)
        {
            this.xPos += this.xSpeed * deltatime;
        }
    }
}
