using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace T_L_O_B_O
{
    class ChestBuilder : IBuilder
    {
        private GameObject buildObject;
        public void BuildGameObject(Vector2 position)
        {
            GameObject Chest = new GameObject();
            Chest.AddComponent(new Transform(Chest, position, 0));
            Chest.AddComponent(new SpriteRenderer(Chest, "ChestImage", 1, 1f));
            Chest.AddComponent(new ChestOfAThousandGrogs(Chest));
            Chest.AddComponent(new Collider(Chest, true, 1f));
            GameWorld.Instance.AddList.Add(Chest);
            buildObject = Chest;
        }
        public GameObject GetResult()
        {
            return buildObject;
        }
    }
}
