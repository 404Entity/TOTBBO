using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace T_L_O_B_O
{
    class Map:IDrawable, ILoadable
    {
        //Fields
        List<Tiles> tileList = new List<Tiles>();
        int tileSize = 100;
        int width, height;

        //Constructor
        public Map()
        {
        }



        //Properties
        public List<Tiles> TileList { get => tileList; set => tileList = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        
        
        //Methods
        public void Generate(int[,] map, int height, int width)
        {
            int size = height*width;
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            Generate(new int[,]
            {
                {1,0,1,2,1,0,1,2,1,0},
                {0,1,2,1,0,1,2,1,0,1},
                {1,0,1,2,1,0,1,2,1,0},
                {2,1,0,1,2,1,0,1,2,1},
                {1,2,1,0,1,2,1,0,1,2},

            }, 5,10);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tiles T in TileList)
            {
                T.Draw(spriteBatch);
            }
        }

        
    }
}
