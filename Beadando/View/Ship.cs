using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Ship : UserControl
    {
        Model.Ship _ship;
        public Ship()
        {
            InitializeComponent();
            var r = new Random();
            _ship = new Model.Ship(new Point(0,0));
            _ship.Moved += OnShipMoved;
        }

        private void Ship_ParentChanged(object sender, EventArgs e)
        {
            var r = new Random();
            _ship.Location = new Point((r.Next() % (Parent.Width)) - Width, 50);
            _ship.Boundaries = new Size(Parent.Width, Parent.Height);
            _ship.Size = Size;
            Location = new Point(_ship.Location.X, _ship.Location.Y);
        }

        private void OnShipMoved(object? sender, EventArgs e)
        {
            if (!IsDisposed)
            {
                BeginInvoke(() =>
                {
                    Location = new Point(_ship.Location.X, _ship.Location.Y);
                });
            }
        }
    }
}
