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
            balls.Add(new Ball(10, 10, 10, 10)); //Placeholder parameters
            
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
            
            //Add a few rows of destructible tiles
            for(int row = 1; row < 5; ++row)
            {
                for(int col = 1; col < width-1; ++col)
                {
                    tiles[col, row] = new DestructibleTile(col, row, this);
                }
            }
            //Draw all the tiles once.
            DrawBoard();
        }
        
        public void DestroyTile(Tile tile)
        {
            tiles[(int)tile.xPos, (int)tile.yPos] = null;
        }
        
        private void DrawBoard()
        {
            //Draw stationary tiles
            Console.SetCursorPosition(0, 0);
            for(int height = 0; height < tiles.GetLength(1); ++height)
            {
                for(int width = 0; width < tiles.GetLength(0); ++width)
                {
                    Tile tile = tiles[width, height];
                    if(tile == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        tile.Render();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ball position (x): " + balls[0].xPos);
            Console.WriteLine("Ball position (y): " + balls[0].yPos);
        }
        
        public void RenderObjects()
        {
            //Draw stationary tiles
            DrawBoard();
            //Draw balls
            foreach(Ball b in balls)
            {
                b.Render();
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
                Tile adjacentTile = tiles[(int)b.xPos, (int)b.yPos];
                if(adjacentTile != null && adjacentTile.CollidesWith(b))
                {
                    //Collided in x-direction. Reverse xSpeed and put the ball back.
                    b.xSpeed *= -1.0;
                    b.xPos = oldX;
                }
                
                double oldY = b.yPos;
                b.MoveY(deltatime);
                adjacentTile = tiles[(int)b.xPos, (int)b.yPos];
                if(adjacentTile != null && adjacentTile.CollidesWith(b))
                {
                    b.ySpeed *= -1.0;
                    b.yPos = oldY;
                }
            }
        }
    }
}
