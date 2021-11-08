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
            ServicioAlquiler serv = new ServicioAlquiler();
            return serv.AgregarAlquiler(alquiler);
        }


        [System.Web.Http.Route("Api/Alquiler/ListarAlquileres")]
        [System.Web.Http.ActionName("ListarAlquileres")]
        [System.Web.Http.HttpGet]
        public object ListarAlquileres(int idCuenta,int tipoCuenta)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            var lista = servicio.ListarAlquileres(idCuenta,tipoCuenta);
            return lista;
        }

        [System.Web.Http.Route("Api/Alquiler/EliminarAlquiler")]
        [System.Web.Http.ActionName("EliminarAlquiler")]
        [System.Web.Http.HttpPost]
        public void EliminarAlquiler(AlquileresViewModel idAlquiler)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
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

        [System.Web.Http.Route("Api/Alquiler/ObtenerInmuebles")]
        [System.Web.Http.ActionName("ObtenerInmuebles")]
        [System.Web.Http.HttpGet]
        public List<InmuebleViewModel> ObtenerInmuebles(int idPropietario)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            var lista = servicio.ObtenerInmuebles(idPropietario);
            return lista;
        }

        //preguntar que me ayude a seguir la idea
        [System.Web.Http.Route("Api/Alquiler/ConfirmarAlquiler")]
        [System.Web.Http.ActionName("ConfirmarAlquiler")]
        [System.Web.Http.HttpPut]
        public void ConfirmarAlquiler(int idAlquiler, int idAlquilerEstado)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            servicio.ConfirmarAlquiler(idAlquiler, idAlquilerEstado);


        }
        [System.Web.Http.Route("Api/Alquiler/CancelarAlquiler")]
        [System.Web.Http.ActionName("CancelarAlquiler")]
        [System.Web.Http.HttpPut]
        public void CancelarAlquiler(int idAlquiler, int idAlquilerEstado)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            servicio.CancelarAlquiler(idAlquiler, idAlquilerEstado);


        }
        [System.Web.Http.Route("Api/Alquiler/EditarAlquiler")]
        [System.Web.Http.ActionName("EditarAlquiler")]
        [System.Web.Http.HttpPost]
        public void EditarAlquiler(AlquileresViewModel alquiler)
        {
            ServicioAlquiler serv = new ServicioAlquiler();
           serv.EditarAlquiler(alquiler);
        }

        [System.Web.Http.Route("Api/Alquiler/verificarDNI")]
        [System.Web.Http.ActionName("verificarDNI")]
        [System.Web.Http.HttpGet]
        public int verificarDNI(int DniArrendatario)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            var idArrendatario = servicio.verificarDNI(DniArrendatario);

            return idArrendatario;
        }

    }
}
