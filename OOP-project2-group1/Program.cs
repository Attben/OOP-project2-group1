using System;
using System.Collections.Generic;
using System.Diagnostics; //Stopwatch
using System.Threading;

namespace MJU20BreakoutClone

{
    class Program
    {
		const double targetFrameRate = 1.0;
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
			//NYI
		}
		
        static void Main(string[] args)
        {
            bool running = true;
			Stopwatch stopwatch = Stopwatch.StartNew();
			long previousFrameTime;
			long currentFrameTime = stopwatch.ElapsedMilliseconds;
			
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
					Thread.Sleep((int)(targetFrameDelay - frameDelay));
				}
			}
        }
    }
}
