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
    class Collider : Component, IDrawable, ILoadable, IUpdateable, ICollisionStay, ICollisionEnter, ICollisionExit
    {
        #region Fields and properties
        private SpriteRenderer spriteRender;
        private Texture2D texture2D;
        private bool isCollideWith;
        private List<Collider> ohterColliders;
        private Animator animator;
        private Dictionary<string, Color[][]> pixels;
        private bool doCollisionChecks;
        public bool DoCollisionChecks
        {
            set { doCollisionChecks = value; }
        }
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                (
                    (int)(GameObject.Transform.Position.X + spriteRender.Offset.X),
                    (int)(gameObject.Transform.Position.Y + spriteRender.Offset.Y),
                    spriteRender.Rectangle.Width,
                    spriteRender.Rectangle.Height
               );
            }
        }
        #endregion
        #region Constructor
        public Collider(GameObject gameObject, bool CheckCollision) : base(gameObject)
        {
            isCollideWith = false;
            doCollisionChecks = CheckCollision;
            GameWorld.Instance.Colliders.Add(this);
            LoadContent(GameWorld.Instance.Content);
            ohterColliders = new List<Collider>();
        }
        #endregion

        #region Draw and LoadContent
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);


            if (isCollideWith)
            {
                spriteBatch.Draw(texture2D, topLine, null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, bottomLine, null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, rightLine, null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, leftLine, null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 1);

            }
            else
            {
                spriteBatch.Draw(texture2D, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
                spriteBatch.Draw(texture2D, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);

            }
        }

        public void LoadContent(ContentManager Content)
        {
            spriteRender = (SpriteRenderer)gameObject.GetComponent("SpriteRender");
            texture2D = Content.Load<Texture2D>("CollisionTexture");
        }
        public void Update()
        {
            CheckCollision();

        }
        #endregion

        #region Collision
        private void CheckCollision()
        {
            if (doCollisionChecks)
            {
                List<Collider> removelist = new List<Collider>();
                foreach (Collider collider in ohterColliders)
                {

                    if (!CollisionBox.Intersects(collider.CollisionBox))
                    {
                        OnCollisionExit(collider);
                        removelist.Add(collider);
                    }
                }
                foreach (Collider item in removelist)
                {
                    ohterColliders.Remove(item);
                }
                foreach (Collider collider in GameWorld.Instance.Colliders)
                {
                    if (collider != this)
                    {
                        if (CollisionBox.Intersects(collider.CollisionBox))
                        {
                            OnCollisionEnter(collider);
                        }
                    }
                }
            }
        }

        public void OnCollisionStay(Collider other)
        {
            other.isCollideWith = true;
        }

        public void OnCollisionExit(Collider other)
        {
            other.isCollideWith = false;
        }

        public void OnCollisionEnter(Collider other)
        {
            ohterColliders.Add(other);
            gameObject.OnCollisionStay(other);
        }

        private void CachePixels()
        {
            foreach (KeyValuePair<string,Animation> pair in animator.MyAnimations)
            {
                Animation animation = pair.Value;
                Color[][] colors = new Color[(int)animation.Fps][];

                for (int i = 0; i < (int)animation.Fps; i++)
                {
                    colors[i] = new Color[animation.Rectangles[i].Width * animation.Rectangles[i].Height];
                    spriteRender.Sprite.GetData(0, animation.Rectangles[i], colors[i], 0, animation.Rectangles[i].Width * animation.Rectangles[i].Height);
                }
                pixels.Add(pair.Key, colors);
            }
        }
        #endregion
    }
}
