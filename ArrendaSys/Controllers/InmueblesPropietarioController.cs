using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    [SessionUtility]
    public class InmueblesPropietarioController : Controller
    {
        // GET: InmueblesPropietario
        [Permiso("INMPROP")]
        public ActionResult InmueblesPropietarioView()
        {
            return View();
        }
        [Permiso("AGRINMPROP")]
        public ActionResult AgregarInmuebleView()
        {
            return View();
        }
    }
}