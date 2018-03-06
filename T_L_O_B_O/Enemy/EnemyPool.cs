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
    class EnemyPool
    {

        List<Enemy> inactive = new List<Enemy>();
        List<Enemy> active = new List<Enemy>();



        public Enemy Create()
        {
            return new Enemy();
        }

        public void ReleaseObject(Enemy enemy)
        {

        }

        public void CleanUp(Enemy enemy)
        {

        }
    }
}
