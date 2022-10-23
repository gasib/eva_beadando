using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Submarine: MovingObject
    {
        public Submarine(Point location, Size size, Size boundaries)
        {
            Location = location;
            Size = size;
            Boundaries = boundaries;
        }

        public Submarine(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public Submarine(Size size)
        {
            Size = size;
        }

        public void IntersectsWith(object? sender, CollisionEventArgs e)
        {
            if (e.Collide)
            {
                GotHit?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? GotHit;
    }
}
