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
    class ScissorBuilder : IBuilder
    {
        private GameObject buildObject;
        public void BuildGameOBject(Vector2 position)
        {
            GameObject Scissor = new GameObject();
            Scissor.AddComponent(new Transform(Scissor, position,1));
            Scissor.AddComponent(new SpriteRenderer(Scissor, "s", 1, 0.5f));
            Scissor.AddComponent(new Animator(Scissor));
            //Scissor.AddComponent(new Scissor);
            Scissor.AddComponent(new Collider(Scissor, false,1));
            buildObject = Scissor;
        }

        public void BuildGameObject(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public GameObject GetResult()
        {
            return buildObject;
        }
    }
}
