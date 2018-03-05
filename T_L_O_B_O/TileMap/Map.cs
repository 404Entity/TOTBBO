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
        int tileSize = 50;
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
        public void Generate(int[,] map, int height, int width,ContentManager content)
        {
            Director director = new Director(new WorldBuilder());

            int size = height*width;
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        if (number == 1)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        else if (number == 2)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        else if (number == 3)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        else if (number == 4)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        else if (number == 5)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize),this));
                        
                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                }
            }
            foreach (Tiles tile in tileList)
            {
                tile.LoadContent(content);
            }
        }

        public void LoadContent(ContentManager content)
        {
            TileList = new List<Tiles>();
            Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},

            }, 10,40,content);
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
