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
    public class RolApiController : ApiController
    {
        [System.Web.Http.Route("Api/Rol/ObtenerMenu")]
        [System.Web.Http.ActionName("ObtenerMenu")]
        [System.Web.Http.HttpGet]
        public List<URLViewModel> ObtenerMenu(string emailCuenta)
        {

            var idCuenta = 0;
            List<URLViewModel> listMenu = new List<URLViewModel>();

            if (emailCuenta != null)
            {
                ServicioRol servRol = new ServicioRol();
                listMenu = servRol.ObtenerMenu(emailCuenta);

            }


            return listMenu;
        }
        [System.Web.Http.Route("Api/Rol/ModificarRol")]
        [System.Web.Http.ActionName("ModificarRol")]
        [System.Web.Http.HttpPost]
        public int ModificarRol(RolViewModel rol)
        {
            ServicioRol servicio = new ServicioRol();
            int codigo;
            codigo = servicio.ModificarRol(rol);
            return codigo;
        }
        [System.Web.Http.Route("Api/Rol/obtenerRol")]
        [System.Web.Http.ActionName("obtenerRol")]
        [System.Web.Http.HttpGet]
        public RolViewModel obtenerRol(int idrol)
        {
            ServicioRol servicio = new ServicioRol();
            
            var rol = servicio.obtenerRol(idrol);
            return rol;
        }

        [System.Web.Http.Route("Api/Rol/obtenerRoles")]
        [System.Web.Http.ActionName("obtenerRoles")]
        [System.Web.Http.HttpGet]
        public List<RolViewModel> obtenerRoles()
        {
            ServicioRol servicio = new ServicioRol();

            var roles = servicio.obtenerRoles();
            return roles;
        }
    }
}