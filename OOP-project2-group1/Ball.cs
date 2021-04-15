namespace MJU20BreakoutClone
{
    class Ball : IndestructibleTile, IMobile
    {
        public double xPos{get; set;}
        public double yPos{get; set;}
        public double xSpeed{get; set;}
        public double ySpeed{get; set;}
        
        public Ball(double x, double y, double xs, double ys) : base("O")
        {
            this.xPos = x;
            this.yPos = y;
            this.xSpeed = xs;
            this.ySpeed = ys;
        }
        
        public void MoveX(double deltatime)
        {
            this.xPos += this.xSpeed * deltatime;
        }
        public void MoveY(double deltatime)
        {
            this.yPos += this.ySpeed * deltatime;
        }
    }
}