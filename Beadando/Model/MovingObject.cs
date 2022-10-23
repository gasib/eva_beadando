using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Direction
    {
        Up, Right, Down, Left
    }
    public class MovingObject
    {
        public Point Location { get; set; }
        public Size? Size { get; set; }
        public Size? Boundaries { get; set; }
        protected int _speed = 3;

        public MovingObject()
        {

        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    Location = new Point(Location.X, Location.Y - _speed);
                    break;
                case Direction.Right:
                    //if (Location.X + Size.Width + _speed > BottomRightBoundaries.X)
                    //{
                    //    Location = new Point(BottomRightBoundaries.X - Size.Width, Location.Y);
                    //    break;
                    //}
                    Location = new Point(Location.X + _speed, Location.Y);
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, Location.Y + _speed);
                    break;
                case Direction.Left:
                    Location = new Point(Location.X - _speed, Location.Y);
                    break;
                default: break;
            }
            Moved?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? Moved;
    }
}
