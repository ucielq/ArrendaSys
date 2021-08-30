using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;

namespace ArrendaSys.Controllers.Api
{
    public class ArrendatarioApiController : ApiController
    {
        [System.Web.Http.Route("Api/Arrendatario/CrearArrendatario")]
        [System.Web.Http.ActionName("CrearArrendatario")]
        [System.Web.Http.HttpGet]
        public int CrearArrendatario(ArrendatarioViewModel arrendatario)
        {
            ServicioCuenta servicioCuenta = new ServicioCuenta();
            //return servicioCuenta.altaCuenta(email, password);
            return 0;
        }

    }
}
