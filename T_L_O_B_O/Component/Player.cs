using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace T_L_O_B_O
{
    enum DIRECTION {Back,Right,Front,Left};
    class Player : Component, IUpdateable, ILoadable, IAnimateable, ICollisionStay
    {
        #region Fields
        private float speed;
        private Animator animator;
        private IStrategy strategy;
        private DIRECTION direction;
        private bool canMove;
        #endregion
        #region Constructor
        public Player(GameObject gameobject) : base(gameobject)
        {
            speed = 100;
            direction = DIRECTION.Front;
            animator = (gameobject.GetComponent("Animator") as Animator);
            canMove = true;
        }
        #endregion
        #region Methods
        public void LoadContent(ContentManager Content)
        {
            CreateAnimation();
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (canMove)
            {
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.D)||keyState.IsKeyDown(Keys.S)||keyState.IsKeyDown(Keys.A))
                {
                    if (keyState.IsKeyDown(Keys.W))
                    {
                        direction = DIRECTION.Back;
                    }
                    else if (keyState.IsKeyDown(Keys.D))
                    {
                        direction = DIRECTION.Right;
                    }
                    else if (keyState.IsKeyDown(Keys.S))
                    {
                        direction = DIRECTION.Front;
                    }
                    else if (keyState.IsKeyDown(Keys.A))
                    {
                        direction = DIRECTION.Left;
                    }
                    if (!(strategy is Walk))
                    {
                        strategy = new Walk(animator,gameObject.Transform,speed);
                    }
                }
                else
                {
                    strategy = new Idle(animator);
                }
                if (keyState.IsKeyDown(Keys.Space))
                {
                    strategy = new Attack(animator);
                }
                strategy.Execute(direction);
            }
            
       
        }
        public void CreateAnimation()
        {
            animator.CreateAnimation("IdleFront", new Animation(4, 0, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleBack", new Animation(4, 0, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(4, 0, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(4, 0, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkFront", new Animation(4, 150, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkBack", new Animation(4, 150, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkLeft", new Animation(4, 150, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(4, 150, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("AttackFront", new Animation(4, 300, 0, 145, 160, 8, new Vector2(-50, 0)));
            animator.CreateAnimation("AttackBack", new Animation(4, 465, 0, 170, 155, 8, new Vector2(-20, 0)));
            animator.CreateAnimation("AttackRight", new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero));
            animator.CreateAnimation("AttackLeft", new Animation(4, 770, 0, 150, 150, 8, new Vector2(-60, 0)));
            animator.CreateAnimation("DieFront", new Animation(3, 920, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieBack", new Animation(3, 920, 3, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));
            animator.PlayAnimation("IdleFront");
        }

        public void OnAnimationDone(string animationName)
        {
            if (animationName == null)
            {
                animationName = "Idle";
            }
            if (animationName.Contains("Attack"))
            {
                //promt i finished an attack

            }
        }

        public void OnCollisionStay(Collider other)
        {
            if (strategy is Attack && (Enemy)other.GameObject.GetComponent("Enemy") != null)
            {
                GameWorld.Instance.RemoveList.Add(other.GameObject);
            }
        }
        #endregion
    }
}
