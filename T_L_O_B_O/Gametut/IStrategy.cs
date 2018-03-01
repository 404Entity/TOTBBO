using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gametut
{
    interface IStrategy
    {
        void Execute(DIRECTION ref_direction);
    }
}
