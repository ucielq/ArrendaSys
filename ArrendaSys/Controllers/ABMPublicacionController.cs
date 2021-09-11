using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class ABMPublicacionController : Controller
    {
        [SessionUtility]
        public ActionResult Index()
        {
            return View();
        }
    }
}