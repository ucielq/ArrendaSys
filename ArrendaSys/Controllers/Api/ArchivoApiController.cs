using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace ArrendaSys.Controllers.Api

{
    public class ArchivoApiController : ApiController
    {
        private readonly Random _random = new Random();
        [System.Web.Http.Route("Api/Archivo/DescargarPdf")]
        [System.Web.Http.ActionName("DescargarPdf")]
        [System.Web.Http.HttpGet]

        public IHttpActionResult DescargarPdf(int idResenia,int idTipo)
        {
            using(ArrendasysEntities db = new ArrendasysEntities())
            {
                var path="";
                if (idTipo == 1)
                {
                    var archivo = db.ReseñaArchivo.Where(x=>x.idReseñaArchivo==idResenia && x.RA_esAoAr== true).FirstOrDefault();
                    if (archivo != null)
                    {
                        path = archivo.urlMultimediaReseñaArchivo;
                    }
                }
                if (idTipo == 2)
                {
                    var archivo = db.ReseñaArchivo.Where(x => x.idReseñaArchivo == idResenia && x.RA_esArAo == true).FirstOrDefault();
                    if (archivo != null)
                    {
                        path = archivo.urlMultimediaReseñaArchivo;
                    }
                }
                IHttpActionResult response;
                HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
                var fileStream = new FileStream(path, FileMode.Open);
                responseMsg.Content = new StreamContent(fileStream);
                responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                responseMsg.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                responseMsg.Content.Headers.ContentDisposition.FileName = "Prueba";
                response = ResponseMessage(responseMsg);
                return response;
            }
        }

        [System.Web.Http.Route("Api/Archivo/Subir")]
        [System.Web.Http.ActionName("Subir")]
        [System.Web.Http.HttpPost]
        public List<ArchivoVM> Subir(string ruta)
        {
            List<ArchivoVM> listaArchivos = new List<ArchivoVM>();

            try
            {
                var rutaArchivo = ConfigurationManager.AppSettings["rutaArchivos"];
                HttpResponseMessage result = null;
                var httpRequest = System.Web.HttpContext.Current.Request;
                var httpContext = HttpContext.Current;
                if (httpContext.Request.Files.Count > 0)
                {
                    var rutaInicial = "";
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/TempFolder/")))
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/TempFolder/"));
                   rutaInicial = "~/TempFolder/";
                    for (int i=0; i<httpContext.Request.Files.Count; i++)
                    {
                        HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                        if (httpPostedFile != null)
                        {
                            var nombreArchivo = Path.GetFileName(httpPostedFile.FileName);
                            var splitParam = httpRequest.Params.AllKeys[1].Split(',')[1];
                            var id = Int32.Parse(splitParam);
                            var numeroAleatorio = _random.Next();
                            var nombreArchivoGuardar = id + "_" + numeroAleatorio + "_" + nombreArchivo;
                            var ruta1 = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(rutaInicial), nombreArchivoGuardar);
                            ArchivoVM archivo = new ArchivoVM
                            {
                                idInmueble = id,
                                url = ruta1,
                                nombreArchivo = nombreArchivoGuardar
                            };
                            listaArchivos.Add(archivo);
                            httpPostedFile.SaveAs(ruta1);
                        }
                    }
                }
                return listaArchivos;

            }
            catch(Exception e)
            {
                ArchivoVM archivito = new ArchivoVM()
                {
                    error = 400
                    
                };
                listaArchivos.Add(archivito);
                listaArchivos[0].error = 400;
                return listaArchivos;
            }
            
        }
    }
}
