using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TanksOnline.ProjektPZ.Game.Views
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    public partial class TestWindow : Form
    {
        /** 
            g = 9.81
            t = 0
            f - siła oporu powietrza
            m - masa ciała
            v - prędkość początkowa
            Δt - przyrost czasu
            α - kąt wystrzelenia pocisku
            kod:
            x = x + ((v* cos(α)) - f / m * t)
            y = y - ((v* sin(α)) - g * t)
            t = t + Δt */

        private RenderWindow _renderWindow;
        private Vector2f startPos = new Vector2f(400f, 250f);
        private List<CircleShape> circles = new List<CircleShape>(100);
        private const float g = 9.81f;
        private const float m = 10f;

        private DispatcherTimer _timer;

        public TestWindow()
        {
            InitializeComponent();

            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            this._renderWindow = new RenderWindow(this.sfmlRenderControl1.Handle, context);
            this._renderWindow.SetActive(true);

            for(int i = 0; i < 100; i++) circles.Add(new CircleShape(1));
            circles.First().FillColor = Color.Red;
            UpdateFoo_Click(null, null);

            this._timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60) };
            this._timer.Tick += MainLoop;
            this._timer.Start();
        }

        private void UpdateFoo_Click(object sender, EventArgs e)
        {
            var t = 0.1f;
            var velocity = new Vector2f( (float) Math.Cos(45), (float) Math.Sin(45)) * 20;
            var position = startPos;

            foreach (var circle in circles)
            {
                var acc = g / m;
                velocity += new Vector2f(0, acc * t);
                position += velocity * t;
                
                circle.Position = position;
                t += 0.1f;
                Console.WriteLine("Pozycja " + t + ": " + position);
            }
        }

        private void MainLoop(object sender, EventArgs e)
        {
            this._renderWindow.DispatchEvents();
            this._renderWindow.Clear(new Color(50, 50, 50));
            this.circles.ForEach(x => this._renderWindow.Draw(x));

            this._renderWindow.Display();
        }
    }
}
