using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    [SessionUtility]
    public class InmueblesInmobiliariaController : Controller
    {
        [Permiso("INMI")]
        public ActionResult InmueblesInmobiliariaView()
        {
            return View();
        }
        [Permiso("AGRINM")]
        public ActionResult AgregarInmueble()
        {
            return View();
        }
    }
}