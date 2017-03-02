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
        private TankWheels _tank;
        private byte _color = 0;
        private RenderWindow _renderWindow;
        private DispatcherTimer _timer;

        public GameWindow()
        {
            InitializeComponent();

            this._tank = new TankWheels(50f) { FillColor = Color.Green };
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
                case Keyboard.Key.Space: this.ChangeCircleColor(); break;
                case Keyboard.Key.Escape:
                    // TODO RK: Trzeba dodać jakieś okno na menu gry
                    PauseMenu.Visible = true;
                    break;
            }
        }

        private void ChangeCircleColor()
        {
            var rand = new Random();
            var color = new Color((byte)rand.Next(), (byte)rand.Next(), (byte)rand.Next());
            this._tank.FillColor = color;
        }

        private void MainLoop(object sender, EventArgs e)
        {
            this._renderWindow.DispatchEvents();
            this._renderWindow.Clear(new Color(this._color, this._color, this._color));
            this._color = this._color >= 255 ? (byte)0 : (byte)(this._color + 1);
            this.GetKeys();
            this._renderWindow.Draw(this._tank);
            this._renderWindow.Display();
        }

        private void GetKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _tank.Position -= new Vector2f(10, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _tank.Position += new Vector2f(10, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) _tank.Position -= new Vector2f(0, 10);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) _tank.Position += new Vector2f(0, 10);
        }
    }
}
