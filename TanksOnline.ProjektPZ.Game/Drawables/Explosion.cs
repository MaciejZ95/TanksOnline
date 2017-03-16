using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    public class Explosion : Sprite
    {
        private static Random RAND = new Random();
        private static Texture TEXTURE;
        private static List<IntRect> RECTS;
        private short _counter;
        private ExplosionAnimation _boom;

        public bool Dead { get; private set; } = false;

        public Explosion(Vector2f pos)
        {
            Position = pos;
            Origin = new Vector2f(32f, 32f);
            Rotation = RAND.Next() % 360;

            if (TEXTURE == null)
            {
                LoadTexture();
            }
            this.Texture = TEXTURE;
            this.TextureRect = RECTS.First();

            _boom = new ExplosionAnimation(this);
        }

        private void LoadTexture()
        {
            TEXTURE = new Texture("resources/explosion.png");
            RECTS = new List<IntRect>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    RECTS.Add(new IntRect(j * 64, i * 64, 64, 64));
                }
            }
        }

        class ExplosionAnimation : IDisposable
        {
            private Explosion _boom;
            private Timer _timer;

            public ExplosionAnimation(Explosion e)
            {
                _boom = e;
                _boom._counter = 1;

                _timer = new Timer { Interval = 50 };
                _timer.Tick += new EventHandler(TimerMethod);
                _timer.Start();
            }

            private void TimerMethod(object s, EventArgs e)
            {
                if (_boom._counter >= RECTS.Count)
                {
                    _timer.Enabled = false;
                    _boom.Dead = true;
                    Dispose();
                    return;
                }
                else _boom.TextureRect = RECTS.ElementAt(_boom._counter++);
            }
            
            private bool disposed;
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool dispose)
            {
                if (!this.disposed)
                {
                    if (dispose)
                    {
                        _boom.Dispose();
                        _timer.Dispose();
                    }

                    disposed = true;
                }
            }
        }
    }
}
