using Model;
using System.Diagnostics;

namespace View
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            CollisionTest += Player.OnCollisionEvent;
            Player.PlayerHit += OnPlayerGotHit;
        }

        private void OnPlayerGotHit(object? sender, EventArgs e)
        {
            Player.BackColor = Color.LightBlue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CollisionTest?.Invoke(this, new CollisionEventArgs(ship1.Bounds.IntersectsWith(Player.Bounds)));
        }

        public event EventHandler<CollisionEventArgs>? CollisionTest;
    }
}