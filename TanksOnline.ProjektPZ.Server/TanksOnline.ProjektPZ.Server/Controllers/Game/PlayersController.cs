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
using TanksOnline.ProjektPZ.Server.Models.Player;

namespace TanksOnline.ProjektPZ.Server.Controllers.Game
{
    [RoutePrefix("api/players")]
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

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> PostPlayer([FromBody] PostPlayerModel model)
        {
            // Trzeba najpierw sprawdzić, czy istnieje obiekt w bazie o podanym Id usera
            // Jeśli się taki znajdzie to podmieniamy wartości, a jak nie to tworzymy nowego
            var player = await db.Players.SingleOrDefaultAsync(x => x.User.Id == model.User.Id);
            if (player != null)
            {
                player.IdInMatch = model.IdInMatch;
                //player.TankHP = // TODO RK: Jakaś stałą ma być
            }
            throw new NotImplementedException();
        }
        
        [HttpPut, Route("{id:int}/turret/")]
        public async Task<IHttpActionResult> PutTurretAngle([FromUri] int id, [FromBody] PutTurretAngleModel model)
        {
            var player = await db.Players.FindAsync(id);
            player.TurretAngle = model.Angle;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}