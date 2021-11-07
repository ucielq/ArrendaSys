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
            var cuenta = servicioCuenta.confirmaCuenta(email);
            System.Web.HttpContext.Current.Session["usuarioLogeado"] = email;
            System.Web.HttpContext.Current.Session["idCuenta"] = cuenta.idCuenta;
            System.Web.HttpContext.Current.Session["foto"] = cuenta.rutaFoto;
            return RedirectToAction("AdministrarPerfil","Perfil",new {id =cuenta.idCuenta });
        }
        public ActionResult CambiarTipoCuenta(int tipoCuenta,int id,int idCuenta)
        {
            System.Web.HttpContext.Current.Session["tipoCuenta"] =tipoCuenta.ToString();
            System.Web.HttpContext.Current.Session["id"] = id.ToString();
            return RedirectToAction("cambiarFoto", "Cuenta",new { id=idCuenta });
            
        }
        public ActionResult cambiarFoto(int id)
        {
            using (ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var cuenta = db.Cuenta.Where(x => x.idCuenta == id).FirstOrDefault();
                if (cuenta != null) {
                    System.Web.HttpContext.Current.Session["foto"] = cuenta.urlImagen;
                }
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
