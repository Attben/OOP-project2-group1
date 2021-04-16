using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20BreakoutClone
{
    class DestructibleTile : Tile
    {
        public DestructibleTile(string ascii) : base(ascii){ }
        
        public void Destroy()
        {
            //NYI | explosion?
            graphicalRepresentation = "";
        }
    }
}
