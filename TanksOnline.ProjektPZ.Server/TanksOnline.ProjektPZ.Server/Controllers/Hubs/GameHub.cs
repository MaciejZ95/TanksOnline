using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TanksOnline.ProjektPZ.Server.Models.GameRoomModels;
using TanksOnline.ProjektPZ.Server.Domain;

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
                var room = db.GameRooms.Include(r => r.Players)
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    room.Players.Single(p => p.IdInMatch == shootedMatchId).TankHP--;
                    db.SaveChanges();

                    var player = room.Players.Single(p => p.Id == playerId);

                    if (player.IdInMatch == (room.PlayersLimit - 1))
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletHitPlayer(shootedMatchId, 0);
                    }
                    else
                    {
                        Clients.OthersInGroup($"{room.Id}").BulletHitPlayer(shootedMatchId, player.IdInMatch + 1);
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
                var room = db.GameRooms.Include(r => r.Players)
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    room.Players.Single(p => p.IdInMatch == killedMatchId).TankHP--;
                    db.SaveChanges();

                    var player = room.Players.Single(p => p.Id == playerId);

                    if (player.IdInMatch == (room.PlayersLimit - 1))
                    {
                        // TODO RK: Jeśli zabity przeciwnik będzie ostatnim żyjącym to trza o tym powiedzieć
                        Clients.OthersInGroup($"{room.Id}").BulletKilledPlayer(killedMatchId, 0);
                    }
                    else
                    {
                        // TODO RK: Jeśli zabity przeciwnik będzie ostatnim żyjącym to trza o tym powiedzieć
                        Clients.OthersInGroup($"{room.Id}").BulletKilledPlayer(killedMatchId, player.IdInMatch + 1);
                    }
                }
            }
        }

        #endregion

        public interface IGameHubModel
        {
            void TurretAngleChanged(float angle, int playerMatchId);
            void PlayerShooted(PlayerShootModel model);
            void BulletHitPlayer(int playerMatchId, int nextPlayerMatchId);
            void BulletKilledPlayer(int killedMatchId, int nextPlayerMatchId);
            void AllPlayersDead(int theLastOfUs);
            void ThisPlayerTurn(int playerMatchId);
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