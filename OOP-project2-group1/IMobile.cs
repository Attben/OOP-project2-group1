namespace MJU20BreakoutClone
{
    interface IMobile
    {
        public double xPos{get; set;}
        public double yPos{get; set;}
        public double xSpeed{get; set;}
        public double ySpeed{get; set;}
        
        //Split movement into components to make collision handlers more flexible
        public void MoveX(double deltatime);
        public void MoveY(double deltatime);
    }
}