using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace T_L_O_B_O
{
    class SpriteRenderer:Component
    {
        Rectangle rectangle;
        Texture2D texture2D;
        string spriteName;
        float layerDepth;
        GameObject gameObject;
        Vector2 offset;

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth): base(gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
        }

        public Vector2 Offset { get => offset; set => offset = value; }
        public Texture2D Texture2D { get => texture2D;}
        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }



        public void Update()
        {

        }

        public void LoadContent(ContentManager content)
        {
            texture2D = content.Load<Texture2D>(spriteName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, gameObject.Transform.GetTransform, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }

    }
}
