using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using static TanksOnline.ProjektPZ.Server.Controllers.Hubs.BulletPositionHub;

namespace TanksOnline.ProjektPZ.Server.Controllers.Hubs
{
    public class BulletPositionBroadCast
    {
        private readonly static Lazy<BulletPositionBroadCast> _instance = new Lazy<BulletPositionBroadCast>(() => new BulletPositionBroadCast());
        // We're going to broadcast to all clients a maximum of 30 times per second
        private readonly TimeSpan BroadcastInterval = TimeSpan.FromMilliseconds(1000/30);
        private readonly IHubContext<IBulletPosHubModel> _hubContext;
        private Timer _broadcastLoop;
        private BulletPositionModel _model;
        private bool _modelUpdated;

        public BulletPositionBroadCast()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<BulletPositionHub, IBulletPosHubModel>();
            _model = new BulletPositionModel();
            _modelUpdated = false;
            _broadcastLoop = new Timer(BroadcastPosition, null, BroadcastInterval, BroadcastInterval);
        }

        public void BroadcastPosition(object state)
        {
            // TODO RK: Docelowo funkcja powinna sama generować tor lotu pocisku oraz obsługiwać moment wybuchu.
            // Wtedy będzie to o wiele płynniejsze
            if (_modelUpdated)
            {
                _hubContext.Clients.AllExcept(_model.CreatedBy).SendBulletPos(_model);
                _modelUpdated = false;
            }
        }

        public void UpdateShape(BulletPositionModel clientModel)
        {
            _model = clientModel;
            _modelUpdated = true;
        }

        public static BulletPositionBroadCast Instance {
            get {
                return _instance.Value;
            }
        }

        public void TriggerExplosion(BulletPositionModel model)
        {
            _hubContext.Clients.AllExcept(_model.CreatedBy).SendExplosionPos(_model);
        }
    }

    public class BulletPositionHub : Hub
    {
        private BulletPositionBroadCast _broadcaster;

        public BulletPositionHub() : this(BulletPositionBroadCast.Instance) { }

        public BulletPositionHub(BulletPositionBroadCast broadcaster)
        {
            _broadcaster = broadcaster;
        }

        public void UpdateBulletModel(BulletPositionModel model)
        {
            model.CreatedBy = Context.ConnectionId;
            _broadcaster.UpdateShape(model);
        }

        public void TriggerExplosion(BulletPositionModel model)
        {
            model.CreatedBy = Context.ConnectionId;
            _broadcaster.TriggerExplosion(model);
        }

        public interface IBulletPosHubModel
        {
            void SendBulletPos(BulletPositionModel model);
            void SendExplosionPos(BulletPositionModel model);
        }
    }

    public class BulletPositionModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
    }
}