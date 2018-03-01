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
    class Collider:Component
    {
        SpriteRenderer spriteRenderer;
        Texture2D texture2D;
        List<Collider> otherColliders = new List<Collider>();
        Animator animator;
        bool doCollisionChecks;
        Dictionary<string, Color[][]> pixel = new Dictionary<string, Color[][]>();

        public Collider(GameObject gameObject, bool doCollisionChecks): base(gameObject)
        {
            this.DoCollisionChecks = doCollisionChecks;
        }

        public Rectangle GetCollisionBox
        {
            get
            {
                return new Rectangle((int)(GameObject.Transform.Position.X + spriteRenderer.Offset.X), (int)(GameObject.Transform.Position.Y + spriteRenderer.Offset.Y), spriteRenderer.Rectangle.Width, spriteRenderer.Rectangle.Height);
            }
        }

        public bool DoCollisionChecks { get => doCollisionChecks; set => doCollisionChecks = value; }




        
        public void LoadContent(ContentManager content)
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sprite)
        {

        }

        public void CheckCollision()
        {

        }

        public void OnCollisionStay(Collider other)
        {

        }

        public void OnCollisionEnter(Collider other)
        {

        }

        public void OnCollisionExit(Collider other)
        {

        }

        public void CachePixels()
        {

        }
    }
}
