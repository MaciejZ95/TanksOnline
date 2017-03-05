using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using TanksOnline.ProjektPZ.Game.Drawables;

namespace TanksOnline.ProjektPZ.Game
{
    public partial class GameWindow : Form
    {
        private Tank _tank;
        private RenderWindow _renderWindow;
        private DispatcherTimer _timer;

        public GameWindow()
        {
            InitializeComponent();

            this._tank = new Tank(10) { FillColor = Color.Green, Position = new Vector2f(100f, 100f) };
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
            this._renderWindow.KeyPressed += RenderWindow_KeyPressed;
            this._renderWindow.SetActive(true);
        }

        private void RenderWindow_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Space: this.RandomTankColor(); break;
                case Keyboard.Key.Escape:
                    // TODO RK: Trzeba dodać jakieś okno na menu gry
                    PauseMenu.Visible = !PauseMenu.Visible;
                    break;
            }
        }

        private void RandomTankColor()
        {
            var rand = new Random();
            this._tank.FillColor = new Color((byte)rand.Next(), (byte)rand.Next(), (byte)rand.Next());
        }

        private void MainLoop(object sender, EventArgs e)
        {
            if (!PauseMenu.Visible)
            {
                this._renderWindow.DispatchEvents();
                this._renderWindow.Clear(new Color(50, 50, 50));
                this.GetKeys();
                this._renderWindow.Draw(this._tank);
            }
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
                if(_tank.TurretAnchor - 2.5f > 85) _tank.TurretAnchor -= 2.5f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                if(_tank.TurretAnchor + 2.5f < 275) _tank.TurretAnchor += 2.5f;
            }
        }
    }
}
