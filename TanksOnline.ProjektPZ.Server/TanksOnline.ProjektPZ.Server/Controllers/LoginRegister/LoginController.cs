using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TanksOnline.ProjektPZ.Server.Domain;
using TanksOnline.ProjektPZ.Server.Domain.Entities;
using TanksOnline.ProjektPZ.Server.Models.UserModels;

namespace TanksOnline.ProjektPZ.Server.Controllers.LoginRegister
{
    [RoutePrefix("api/Login")]
    public class LoginController : BaseController
    {
        // GET: api/Login
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }


        // POST: api/Login
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (EmailExist(model.Email))
            {
                var user = await db.Users.SingleOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            else
            {
                return NotFound();
            }
        }
        // GET: api/Login/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.Include(t => t.TankInfo).Include(s => s.UserScore).SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
      
        [ResponseType(typeof(void))]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
        public bool EmailExist(string email)
        {
            var user = db.Users.Where(u => u.Email.Equals(email));
            if (user.Any())
            {
                return true;
            }
            return false;
        }
    }
}