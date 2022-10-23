using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CollisionEventArgs
    {
        public bool Collide { get; private set; }

        public CollisionEventArgs(bool collide)
        {
            Collide = collide;
        }
    }
}
