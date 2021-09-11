using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class PublicacionController : Controller
    {
        // GET: Publicacion
        public ActionResult Publicaciones()
        {
            return View();
        }

    }
}
