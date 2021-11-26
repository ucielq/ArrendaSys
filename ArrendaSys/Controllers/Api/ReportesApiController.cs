using ArrendaSysModelos;
using ArrendaSysServicios;
using ArrendaSysUtilidades;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
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
    public class ReportesApiController : ApiController
    {
        public Dictionary<string, Dictionary<int?, int>> obtenerLista(int tipoCuenta,int id,string fechaDesde, string fechaHasta)
        {
            ArrendasysEntities db = new ArrendasysEntities();
            Dictionary<string, Dictionary<int?, int>> hash = new Dictionary<string, Dictionary<int?, int>>();
            DateTime desde = Convert.ToDateTime(fechaDesde);
            DateTime hasta = Convert.ToDateTime(fechaHasta);
            if (tipoCuenta == 2) //Arrendatario
            {
                var lista = (from r in db.ReseñaArrendadorArrendatario
                         join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                         join i in db.Inmueble on a.idInmueble equals i.idInmueble
                         where a.idArrendatario == id && r.fechaAltaReseñaAoAr>=desde && r.fechaAltaReseñaAoAr<=hasta
                         select new ReseniaPDFVM
                         {
                             fechaResenia = r.fechaAltaReseñaAoAr,
                             descripcion = r.descripcionReseñaAoAr,
                             puntuacionResenia = r.puntuacionReseñaAoAr,
                             idResenia = r.idReseñaAoAr
                         }).ToList();


                int cont = 0;
                Dictionary<int?, int> hash2 = new Dictionary<int?, int>();
                Dictionary<int?, int> hash3 = new Dictionary<int?, int>();
                foreach (var item in lista)
                {
                    var listaItems = db.ReseñaItemAoAr.Where(x => x.idReseñaAoAr == item.idResenia).ToList();
                    foreach (var i in listaItems)
                    {
                        var nombre = db.ItemReseña.Where(x => x.idItemReseña == i.idItemReseña).FirstOrDefault().nombreItemReseña;
                        if (hash.TryGetValue(nombre, out hash3))
                        {
                            if (hash[nombre].TryGetValue(i.puntuacionReseñaItemAoAr, out cont))
                            {
                                hash[nombre][i.puntuacionReseñaItemAoAr]++;
                            }
                            else
                            {
                                hash[nombre].Add(i.puntuacionReseñaItemAoAr, 1);
                            }
                        }
                        else
                        {
                            Dictionary<int?, int> dic = new Dictionary<int?, int>();
                            dic.Add(i.puntuacionReseñaItemAoAr, 1);
                            hash.Add(nombre, dic);
                        }

                    }
                }
            } 
            if (tipoCuenta == 3) //Propietario
            {
                var lista = (from r in db.ReseñaArrendatarioArrendador
                         join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                         join i in db.Inmueble on a.idInmueble equals i.idInmueble
                         where i.tipoArrendador == 3 && i.idArrendador==id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                             select new ReseniaPDFVM
                         {
                             fechaResenia = r.fechaAltaReseñaArAo,
                             descripcion = r.descripcionReseñaArAo,
                             puntuacionResenia = r.puntuacionReseñaArAo,
                             idResenia = r.idReseñaArAo
                         }).ToList();

                int cont = 0;
                Dictionary<int?, int> hash2 = new Dictionary<int?, int>();
                Dictionary<int?, int> hash3 = new Dictionary<int?, int>();
                foreach (var item in lista)
                {
                    var listaItems = db.ReseñaItemArAo.Where(x => x.idReseñaArAo == item.idResenia).ToList();
                    foreach (var i in listaItems)
                    {
                        var nombre = db.ItemReseña.Where(x => x.idItemReseña == i.idItemReseña).FirstOrDefault().nombreItemReseña;
                        if (hash.TryGetValue(nombre, out hash3))
                        {
                            if (hash[nombre].TryGetValue(i.puntuacionReseñaItemArAo, out cont))
                            {
                                hash[nombre][i.puntuacionReseñaItemArAo]++;
                            }
                            else
                            {
                                hash[nombre].Add(i.puntuacionReseñaItemArAo, 1);
                            }
                        }
                        else
                        {
                            Dictionary<int?, int> dic = new Dictionary<int?, int>();
                            dic.Add(i.puntuacionReseñaItemArAo, 1);
                            hash.Add(nombre, dic);
                        }
                    }
                }
            }
            if (tipoCuenta == 4) //Inmobiliaria
            {
                var lista = (from r in db.ReseñaArrendatarioArrendador
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                         join i in db.Inmueble on a.idInmueble equals i.idInmueble
                         where i.tipoArrendador == 4 && i.idArrendador==id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                         select new ReseniaPDFVM
                         {
                             fechaResenia = r.fechaAltaReseñaArAo,
                             descripcion = r.descripcionReseñaArAo,
                             puntuacionResenia = r.puntuacionReseñaArAo,
                             idResenia = r.idReseñaArAo
                         }).ToList();
                int cont = 0;
                Dictionary<int?, int> hash2 = new Dictionary<int?, int>();
                Dictionary<int?, int> hash3 = new Dictionary<int?, int>();
                foreach (var item in lista)
                {
                    var listaItems = db.ReseñaItemArAo.Where(x => x.idReseñaArAo == item.idResenia).ToList();
                    foreach (var i in listaItems)
                    {
                        var nombre = db.ItemReseña.Where(x => x.idItemReseña == i.idItemReseña).FirstOrDefault().nombreItemReseña;
                        if (hash.TryGetValue(nombre, out hash3))
                        {
                            if (hash[nombre].TryGetValue(i.puntuacionReseñaItemArAo, out cont))
                            {
                                hash[nombre][i.puntuacionReseñaItemArAo]++;
                            }
                            else
                            {
                                hash[nombre].Add(i.puntuacionReseñaItemArAo, 1);
                            }
                        }
                        else
                        {
                            Dictionary<int?, int> dic = new Dictionary<int?, int>();
                            dic.Add(i.puntuacionReseñaItemArAo, 1);
                            hash.Add(nombre, dic);
                        }
                    }
                }
            }
            
            return hash;
        }
        [System.Web.Http.Route("Api/Reportes/excel")]
        [System.Web.Http.ActionName("excel")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage excel(int tipoCuenta,int id,string fechaDesde,string fechaHasta)
        {

            var hash = obtenerLista(tipoCuenta,id,fechaDesde,fechaHasta);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
            var aux = 1;
            var cont = 0;
            foreach(var item in hash)
            {
                worksheet.Cells[aux + 1, 1].Value = item.Key;
                if (item.Value.TryGetValue(1,out cont))
                {
                    worksheet.Cells[aux + 1, 2].Value = item.Value[1];
                }
                if (item.Value.TryGetValue(2, out cont))
                {
                    worksheet.Cells[aux + 1, 3].Value = item.Value[2];
                }
                if (item.Value.TryGetValue(3, out cont))
                {
                    worksheet.Cells[aux + 1, 4].Value = item.Value[3];
                }
                if (item.Value.TryGetValue(4, out cont))
                {
                    worksheet.Cells[aux + 1, 5].Value = item.Value[4];
                }
                if (item.Value.TryGetValue(5, out cont))
                {
                    worksheet.Cells[aux + 1, 6].Value = item.Value[5];
                }
                aux++;
            }
            for (int i= 2; i <= 6; i++)
            {
                
                worksheet.Cells[1, i].Value = i-1 + "☆";
            }
            worksheet.Cells.AutoFitColumns();
            ExcelBarChart columnChart = worksheet.Drawings.AddChart("chart", eChartType.ColumnStacked1003D) as ExcelBarChart;

            //set the title
            columnChart.Title.Text = "Estadísticas de puntuaciones";

            //select the ranges for the columns. First the values, then the header range

            var series = columnChart.Series.Add(ExcelRange.GetAddress(2, 2, hash.Count + 1, 2), "A2:A" + (hash.Count + 1).ToString());
            series.HeaderAddress = new ExcelAddress("'Sheet1'!B1");
            var series2 = columnChart.Series.Add(ExcelRange.GetAddress(2, 3, hash.Count+1, 3), "A2:A" + (hash.Count + 1).ToString());
            series2.HeaderAddress = new ExcelAddress("'Sheet1'!C1");
            var series3 = columnChart.Series.Add(ExcelRange.GetAddress(2, 4, hash.Count+1, 4), "A2:A" + (hash.Count + 1).ToString());
            series3.HeaderAddress = new ExcelAddress("'Sheet1'!D1");
            var series4 = columnChart.Series.Add(ExcelRange.GetAddress(2, 5, hash.Count+1, 5), "A2:A" + (hash.Count + 1).ToString());
            series4.HeaderAddress = new ExcelAddress("'Sheet1'!E1");
            var series5 = columnChart.Series.Add(ExcelRange.GetAddress(2, 6, hash.Count+1, 6), "A2:A" + (hash.Count + 1).ToString());
            series5.HeaderAddress = new ExcelAddress("'Sheet1'!F1");

            columnChart.DataLabel.ShowValue=true;
            columnChart.SetSize(500, 500);
            columnChart.SetPosition(0,500);
            var pathInic = "~/TempFolder/";
            var nombreArchivo = "Excel" + Convert.ToDateTime(DateTime.Today).ToString("dd-MM-yyyy") + ".xlsx";
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(pathInic), nombreArchivo);
            FileInfo excelFile = new FileInfo(path);
            excelPackage.SaveAs(excelFile);
            byte[] bytes = File.ReadAllBytes(path);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(bytes);

            //Set the Response Content Length.
            response.Content.Headers.ContentLength = bytes.LongLength;

            //Set the Content Disposition Header Value and FileName.
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = nombreArchivo;


            //Set the File Content Type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(nombreArchivo));
            return response;
        }

        [System.Web.Http.Route("Api/Reportes/obtenerEstadisticas")]
        [System.Web.Http.ActionName("obtenerEstadisticas")]
        [System.Web.Http.HttpGet]
        public Dictionary<string, Dictionary<int?, int>> obtenerEstadisticas(int tipoCuenta, int id, string fechaDesde, string fechaHasta)
        {
            var response = obtenerLista(tipoCuenta, id, fechaDesde, fechaHasta);
            return response;
        }
    }

    public class estadisticaViewModel
    {
    }
}
