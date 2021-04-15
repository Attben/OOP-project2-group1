using System;
using System.Collections.Generic;

namespace MJU20BreakoutClone
{
    class GamePlane
    {
        List<Ball> balls;
        Tile[,] tiles;
        
        public GamePlane(uint width, uint height)
        {
            balls = new List<Ball>();
            balls.Add(new Ball(10, 10, 5, 5)); //Placeholder parameters
            
            //Initialize border tiles
            tiles = new Tile[width, height];
            
            //Corners
            tiles[0, 0] = new IndestructibleTile("╔", 0, 0);
            tiles[width-1, 0] = new IndestructibleTile("╗", width-1, 0);
            tiles[0, height-1] = new IndestructibleTile("╚", 0, height-1);
            tiles[width-1, height-1] = new IndestructibleTile("╝", width-1, height-1);
            
            //Top and bottom
            for(int n = 1; n < (width - 1); ++n)
            {
                tiles[n, 0] = new IndestructibleTile("═", n, 0);
                tiles[n, height-1] = new IndestructibleTile("═", n, height-1);
            }
            
            //Left and right
            for(int n = 1; n < (height - 1); ++n)
            {
                tiles[0, n] = new IndestructibleTile("║", 0, n);
                tiles[width-1, n] = new IndestructibleTile("║", width-1, n);
            }
        }
        
        public void RenderObjects()
        {
            //Draw stationary tiles
            Console.SetCursorPosition(0, 0);
            //Console.WriteLine("x: " + balls[0].xPos);
            //Console.WriteLine("y: " + balls[0].yPos);
            for(int height = 0; height < tiles.GetLength(1); ++height)
            {
                for(int width = 0; width < tiles.GetLength(0); ++width)
                {
                    string charsToRender = 
                    (tiles[width, height] == null ? " " : tiles[width, height].graphicalRepresentation);
                    Console.Write(charsToRender);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ball position (x): " + balls[0].xPos);
            Console.WriteLine("Ball position (y): " + balls[0].yPos);
            //Draw balls
            foreach(Ball b in balls)
            {
                Console.SetCursorPosition((int)b.xPos, (int)b.yPos);
                Console.Write(b.graphicalRepresentation);
            }
        }
        
        public void UpdateGameState(double deltatime)
        {
            foreach(Ball b in balls)
            {
                //Save old position so the ball can be put back
                //if the movement makes it collide with a solid tile.
                double oldX = b.xPos;
                b.MoveX(deltatime);
                //Tile xAdjacentTile = tiles[(int)b.xPos + 1*Math.Sign(b.xSpeed), (int)b.yPos];
                if(b.CollidesWith(tiles[(int)b.xPos, (int)b.yPos]))
                {
                    //Collided in x-direction. Reverse xSpeed and put the ball back.
                    b.xSpeed *= -1.0;
                    b.xPos = oldX;
                }
                
                double oldY = b.yPos;
                b.MoveY(deltatime);
                //Tile yAdjacentTile = tiles[(int)b.xPos, (int)b.yPos + 1*Math.Sign(b.ySpeed)];
                if(b.CollidesWith(tiles[(int)b.xPos, (int)b.yPos]))
                {
                    b.ySpeed *= -1.0;
                    b.yPos = oldY;
                }
            }
        }
    }
}
