using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


//using ArrendaSysModelos;


namespace ArrendaSys.Controllers
{
    //[Permiso("NOT")]
    [SessionUtility]
    public class NotificacionesController : Controller
    {
        // GET: Notificaciones
        public ActionResult Index()
        {
            
            return View();
        }
    }
}