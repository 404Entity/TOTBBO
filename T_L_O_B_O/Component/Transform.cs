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
    class Transform : Component
    {
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Transform(GameObject gameobject, Vector2 position) :base(gameobject)
        {
            this.position = position;
            gameobject.Transform = this;
        }
        public void Translate(Vector2 translation)
        {
            position += translation;
        }
    }
}
