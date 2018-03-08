using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace T_L_O_B_O
{
    class Scissor : ILoadable, IUpdateable, IAnimateable
    {
        private Animator animator;
        private IStrategy strategy;
        private DIRECTION _direction;

        
        public Scissor()
        {
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void OnAnimationDone(string animationName)
        {
            throw new NotImplementedException();
        }
        public void CreateAnimation()
        {

        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
