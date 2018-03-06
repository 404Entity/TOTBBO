using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace T_L_O_B_O
{
    class EnemyBuilder : IBuilder
    {
        private GameObject buildobject;
        public void BuildGameObject(Vector2 position)
        {
            GameObject slime = new GameObject();
            slime.AddComponent(new Transform(slime, position,1));
            slime.AddComponent(new SpriteRenderer(slime, "SlimeSheet", 1, 0.5f));
            slime.AddComponent(new Animator(slime));
            slime.AddComponent(new Enemy(slime));
            slime.LoadContent(GameWorld.Instance.Content);
            slime.AddComponent(new Collider(slime, false, 2));
            buildobject = slime;
        }

        public GameObject GetResult()
        {
            return buildobject;
        }
    }
}
