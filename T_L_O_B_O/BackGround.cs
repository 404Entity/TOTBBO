using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace T_L_O_B_O
{
    class BackGround : ILoadable, IDrawable
    {
        Texture2D backGround;
        

        public void LoadContent(ContentManager content)
        {
            backGround = content.Load<Texture2D>("BackGround");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 5; i++)
            {
                spriteBatch.Draw(backGround, new Vector2(i*1024, -80), Color.White);
            }
        }
    }
}
