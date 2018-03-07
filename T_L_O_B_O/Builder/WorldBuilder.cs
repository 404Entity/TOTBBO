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
            worldBuilder.AddComponent(new Transform(worldBuilder, position,0));
            worldBuilder.AddComponent(new SpriteRenderer(worldBuilder, "Map1", 1, 0.5f));
            SpriteRenderer test = (SpriteRenderer)worldBuilder.GetComponent("SpriteRenderer");
            //worldBuilder.AddComponent(new Tiles(worldBuilder));
            worldBuilder.LoadContent(GameWorld.Instance.Content);
            worldBuilder.AddComponent(new Collider(worldBuilder, false, 1f));
            buildobject = worldBuilder;
        }

        public GameObject GetResult()
        {
            return buildobject;
        }
    }
}
