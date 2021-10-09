using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace ArrendaSys.Controllers.Api
{
    public class DireccionApiController : ApiController
    {
        [System.Web.Http.Route("Api/Direccion/AgregarDireccion")]
        [System.Web.Http.ActionName("AgregarDireccion")]
        [System.Web.Http.HttpPost]
        public DireccionViewModel AgregarDireccion(DireccionViewModel direccion)
        {

            ServicioDireccion serv = new ServicioDireccion();
            return serv.AgregarDireccion(direccion);
        }
    }
}
