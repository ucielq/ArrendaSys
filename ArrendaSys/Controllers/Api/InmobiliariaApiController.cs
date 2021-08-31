using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class InmobiliariaApiController : Controller
    {
        [System.Web.Http.Route("Api/Inmobiliaria/CrearInmobiliaria")]
        [System.Web.Http.ActionName("CrearInmobiliaria")]
        [System.Web.Http.HttpPost]
        public int CrearInmobiliaria(InmobiliariaApiController inmobiliaria)
        {
            return 0;
        }

    }
}
