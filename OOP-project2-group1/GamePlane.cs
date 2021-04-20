using System;
using System.Collections.Generic;

namespace MJU20BreakoutClone
{
    class GamePlane
    {
        private List<Ball> balls;
        private List<Paddle> paddles;
        private Tile[,] tiles;
        private uint score = 0;
        private uint width, height;
        
        public GamePlane(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            balls = new List<Ball>();
            balls.Add(new Ball(10, 10, 10, 10)); //Placeholder parameters
            paddles = new List<Paddle>();
            paddles.Add(new Paddle((int)(width / 2), height - 2));
            
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
            Console.WriteLine("Score: " + score + " points");
            Console.WriteLine("Paddle position: " + paddles[0].xPos);
            //Console.WriteLine("Ball position (x): " + balls[0].xPos);
            //Console.WriteLine("Ball position (y): " + balls[0].yPos);
        }
        
        public void GainPoints(uint points)
        {
            score += points;
        }
        
        //Unfortunately, this method of input handling isn't very responsive.
        public void HandleInputs(ConsoleKeyInfo cki)
        {
            foreach(Paddle paddle in paddles)
            {
                if (cki.Key == ConsoleKey.D)
                {
                    paddle.xSpeed = paddle.maxXspeed;
                }
                else if(cki.Key == ConsoleKey.A)
                {
                   paddle.xSpeed = -paddle.maxXspeed;
                }/*
                if (cki.Key == ConsoleKey.Escape)
                {
                    break;
                }*/
            }
        }
        
        //Workaround to simulate key release events
        public void HandleEmptyInput()
        {
            foreach(Paddle p in paddles)
            {
                p.xSpeed = 0;
            }
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
            foreach(Paddle p in paddles)
            {
                p.Render();
            }
        }
        
        //TODO: Refactor to reduce code duplication
        public void UpdateGameState(double deltatime)
        {
            if (score == 232)
            {
                foreach (Ball ball in balls)
                {
                    ball.xSpeed = 0;
                    ball.ySpeed = 0;
                }
                Console.SetCursorPosition(23, 15);
                Console.WriteLine("You have Won!");
            }
            foreach (Ball ball in balls)
            {
                //Save old position so the ball can be put back
                //if the movement makes it collide with a solid tile.
                double oldX = ball.xPos;
                ball.MoveX(deltatime);
                Tile adjacentTile = tiles[(int)ball.xPos, (int)ball.yPos];
                if(adjacentTile != null && adjacentTile.CollidesWith(ball))
                {
                    //Collided in x-direction. Reverse xSpeed and put the ball back.
                    ball.xSpeed *= -1.0;
                    ball.xPos = oldX;
                }
                foreach(Paddle paddle in paddles)
                {
                    if(paddle.CollidesWith(ball))
                    {
                        ball.xSpeed *= -1.0;
                        ball.xSpeed += paddle.xSpeed;
                        ball.xPos = oldX;
                    }
                }
                
                double oldY = ball.yPos;
                ball.MoveY(deltatime);
                adjacentTile = tiles[(int)ball.xPos, (int)ball.yPos];
                if(adjacentTile != null && adjacentTile.CollidesWith(ball))
                {
                    ball.ySpeed *= -1.0;
                    ball.yPos = oldY;
                }
                foreach(Paddle paddle in paddles)
                {
                    if(paddle.CollidesWith(ball))
                    {
                        ball.ySpeed *= -1.0;
                        ball.ySpeed += paddle.ySpeed;
                        ball.yPos = oldY;
                    }
                }
            }
            foreach(Paddle p in paddles)
            {
                double oldX = p.xPos;
                p.MoveX(deltatime);
                //Detect whether the paddle is trying to move outside the gameboard
                if(p.xPos < 2.0 || (p.xPos + p.Width) >= this.width - 1)
                {
                    p.xPos = oldX;
                    p.xSpeed = 0;
                }
                
                double oldY = p.yPos;
                p.MoveY(deltatime);
                if(p.yPos < 2.0 || (p.yPos + p.Height) >= this.height - 1)
                {
                    p.yPos = oldY;
                    p.ySpeed = 0;
                }
            }
            
        }
    }
}
