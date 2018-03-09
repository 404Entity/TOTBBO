using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace T_L_O_B_O
{
    class Scissor : Component, ILoadable, IUpdateable, IAnimateable
    {
        private float speed;
        private Animator animator;
        private IStrategy strategy;
        private DIRECTION _direction;


        public Scissor(GameObject gameObject): base(gameObject)
        {
            animator = (Animator)gameObject.GetComponent("Animator");
            _direction = DIRECTION.Left;
            speed = 10;
        }
        

        public void LoadContent(ContentManager content)
        {
            CreateAnimation();
        }

        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("IdleLeft"))
            {
                _direction = DIRECTION.Right;
                strategy = new Walk(animator,gameObject.Transform,speed);
                strategy.Execute(_direction);
            }
            else if (animationName.Contains("IdleRight"))
            {
                _direction = DIRECTION.Left;
                strategy = new Walk(animator, gameObject.Transform, speed);
                strategy.Execute(_direction);
            }
            else if (animationName.Contains("Walkleft"))
            {
                strategy = new Idle(animator);
                strategy.Execute(_direction);
            }
            else if (animationName.Contains("WalkRight"))
            {
                strategy = new Idle(animator);
                strategy.Execute(_direction);
            }
        }
        public void CreateAnimation()
        {
            animator.CreateAnimation("WalkLeft", new Animation(5, 0, 0, 371, 380, 5, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(5, 374, 0, 371, 380, 5, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(2, 0, 0, 371, 380, 2, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(2, 374, 0, 371, 380, 2, Vector2.Zero));
            animator.PlayAnimation("IdleLeft");
        }
        public void Update()
        {
            if (strategy == null)
            {
                strategy = new Idle(animator);
                //strategy = new Detect();
            }
            if (strategy is Walk)
            {
                Vector2 translation = Vector2.Zero;
                if (this._direction == DIRECTION.Left)
                {
                    translation = new Vector2(-2f, 0);
                }
                else if (this._direction == DIRECTION.Right)
                {
                    translation = new Vector2(2f, 0);
                }
                gameObject.Transform.Translate(translation * GameWorld.Instance.deltaTime * speed);
            }
        }
    }
}
