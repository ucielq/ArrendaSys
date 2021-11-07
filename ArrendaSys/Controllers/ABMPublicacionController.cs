using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    [SessionUtility]
    public class ABMPublicacionController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        
        [Permiso("VERPUBLI")]
        public ActionResult VerPublicacion()
        {
            return View();
        }
    }
}