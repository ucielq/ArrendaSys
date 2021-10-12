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
        [System.Web.Http.Route("Api/Configuraciones/ObtenerListaMenu")]
        [System.Web.Http.ActionName("ObtenerListaMenu")]
        [System.Web.Http.HttpGet]
        public object ObtenerListaMenu()
        {
            ServicioRol servicio = new ServicioRol();
            var lista = servicio.ObtenerListaMenu();
            return lista;
        }

        [System.Web.Http.Route("Api/Configuraciones/ConsultarRol")]
        [System.Web.Http.ActionName("ConsultarRol")]
        [System.Web.Http.HttpGet]
        public RolViewModel ConsultarRol(int idRol)
        {
            ServicioRol servicio = new ServicioRol();

            RolViewModel rol = servicio.ConsultarRol(idRol);

            return rol;
        }
    }
}
