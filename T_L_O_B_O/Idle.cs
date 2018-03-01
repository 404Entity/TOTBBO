﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gametut
{
    class Idle : IStrategy
    {
        private Animator animator;
        public Idle(Animator animator)
        {
            this.animator = animator;
        }

        public void Execute(DIRECTION ref_direction)
        {
            animator.playAnimation("Idle" + ref_direction);
        }
    }
}
