using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    class DestructibleTile : Tile
    {
        // "| , -" Char example for tiles
        
        public DestructibleTile(string ascii) : base(ascii){ }
        
        public void Destroy()
        {
            //NYI
        }
    }
}
