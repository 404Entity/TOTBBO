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
    class SpriteRenderer:Component, IDrawable,IUpdateable,ILoadable
    {
        Rectangle rectangle;
        Texture2D texture2D;
        string spriteName;
        float layerDepth;
        GameObject gameObject;
        Vector2 offset;
        float scale;

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth, float scale): base(gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
            this.gameObject = gameObject;
            this.scale = scale;
        }

        public Vector2 Offset { get => offset; set => offset = value; }
        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
        public Texture2D Texture2D { get => texture2D; set => texture2D = value; }

        public void Update()
        {

        }

        public void LoadContent(ContentManager content)
        {
            Texture2D = content.Load<Texture2D>(spriteName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture2D, gameObject.Transform.Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
        }

    }
}
