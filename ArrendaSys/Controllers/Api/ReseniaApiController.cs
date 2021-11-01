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
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAorAr")]
        [System.Web.Http.ActionName("CrearReseniaAorAr")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaArAo(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaArAo(resenia);
        }
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAorAr")]
        [System.Web.Http.ActionName("CrearReseniaAorAr")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaAI(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaAI(resenia);
        }

        //Listar reseñas


        [System.Web.Http.Route("Api/Resenia/ListarReseniasAoAr")]
        [System.Web.Http.ActionName("ListarReseniasAoAr")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasAoAr(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasAoAr(idAlquiler);
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/ListarReseniasArAo")]
        [System.Web.Http.ActionName("ListarReseniasArAo")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasArAo(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasArAo(idAlquiler);
            return lista;
        }
        [System.Web.Http.Route("Api/Resenia/ListarReseniasAI")]
        [System.Web.Http.ActionName("ListarReseniasAI")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasAI(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasAI(idAlquiler);
            return lista;
        }

    }
}
