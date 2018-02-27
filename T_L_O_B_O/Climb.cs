using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_L_O_B_O
{
    class Climb:IStrategy
    {
        Animator animator;

        public Climb(Animator animator)
        {
            this.animator = animator;
        }

        public void Execute(DIRECTION direction)
        {
            throw new NotImplementedException();
        }
    }
}
