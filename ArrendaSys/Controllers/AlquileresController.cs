using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ArrendaSys.Controllers
{
    //[SessionUtility]
    //Preguntar
    //[Permiso("ALQ")]
    public class AlquileresController : Controller
    {
        
        public ActionResult Alquileres()
        {
            return View();
        }
        public ActionResult Alquiler()
        { return View(); }
    }
}