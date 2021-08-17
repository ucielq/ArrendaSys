using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class CuentaApiController : Controller
    {
        [System.Web.Http.Route("Api/CrearCuenta")]
        [System.Web.Http.ActionName("CrearCuenta")]
        [System.Web.Http.HttpGet]
        public int ValidarDatos()
        {
            return 0;
        }


    }
}