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

namespace Menu.Views
{
    public partial class GameWindow : Form
    {
        private List<Bullet> _bullets;
        private List<Tank> _tanks;
        private List<Explosion> _missiles;
        private RenderWindow _renderWindow;
        private Timer _timer, _httpLoopTimer;
        private bool _justShooted_Player0, _justShooted_Player1;
        private FrameCollisionBox _colBox;

        private GameRoomModel _room;
        private PlayerModel _player;

        private GameWindow(GameRoomModel room, PlayerModel player, HttpClient client)
        {
            InitializeComponent();

            _client = client;
            _player = player;
            _room = room;

            _missiles = new List<Explosion>();
            _tanks = new List<Tank>() {
                new Tank(7.5f) { FillColor = Color.Green, Position = new Vector2f(100f, 100f) },
                new Tank(7.5f) { FillColor = Color.Magenta, Position = new Vector2f(650f, 400f), TurretAngle = -90 },
            };
            _bullets = new List<Bullet>();
            _colBox = new FrameCollisionBox();

            CreateRenderWindow();
            CreateHttpListenerLoop();
        }

        public static async Task<GameWindow> Create(GameRoomModel room, PlayerModel player, HttpClient client)
        {

            var window = new GameWindow(room, player, client);
            await window.InitializeSignalRHub();
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

                // Usuwanie "martwych" obiektów
                RemoveDeadObjects();

                // Rysowanie modeli
                DrawModels();
            }
            AdditionalInfo();
            _renderWindow.Display();
        }

        private void CreateHttpListenerLoop()
        {
            _itsMyTurn = true;// _room.Match.ActualPlayer == _player.IdInMatch;

            _httpLoopTimer = new Timer { Interval = 1000 / 60 };
            _httpLoopTimer.Tick += (s, e) =>
            {
                // aktualizowanie pozycji swojego działa lub dział przeciwnika
                if (!_tankPosProcesing) ProcessTanksPositions();

                // aktualizowanie stanu gry (kto teraz gra)
                //if (!_updatingStatus) UpdateGameStatus();
            };
            _httpLoopTimer.Start();
        }

