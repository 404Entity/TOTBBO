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
    class PlayerBuilder:IBuilder
    {
        private GameObject buildObject;
public void BuildGameOBject(Vector2 position)
        {
            ///<summary>
            ///Builds the players Gameobject with the right Components
            /// </summary>
            GameObject Player = new GameObject();
            Player.AddComponent(new Transform(Player,position));
            Player.AddComponent(new SpriteRenderer(Player, "Missing", 1));
            Player.AddComponent(new Animator(Player));
            Player.AddComponent(new Player(Player));
            Player.AddComponent(new Collider(Player, true));
            buildObject = Player;
        }

        public GameObject GetResult()
        {
            //returns the build obejct.
            return buildObject;
        }
    }
}
