using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ArrendaSys.Controllers.Api
{
    public class CuentaApiController : ApiController
    {
        [System.Web.Http.ActionName("hola")]
        [System.Web.Http.HttpGet]
        public CuentaViewModel hola()
        {
            ArrendaSysServicios.ServicioCuenta _servicio = new ArrendaSysServicios.ServicioCuenta();
            var tmp = _servicio.hola();
            return tmp;
        }
    }
}