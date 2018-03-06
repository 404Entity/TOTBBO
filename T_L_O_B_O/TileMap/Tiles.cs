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
    class Tiles: IDrawable, ILoadable
    {

        protected Texture2D texture;
        private List<Texture2D> picList = new List<Texture2D>();
        protected Rectangle rectangle;
        Map map;

        int i;


        public Tiles(int i, Rectangle newRectangle, Map map)
        {
            this.i = i;
            this.Rectangle = newRectangle;
            this.map = map;
        }

        public Tiles(GameObject gameObject)
        {
        }

        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }




        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Map" + i.ToString());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
