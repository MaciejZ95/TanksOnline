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
using TanksOnline.ProjektPZ.Server.Models.PlayerModels;

namespace TanksOnline.ProjektPZ.Server.Controllers.Game
{
    [RoutePrefix("api/Players")]
    public class PlayersController : BaseController
    {
        [HttpGet, Route("{id:int}"), ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> GetPlayer([FromUri] int id)
        {
            Player player = await db.Players.Include(u => u.User).SingleOrDefaultAsync(x => x.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpGet, Route("User/{id:int}"), ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> GetPlayerByUserId([FromUri] int id)
        {
            Player player = await db.Players.Include(x => x.User).SingleOrDefaultAsync(x => x.User.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpGet, Route("User/Name/{name}/Email/{email}"), ResponseType(typeof(PlayerModel))]
        public async Task<IHttpActionResult> GetPlayerByUserEmailAndName([FromUri] string name, [FromUri] string email)
        {
            Player player = await db.Players.Include(u => u.User)
                .SingleOrDefaultAsync(x => x.User.Name == name && x.User.Email == email);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        /// <summary>
        /// Operacja dodawania nowego gracza
        /// </summary>
        /// <param name="model"></param>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> PostPlayer([FromBody] PostPlayerModel model)
        {
            // Trzeba najpierw sprawdzić, czy istnieje obiekt w bazie o podanym Id usera
            // Jeśli się taki znajdzie to podmieniamy wartości, a jak nie to tworzymy nowego
            var player = await db.Players.SingleOrDefaultAsync(x => x.User.Id == model.User.Id);
            if (player != null)
            {
                player.IdInMatch = model.IdInMatch;
                player.TankHP = Consts.DEFAULT_TANK_HP;
            }
            throw new NotImplementedException();
        }

        // DELETE: api/Palyers/5
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> DeletePlayer(int id)
        {
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            await db.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}