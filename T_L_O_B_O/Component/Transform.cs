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
    class Transform:Component
    {
        protected Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Transform(GameObject gameObject, Vector2 position)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {

        }
    }
}
