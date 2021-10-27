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

        [System.Web.Http.Route("Api/Alquiler/CrearAlquiler")]
        [System.Web.Http.ActionName("CrearAlquiler")]
        [System.Web.Http.HttpPost]
        public int Alquiler(AlquileresViewModel alquiler)
        {
            ServicioReseña serv = new ServicioReseña();
            return serv.AgregarAlquiler(alquiler);
        }


        [System.Web.Http.Route("Api/Alquiler/ListarAlquileres")]
        [System.Web.Http.ActionName("ListarAlquileres")]
        [System.Web.Http.HttpGet]
        public object ListarAlquileres(int idCuenta,int tipoCuenta)
        {
            ServicioReseña servicio = new ServicioReseña();
            var lista = servicio.ListarAlquileres(idCuenta,tipoCuenta);
            return lista;
        }

        [System.Web.Http.Route("Api/Alquiler/EliminarAlquiler")]
        [System.Web.Http.ActionName("EliminarAlquiler")]
        [System.Web.Http.HttpPut]
        public void EliminarAlquiler(int idAlquiler)
        {
            ServicioReseña servicio = new ServicioReseña();
            servicio.EliminarAlquiler(idAlquiler);
        }
        [System.Web.Http.Route("Api/Alquiler/ObtenerAlquiler")]
        [System.Web.Http.ActionName("ObtenerAlquiler")]
        [System.Web.Http.HttpGet]
        public object ObtenerAlquiler(int idAlquiler, int tipoCuenta)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            var lista = servicio.ObtenerAlquiler(idAlquiler,tipoCuenta);
            return lista;
        }
    }
}
