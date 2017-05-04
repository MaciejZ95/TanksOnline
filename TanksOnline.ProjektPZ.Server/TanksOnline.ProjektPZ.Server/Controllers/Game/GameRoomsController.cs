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
        #region Find rooms

        #endregion

        #region Checked room     
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
        #endregion
        
        #region Get by ID. GET
        [HttpGet, Route("{id:int}"), ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRoom([FromUri] int id)
        {
            var room = db.GameRooms
                .Include(x => x.Match)
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User.TankInfo))
                .Include(x => x.Owner)
                .SingleOrDefault(x => x.Id == id);

            if (room != null)
            {
                return Json(Mapper.Map<GameRoomModel>(room));
            }

            return NotFound();
        }
        #endregion

        #region Get by player ID. GET
        [HttpGet, Route("GetByPlayer/{id:int}"), ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRoomByPlayerId([FromUri] int id)
        {
            var room = db.GameRooms
                .Include(x => x.Match)
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User.TankInfo))
                .Include(x => x.Owner)
                .SingleOrDefault(x => x.Players.Any(p => p.Id == id));

            if (room != null)
            {
                return Json(Mapper.Map<GameRoomModel>(room));
            }

            return NotFound();
        }
        #endregion

        /// <summary>
        /// Zwraca obiekt pokoju jeżeli znajdzie się jakikolwiek z wolnymi miejscami
        /// </summary>
        /// <param name="id">Id użytkownika</param>
        /// <returns></returns>
        /// 
        #region Find empty room for user
        [HttpGet, Route("FindEmptyRoom/ForUser/{id:int}")]
        public IHttpActionResult FindEmptyRoom(int id)
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    var rooms = db.GameRooms
                        .Include(room => room.Players)
                        .Include(room => room.Owner)
                        .Include(room => room.Match)
                        .Where(x => x.RoomStatus == RoomStatus.Waiting);

                    if (rooms.Any(x => x.Players.Count < x.PlayersLimit))
                    {
                        var room = rooms.First(x => x.Players.Count < x.PlayersLimit);
                        room.Players.Add(new Player(true)
                        {
                            IdInMatch = room.Players.Last().IdInMatch + 1,
                            User = db.Users.Single(u => u.Id == id)
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
        #endregion

        #region Check everybody
        [HttpGet, Route("CheckIfEveryoneReady/Room/{id:int}")]
        public IHttpActionResult CheckIfEveryoneReady(int id)
        {
            var room = db.GameRooms
                .Include(x => x.Players).Include(x => x.Players.Select(p => p.User))
                .Include(x => x.Owner)
                .Include(x => x.Match)
                .SingleOrDefault(r => r.Id == id);

            if (room != null)
            {
                if (room.Match != null)
                {
                    return Json(room);
                }

                return new ErrorResult(Request, HttpStatusCode.NoContent);
            }

            return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak szukanego pokoju");
        }
        #endregion

        /// <summary>
        /// Ustawia gracza w tryb READY co oznacza, że jest gotowy do gry. Jak wszyscy przejdą w ten stan to można rozpocząć rozgrywkę.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        #region Set me redy
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
                    room.Match = new Match
                    {
                        ActualPlayer = 0,
                        Players = room.Players,
                    };
                }

                db.SaveChanges();
                return Ok();
            }
            else
            {
                return new ErrorResult(Request, HttpStatusCode.NotFound, "Brak szukanego pokoju");
            }
        }
        #endregion

        /// <summary>
        /// Ustawia flagę informującą, że każdy już dołączył do gry i czeka na ruch kolejnego gracza.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #region Set me in game 
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
        #endregion

        #region Create room for owner. POST
        [HttpPost, Route("CreateRoom/Owner/{id:int}/PlayersLimit/{limit:int}")]
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
                }}
            });

            db.SaveChanges();
            return Json(Mapper.Map<GameRoomModel>(room));
        }
        #endregion

        #region Create room for owner. POST
        [HttpPost]
        [ResponseType(typeof(GameRoom))]
        public IHttpActionResult CreateRoom2(RoomModel model)
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
                }}
            });

            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }
        #endregion

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

        /// <summary>
        /// Usuwanie gracza z pokoju
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        /// <summary>
        /// Usuwanie pokoju
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        #region GameRoomExists?
        private bool GameRoomExists(int id)
        {
            return db.GameRooms.Count(e => e.Id == id) > 0;
        }
        #endregion
    }
}