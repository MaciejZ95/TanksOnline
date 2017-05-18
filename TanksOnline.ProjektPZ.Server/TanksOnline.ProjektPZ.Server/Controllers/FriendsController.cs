using System.Linq;
using System.Data.Entity;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using TanksOnline.ProjektPZ.Server.Models.UserModels;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace TanksOnline.ProjektPZ.Server.Controllers
{
    public class FriendsController : BaseController
    {
        // GET: api/Users
        public IQueryable<Friends> GetFriends()
        {
            return db.Friends;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Friends))]
        public async Task<IHttpActionResult> GetFriend(int id)
        {
            Friends user = await db.Friends.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Friends
        [ResponseType(typeof(Friends))]
        public async Task<IHttpActionResult> PostFriend(FriendsModel friendsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friend = db.Friends.Add(MapToDbo<Friends>(friendsModel));
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { RelationId = friend.RelationId }, friend);
        }
    }
}