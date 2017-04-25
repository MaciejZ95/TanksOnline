using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using TanksOnline.ProjektPZ.Server.Domain;
using TanksOnline.ProjektPZ.Server.Domain.Enums;

namespace TanksOnline.ProjektPZ.Server.Controllers.Hubs
{
    public partial class GameHub : Hub<GameHub.IGameHubModel>
    {
        public void Connect(int playerId, string roomId)
        {
            using (var db = new Db())
            {
                var room = db.GameRooms
                    .Include(p => p.Players).Include(p => p.Players.Select(x => x.User))
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                if (room != null)
                {
                    room.Players.Single(p => p.Id == playerId).User.Status = UserStatus.InGame;

                    db.SaveChanges();

                    var dupa = db.GameRooms
                    .Include(p => p.Players).Include(p => p.Players.Select(x => x.User))
                    .SingleOrDefault(r => r.Players.Any(p => p.Id == playerId));

                    Groups.Add(Context.ConnectionId, $"Room{roomId}");

                    if (room.Players.Count(p => p.User.Status == UserStatus.InGame) == room.PlayersLimit)
                    {
                        Clients.Group($"Room{roomId}").ThisPlayerTurn(new Random().Next() % (room.PlayersLimit - 1));
                    }
                }
                else
                {
                    // TODO RK: No w sumie tu możnaby zrobić rzucanie wyjątku poprzez to dziwne ErrorPipeline
                    // ale na razie byle działało...
                }
            }
        }

        // TODO RK: Niezła by była możliwość akcji na onconnected/disconnected i reconnected
    }
}