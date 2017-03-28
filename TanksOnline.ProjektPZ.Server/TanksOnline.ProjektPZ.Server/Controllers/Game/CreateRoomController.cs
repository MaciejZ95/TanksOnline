using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TanksOnline.ProjektPZ.Server.Domain.Entities;

namespace TanksOnline.ProjektPZ.Server.Controllers.Game
{
    public class CreateRoomController : ApiController
    {
        // GET: api/CreateRoom
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreateRoom/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CreateRoom
        public void Post([FromBody]GameRoom value)
        {
        }

        // PUT: api/CreateRoom/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CreateRoom/5
        public void Delete(int id)
        {
        }
    }
}
