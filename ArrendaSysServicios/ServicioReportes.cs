using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrendaSysModelos;
using ArrendaSysUtilidades;
namespace ArrendaSysServicios
{
    public class ServicioReportes
    {
        public List<ReseniaPDFVM> prueba(int tipoCuenta,int id, string fechaDesde, string fechaHasta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                DateTime desde = Convert.ToDateTime(fechaDesde);
                DateTime hasta = Convert.ToDateTime(fechaHasta);
                List<ReseniaPDFVM> lista = new List<ReseniaPDFVM>();
                if (tipoCuenta == 2) //Arrendatario
                { 
                    lista = (from r in db.ReseñaArrendadorArrendatario
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                             join i in db.Inmueble on a.idInmueble equals i.idInmueble
                             join ar in db.Arrendatario on a.idArrendatario equals ar.idArrendatario
                             where a.idArrendatario == id && r.fechaAltaReseñaAoAr>=desde && r.fechaAltaReseñaAoAr<=hasta
                             select new ReseniaPDFVM
                             {
                                 fechaResenia = r.fechaAltaReseñaAoAr,
                                 descripcion = r.descripcionReseñaAoAr,
                                 puntuacionResenia = r.puntuacionReseñaAoAr,
                                 tipoArrendador=i.tipoArrendador,
                                 idArrendador=i.idArrendador,
                                 nombre = ar.nombreArrendatario + " "+ ar.apellidoArrendatario
                             }).ToList();
                    foreach (var item in lista)
                    {
                        item.autorResenia = "";
                        if (item.tipoArrendador == 3)
                        {
                            var autor = db.Propietario.Where(x => x.idPropietario == item.idArrendador).FirstOrDefault();
                            item.autorResenia = autor.apellidoPropietario + " " + autor.nombrePropietario;
                        }
                        if (item.tipoArrendador == 4) {
                            var autor = db.Inmobiliaria.Where(x => x.idInmobiliaria == item.idArrendador).FirstOrDefault();
                            item.autorResenia = autor.nombreInmobiliaria;
                        }
                    }
                }
                if (tipoCuenta == 3) //Propietario
                {
                    lista = (from r in db.ReseñaArrendatarioArrendador
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                             join i in db.Inmueble on a.idInmueble equals i.idInmueble
                             join arr in db.Arrendatario on a.idArrendatario equals arr.idArrendatario
                             join prop in db.Propietario on i.idArrendador equals prop.idPropietario
                             where i.tipoArrendador == 3 && i.idArrendador == id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                             select new ReseniaPDFVM
                             {
                                 autorResenia = arr.apellidoArrendatario + " " + arr.nombreArrendatario,
                                 fechaResenia = r.fechaAltaReseñaArAo,
                                 descripcion = r.descripcionReseñaArAo,
                                 puntuacionResenia = r.puntuacionReseñaArAo,
                                 nombre = prop.nombrePropietario + " "+prop.apellidoPropietario
                             }).ToList();

                }
                if (tipoCuenta == 4) //Inmobiliaria
                {
                    lista = (from r in db.ReseñaArrendatarioArrendador
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                             join i in db.Inmueble on a.idInmueble equals i.idInmueble
                             join arr in db.Arrendatario on a.idArrendatario equals arr.idArrendatario
                             join inmo in db.Inmobiliaria on i.idArrendador equals inmo.idInmobiliaria
                             where i.tipoArrendador == 4 && i.idArrendador == id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                             select new ReseniaPDFVM
                             {
                                 autorResenia = arr.apellidoArrendatario + " " + arr.nombreArrendatario,
                                 fechaResenia = r.fechaAltaReseñaArAo,
                                 descripcion = r.descripcionReseñaArAo,
                                 puntuacionResenia = r.puntuacionReseñaArAo,
                                 nombre = inmo.nombreInmobiliaria
                             }).ToList();

                }
                return lista;
            }
        }
    }
}
