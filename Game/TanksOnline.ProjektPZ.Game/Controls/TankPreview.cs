using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using System.Windows.Threading;
using TanksOnline.ProjektPZ.Game.Drawables.TankNs;
using SFML.System;

namespace TanksOnline.ProjektPZ.Game.Controls
{
    public partial class TankPreview : UserControl
    {
        public byte RED {
            get { return _red; }
            set {
                _colorChanged = true;
                _red = value;
            }
        }
        public byte GREEN {
            get { return _green; }
            set {
                _colorChanged = true;
                _green = value;
            }
        }
        public byte BLUE {
            get { return _blue; }
            set {
                _colorChanged = true;
                _blue = value;
            }
        }
        
        private RenderWindow _renderWindow;
        private DispatcherTimer _timer;
        private Color _tankColor;
        private bool _colorChanged;
        private byte _red, _blue, _green;
        private Tank _tank;

        public TankPreview()
        {
            InitializeComponent();
        }

        public void RunPreview()
        {
            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            this._renderWindow = new RenderWindow(this.Handle, context);
            this._renderWindow.SetActive(true);

            this._timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60) };
            this._timer.Tick += MainLoop;
            this._timer.Start();

            this._tankColor = Color.Green;
            this._colorChanged = false;
            // NOTE MACIEK: Zmiana wielkości czołgu w konstruktorze, a jego przemieszczanie w position
            this._tank = new Tank(20f)
            {
                FillColor = _tankColor,
                Position = new Vector2f(40f, 30f),
                TurretAngle = 90
            };
        }

        private void MainLoop(object sender, EventArgs e)
        {
            if (_colorChanged)
            {
                _tankColor = new Color(_red, _green, _blue);
                _tank.FillColor = _tankColor;
                _colorChanged = false;
            }
            // NOTE MACIEK: Zmiana koloru tła
            this._renderWindow.Clear(new Color(50, 50, 50));
            this._renderWindow.Draw(_tank);
            this._renderWindow.Display();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_renderWindow == null) base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_renderWindow == null) base.OnPaintBackground(e);
        }
    }
}
