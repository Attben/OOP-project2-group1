﻿using System;

namespace Paddletest
{
    
        
        class Program
        {
            private class Paddle : IndestructibleTile, IMobile
            {
                public Paddle(double x, double y, double xs, double ys) : base("====================", x, y)
            {
                    this.xSpeed = xs;
                    this.ySpeed = ys;
                }
                public double xSpeed { get; set; }
                public double ySpeed { get; set; }
                public void MoveX(double deltatime)
                {
                    this.xPos += this.xSpeed * deltatime;
                }
                public bool ballRelease;
                public void checkKey()
                {
                    ConsoleKeyInfo cki;
                    while (true)
                    {
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.D)
                        {
                            this.xSpeed = 2;
                            
                        }
                        if(cki.Key == ConsoleKey.A)
                        {
                           this.xSpeed = -2;
                        }
                        if(cki.Key == ConsoleKey.Spacebar && gameState == 1)
                        {
                        ballRelease = true;
                        }
                        if (cki.Key == ConsoleKey.Escape)
                            break;
                    }
                }
            }
        }
    
}
