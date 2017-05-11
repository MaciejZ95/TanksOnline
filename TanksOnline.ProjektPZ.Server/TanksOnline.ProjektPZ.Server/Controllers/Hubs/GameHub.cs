using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TanksOnline.ProjektPZ.Server.Domain;
using TanksOnline.ProjektPZ.Server.Domain.Enums;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using System.Threading.Tasks;

namespace TanksOnline.ProjektPZ.Server.Controllers.Hubs
{
    public partial class GameHub : Hub<GameHub.IGameHubModel>
    {
        #region Hub Methods

        public void Shoot(PlayerShootModel model)
        {
            Clients.OthersInGroup($"{model.RoomId}").PlayerShooted(model);
        }
        
        public void NewTurretAngle(int roomId, int playerMatchId, float angle)
        {
            Clients.OthersInGroup($"{roomId}").TurretAngleChanged(angle, playerMatchId);
        }

        /// <summary>
        /// Operacja gdy pocisk gdzieś spadnie bez kolizji
        /// </summary>
        /// <param name="playerId">Id gracza wywołującego zdarzenie</param>
        public void BulletFallDown(int playerId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms.Include(r => r.Players)
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    var playerMatchId = room.Players.SingleOrDefault(p => p.Id == playerId).IdInMatch;

                    if (playerMatchId == (room.PlayersLimit - 1))
                    {
                        Clients.OthersInGroup($"{room.Id}").ThisPlayerTurn(0);
                    }
                    else
                    {
                        Clients.OthersInGroup($"{room.Id}").ThisPlayerTurn(playerMatchId + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Operacja gdy pocisk trafi gracza
        /// </summary>
        /// <param name="playerId">Id gracza wywołującego zdarzenie</param>
        /// <param name="shootedMatchId">Id meczowe trafionego gracza</param>
        public void BulletHitPlayer(int playerId, int shootedMatchId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms
                    .Include(r => r.Players)
                    .Include(r => r.PlayerPoints)
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    var shooter = room.Players.Single(p => p.Id == playerId);
                    room.PlayerPoints.Single(p => p.IdInMatch == shooter.IdInMatch).DealedHits++;
                    room.PlayerPoints.Single(p => p.IdInMatch == shootedMatchId).HitsTaken++;
                    db.SaveChanges();
                    
                    if (shooter.IdInMatch == (room.PlayersLimit - 1))
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletHitPlayer(shootedMatchId, 0);
                    }
                    else
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletHitPlayer(shootedMatchId, shooter.IdInMatch + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Operacja gdy gracz zabije przeciwnika
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="killedMatchId"></param>
        public void BulletKilledPlayer(int playerId, int killedMatchId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms
                    .Include(r => r.Players)
                    .Include(r => r.PlayerPoints)
                    .Include(r => r.Players.Select(p => p.User))
                    .Include(r => r.Players.Select(p => p.User.UserScore))
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    // Najpierw SignalR potem DB
                    var player = room.Players.Single(p => p.Id == playerId);

                    if (player.IdInMatch == (room.PlayersLimit - 1))
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletKilledPlayer(killedMatchId);
                    }
                    else
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletKilledPlayer(killedMatchId);
                    }

                    // Ogarnięcie statystyk zabitego gracza
                    room.Players.Single(p => p.IdInMatch == killedMatchId).TankHP--;
                    var deadPlayer = room.PlayerPoints.Single(p => p.IdInMatch == killedMatchId);
                    deadPlayer.Dead = true;
                    deadPlayer.HitsTaken++;

                    // Ogarnięcie statystyk zwycięskiego gracza
                    var winner = room.Players.Single(p => p.Id == playerId);
                    var points = room.PlayerPoints.Single(p => p.IdInMatch == winner.IdInMatch);
                    points.Kills++;
                    points.DealedHits++;

                    // Przełączenie pokoju w tryb zakończonej gry
                    room.Players.ForEach(p => p.User.Status = UserStatus.Logged);
                    room.RoomStatus = RoomStatus.GameEnded;
                    
                    PushStatisticsToDB(db, room);
                }
            }
        }

        /// <summary>
        /// Zamyka pokój w razie wyjścia gracza i wyłącza resztę graczy
        /// </summary>
        /// <param name="roomId"></param>
        public void CloseRoom(int roomId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms
                    .Include(r => r.Players)
                    .Include(r => r.Players.Select(p => p.User))
                    .Single(x => x.Id == roomId);

                Clients.OthersInGroup($"{room.Id}").SomeOneLeaveRoom();

                room.Players.ForEach(p =>
                {
                    p.User.Status = UserStatus.Logged;
                });
                room.RoomStatus = RoomStatus.Closed;

                db.SaveChanges();
            }
        }

        #endregion

        private void PushStatisticsToDB(Db db, GameRoom room)
        {
            foreach (var player in room.Players)
            {
                var p = room.PlayerPoints.Single(x => x.IdInMatch == player.IdInMatch);

                var userScore = player.User.UserScore;
                userScore.DealedHits += p.DealedHits;
                userScore.HitsTaken += p.HitsTaken;
                if (p.Dead) userScore.LostGames++;
                else userScore.WonGames++;
                userScore.PlayedGames++;
            }

            db.SaveChanges();
        }

        public interface IGameHubModel
        {
            void TurretAngleChanged(float angle, int playerMatchId);
            void PlayerShooted(PlayerShootModel model);
            void BulletHitPlayer(int playerMatchId, int nextPlayerMatchId);
            void BulletKilledPlayer(int killedMatchId);
            void ThisPlayerTurn(int playerMatchId);
            void SomeOneLeaveRoom();
        }

        #region Models
        public class PlayerShootModel
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Angle { get; set; }
            public float Speed { get; set; }
            public float AirSpeed { get; set; }
            public float Mass { get; set; }
            public float Gravity { get; set; }
            public int PlayerMatchId { get; set; }
            public int RoomId { get; set; }
        }
        #endregion
    }
}