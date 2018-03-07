using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_L_O_B_O
{
    class ChestOfAThousandGrogs : Component, ICollisionStay
    {
        //Fields





        //Propertys

        //Constructor
        public ChestOfAThousandGrogs(GameObject gameObject): base(gameObject)
        {

        }

        

        //Methods
        public void OnCollisionStay(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}
