using ArrendaSys.Controllers.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    [SessionUtility]
    [Permiso("CON")]
    public class ConfiguracionesController : Controller
    {
        // GET: Configuraciones
        public ActionResult AdministrarRoles()
        {
            return View();
        }

        public ActionResult AdministrarPermisosRol()
        {
            return View();
        }
        public ActionResult AdministrarItemsResenias()
        {
            return View();
        }
    }
}