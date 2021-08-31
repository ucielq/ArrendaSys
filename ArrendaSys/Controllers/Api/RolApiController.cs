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
    }
}