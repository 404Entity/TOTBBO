using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_L_O_B_O
{
    class Walk : IStrategy
    {
        Animator animator;
        Transform transform;

        public Walk(Animator animator, Transform transform, float speed)
        {
            this.animator = animator;
            this.transform = transform;
        }

        public void Execute(DIRECTION direction)
        {
            animator.PlayAnimation("Walk" + direction);
        }
    }
}
