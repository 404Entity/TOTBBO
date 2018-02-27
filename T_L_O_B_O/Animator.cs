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
    class Animator:GameObject
    {
        #region fields
        SpriteRenderer spriteRenderer;
        int currentIndex;
        float timeElapsed;
        float fps;
        Rectangle[] rectangles;
        string animationName;
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        #region constructers
        public Animator(GameObject gameObject): base(gameObject)
        {

        }



        #endregion
        #endregion


        #region property
        public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }
        public float Fps { get => fps; set => fps = value; }
        public Rectangle[] Rectangles { get => rectangles; }








        #endregion

        #region Methods
        public void Update()
        {

        }

        public void CreateAnimation(string name, Animation animation)
        {

        }




        #endregion
    }
}
