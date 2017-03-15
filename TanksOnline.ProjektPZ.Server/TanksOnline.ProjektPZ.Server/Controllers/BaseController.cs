using AutoMapper;
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
        protected Db db = new Db();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        protected TDomain MapToDbo<TDomain>(object model)
        {
            return Mapper.Instance.Map<TDomain>(model);
        }
    }
}