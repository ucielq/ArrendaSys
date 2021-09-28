using ArrendaSysServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class DepartamentoApiController : ApiController
    {
        

        [System.Web.Http.Route("Api/Departamento/ObtenerDepto")]
        [System.Web.Http.ActionName("ObtenerDepto")]
        [System.Web.Http.HttpGet]
        public object ObtenerDepto()
        {
            ServicioDepartamento servDepto = new ServicioDepartamento();
            object listaDepto = servDepto.ObtenerDepto();
            return listaDepto;
        }
    }
}
