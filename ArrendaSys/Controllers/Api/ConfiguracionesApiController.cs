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
        [System.Web.Http.Route("Api/Configuraciones/ConsultarItem")]
        [System.Web.Http.ActionName("ConsultarItem")]
        [System.Web.Http.HttpGet]
        public ItemViewModel ConsultarItem(int idItem)
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ConsultarItem(idItem);
            return lista;
        }
        [System.Web.Http.Route("Api/Configuraciones/GuardarItem")]
        [System.Web.Http.ActionName("GuardarItem")]
        [System.Web.Http.HttpPost]
        public int GuardarItem(ItemViewModel item)
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.GuardarItem(item);
            return lista;
        }
        [System.Web.Http.Route("Api/Configuraciones/EliminarItem")]
        [System.Web.Http.ActionName("EliminarItem")]
        [System.Web.Http.HttpPost]
        public int EliminarItem(int idItem)
        {
            using(ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var item = db.ItemReseña.Where(x => x.idItemReseña == idItem).FirstOrDefault();
                if (item != null)
                {
                    db.ItemReseña.Remove(item);
                    db.SaveChanges();
                }
                return 1;
            }
        }
        [System.Web.Http.Route("Api/Configuraciones/ObtenerItems")]
        [System.Web.Http.ActionName("ObtenerItems")]
        [System.Web.Http.HttpGet]
        public object ObtenerItems()
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ObtenerItems();
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
        //Maury
        [System.Web.Http.Route("Api/Configuraciones/AgregarRol")]
        [System.Web.Http.ActionName("AgregarRol")]
        [System.Web.Http.HttpPost]
        public int AgregarRol(RolViewModel rol)
        {
            ServicioRol servicio = new ServicioRol();
            var rol1 = servicio.AgregarRol(rol);
            return rol1;
        }
        [System.Web.Http.Route("Api/Configuraciones/EliminarRol")]
        [System.Web.Http.ActionName("EliminarRol")]
        [System.Web.Http.HttpPost]
        public int EliminarRol(RolViewModel rol)
        {
            ServicioRol servicio = new ServicioRol();
            var rol1 = servicio.EliminarRol(rol);
            return rol1;
        }
        [System.Web.Http.Route("Api/Configuraciones/EditarRol")]
        [System.Web.Http.ActionName("EditarRol")]
        [System.Web.Http.HttpPost]
        public int EditarRol(RolViewModel rol)
        {
            ServicioRol servicio = new ServicioRol();
            var rol1 = servicio.EditarRol(rol);
            return rol1;
        }



    }
}
