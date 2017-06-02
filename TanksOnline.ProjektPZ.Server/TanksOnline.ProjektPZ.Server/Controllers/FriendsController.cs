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

        // PUT: api/Friends/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, Friends friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friend.RelationId)
            {
                return BadRequest();
            }

            db.Entry(friend).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Friends/5
        [ResponseType(typeof(Friends))]
        public async Task<IHttpActionResult> DeleteFriend(int id)
        {
            Friends friend = await db.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }

            db.Friends.Remove(friend);
            await db.SaveChangesAsync();

            return Ok(friend);
        }

        private bool UserExists(int id)
        {
            return db.Friends.Count(e => e.RelationId == id) > 0;
        }
    }
}