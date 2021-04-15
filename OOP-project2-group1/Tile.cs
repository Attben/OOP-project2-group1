using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    abstract class Tile : Rectangle
    {
        public string graphicalRepresentation{get; protected set;}
        //protected bool isDestructible;
        
        //Default values are arbitrary.
        public Tile(string ascii, double x = 0, double y = 0, uint width = 1, uint height = 1)
        : base(x, y, width, height)
        {
            graphicalRepresentation = ascii;
        }
    }
}
