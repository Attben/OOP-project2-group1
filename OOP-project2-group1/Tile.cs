using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    abstract class Tile : Rectangle
    {
        public string graphicalRepresentation{get; protected set;}
        //protected bool isDestructible;
        
        public Tile(string ascii, int x = 0, int y = 0, int width = 0, int height = 0)
        : base(x, y, width, height)
        {
            graphicalRepresentation = ascii;
        }
    }
}
