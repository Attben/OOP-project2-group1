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
            tiles[0, 0] = new IndestructibleTile("╔");
            tiles[width-1, 0] = new IndestructibleTile("╗");
            tiles[0, height-1] = new IndestructibleTile("╚");
            tiles[width-1, height-1] = new IndestructibleTile("╝");
            
            //Top and bottom
            for(int n = 1; n < (width - 1); ++n)
            {
                tiles[n, 0] = new IndestructibleTile("═");
                tiles[n, height-1] = new IndestructibleTile("═");
            }
            
            //Left and right
            for(int n = 1; n < (height - 1); ++n)
            {
                tiles[0, n] = new IndestructibleTile("║");
                tiles[width-1, n] = new IndestructibleTile("║");
            }
            //var rectangleListofBorders = new List<Rectangle>;
            //Rectangle MygameplaneArea = new Rectangle();
        }
        
        public void RenderObjects()
        {
            //Draw stationary tiles
            Console.SetCursorPosition(0, 0);
            //Console.WriteLine("x: " + balls[0].xPos);
            //Console.WriteLine("y: " + balls[0].yPos);
            for(int height = 0; height < tiles.GetLength(1); ++height){
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
                b.MoveX(deltatime);
                b.MoveY(deltatime);
            }
        }
    }
}
