using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace T_L_O_B_O
{
    class Tiles : IDrawable, ILoadable
    {

        protected Texture2D texture;
        private List<Texture2D> picList = new List<Texture2D>();
        //public static ContentManager content;
        protected Rectangle rectangle;
        Map map;

        int i;


        public Tiles(int i, Rectangle newRectangle, Map map)
        {
            this.i = i;
            this.Rectangle = newRectangle;
            this.map = map;
            //picList.Add(content.Load<Texture2D>("Map" + i.ToString()));
        }

        public Tiles()
        {
        }

        protected Rectangle Rectangle { get => rectangle; set => rectangle = value; }




        public void LoadContent(ContentManager content)
        {
            //map.LoadContent(content);


            texture = content.Load<Texture2D>("Map" + i.ToString());
            // picList.Add(content.Load<Texture2D>("Map" + i.ToString()));


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*
            foreach (Texture2D tex in picList)
            {
                spriteBatch.Draw(tex, rectangle, Color.White);
            }
            */
            spriteBatch.Draw(texture, rectangle, Color.White);
            //map.Draw(spriteBatch);
        }
    }
}
