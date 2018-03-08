using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace T_L_O_B_O
{
    class EnemyPool
    {
        private List<GameObject> inactive;
        private List<GameObject> active;
        public List<GameObject> Inactive
        {
            get { return inactive; }
            set { inactive = value; }
        }
        public List<GameObject> Active
        {
            get { return active; }
            set { active = value; }
        }
        public EnemyPool()
        {
            inactive = new List<GameObject>();
            active = new List<GameObject>();
        }
        public GameObject Create()
        {
            Random locata = new Random();
            Vector2 location = new Vector2(locata.Next(500), locata.Next(500));
            if (inactive.Count <= 0)
            {
                Director director = new Director(new EnemyBuilder());
                Random pickone = new Random();
                if (pickone.Next(10)>=5)
                {
                    director = new Director(new EnemyBuilder());
                }
                else
                {
                    director = new Director(new ScissorBuilder());
                }
               


                GameObject newlySpawned = director.Construct(location);
                active.Add(newlySpawned);
                return newlySpawned;
            }
            else
            {
                GameObject firstofInactive = Inactive[0];
                firstofInactive.Transform.Position = location;
                active.Add(firstofInactive);
                inactive.Remove(inactive[0]);
                return firstofInactive;
               
            }
            
        }
        public void ReleaseObject(GameObject gameObject)
        {
            active.Remove(gameObject);
            inactive.Add(gameObject);
            CleanUp(gameObject);
        }
        public void CleanUp(GameObject gameObject)
        {
            GameWorld.Instance.RemoveList.Add(gameObject);  
        }
    }
}