        private void GetKeys()
        {
            if (_player.IdInMatch == 0)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _tanks[_player.IdInMatch].Move(-new Vector2f(5f, 0));
                if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _tanks[_player.IdInMatch].Move(new Vector2f(5f, 0));
                if (Keyboard.IsKeyPressed(Keyboard.Key.W)) _tanks[_player.IdInMatch].Move(-new Vector2f(0, 5f));
                if (Keyboard.IsKeyPressed(Keyboard.Key.S)) _tanks[_player.IdInMatch].Move(new Vector2f(0, 5f));

                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                {
                   // if (_tanks[_player.IdInMatch].TurretAngle - 2.5f > -95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle -= 2.5f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                {
                    //if (_tanks[_player.IdInMatch].TurretAngle + 2.5f < 95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle += 2.5f;
                    }
                }
                // HELL MODE: Odkomentuj to zobaczysz piekło :D (tylko w połączeniu z kodem u góry)
                //if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) LaunchBullet();
                if (_justShooted_Player0 && !Keyboard.IsKeyPressed(Keyboard.Key.Space)) _justShooted_Player0 = false;
                if (!_justShooted_Player0 && Keyboard.IsKeyPressed(Keyboard.Key.Space)) LaunchBullet(); 
            }
            else if(_player.IdInMatch == 1)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad4)) _tanks[_player.IdInMatch].Move(-new Vector2f(5f, 0));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad6)) _tanks[_player.IdInMatch].Move(new Vector2f(5f, 0));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad8)) _tanks[_player.IdInMatch].Move(-new Vector2f(0, 5f));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad5)) _tanks[_player.IdInMatch].Move(new Vector2f(0, 5f));

                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad7))
                {
                    if (_tanks[_player.IdInMatch].TurretAngle - 2.5f > -95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle -= 2.5f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad9))
                {
                    if (_tanks[_player.IdInMatch].TurretAngle + 2.5f < 95)
                    {
                        _tanks[_player.IdInMatch].TurretAngle += 2.5f;
                    }
                }
                // HELL MODE: Odkomentuj to zobaczysz piekło :D (tylko w połączeniu z kodem u góry)
                //if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) LaunchBullet();
                if (_justShooted_Player1 && !Keyboard.IsKeyPressed(Keyboard.Key.Numpad0)) _justShooted_Player1 = false;
                if (!_justShooted_Player1 && Keyboard.IsKeyPressed(Keyboard.Key.Numpad0)) LaunchBullet();
            }
            if (_canClickPauseMenu && Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _canClickPauseMenu = false;
                PauseMenu.Visible = !PauseMenu.Visible;
            };
            if (!_canClickPauseMenu && Keyboard.IsKeyPressed(Keyboard.Key.Escape)) _canClickPauseMenu = true;
        }
        #endregion
        bool _canClickPauseMenu = true;
        #region Przetwarzanie związane z obsługą serwera
        private bool _itsMyTurn, _tankPosProcesing = false, _updatingStatus = false;
        private async void ProcessTanksPositions()
        {
            _tankPosProcesing = true;
            if (_itsMyTurn)
            {
                await SetPlayerCanon(_player.IdInMatch, _tanks[_player.IdInMatch].TurretAngle);
                _tankPosProcesing = false;
            }
            else
            {
                // TODO RK: Ogarnianie jak zmienił się stan pozostąłych graczy
                _tankPosProcesing = false;
            }
        }

        private async void UpdateGameStatus()
        {
            _updatingStatus = true;

            _room = await GetRoom();
            for (int i = 0; i < _tanks.Count; i++)
            {
                if (i == _player.IdInMatch) continue;
                _tanks[i].TurretAngle = _room.Players[i].TurretAngle;
            }

            _updatingStatus = false;
        }
        #endregion

        #region Pozostałe Metody (rysowanie, kolizje, inne pomocnicze)

        private void DrawModels()
        {
            _renderWindow.Clear(new Color(50, 50, 50));
            _renderWindow.Draw(_colBox);

            _bullets.ForEach(x => _renderWindow.Draw(x));
            _tanks.ForEach(x => _renderWindow.Draw(x));
            _missiles.ForEach(x => _renderWindow.Draw(x));
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

        private void RemoveDeadObjects()
        {
            _missiles.RemoveAll(x => x.Dead);
            _bullets.RemoveAll(x =>
            {
                // HELL MODE: Odkomentuj to zobaczysz piekło :D
                // _missiles.Add(new Explosion(x.Position));
                return x.Dead == true;
            });
            _tanks.RemoveAll(x =>
            {
                // TODO RK: Dodawanie ładniejszych wybuchów :>
                if (x.Dead)
                {
                    _missiles.Add(new Explosion(x.Position));
                    _missiles.Last().Move(new Vector2f(1.5f * x.Rad, 1.5f * x.Rad));
                }
                return x.Dead;
            });
        }

        private void CalcBulletCollisions()
        {
            _bullets.ForEach(x =>
            {
                if (_colBox.CheckCol(x) || _tanks.Any(t => t.CheckCol(x)))
                {
                    x.Dispose();
                }
                else x.Move();
            });
            _bullets.Where(x => x.Dead).ToList().ForEach(x =>
            {
                _missiles.Add(new Explosion(x.Position));
            });
            // hell mode :>
            //_bullets.ToList().ForEach(x =>
            //{
            //    _missiles.Add(new Explosion(x.Position));
            //});
        }

        private void LaunchBullet()
        {
            _justShooted_Player0 = _justShooted_Player1 = true;

            float speed = 0f, airspeed = 0f, mass = 0f, gravity = 0f;

            try
            {
                speed = float.Parse(Speed.Text);
                airspeed = float.Parse(AirSpeed.Text);
                mass = float.Parse(Mass.Text);
                gravity = float.Parse(Gravity.Text);
            }
            catch (Exception) { }

            _bullets.Add(new Bullet(_tanks[_player.IdInMatch], _tanks[_player.IdInMatch].TurretAngle - 90, speed, airspeed, mass, gravity)
            {
                Origin = new Vector2f(2f, 2f),
                Position = _tanks[_player.IdInMatch].Position + new Vector2f(
                    _tanks[_player.IdInMatch].Rad + 2,
                    _tanks[_player.IdInMatch].Rad + 2
                ),
                FillColor = Color.Black,
                Radius = 4,
            });

            AirSpeed.Text = (new Random().NextDouble() * 10 % 10 - 5).ToString();
        } 
        #endregion
    }
}
