using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using TanksOnline.ProjektPZ.Server.Controllers.CustomActionResults;
using TanksOnline.ProjektPZ.Server.Domain;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using TanksOnline.ProjektPZ.Server.Domain.Enums;
using TanksOnline.ProjektPZ.Server.Models.GameRoomModels;

namespace TanksOnline.ProjektPZ.Server.Controllers.Game
{
    [RoutePrefix("api/GameRooms")]
    public class GameRoomsController : BaseController
    {
        /// <summary>
        /// Sprawdzenie czy są wolne pokoje
        /// </summary>
        [HttpGet, ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRoomss()
        {
            var room = db.GameRooms.Include(x => x.Players.Select(p => p.User.TankInfo)).Where(x => x.PlayersLimit != x.Players.Count() && x.Players.Count()>0);
            if (!room.Any())
            {
                return Json(false);
            }
            return Json(true);
        }
        
        /// <summary>
        /// Wyszukanie pokoju po ID
        /// </summary>
        /// <param name="id">ID pokoju</param>
        [HttpGet, Route("{id:int}"), ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRoom([FromUri] int id)
        {
            var room = db.GameRooms
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User.TankInfo))
                .Include(x => x.Owner)
                .SingleOrDefault(x => x.Id == id);

            if (room != null)
            {
                return Json(Mapper.Map<GameRoomModel>(room));
            }

            return NotFound();
        }

        /// <summary>
        /// Wyszukanie pokoju po ID gracza
        /// </summary>
        /// <param name="id">ID gracza</param>
        [HttpGet, Route("GetByPlayer/{id:int}"), ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRoomByPlayerId([FromUri] int id)
        {
            var room = db.GameRooms
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User.TankInfo))
                .Include(x => x.Owner)
                .SingleOrDefault(x => x.Players.Any(p => p.Id == id));

            if (room != null)
            {
                return Json(Mapper.Map<GameRoomModel>(room));
            }

            return NotFound();
        }

        /// <summary>
        /// Zwraca obiekt pokoju jeżeli znajdzie się jakikolwiek z wolnymi miejscami
        /// </summary>
        /// <param name="id">Id użytkownika</param>
        [HttpGet, Route("FindEmptyRoom/ForUser/{id:int}")]
        public IHttpActionResult FindEmptyRoom(int id)
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    var rooms = db.GameRooms
                        .Include(room => room.Players).Include(room => room.Players.Select(x => x.User))
                        .Include(room => room.PlayerPoints)
                        .Include(room => room.Owner)
                        .Where(x => x.RoomStatus == RoomStatus.Waiting);

                    if (rooms.Any(x => x.Players.Count < x.PlayersLimit))
                    {
                        var room = rooms.First(x => x.Players.Count < x.PlayersLimit);
                        var idInMatch = room.Players.Last().IdInMatch + 1;
                        var user = db.Users.Single(u => u.Id == id);
                        room.Players.Add(new Player(true)
                        {
                            IdInMatch = idInMatch,
                            User = user
                        });
                        room.PlayerPoints.Add(new PlayerPoints
                        {
                            IdInMatch = idInMatch,
                            User = user
                        });

                        db.SaveChanges();
                        trans.Commit();

                        return Json(room);
                    }

                    return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak wolnych pokojów - stwórz własny :)");
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Sprawdza czy wszyscy gracze w pokoju są gotowi // TODO RK: Chyba niepotrzebne
        /// </summary>
        /// <param name="id">ID pokoju</param>
        [HttpGet, Route("CheckIfEveryoneReady/Room/{id:int}")]
        public IHttpActionResult CheckIfEveryoneReady(int id)
        {
            var room = db.GameRooms
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User))
                .Include(x => x.Owner)
                .SingleOrDefault(r => r.Id == id);

            if (room != null)
            {
                return Json(room);                
            }

            return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak szukanego pokoju");
        }

        /// <summary>
        /// Ustawia gracza w tryb READY co oznacza, że jest gotowy do gry. Jak wszyscy przejdą w ten stan to można rozpocząć rozgrywkę.
        /// </summary>
        /// <param name="model"></param>
        [HttpPut, Route("SetMeReady")]
        public IHttpActionResult SetMeReady(PutSetMeReadyModel model)
        {
            var room = db.GameRooms
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User))
                .SingleOrDefault(r => r.Id == model.GameRoomId);
                
            if (room != null)
            {
                var player = room.Players.SingleOrDefault(p => p.Id == model.PlayerId);

                if (player == null)
                {
                    return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak pokoju z szukanym graczem");
                }

                player.User.Status = UserStatus.Ready;

                if (room.Players.Count == room.PlayersLimit && !room.Players.Any(p => p.User.Status != UserStatus.Ready))
                {
                    room.RoomStatus = RoomStatus.Ready;
                }

                db.SaveChanges();
                return Ok();
            }
            else
            {
                return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak szukanego pokoju");
            }
        }

        /// <summary>
        /// Ustawia flagę informującą, że każdy już dołączył do gry i czeka na ruch kolejnego gracza.
        /// </summary>
        /// <param name="model"></param>
        [HttpPut, Route("SetMeInGame")]
        public IHttpActionResult SetMeInGame(PutSetMeInGameModel model)
        {
            var room = db.GameRooms.SingleOrDefault(r => r.Id == model.GameRoomId);

            if (room != null)
            {
                var player = room.Players.SingleOrDefault(p => p.Id == model.PlayerId);

                if (player == null)
                {
                    return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak pokoju z szukanym graczem");
                }

                player.User.Status = UserStatus.InGame;
                
                return Ok();
            }
            else
            {
                return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak szukanego pokoju");
            }
        }
        
        /// <summary>
        /// Tworzenie pokoju dla gracza
        /// </summary>
        /// <param name="model"></param>
        [HttpPost, ResponseType(typeof(GameRoom))]
        public IHttpActionResult CreateRoom(RoomModel model)
        {
            var user = db.Users.Include(x => x.TankInfo).Single(x => x.Id == model.Id);

            var room = db.GameRooms.Add(new GameRoom
            {
                Owner = user,
                PlayersLimit = model.Limit,
                RoomStatus = RoomStatus.Waiting,
                Players = new List<Player>() { new Player(true)
                {
                    IdInMatch = 0,
                    User = user
                }},
                PlayerPoints = new List<PlayerPoints>() { new PlayerPoints
                {
                    IdInMatch = 0,
                    User = user
                }}
            });

            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = room.Id }, room);
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region GameRoomExists?
        private bool GameRoomExists(int id)
        {
            return db.GameRooms.Count(e => e.Id == id) > 0;
        }
        #endregion
    }
}