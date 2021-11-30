using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios.Modelos;
namespace ArrendaSys.Controllers.Api
{
    [SessionUtility]

    public class ReseniaApiController : ApiController
    {

        
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAorAr")]
        [System.Web.Http.ActionName("CrearReseniaAorAr")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaAorAr(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaAorAr(resenia);
        }
        [System.Web.Http.Route("Api/Resenia/CrearReseniaArAo")]
        [System.Web.Http.ActionName("CrearReseniaArAo")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaArAo(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaArAo(resenia);
        }
        [System.Web.Http.Route("Api/Resenia/CrearReseniaAI")]
        [System.Web.Http.ActionName("CrearReseniaAI")]
        [System.Web.Http.HttpPost]
        public int CrearReseniaAI(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.CrearReseniaAI(resenia);
        }

        //Listar reseñas


        [System.Web.Http.Route("Api/Resenia/ListarReseniasAoAr")]
        [System.Web.Http.ActionName("ListarReseniasAoAr")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasAoAr(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasAoAr(idAlquiler);
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/ListarReseniasArAo")]
        [System.Web.Http.ActionName("ListarReseniasArAo")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasArAo(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasArAo(idAlquiler);
            return lista;
        }
        [System.Web.Http.Route("Api/Resenia/ListarReseniasAI")]
        [System.Web.Http.ActionName("ListarReseniasAI")]
        [System.Web.Http.HttpGet]
        public object ListarReseniasAI(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.ListarReseniasAI(idAlquiler);
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/obtenerResenias")]
        [System.Web.Http.ActionName("obtenerResenias")]
        [System.Web.Http.HttpGet]
        public ViewModelReseniaAux obtenerResenias(int tipoCuenta,int id,int pag,string fechaDesde,string fechaHasta)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.obtenerResenias(tipoCuenta,id,pag,fechaDesde,fechaHasta);
            return lista;
        }
        [System.Web.Http.Route("Api/Resenia/obtenerReseniasV2")]
        [System.Web.Http.ActionName("obtenerReseniasV2")]
        [System.Web.Http.HttpGet]
        public ViewModelReseniaAux obtenerReseniasV2(int id, int tipo, int pag,string fechaDesde,string fechaHasta)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.obtenerReseniasV2(id,tipo, pag,Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta));
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/obtenerReseniasAlquiler")]
        [System.Web.Http.ActionName("obtenerReseniasAlquiler")]
        [System.Web.Http.HttpGet]
        public ViewModelReseniaAux obtenerReseniasAlquiler(int tipoCuenta, int id, int pag, int idAlquiler, int tipoBusqueda,string fechaDesde,string fechaHasta)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.obtenerReseniasAlquiler(tipoCuenta, id, pag, idAlquiler, tipoBusqueda,Convert.ToDateTime(fechaDesde),Convert.ToDateTime(fechaHasta));
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/obtenerReseniasAlquilerInmueble")]
        [System.Web.Http.ActionName("obtenerReseniasAlquilerInmueble")]
        [System.Web.Http.HttpGet]
        public ViewModelReseniaAux obtenerReseniasAlquilerInmueble(int tipoCuenta, int id, int pag, int idAlquiler, int tipoBusqueda)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.obtenerReseniasAlquilerInmueble(tipoCuenta, id, pag, idAlquiler, tipoBusqueda);
            return lista;
        }
        

        [System.Web.Http.Route("Api/Resenia/obtenerReseniasInmueble")]
        [System.Web.Http.ActionName("obtenerReseniasInmueble")]
        [System.Web.Http.HttpGet]
        public ViewModelReseniaAux obtenerReseniasInmueble(int idInmueble, int pag)
        {
            ServicioResenia servicio = new ServicioResenia();
            var lista = servicio.obtenerReseniasInmueble(idInmueble, pag);
            return lista;
        }

        [System.Web.Http.Route("Api/Resenia/indicadorAlquilerActivo")]
        [System.Web.Http.ActionName("indicadorAlquilerActivo")]
        [System.Web.Http.HttpGet]
        public int? indicadorAlquilerActivo(int idAlquiler)
        {
            ServicioResenia servicio = new ServicioResenia();
            var indicador = servicio.indicadorAlquilerActivo(idAlquiler);

            return indicador;
        }

        [System.Web.Http.Route("Api/Resenia/GuardarArchivosArAo")]
        [System.Web.Http.ActionName("GuardarArchivosArAo")]
        [System.Web.Http.HttpPost]
        public int GuardarArchivosArAo()
        {
            ArchivoApiController api = new ArchivoApiController();
            ServicioResenia serv2 = new ServicioResenia();
            var listaArchivos = api.Subir("Inmueble");
            if (listaArchivos.Count > 0)
            {
                if (listaArchivos[0].error != 400)
                {
                    return serv2.GuardarArchivosArAo(listaArchivos);
                }
                else return 500;
            }
            else
            {
                return 500;
            }
        }
        [System.Web.Http.Route("Api/Resenia/GuardarArchivosAoAr")]
        [System.Web.Http.ActionName("GuardarArchivosAoAr")]
        [System.Web.Http.HttpPost]
        public int GuardarArchivosAoAr()
        {
            ArchivoApiController api = new ArchivoApiController();
            ServicioResenia serv2 = new ServicioResenia();
            var listaArchivos = api.Subir("Inmueble");
            if (listaArchivos.Count > 0)
            {
                if (listaArchivos[0].error != 400)
                {
                    return serv2.GuardarArchivosAoAr(listaArchivos);
                }
                else return 500;
            }
            else
            {
                return 500;
            }
        }
        [System.Web.Http.Route("Api/Resenia/GuardarArchivosAI")]
        [System.Web.Http.ActionName("GuardarArchivosAI")]
        [System.Web.Http.HttpPost]
        public int GuardarArchivosAI()
        {
            ArchivoApiController api = new ArchivoApiController();
            ServicioResenia serv2 = new ServicioResenia();
            var listaArchivos = api.Subir("Inmueble");
            if (listaArchivos.Count > 0)
            {
                if (listaArchivos[0].error != 400)
                {
                    return serv2.GuardarArchivosAI(listaArchivos);
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
