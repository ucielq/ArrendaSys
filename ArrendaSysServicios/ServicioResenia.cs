using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using ArrendaSysUtilidades;

namespace ArrendaSysServicios
{
    public class ServicioResenia
    {
        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS  ------------
        public object ListarItemsReseñaPropietario(int idCuenta, int tipoCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                if (tipoCuenta == 3)
                {
                    var id = db.Propietario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idPropietario;
                    var alquileres = (from a in db.Reseña
                                      join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                      join p in db.Propietario on i.idArrendador equals p.idPropietario
                                      where p.idPropietario == id
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }
                else if (tipoCuenta == 4)
                {
                    var id = db.Inmobiliaria.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idInmobiliaria;
                    var alquileres = (from a in db.Reseña
                                      join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                      join p in db.Inmobiliaria on i.idArrendador equals p.idInmobiliaria
                                      where p.idInmobiliaria == idCuenta
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }
                else
                {

                    //
                    var id = db.Arrendatario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idArrendatario;
                    var alquileres = (from a in db.Reseña
                                      where a.idArrendatario == idCuenta
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }

            }
        }
        public int AgregarReseña(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendadorArrendatario reseña1 = new ReseñaArrendadorArrendatario();


                reseña1.fechaAltaReseñaArAo= resenia.fechaAltaReseñaArAo;
                reseña1.fechaBajaReseñaArAo = resenia.fechaBajaReseñaArAo;
                reseña1.idAlquiler = resenia.idAlquiler;
                reseña1.idReseñaArAo = resenia.idReseñaAoAr;
                reseña1.puntuacionReseñaArAo = resenia.puntuacionReseñaAoAr;
                reseña1.descripcionReseñaArAo = resenia.descripcionReseñaArAo;

                db.ReseñaArrendadorArrendatario.Add(reseña1);

                db.SaveChanges();

                return 1;

            }
        }
    }
}
