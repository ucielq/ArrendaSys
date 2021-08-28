using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class ArrendadorApiController : Controller
    {
        [System.Web.Http.Route("Api/Arrendador/CrearArrendador")]
        [System.Web.Http.ActionName("CrearProp")]
        [System.Web.Http.HttpPost]
        public int CrearProp(ArrendadorViewModel propietario)
        {
            //int codigo;
            //codigo = CrearProp(propietario);
            //return codigo;
            return 0;
        }

        [System.Web.Http.Route("Api/Arrendador/PerfilArrendador")]
        [System.Web.Http.ActionName("PerfilArrendador")]
        [System.Web.Http.HttpGet]
        public int PerfilArrendador()
        {
            return 0;
        }
    }
}
