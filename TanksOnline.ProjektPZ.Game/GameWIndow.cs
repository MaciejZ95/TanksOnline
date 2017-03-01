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

namespace TanksOnline.ProjektPZ.Game
{
    public partial class GameWindow : Form
    {
        private CircleShape _circle;
        private byte _color = 0;
        private RenderWindow _renderWindow;
        private DispatcherTimer _timer;

        public GameWindow()
        {
            InitializeComponent();

            this._circle = new CircleShape(100) { FillColor = Color.Magenta };
            this.CreateRenderWindow();

            this._timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60) };
            this._timer.Tick += Timer_Tick;
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
            this._renderWindow.MouseButtonPressed += RenderWindow_MouseButtonPressed;
            this._renderWindow.KeyPressed += RenderWindow_KeyPressed;
            this._renderWindow.SetActive(true);
        }

        private void RenderWindow_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Space: this.ChangeCircleColor(); break;
            }
        }

        private void ChangeCircleColor()
        {
            var rand = new Random();
            var color = new Color((byte)rand.Next(), (byte)rand.Next(), (byte)rand.Next());
            this._circle.FillColor = color;
        }

        private void RenderWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            this._circle.Position = new Vector2f(e.X, e.Y);
        }

        private void DrawSurface_SizeChanged(object sender, EventArgs e)
        {
            this.CreateRenderWindow();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this._renderWindow.DispatchEvents();

            this._renderWindow.Clear(new Color(this._color, this._color, this._color));
            this._color = this._color >= 255 ? (byte)0 : (byte)(this._color + 1);

            this.GetKeys();

            this._renderWindow.Draw(this._circle);

            this._renderWindow.Display();
        }

        private void GetKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _circle.Position -= new Vector2f(10, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _circle.Position += new Vector2f(10, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) _circle.Position -= new Vector2f(0, 10);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) _circle.Position += new Vector2f(0, 10);
        }
    }
}
