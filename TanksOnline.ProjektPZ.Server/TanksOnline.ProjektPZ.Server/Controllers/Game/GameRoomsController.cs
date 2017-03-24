﻿using System;
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

namespace TanksOnline.ProjektPZ.Server.Controllers.Game
{
    public class GameRoomsController : ApiController
    {
        private Db db = new Db();

        // GET: api/GameRooms
        public IQueryable<GameRoom> GetGameRooms()
        {
            return db.GameRooms;
        }

        // GET: api/GameRooms/5
        [ResponseType(typeof(GameRoom))]
        public async Task<IHttpActionResult> GetGameRoom(int id)
        {
            GameRoom gameRoom = await db.GameRooms.FindAsync(id);
            if (gameRoom == null)
            {
                return NotFound();
            }

            return Ok(gameRoom);
        }

        // POST: api/GameRooms
        [ResponseType(typeof(GameRoom))]
        public async Task<IHttpActionResult> PostGameRoom(GameRoom gameRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameRooms.Add(gameRoom);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gameRoom.Id }, gameRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameRoomExists(int id)
        {
            return db.GameRooms.Count(e => e.Id == id) > 0;
        }
    }
}