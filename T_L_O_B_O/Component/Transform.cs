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
        Vector2 position;

        public Transform(Vector2 transform, GameObject gameObject)
        {
            this.position = transform;
        }

        public Vector2 GetTransform { get => position; set => position = value; }

        public void Translate(Vector2 translation)
        {

        }
    }
}
