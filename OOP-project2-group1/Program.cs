using System;
using System.Collections.Generic;
using System.Diagnostics; //Stopwatch
using System.Threading;

namespace MJU20BreakoutClone
{
    public delegate void ASCIIrenderer(string msg);
    
    class Program
    {
        private static GamePlane gamePlane;
        const double targetFrameRate = 5.0; //placeholder value for testing
        const long millisecondsPerSecond = 1000;
        const long targetFrameDelay = (long)(millisecondsPerSecond / targetFrameRate);
        
        static void getGameInputs()
        {
            //NYI
        }
        
        static void updateGameState(double deltatime)
        {
            //NYI
        }
        
        static void renderGame()
        {
            //TODO: Only re-render locations that have changed since the last frame
            gamePlane.RenderObjects();
        }
        
        static void Main(string[] args)
        {
            //Set up console
            Console.Clear();
            Console.CursorVisible = false;
            
            //Initialize game state
            gamePlane = new GamePlane(20, 10); //gamePlane = new GamePlane(Console.WindowWidth, Console.WindowHeight);
            bool running = true;
            Stopwatch stopwatch = Stopwatch.StartNew();
            long previousFrameTime;
            long currentFrameTime = stopwatch.ElapsedMilliseconds;
            
            //Main game loop
            while(running)
            {
                previousFrameTime = currentFrameTime;
                currentFrameTime = stopwatch.ElapsedMilliseconds;
                long frameDelay = currentFrameTime - previousFrameTime;
                double deltatime = (double)frameDelay;
                
                getGameInputs();
                updateGameState(deltatime);
                renderGame();
                
                if(frameDelay < targetFrameDelay)
                {
                    //Thread.Sleep((int)(targetFrameDelay - frameDelay));
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
