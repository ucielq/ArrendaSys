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
    public class ItemApiController : ApiController
    {
        [System.Web.Http.Route("Api/Item/ListarItems")]
        [System.Web.Http.ActionName("ListarItems")]
        [System.Web.Http.HttpGet]
        public object ListarItems(int tipocuenta, Boolean esAI, Boolean esAoAr, Boolean esArAo)
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ListarItems(tipocuenta, esAI, esAoAr, esArAo);
            return lista;
        }
    }
}