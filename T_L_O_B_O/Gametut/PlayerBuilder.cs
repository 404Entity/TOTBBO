using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gametut
{
    class PlayerBuilder : IBuilder
    {
        private GameObject buildObject;
        public void BuildGameObject(Vector2 position)
        {
            GameObject Player = new GameObject();            
            Player.AddComponent(new Transform(Player, position));
            Player.AddComponent(new SpriteRender(Player, "HeroSheet", 1));
            Player.AddComponent(new Animator(Player));
            Player.AddComponent(new Player(Player));
            Player.AddComponent(new Collider(Player,true));
            buildObject = Player;
        }

        public GameObject GetResult()
        {
            return buildObject;
        }
    }
}
