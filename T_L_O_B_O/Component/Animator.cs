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
    class Animator:Component,IUpdateable,ILoadable
    {
        #region fields
        SpriteRenderer spriteRenderer;
        int currentIndex;
        float timeElapsed;
        float fps;
        Rectangle[] rectangles;
        string animationName;
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        #endregion
        #region constructers
        public Animator(GameObject gameObject): base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
        }



        
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
            timeElapsed += GameWorld.GetInstance.DeltaTime;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }

            spriteRenderer.Rectangle = rectangles[currentIndex];
        }

        public void CreateAnimation(string name, Animation animation)
        {

        }

        public void PlayAnimation(string animationName)
        {
            this.animationName = animationName;
        }

        public void LoadContent(ContentManager content)
        {
            int width = spriteRenderer.Texture2D.Width / 4;

            rectangles = new Rectangle[4];

            for (int i = 0; i < 4; i++)
            {
                rectangles[i] = new Rectangle(i * width, 0, width, spriteRenderer.Texture2D.Height);
            }
        }




        #endregion
    }
}
