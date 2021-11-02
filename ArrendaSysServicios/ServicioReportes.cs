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
        public List<ReseniaPDFVM> prueba(int tipoCuenta,int id)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                
                List<ReseniaPDFVM> lista = new List<ReseniaPDFVM>();
                if (tipoCuenta == 2) //Arrendatario
                { 
                    lista = (from r in db.ReseñaArrendadorArrendatario
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                             join i in db.Inmueble on a.idInmueble equals i.idInmueble
                             where a.idArrendatario == id
                             select new ReseniaPDFVM
                             {
                                 fechaResenia = r.fechaAltaReseñaAoAr,
                                 descripcion = r.descripcionReseñaAoAr,
                                 puntuacionResenia = r.puntuacionReseñaAoAr,
                                 tipoArrendador=i.tipoArrendador,
                                 idArrendador=i.idArrendador
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
                             where i.tipoArrendador == 3 && i.idArrendador == id
                             select new ReseniaPDFVM
                             {
                                 autorResenia = arr.apellidoArrendatario + " " + arr.nombreArrendatario,
                                 fechaResenia = r.fechaAltaReseñaArAo,
                                 descripcion = r.descripcionReseñaArAo,
                                 puntuacionResenia = r.puntuacionReseñaArAo
                             }).ToList();

                }
                if (tipoCuenta == 4) //Inmobiliaria
                {
                    lista = (from r in db.ReseñaArrendatarioArrendador
                             join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                             join i in db.Inmueble on a.idInmueble equals i.idInmueble
                             join arr in db.Arrendatario on a.idArrendatario equals arr.idArrendatario
                             where i.tipoArrendador == 4 && i.idArrendador == id
                             select new ReseniaPDFVM
                             {
                                 autorResenia = arr.apellidoArrendatario + " " + arr.nombreArrendatario,
                                 fechaResenia = r.fechaAltaReseñaArAo,
                                 descripcion = r.descripcionReseñaArAo,
                                 puntuacionResenia = r.puntuacionReseñaArAo
                             }).ToList();

                }
                return lista;
            }
        }
    }
}
