using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TanksOnline.ProjektPZ.Server.Controllers.Hubs
{
    public class TankTurretHub : Hub<TankTurretHub.ITankTurretHubModel>
    {
        public void NewTurretAngle(int roomId, int playerMatchId, float angle)
        {
            Clients.OthersInGroup($"GameRoom.{roomId}").TurretAngleChanged(new TurretChangedModel
            {
                Angle = angle,
                PlayerMatchId = playerMatchId,
            });
        }

        public void Connect(int roomId)
        {
            Groups.Add(Context.ConnectionId, $"GameRoom.{roomId}");
        }

        public interface ITankTurretHubModel
        {
            void TurretAngleChanged(TurretChangedModel model);
        }

        public class TurretChangedModel
        {
            public float Angle { get; set; }
            public int PlayerMatchId { get; set; }
        }
    }
}