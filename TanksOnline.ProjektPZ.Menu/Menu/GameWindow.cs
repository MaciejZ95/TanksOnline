using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanksOnline.ProjektPZ.Game.Drawables;
using TanksOnline.ProjektPZ.Game.Drawables.TankNs;
using SFML.Graphics;
using TanksOnline.ProjektPZ.Game.Collision;
using Menu.Models;
using SFML.System;
using SFML.Window;
using TanksOnline.ProjektPZ.Game.Infrastructure.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Concurrent;

namespace Menu.Views
{
    public partial class GameWindow : Form
    {
        private List<Bullet> _bullets;
        private List<Tank> _tanks;
        private List<Explosion> _explosions;
        private RenderWindow _renderWindow;
        private Timer _timer, _httpLoopTimer;
        private bool _justShooted_Player;
        private FrameCollisionBox _colBox;

        private GameRoomModel _room;
        private PlayerModel _player;

        private ConcurrentStack<BoomModel> _boomModels;

        private GameWindow(GameRoomModel room, PlayerModel player, HttpClient client)
        {
            InitializeComponent();

            _client = client;
            _player = player;
            _room = room;
            
            _boomModels = new ConcurrentStack<BoomModel>();
            _explosions = new List<Explosion>();
            // TODO RK: Chwilowo jest statycznie wstawiane ile żyć jak i ilość czołgów - potem dodawać ładniej
            _tanks = new List<Tank>() {
                new Tank(7.5f, 0) { FillColor = Color.Green, Position = new Vector2f(100f, 400f) },
                new Tank(7.5f, 1) { FillColor = Color.Magenta, Position = new Vector2f(650f, 400f), TurretAngle = -90, },
            };
            _tanks.ForEach(tank => tank.TankHp = 4);
            _bullets = new List<Bullet>();
            _colBox = new FrameCollisionBox();

            CreateRenderWindow();
            CreateSignalRRequestLoop();
        }

        public static async Task<GameWindow> Create(GameRoomModel room, PlayerModel player, HttpClient client)
        {

            var window = new GameWindow(room, player, client);
            await window.InitHub();
            window.Text += $" - player {player.IdInMatch}";
            return window;
        }
        
        #region Główne Metody
        private void MainLoop(object sender, EventArgs e)
        {
            if (!PauseMenu.Visible)
            {
                _renderWindow.DispatchEvents();

                // Sprawdzanie istotnych przycisków
                GetKeys();

                // Kolizje pocisków ze ścianami/czołgami
                CalcBulletCollisions();

                // Przesuwanie pocisków
                _bullets.ForEach(bullet => bullet.Move());

                // Usuwanie "wypalonych" wybuchów
                _explosions.RemoveAll(x => x.Dead);

                // Rysowanie modeli
                DrawModels();
            }
            AdditionalInfo();
            _renderWindow.Display();
        }

        private bool _canClickPauseMenu = true;
        private bool _itsMyTurn, _alreadyUpdatingTurret = false;
        private void CreateSignalRRequestLoop()
        {
            _httpLoopTimer = new Timer { Interval = 1000 / 120 };
            _httpLoopTimer.Tick += async (s, e) =>
            {
                // aktualizowanie pozycji swojego działa
                if (_itsMyTurn && !_alreadyUpdatingTurret)
                {
                    _alreadyUpdatingTurret = true;
                    await SetPlayerCanon(_player.IdInMatch, _tanks[_player.IdInMatch].TurretAngle);
                    _alreadyUpdatingTurret = false;
                }

                if (_boomModels.Any())
                {
                    var booms = _boomModels.ToArray();
                    _boomModels.Clear();

                    booms.ToList().ForEach(async b =>
                    {
                        if (b.BulletFallDown)
                        {
                            await BulletFallDown();
                        }
                        else if (b.BulletHitPlayer)
                        {
                            await BulletHitPlayer(b.ShootedIdInMatch);
                        }
                        else if (b.BulletKilledPlayer)
                        {
                            await BulletKilledPlayer(b.ShootedIdInMatch);
                        }
                    });
                }
            };
            _httpLoopTimer.Start();
        }

