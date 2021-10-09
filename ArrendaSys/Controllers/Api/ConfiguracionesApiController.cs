using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArrendaSys.Controllers.Api
{
    
    public class ConfiguracionesApiController : ApiController
    {
        [System.Web.Http.Route("Api/Configuraciones/ObtenerRoles")]
        [System.Web.Http.ActionName("ObtenerRoles")]
        [System.Web.Http.HttpGet]
        public object ObtenerRoles(bool activo)
        {
            ServicioRol servicio = new ServicioRol();
            var lista = servicio.ObtenerRoles(activo);
            return lista;
        }
    }
}
