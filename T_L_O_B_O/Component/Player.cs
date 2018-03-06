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
    enum DIRECTION { Back, Right, Front, Left };
    class Player : Component, IUpdateable, ILoadable, IAnimateable, ICollisionStay, IGravity, ICollisionExit, ICollisionEnter
    {
        #region Fields
        private float speed;
        private Animator animator;
        private IStrategy strategy;
        private DIRECTION direction;
        private bool canMove;
        private bool isgrounded;
        #endregion
        #region Constructor
        public Player(GameObject gameobject) : base(gameobject)
        {
            speed = 100;
            direction = DIRECTION.Front;
            animator = (gameobject.GetComponent("Animator") as Animator);
            canMove = true;
            isgrounded = false;
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
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.A))
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
                        strategy = new Walk(animator, gameObject.Transform, speed);
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
            Fall(isgrounded);
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
            Collider collider = (Collider)gameObject.GetComponent("Collider");

            if (collider.CollisionBox.Bottom >= other.CollisionBox.Top && collider.CollisionBox.Bottom - 20 <= other.CollisionBox.Top)
            {
                isgrounded = true;
                gameObject.Transform.Translate(new Vector2(0, other.CollisionBox.Top - collider.CollisionBox.Bottom + 1));
            }
            else if (collider.CollisionBox.Right >= other.CollisionBox.Left && collider.CollisionBox.Right - 10 <= other.CollisionBox.Left)
            {
                gameObject.Transform.Translate(new Vector2(other.CollisionBox.Left - collider.CollisionBox.Right + 1, 0));
            }
            else if (collider.CollisionBox.Left <= other.CollisionBox.Right && collider.CollisionBox.Left + 10 >= other.CollisionBox.Right)
            {
                gameObject.Transform.Translate(new Vector2(collider.CollisionBox.Left - other.CollisionBox.Right + 1, 0));
            }
            else if (collider.CollisionBox.Top <= other.CollisionBox.Bottom && collider.CollisionBox.Top + 10 >= other.CollisionBox.Bottom)
            {
                gameObject.Transform.Translate(new Vector2(other.CollisionBox.Top - collider.CollisionBox.Top, 0));
            }
        }

        public void Fall(bool isgrounded)
        {
            if (!isgrounded)
            {
                GameObject.Transform.Translate(new Vector2(0, 9.82f));
            }
        }

        public void OnCollisionExit(Collider other)
        {
            isgrounded = false;
        }

        public void OnCollisionEnter(Collider other)
        {
            /*
            Collider collider = (Collider)gameObject.GetComponent("Collider");

            if (collider.CollisionBox.Bottom >= other.CollisionBox.Top && collider.CollisionBox.Bottom - 10 <= other.CollisionBox.Top)
            {
                isgrounded = true;
                gameObject.Transform.Translate(new Vector2(0, other.CollisionBox.Top - collider.CollisionBox.Bottom + 1));
            }
            else if (collider.CollisionBox.Right >= other.CollisionBox.Left && collider.CollisionBox.Right - 10 <= other.CollisionBox.Left)
            {
                gameObject.Transform.Translate(new Vector2(other.CollisionBox.Left - collider.CollisionBox.Right - 1));
            }
            */
        }
        #endregion
    }
}
