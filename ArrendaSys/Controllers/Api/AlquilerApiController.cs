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
    [SessionUtility]

    public class AlquilerApiController : ApiController
    {

        [System.Web.Http.Route("Api/Alquiler/listarAlquileres")]
        [System.Web.Http.ActionName("listarAlquileres")]
        [System.Web.Http.HttpGet]
        public List<AlquileresViewModel> listarAlquileres(int idPropietario)
        {
            var servicio = new ServicioAlquiler();
            return servicio.ListarAlquileresPropietario(idPropietario);

        }

    }
}
