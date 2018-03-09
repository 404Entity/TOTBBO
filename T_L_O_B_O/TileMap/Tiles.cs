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

        private Texture2D texture;
        protected Rectangle rectangle;
        Map map;

        int i;


        public Tiles(int i, Rectangle newRectangle, Map map)
        {
            this.i = i;
            this.Rectangle = newRectangle;
            this.map = map;
        }
        

        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
        public Texture2D Texture { get => texture; set => texture = value; }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("Map" + i.ToString());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }
    }
}
