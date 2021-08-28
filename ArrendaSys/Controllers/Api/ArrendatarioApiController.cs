using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class ArrendatarioApiController : Controller
    {
        [System.Web.Http.Route("Api/Arrendatario/CrearArrendatario")]
        [System.Web.Http.ActionName("CrearArr")]
        [System.Web.Http.HttpPost]
        public int CrearArr()
        {
            //int codigo;
            //codigo = CrearProp(propietario);
            //return codigo;
            return 0;
        }

    }
}
