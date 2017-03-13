using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TanksOnline.ProjektPZ.Server.Domain;

namespace TanksOnline.ProjektPZ.Server.Controllers
{
    public class BaseController : ApiController
    {
        public Db ctx {
            get { return new Db(); }
        }
    }
}