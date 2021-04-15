namespace MJU20BreakoutClone
{
    interface IMobile
    {
        public double xPos{get; set;}
        public double yPos{get; set;}
        public double xSpeed{get; set;}
        public double ySpeed{get; set;}
        
        public void Move(double deltatime);
    }
}