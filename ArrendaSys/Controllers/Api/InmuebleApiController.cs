using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
using System;
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

    }
}
