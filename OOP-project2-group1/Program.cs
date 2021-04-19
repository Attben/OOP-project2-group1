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
        const double targetFrameRate = 30.0;
        const long millisecondsPerSecond = 1000;
        const long targetFrameDelay = (long)(millisecondsPerSecond / targetFrameRate);
        
        static void GetGameInputs()
        {
            if(Console.KeyAvailable)
            {
                gamePlane.HandleInputs(Console.ReadKey(true));
            }
            else
            {
                gamePlane.HandleEmptyInput();
            }
        }
        
        static void UpdateGameState(double deltatime)
        {
            gamePlane.UpdateGameState(deltatime);
        }
        
        static void RenderGame()
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
            gamePlane = new GamePlane(60, 30);
            //gamePlane = new GamePlane(Console.WindowWidth, Console.WindowHeight);
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
                //Dividing by an arbitrary scaling factor to give deltatime a more desirable size
                double deltatime = frameDelay / 1000.0;
                
                GetGameInputs();
                UpdateGameState(deltatime);
                RenderGame();
                
                if(frameDelay < targetFrameDelay)
                {
                    Thread.Sleep((int)(targetFrameDelay - frameDelay));
                }
            }
        }
    }
}
