using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios.Modelos;
namespace ArrendaSys.Controllers.Api
{
    [SessionUtility]

    public class ReseniaApiController : ApiController
    {

        
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAorAr")]
        [System.Web.Http.ActionName("CrearReseniaAorAr")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaAorAr(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaAorAr(resenia);
        }
        [System.Web.Http.Route("Api/Resenia/CrearReseniaArAo")]
        [System.Web.Http.ActionName("CrearReseniaArAo")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaArAo(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaArAo(resenia);
        }
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAI")]
        [System.Web.Http.ActionName("CrearReseniaAI")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaAI(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaAI(resenia);
        }
    }
}