        private void GetKeys()
        {
            if (_itsMyTurn)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                {
                    if (_tanks[_player.IdInMatch].TurretAngle - 2.5f > -95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle -= 2.5f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                {
                    if (_tanks[_player.IdInMatch].TurretAngle + 2.5f < 95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle += 2.5f;
                    }
                }
                //if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) LaunchBullet();
                if (_justShooted_Player && !Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    _justShooted_Player = _itsMyTurn = false;
                }
                if (!_justShooted_Player && Keyboard.IsKeyPressed(Keyboard.Key.Space)) LaunchBullet();
            }

            if (_canClickPauseMenu && Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _canClickPauseMenu = false;
                PauseMenu.Visible = !PauseMenu.Visible;
            };
            if (!_canClickPauseMenu && Keyboard.IsKeyPressed(Keyboard.Key.Escape)) _canClickPauseMenu = true;
        }
        #endregion

        #region Pozostałe Metody (rysowanie, kolizje, inne pomocnicze)

        private void DrawModels()
        {
            _renderWindow.Clear(new Color(50, 50, 50));
            _renderWindow.Draw(_colBox);

            _bullets.ForEach(x => _renderWindow.Draw(x));
            _tanks.ForEach(x => _renderWindow.Draw(x));
            _explosions.ForEach(x => _renderWindow.Draw(x));
        }

        private void CreateRenderWindow()
        {
            _timer = new Timer { Interval = 1000 / 60 };
            _timer.Tick += MainLoop;
            _timer.Start();

            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            _renderWindow = new RenderWindow(SFMLRenderControl.Handle, context);
            _renderWindow.SetActive(true);
        }

        private void AdditionalInfo()
        {
            LabelAnchor.Text = $"Turret anchor: {_tanks[_player.IdInMatch].TurretAngle}";
            LabelTankPos.Text = $"Tank position: {_tanks[_player.IdInMatch].Position}";
            LabelBulletCnt.Text = $"Bullets alive: {_bullets.Count}";
        }
        
        private void CalcBulletCollisions()
        {
            // Usuwanie pocisków, które miały kolizję
            _bullets.RemoveAll(bullet =>
            {
                // Sprawdzanie czy pocisk nie jest "makietą"
                if (!bullet.IsDummy)
                {
                    // Sprawdzanie kolizji ze ścianami
                    if (_colBox.CheckCol(bullet))
                    {
                        _boomModels.Push(new BoomModel(bullet.Position)
                        {
                            BulletFallDown = true,
                        });

                        _explosions.Add(new Explosion(bullet.Position));
                        return true;
                    }

                    // TODO RK: Sprawdzanie kolizji z powierzchnią

                    // Sprawdzanie kolizji z czołgami
                    var tank = _tanks.SingleOrDefault(t => t.CheckCol(bullet));
                    if (tank != null)
                    {
                        // Jeżeli już wcześniej czołg był zniszczony to pocisk jedynie zniknie
                        // nie ma potrzeby dodawać wybuchu - czołg i tak płonie
                        if (tank.Dead) return true;

                        // Jeżeli czołg ma jeszcze punkty życia to nawalamy
                        tank.TankHp--;
                        if (tank.TankHp > 0)
                        {
                            _boomModels.Push(new BoomModel(bullet.Position)
                            {
                                BulletHitPlayer = true,
                                ShootedIdInMatch = tank.IdInMatch,
                            });

                            // Trafiło gracza, więc dodajemy wybuch
                            _explosions.Add(new Explosion(bullet.Position));
                            return true;
                        }
                        // Jeżeli skończyły się hapsy, to zabić drania
                        else
                        {
                            tank.Dead = true;
                            _boomModels.Push(new BoomModel(bullet.Position)
                            {
                                BulletKilledPlayer = true,
                                ShootedIdInMatch = tank.IdInMatch,
                            });

                            // Trafiło gracza, więc dodajemy wybuch
                            _explosions.Add(new Explosion(bullet.Position));
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    // Sprawdzanie kolizji ze ścianami i czołgami
                    if (_colBox.CheckCol(bullet) || _tanks.Any(t => t.CheckCol(bullet)))
                    {
                        _explosions.Add(new Explosion(bullet.Position));
                        return true;
                    }
                    else return false;
                }
            });           
            // hell mode :>
            //_bullets.ToList().ForEach(x =>
            //{
            //    _missiles.Add(new Explosion(x.Position));
            //});
        }

        private async void LaunchBullet()
        {
            _justShooted_Player = true;

            float speed = 0f, airspeed = 0f, mass = 0f, gravity = 0f;

            try
            {
                speed = float.Parse(Speed.Text);
                airspeed = float.Parse(AirSpeed.Text);
                mass = float.Parse(Mass.Text);
                gravity = float.Parse(Gravity.Text);
            }
            catch (Exception) { }

            _bullets.Add(new Bullet(_tanks[_player.IdInMatch], _tanks[_player.IdInMatch].TurretAngle - 90, speed, airspeed, mass, gravity, _player.IdInMatch)
            {
                Origin = new Vector2f(2f, 2f),
                Position = _tanks[_player.IdInMatch].Position + new Vector2f(
                    _tanks[_player.IdInMatch].Rad + 2,
                    _tanks[_player.IdInMatch].Rad + 2
                ),
                FillColor = Color.Black,
                Radius = 4,
            });

            await Shoot(new PlayerShootModel
            {
                X = _bullets.Last().Position.X,
                Y = _bullets.Last().Position.Y,
                Angle = _tanks[_player.IdInMatch].TurretAngle - 90,
                Speed = speed,
                AirSpeed = airspeed,
                Mass = mass,
                Gravity = gravity,
                PlayerMatchId = _player.IdInMatch,
                RoomId = _room.Id,
            });

            AirSpeed.Text = (new Random().NextDouble() * 10 % 10 - 5).ToString();
        }
        #endregion

        public class BoomModel
        {
            /// <summary>
            /// Pocisk spadł na ziemię lub walnął w ścianę
            /// </summary>
            public bool BulletFallDown { get; set; }
            /// <summary>
            /// Pocisk trafił gracza ale go nie zabił
            /// </summary>
            public bool BulletHitPlayer { get; set; }
            /// <summary>
            /// Pocisk trafił gracza i go zabił
            /// </summary>
            public bool BulletKilledPlayer { get; set; }
            /// <summary>
            /// Id trafionego gracza (niezależnie czy zginął lub nie)
            /// </summary>
            public int ShootedIdInMatch { get; set; }
            /// <summary>
            /// Pozycja pocisku // TODO RK: W sumie bez sensu... Może wywalić? -.-
            /// </summary>
            public Vector2f Pos { get; private set; }

            public BoomModel(Vector2f pos)
            {
                Pos = pos;
            }
        }
    }
}
