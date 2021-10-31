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
        public List<List<ItemViewModel>> ListarItems(bool esAI, bool esAoAr, bool esArAo)
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ListarItems(esAI, esAoAr, esArAo);
            return lista;
        }
        [System.Web.Http.Route("Api/Item/ListarItemsAoAr")]
        [System.Web.Http.ActionName("ListarItemsAoAr")]
        [System.Web.Http.HttpGet]
        public List<ItemViewModel> ListarItemsAoAr()
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ListarItemsAoAr();
            return lista;
        }
        [System.Web.Http.Route("Api/Item/ListarItemsArAo")]
        [System.Web.Http.ActionName("ListarItemsArAo")]
        [System.Web.Http.HttpGet]
        public List<ItemViewModel> ListarItemsArAo()
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ListarItemsArAo();
            return lista;
        }
        [System.Web.Http.Route("Api/Item/ListarItemsAI")]
        [System.Web.Http.ActionName("ListarItemsAI")]
        [System.Web.Http.HttpGet]
        public List<ItemViewModel> ListarItemsAI()
        {
            ServicioItem servicio = new ServicioItem();
            var lista = servicio.ListarItemsAI();
            return lista;
        }
    }
}