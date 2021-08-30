using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class CuentaApiController : ApiController
    {
        [System.Web.Http.Route("Api/Cuenta/ValidarMail")]
        [System.Web.Http.ActionName("ValidarMail")]
        [System.Web.Http.HttpGet]
        public int ValidarMail(string email)
        {
            using(ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var existe = db.Cuenta.Where(x => x.emailCuenta == email).FirstOrDefault();
                if (existe != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        [System.Web.Http.Route("Api/Cuenta/altaCuenta")]
        [System.Web.Http.ActionName("altaCuenta")]
        [System.Web.Http.HttpGet]
        public int altaCuenta(string email, string password)
        {
            ArrendaSysServicios.ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            return servicioCuenta.altaCuenta(email, password);
        }

        [System.Web.Http.Route("Api/Cuenta/confirmaCuenta")]
        [System.Web.Http.ActionName("confirmaCuenta")]
        [System.Web.Http.HttpGet]
        public int confirmaCuenta(string email)
        {            
            ArrendaSysServicios.ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            var id=servicioCuenta.confirmaCuenta(email);
            return id;
        }
    }
}