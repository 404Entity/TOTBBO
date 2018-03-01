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
    class SpriteRenderer:Component ,IDrawable,ILoadable
    {
        private Rectangle rectangle;
        private Texture2D sprite;
        private float scale;
        private Vector2 offset;
        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
        private string spriteName;
        private float layerDepth;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public SpriteRenderer(GameObject gameobject, string spriteName, float layerDepth, float scale) : base(gameobject)
        {
            this.layerDepth = layerDepth;
            this.spriteName = spriteName;
            this.scale = scale;
        }
        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GameObject.Transform.Position + offset, rectangle, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
        }

    }
}
