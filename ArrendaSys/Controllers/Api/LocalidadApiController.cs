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
    public class LocalidadApiController : ApiController
    {
        [System.Web.Http.Route("Api/Localidad/ObtenerLocalidad")]
        [System.Web.Http.ActionName("ObtenerLocalidad")]
        [System.Web.Http.HttpGet]
        public List<LocalidadViewModel> ObtenerLocalidad(int idDepto)
        {
            ServicioLocalidad servLoca = new ServicioLocalidad();
            var listaLocalidad = servLoca.ObtenerLocalidad(idDepto);
            return listaLocalidad;
        }
    }
}
