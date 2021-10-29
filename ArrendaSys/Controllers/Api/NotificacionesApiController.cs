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

    public class NotificacionesApiController : ApiController
    {
        [System.Web.Http.Route("Api/Notificaciones/ListarNotificaciones")]
        [System.Web.Http.ActionName("ListarNotificaciones")]
        [System.Web.Http.HttpGet]
        public object ListarNotificaciones(int idCuenta)
        {
            ServicioNotificaciones servicio = new ServicioNotificaciones();
            var lista = servicio.ListarNotificaciones(idCuenta);
            return lista;
        }


        [System.Web.Http.Route("Api/Notificaciones/EliminarNotificaciones")]
        [System.Web.Http.ActionName("EliminarNotificaciones")]
        [System.Web.Http.HttpPut]
        public void EliminarNotificaciones(int idNotificacion)
        {
            ServicioNotificaciones servicio = new ServicioNotificaciones();
            servicio.EliminarNotificaciones(idNotificacion);

        }
        [System.Web.Http.Route("Api/Notificaciones/VistoNotificacion")]
        [System.Web.Http.ActionName("VistoNotificacion")]
        [System.Web.Http.HttpPut]
        public void VistoNotificacion(int idNotificacion)
        {
            ServicioNotificaciones servicio = new ServicioNotificaciones();
            servicio.VistoNotificacion(idNotificacion);

        }



    }
}