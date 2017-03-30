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
        [HttpGet, Route("{id:int}"), ResponseType(typeof(GameRoomModel))]
        public IHttpActionResult GetRooom([FromUri] int id)
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

        /// <summary>
        /// Zwraca obiekt pokoju jeżeli znajdzie się jakikolwiek z wolnymi miejscami
        /// </summary>
        /// <param name="id">Id użytkownika</param>
        /// <returns></returns>
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

        // TODO RK: Trzeba to zastąpić operacami z SignalR
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

        /// <summary>
        /// Ustawia gracza w tryb READY co oznacza, że jest gotowy do gry. Jak wszyscy przejdą w ten stan to można rozpocząć rozgrywkę.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Ustawia flagę informującą, że każdy już dołączył do gry i czeka na ruch kolejnego gracza.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        [HttpPost, Route("CreateRoom/Owner/{id:int}/PlayersLimit/{limit:int}")]
        public IHttpActionResult CreateRoom(int id, int limit)
        {
            var user = db.Users.Include(x => x.TankInfo).Single(x => x.Id == id);

            var room = db.GameRooms.Add(new GameRoom
            {
                Owner = user,
                PlayersLimit = limit,
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameRoomExists(int id)
        {
            return db.GameRooms.Count(e => e.Id == id) > 0;
        }
    }
}