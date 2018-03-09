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
                        if (number == 7)
                        {
                            director = new Director(new ScissorBuilder());
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize)));
                        }
                        else
                        {
                            AddtoTiles(x, y, number);
                        }
                        //there is a bad smell here So i made a metode to solve the issue.
                        /*
                        if (number == 1)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize),1));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        else if (number == 2)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize),2));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        else if (number == 3)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize),3));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        else if (number == 4)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize),4));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        else if (number == 5)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize),5));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        else if (number == 6)
                        {
                            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize), 6));
                            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
                        }
                        */
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
        private void AddtoTiles( int x, int y, int number)
        {
            // small bit of code Refactoring
            Director director = new Director(new WorldBuilder());
            GameWorld.Instance.AddList.Add(director.Construct(new Vector2(x * tileSize, y * tileSize), number));
            tileList.Add(new Tiles(number, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), this));
        }
        public void LoadContent(ContentManager content)
        {
            TileList = new List<Tiles>();
            Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,3,5,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,3,4,0,0,0,0,0,0,0,0,0,0,0,0},
                {6,6,6,6,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,5,5,3,3,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,6,4,4,4,4,3,3,3,3,4,4,5,5,5,5,6,0,0,0,0,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,0,0,0,0,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,7,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,7,0,0,7,0,0,0,0,0,0},
                {1,2,2,1,2,2,2,2,2,2,1,1,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {5,3,4,4,5,5,4,3,4,4,4,3,3,4,5,4,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {2,2,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},

            }, 12,40,content);
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
