using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksOnline.ProjektPZ.Game.Drawables;

namespace TanksOnline.ProjektPZ.Game.Interfaces
{
    public interface ICollidable
    {
        bool CheckCollisionWithBullet(Bullet obj);
    }
}
