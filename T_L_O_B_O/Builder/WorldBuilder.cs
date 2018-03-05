using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace T_L_O_B_O
{
    class WorldBuilder : IBuilder
    {
        private GameObject buildobject;
        public void BuildGameObject(Vector2 position)
        {
            GameObject worldBuilder = new GameObject();
            worldBuilder.AddComponent(new Transform(worldBuilder, position));
            worldBuilder.AddComponent(new SpriteRenderer(worldBuilder, "Map1", 1, 0.5f));
            //worldBuilder.AddComponent(new Tiles(worldBuilder));
            worldBuilder.LoadContent(GameWorld.Instance.Content);
            worldBuilder.AddComponent(new Collider(worldBuilder, true, 1));
            buildobject = worldBuilder;
        }

        public GameObject GetResult()
        {
            return buildobject;
        }
    }
}
