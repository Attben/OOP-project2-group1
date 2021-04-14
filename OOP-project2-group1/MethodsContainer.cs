using System;


namespace MJU20BreakoutClone
{
    public static class MethodsContainer
    {

        public static void UserInput()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow://TODO paddle moves left
                    break;
                case ConsoleKey.RightArrow://TODO Paddle Moves Right
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.Write("Game is closed.");
                    return;
                default:
                    break;
            }
            
        }
    }
}
