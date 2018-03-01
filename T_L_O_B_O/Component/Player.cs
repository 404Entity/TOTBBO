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
    class Player:Component, IUpdateable
    {
        float speed;
        Animator animator;
        IStrategy strategy;
        DIRECTION direction;
        bool canMove = true;

        public Player(GameObject gameObject)
        {
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (canMove)
            {
                if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.D))
                {
                    if (!(strategy is Walk))
                    {
                        strategy = new Walk(animator, GameObject.Transform);
                    }
                }
                else
                {
                    strategy = new Idle(animator);
                }
                if (keyState.IsKeyDown(Keys.E))
                {
                    strategy = new Attack(animator);
                }
                if (keyState.IsKeyDown(Keys.Space))
                {
                    strategy = new Jump(animator);
                }
            }
        }

        public void LoadContent(ContentManager content)
        {

        }

        public void CreateAnimations()
        {

        }
    }
}
