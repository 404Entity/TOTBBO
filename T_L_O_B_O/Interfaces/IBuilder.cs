using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace T_L_O_B_O
{
    interface IBuilder
    {
        GameObject GetResult();
        void BuildGameObject(Vector2 position);
        void BuildGameObject(Vector2 position,int id);
    }
}
