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

        public void BulletFallDown(int x, int y, int playerId, int roomId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms.Include(r => r.Players).SingleOrDefault(r => r.Id == roomId);

                if (room != null)
                {
                    var playerMatchId = room.Players.SingleOrDefault(p => p.Id == playerId).IdInMatch;

                    if (playerMatchId == (room.PlayersLimit - 1))
                    {
                        Clients.OthersInGroup($"{roomId}").ThisPlayerTurn(0);
                    }
                    else
                    {
                        Clients.OthersInGroup($"{roomId}").ThisPlayerTurn(playerMatchId + 1);
                    }
                }
            }
        }

        public void BulletHitPlayer(int x, int y, int playerMatchId)
        {
            using (var db = new Db())
            {

            }
        }

        #endregion

        public interface IGameHubModel
        {
            void TurretAngleChanged(float angle, int playerMatchId);
            void PlayerShooted(PlayerShootModel model);
            void BulletHitPlayer();
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