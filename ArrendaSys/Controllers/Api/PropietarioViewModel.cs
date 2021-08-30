using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class PropietarioViewModel : ApiController
    {
        [System.Web.Http.Route("Api/Propietario/CrearPropietario")]
        [System.Web.Http.ActionName("CrearPropietario")]
        [System.Web.Http.HttpPost]
        public int CrearPropietario(PropietarioViewModel propietario)
        {
            //int codigo;
            //codigo = CrearProp(propietario);
            //return codigo;
            return 0;
        }

        [System.Web.Http.Route("Api/Propietario/PerfilPropietario")]
        [System.Web.Http.ActionName("PerfilArrendador")]
        [System.Web.Http.HttpGet]
        public int PerfilArrendador()
        {
            return 0;
        }
    }
}
