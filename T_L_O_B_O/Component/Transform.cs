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
    class Transform : Component, IUpdateable
    {
        private Vector2 position;
        int gravity;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Transform(GameObject gameobject, Vector2 position, int gravity) :base(gameobject)
        {
            this.position = position;
            gameobject.Transform = this;
            this.gravity = gravity;
        }
        public void Translate(Vector2 translation)
        {
            position += translation;
        }

        public void Update()
        {
            //position.Y += gravity;
        }
    }
}
