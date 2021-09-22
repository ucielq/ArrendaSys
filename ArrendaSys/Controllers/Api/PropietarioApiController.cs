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
    public class PropietarioApiController : ApiController
    {
        [System.Web.Http.Route("Api/Propietario/CrearPropietario")]
        [System.Web.Http.ActionName("CrearPropietario")]
        [System.Web.Http.HttpPost]
        public int CrearPropietario(PropietarioViewModel propietario)
        {
            ServicioPropietario serv = new ServicioPropietario();
            return serv.CrearPropietario(propietario);
        }
       
        

    }
}