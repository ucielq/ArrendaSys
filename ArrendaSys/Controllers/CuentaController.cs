using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult CrearCuenta()
        {
            return View();
        }
        public ActionResult confirmaCuenta(string email)
        {
            ArrendaSysServicios.ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            var id = servicioCuenta.confirmaCuenta(email);
            System.Web.HttpContext.Current.Session["usuarioLogeado"] = email;
            System.Web.HttpContext.Current.Session["idCuenta"] = id;
            return RedirectToAction("AdministrarPerfil","Perfil",new {id =id });
        }
        public ActionResult CambiarTipoCuenta(int tipoCuenta,int id)
        {
            System.Web.HttpContext.Current.Session["tipoCuenta"] =tipoCuenta.ToString();
            System.Web.HttpContext.Current.Session["id"] = id.ToString();
            return RedirectToAction("Index", "Home");

        }
    }
}
