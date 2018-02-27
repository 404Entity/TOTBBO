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
    abstract class Component
    {
        GameObject gameObject;


        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public Component()
        {

        }

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
