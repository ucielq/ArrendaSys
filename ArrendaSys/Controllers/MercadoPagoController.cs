using ArrendaSysModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class MercadoPagoController : Controller
    {

        public ActionResult pagoAprobado()
        {
            var idCuenta = (int)System.Web.HttpContext.Current.Session["idCuenta"];
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                Cuenta cuenta = db.Cuenta.Where(x=>x.idCuenta == idCuenta).FirstOrDefault();
                System.Web.HttpContext.Current.Session["premium"] = "1";
                Premium premium = new Premium();
                premium.fechaAltaPremium=DateTime.Now;
                db.Premium.Add(premium);
                db.SaveChanges();
                cuenta.idPremium=premium.idPremium; ;
                db.SaveChanges();
            };
            return RedirectToAction("Index", "Home");
        }
    }
}