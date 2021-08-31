using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    [SessionUtility]
    public class EstadisticasController : Controller
    {
     
        public ActionResult Estadisticas()
        {
            return View();
        }
    }
}