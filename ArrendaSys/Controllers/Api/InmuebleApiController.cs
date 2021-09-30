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
    public class InmuebleApiController : ApiController
    {
        [System.Web.Http.Route("Api/Inmueble/AgregarInmueble")]
        [System.Web.Http.ActionName("AgregarInmueble")]
        [System.Web.Http.HttpPost]
        public InmuebleViewModel AgregarInmueble(InmuebleViewModel inmueble)
        {
            ServicioInmueble serv = new ServicioInmueble();
            return serv.AgregarInmueble(inmueble);
        }

        [System.Web.Http.Route("Api/Inmueble/GuardarArchivosInmueble")]
        [System.Web.Http.ActionName("GuardarArchivosInmueble")]
        [System.Web.Http.HttpPost]
        public int GuardarArchivosInmueble()
        {
            ArchivoApiController api = new ArchivoApiController();
            ServicioInmueble serv2 = new ServicioInmueble();
            var listaArchivos = api.Subir("Inmueble");
            if (listaArchivos.Count > 0)
            {
                if (listaArchivos[0].error != 400)
                {
                    return serv2.GuardarArchivoInmueble(listaArchivos);
                }
                else return 500;
            }
            else
            {
                return 500;
            }
            

           
        }
        [System.Web.Http.Route("Api/Inmueble/ObtenerInmueblesPropietario")]
        [System.Web.Http.ActionName("ObtenerInmueblesPropietario")]
        [System.Web.Http.HttpGet]
        public List<InmuebleViewModel> ObtenerInmueblesPropietario(int idPropietario)
        {
            ServicioInmueble servicio = new ServicioInmueble();
            var listaInmuebles = servicio.ObtenerInmueblesPropietario(idPropietario);

            return listaInmuebles;
        }

        [System.Web.Http.Route("Api/Inmueble/ObtenerInmueblesInmobiliaria")]
        [System.Web.Http.ActionName("ObtenerInmueblesInmobiliaria")]
        [System.Web.Http.HttpGet]
        public List<InmuebleViewModel> ObtenerInmueblesInmobiliaria(int idInmobiliaria)
        {
            ServicioInmueble servicio = new ServicioInmueble();
            var listaInmuebles = servicio.ObtenerInmueblesInmobiliaria(idInmobiliaria);

            return listaInmuebles;
        }

        [System.Web.Http.Route("Api/Inmueble/ObtenerInmueble")]
        [System.Web.Http.ActionName("ObtenerInmueble")]
        [System.Web.Http.HttpGet]
        public InmuebleViewModel ObtenerInmueble(int idInmueble)
        {
            ServicioInmueble servicio = new ServicioInmueble();
            var listaInmuebles = servicio.ObtenerInmueble(idInmueble);

            return listaInmuebles;
        }

        



        [System.Web.Http.Route("Api/Inmueble/EliminarInmueble")]
        [System.Web.Http.ActionName("EliminarInmueble")]
        [System.Web.Http.HttpPut]
        public void EliminarInmueble(int idInmueble)
        {
            ServicioInmueble servicio = new ServicioInmueble();
            servicio.EliminarInmueble(idInmueble);

            
        }
    }
}
