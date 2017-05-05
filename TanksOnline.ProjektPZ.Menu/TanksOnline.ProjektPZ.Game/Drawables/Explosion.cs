using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.ProjektPZ.Game.Drawables
{
    using SFML.Graphics;
    using SFML.System;
    using Infrastructure.Interfaces;

    public class Explosion : Sprite, IMoveAble
    {
        private static Random RAND = new Random();
        private static Texture TEXTURE;
        private static List<IntRect> RECTS;
        private int _counter;
        private ExplosionAnimation _boom;

        public bool Dead { get; private set; } = false;
        public bool Infinite { get; set; } = false;

        public Explosion(Vector2f pos, bool infinite = false)
        {
            Position = pos;
            Origin = new Vector2f(32f, 32f);
            Rotation = RAND.Next() % 360;

            if (TEXTURE == null)
            {
                LoadTexture();
            }
            this.Texture = TEXTURE;
            if (infinite)
            {
                this.TextureRect = RECTS.ElementAt(new Random().Next() % 16);
            }
            else this.TextureRect = RECTS.First();

            _boom = new ExplosionAnimation(this, infinite);
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
            private int x;

            public ExplosionAnimation(Explosion e, bool infinite = false)
            {
                if (infinite)
                {
                    _timer = new Timer { Interval = 25 };
                }
                else
                {
                    _timer = new Timer { Interval = 50 };
                }
                _boom = e;
                _boom._counter = 1;
                x = 1;

                _timer.Tick += new EventHandler(TimerMethod);
                _timer.Start();
            }

            private void TimerMethod(object s, EventArgs e)
            {
                if (_boom.Infinite)
                {
                    _boom.Rotation += new Random().Next() % 10 - 5;
                    if (x == 1)
                    {
                        if (_boom._counter < (RECTS.Count - 5))
                        {
                            _boom.TextureRect = RECTS.ElementAt(_boom._counter++);
                        }
                        else
                        {
                            x = -1;
                            _boom._counter--;
                        }
                    }
                    else
                    {
                        if (_boom._counter > 3)
                        {
                            _boom.TextureRect = RECTS.ElementAt(_boom._counter--);
                        }
                        else x = 1;
                    }
                }
                else
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
