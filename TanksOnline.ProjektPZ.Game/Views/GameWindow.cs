using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TanksOnline.ProjektPZ.Game.Views
{
    using SFML.System;
    using SFML.Window;
    using SFML.Graphics;
    using Drawables;
    using Drawables.Tank;
    using Collision;

    public partial class GameWindow : Form
    {
        private List<Bullet> _bullets;
        private Tank _tank;
        private RenderWindow _renderWindow;
        private DispatcherTimer _timer;
        private bool justShooted;
        private FrameCollisionBox _colBox = new FrameCollisionBox();

        public GameWindow()
        {
            InitializeComponent();

            this._tank = new Tank(10) { FillColor = Color.Green, Position = new Vector2f(100f, 100f) };
            this._bullets = new List<Bullet>();
            this.CreateRenderWindow();

            this._timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60) };
            this._timer.Tick += MainLoop;
            this._timer.Start();
        }

        private void CreateRenderWindow()
        {
            if (this._renderWindow != null)
            {
                this._renderWindow.SetActive(false);
                this._renderWindow.Dispose();
            }

            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            this._renderWindow = new RenderWindow(this.SFMLRenderControl.Handle, context);
            this._renderWindow.SetActive(true);
        }

        private void MainLoop(object sender, EventArgs e)
        {
            if (!PauseMenu.Visible)
            {
                this._renderWindow.DispatchEvents();
                this._renderWindow.Clear(new Color(50, 50, 50));
                this.GetKeys();
                this._renderWindow.Draw(this._colBox);
                this._bullets.ForEach(x =>
                {
                    this._renderWindow.Draw(x);
                    x.Move();
                });
                this._renderWindow.Draw(this._tank);
            }
            this.LabelAnchor.Text = $"Turret anchor: {_tank.TurretAngle}";
            this.LabelTankPos.Text = $"Tank position: {_tank.Position}";
            this._renderWindow.Display();
        }

        private void GetKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _tank.Move(-new Vector2f(5f, 0));
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _tank.Move(new Vector2f(5f, 0));
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) _tank.Move(-new Vector2f(0, 5f));
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) _tank.Move(new Vector2f(0, 5f));

            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                if (_tank.TurretAngle - 2.5f > -95) _tank.TurretAngle -= 2.5f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                if (_tank.TurretAngle + 2.5f < 95) _tank.TurretAngle += 2.5f;
            }
            if (justShooted && !Keyboard.IsKeyPressed(Keyboard.Key.Space)) justShooted = false;
            if (!justShooted && Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                justShooted = true;
                _bullets.Add(new Bullet(_tank.TurretAngle - 90, 10)
                {
                    Position = _tank.Position + new Vector2f(
                        _tank.Rad + 2,
                        _tank.Rad + 2
                    ),
                    FillColor = Color.Blue,
                    Radius = 4
                });
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) PauseMenu.Visible = !PauseMenu.Visible;
        }
    }
}
