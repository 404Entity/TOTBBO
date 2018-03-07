using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace T_L_O_B_O
{
    class Walk : IStrategy
    {
        private Animator animator;
        private Transform transform;
        private float speed;
        public Walk(Animator animator, Transform transform, float speed)
        {
            this.animator = animator;
            this.transform = transform;
            this.speed = speed;
        }
        public void Execute(DIRECTION ref_direction)
        {
            Vector2 translation = Vector2.Zero;
            if (ref_direction == DIRECTION.Right)
            {
                translation += new Vector2(2, 0);
                animator.PlayAnimation("WalkRight");
            }
            if (ref_direction == DIRECTION.Left)
            {
                translation += new Vector2(-2, 0);
                animator.PlayAnimation("WalkLeft");
            }
            if (ref_direction == DIRECTION.Back)
            {
                translation += new Vector2(0, -2);
                animator.PlayAnimation("WalkBack");
            }
            if (ref_direction == DIRECTION.Front)
            {
                translation += new Vector2(0, 2);
                animator.PlayAnimation("WalkFront");
            }
            transform.Translate(translation * GameWorld.Instance.deltaTime * speed);
        }
    }
}
