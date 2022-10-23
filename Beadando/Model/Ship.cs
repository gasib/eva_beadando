using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Model
{
    public class Ship: MovingObject
    {
        private Direction _direction;
        private System.Timers.Timer _timer = new System.Timers.Timer();

        public Ship(Point location)
        {
            Location = location;
            var r = new Random();
            _direction = r.Next() % 2 == 1 ? Direction.Left : Direction.Right;
            //_timer.Interval = r.Next() % 500 + 100;
            _timer.Interval = 16;
            _timer.Start();
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object? sender, EventArgs e)
        {
            Move(_direction);
            if (Boundaries != null)
            {
                if (Location.X < 0)
                {
                    _direction = Direction.Right;
                }
                if (Location.X > Boundaries?.Width - Size?.Width)
                {
                    _direction = Direction.Left;
                }
            }
        }
    }
}
