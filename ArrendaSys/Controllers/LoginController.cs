using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;

namespace ArrendaSys.Controllers
{
    //[SessionUtility]
    //[Permiso("HOME")]
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Validar(string mail, string password)
        {
            try
            {
                ServicioCuenta servicio = new ServicioCuenta();
                if (string.IsNullOrEmpty(mail))
                {
                    return RedirectToAction("LoginManual", "Login");
                }
                if (string.IsNullOrEmpty(password))
                {
                    return RedirectToAction("LoginManual", "Login");
                }
                var resp = servicio.ObtenerLoginUsuario(mail, password);
                if (resp != "DatosIncorrectos#Login" && resp != "PermisoDenegado#Login")
                {
                    System.Web.HttpContext.Current.Session["usuarioLogeado"] = mail;
                }
                return RedirectToAction(resp.Split('#')[0], resp.Split('#')[1]);

            }
            catch (UnauthorizedAccessException e)
            {
                ViewBag.User = e.Message;
            }
            return RedirectToAction("LoginManual", "Login");
        }
    }
}