using System;
using System.Collections.Generic;

namespace MJU20BreakoutClone
{
    class GamePlane
    {
        Tile[,] tiles;
        
        public GamePlane(uint width, uint height)
        {
            //Initialize border tiles
            tiles = new Tile[width, height];
            
            //Corners
            tiles[0, 0] = new IndestructibleTile("╔");
            tiles[width-1, 0] = new IndestructibleTile("╗");
            tiles[0, height-1] = new IndestructibleTile("╚");
            tiles[width-1, height-1] = new IndestructibleTile("╝");
            
            //Top and bottom
            for(int n = 1; n < (width - 1); ++n)
            {
                tiles[n, 0] = new IndestructibleTile("═");
                tiles[n, height-1] = new IndestructibleTile("═");
            }
            
            //Left and right
            for(int n = 1; n < (height - 1); ++n)
            {
                tiles[0, n] = new IndestructibleTile("║");
                tiles[width-1, n] = new IndestructibleTile("║");
            }
            //var rectangleListofBorders = new List<Rectangle>;
            //Rectangle MygameplaneArea = new Rectangle();
        }
        
        public void RenderObjects(){
            Console.SetCursorPosition(0, 0);
            for(int height = 0; height < tiles.GetLength(1); ++height){
                for(int width = 0; width < tiles.GetLength(0); ++width)
                {
                    string charsToRender = 
                    (tiles[width, height] == null ? " " : tiles[width, height].graphicalRepresentation);
                    Console.Write(charsToRender);
                }
                Console.WriteLine();
            }
        }
    }
}
