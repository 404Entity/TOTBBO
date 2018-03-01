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
    class Enemy:Component
    {
        float speed;
        Animator animator;
        IStrategy strategy;
        DIRECTION direction;
        bool canMove;

        public Enemy()
        {

        }

        public void Update()
        {

        }

        public void LoadContent(ContentManager content)
        {

        }

        public void CreateAnimations()
        {

        }
    }
}
