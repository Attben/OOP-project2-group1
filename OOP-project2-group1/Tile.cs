using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    public delegate void TileCallback(Tile t);
    
    public abstract class Tile : Rectangle
    {
        public string graphicalRepresentation{get; protected set;}
        //protected bool isDestructible;
        
        //Default values are arbitrary.
        public Tile(string ascii, double x = 0, double y = 0, uint width = 1, uint height = 1)
        : base(x, y, width, height)
        {
            graphicalRepresentation = ascii;
        }
        
        public virtual void Render()
        {
            //Assuming that "rendering" takes place in text console.
            Console.SetCursorPosition((int)xPos, (int)yPos);
            Console.Write(graphicalRepresentation);
        }
    }
}
