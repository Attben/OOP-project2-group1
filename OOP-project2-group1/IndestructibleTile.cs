using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    class IndestructibleTile : Tile
    {
        // "| , -" Char example for tiles
        
        public IndestructibleTile(string ascii, double x, double y, uint width = 1, uint height = 1)
        : base(ascii, x, y, width, height) { }
    }
}
