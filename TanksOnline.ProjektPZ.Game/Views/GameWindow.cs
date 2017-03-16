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
    using Drawables.TankNs;
    using Collision;

    public partial class GameWindow : Form
    {
        private List<Bullet> _bullets;
        private Tank _tank1, _tank2;
        private RenderWindow _renderWindow;
        private Timer _timer;
        private bool justShooted;
        private FrameCollisionBox _colBox = new FrameCollisionBox();
        private List<Explosion> booms;

        public GameWindow()
        {
            InitializeComponent();

            booms = new List<Explosion>()
            {
                new Explosion(new Vector2f(300, 300))
            };

            _tank1 = new Tank(20) { FillColor = Color.Green, Position = new Vector2f(100f, 100f) };
            _tank2 = new Tank(20) { FillColor = Color.Magenta, Position = new Vector2f(650f, 400f), TurretAngle = -90 };
            _bullets = new List<Bullet>();
            CreateRenderWindow();

            _timer = new Timer { Interval = 1000 / 60 };
            _timer.Tick += MainLoop;
            _timer.Start();
        }

        private void CreateRenderWindow()
        {
            if (_renderWindow != null)
            {
                _renderWindow.SetActive(false);
                _renderWindow.Dispose();
            }

            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            _renderWindow = new RenderWindow(SFMLRenderControl.Handle, context);
            _renderWindow.SetActive(true);
        }

        private void MainLoop(object sender, EventArgs e)
        {
            if (!PauseMenu.Visible)
            {
                _renderWindow.DispatchEvents();
                _renderWindow.Clear(new Color(50, 50, 50));
                GetKeys();
                _renderWindow.Draw(_colBox);
                _bullets.ForEach(x =>
                {
                    if (_colBox.CheckCol(x) || _tank1.CheckCol(x) || _tank2.CheckCol(x))
                    {
                        x.Dispose();
                    }
                    else
                    {
                        _renderWindow.Draw(x);
                        x.Move();
                    }
                });
                _bullets.Where(x => x.Dead).ToList().ForEach(x => {
                    booms.Add(new Explosion(x.Position));
                });
                _bullets.RemoveAll(x =>
                {
                    // HELL MODE: Odkomentuj to zobaczysz piekło :D
                    //booms.Add(new Explosion(x.Position));
                    return x.Dead == true;
                });
                _renderWindow.Draw(_tank1);
                _renderWindow.Draw(_tank2);
                booms.RemoveAll(x => x.Dead);
                booms.ForEach(x => _renderWindow.Draw(x));
            }
            LabelAnchor.Text = $"Turret anchor: {_tank1.TurretAngle}";
            LabelTankPos.Text = $"Tank position: {_tank1.Position}";
            LabelBulletCnt.Text = $"Bullets alive: {_bullets.Count}";
            _renderWindow.Display();
        }

        private void GetKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _tank1.Move(-new Vector2f(5f, 0));
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _tank1.Move(new Vector2f(5f, 0));
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) _tank1.Move(-new Vector2f(0, 5f));
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) _tank1.Move(new Vector2f(0, 5f));

            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                if (_tank1.TurretAngle - 2.5f > -95) _tank1.TurretAngle -= 2.5f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                if (_tank1.TurretAngle + 2.5f < 95) _tank1.TurretAngle += 2.5f;
            }
            // HELL MODE: Odkomentuj to zobaczysz piekło :D (tylko w połączeniu z kodem u góry)
            //if (justShooted && !Keyboard.IsKeyPressed(Keyboard.Key.Space)) justShooted = false;
            //if (!justShooted && Keyboard.IsKeyPressed(Keyboard.Key.Space))
            if (justShooted && !Keyboard.IsKeyPressed(Keyboard.Key.Space)) justShooted = false;
            if (!justShooted && Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                justShooted = true;
                _bullets.Add(new Bullet(_tank1, _tank1.TurretAngle - 90, 10)
                {
                    Origin = new Vector2f(2f, 2f),
                    Position = _tank1.Position + new Vector2f(
                        _tank1.Rad + 2,
                        _tank1.Rad + 2
                    ),
                    FillColor = Color.Blue,
                    Radius = 4,
                });
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) PauseMenu.Visible = !PauseMenu.Visible;
        }
    }
}
