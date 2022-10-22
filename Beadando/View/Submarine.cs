using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Submarine : UserControl
    {
        Model.Submarine _submarine;
        public Submarine()
        {
            InitializeComponent();
            _submarine = new Model.Submarine(Location, Size);
            _submarine.Moved += new EventHandler(ModelMoved);
        }

        private void ModelMoved(object? sender, EventArgs e)
        {
            Location = new Point(_submarine.Location.X, _submarine.Location.Y);
        }

        private void Submarine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                _submarine.Move(Model.Direction.Left);
            }
            if (e.KeyCode == Keys.D)
            {
                _submarine.Move(Model.Direction.Right);
            }
            if (e.KeyCode == Keys.W)
            {
                _submarine.Move(Model.Direction.Up);
            }
            if (e.KeyCode == Keys.S)
            {
                _submarine.Move(Model.Direction.Down);
            }
        }

        private void Submarine_ParentChanged(object sender, EventArgs e)
        {
            _submarine.Location = Location;
            _submarine.BottomRightBoundaries = new Point(Parent.Width, Parent.Height);
        }
    }
}
