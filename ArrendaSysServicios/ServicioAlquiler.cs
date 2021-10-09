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
    public class ServicioAlquiler
    {
        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS PROPIETARIO ------------
        public List<AlquileresViewModel> ListarAlquileresPropietario(int idPropietario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var alquileres = (from i in db.Alquiler
                                  where i.idAlquiler == idPropietario
                                  select new AlquileresViewModel
                                  {
                                      idAlquiler = i.idAlquiler,
                                      fechaAltaAlquiler = i.fechaAltaAlquiler,
                                      fechaBajaAlquiler = i.fechaBajaAlquiler,
                                      idArrendatario = i.idArrendatario,
                                      idInmueble = i.idInmueble,
                                  }).ToList();

                return alquileres;
            }

        }

        public AlquileresViewModel AgregarAlquiler(AlquileresViewModel alquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                if (alquiler.idInmueble == null)
                {
                    Alquiler alquiler1 = new Alquiler
                    {
                        fechaAltaAlquiler = alquiler.fechaAltaAlquiler,
                        fechaBajaAlquiler = alquiler.fechaBajaAlquiler,
                        idArrendatario = alquiler.idArrendatario,
                        idInmueble = alquiler.idInmueble,
                    };
                    db.Alquiler.Add(alquiler1);

                    db.SaveChanges();
                    var ultimo = db.Alquiler.OrderByDescending(x => x.idAlquiler).FirstOrDefault();
                    alquiler.idAlquiler = ultimo.idAlquiler;
                    return alquiler;
                }
                else
                {
                    var esteAlquiler = db.Alquiler.Where(x => x.idAlquiler == alquiler.idAlquiler).FirstOrDefault();
                    AlquileresViewModel alquiler2 = new AlquileresViewModel();
                    if (esteAlquiler != null)
                    {
                        esteAlquiler.fechaAltaAlquiler = alquiler.fechaAltaAlquiler;
                        esteAlquiler.fechaBajaAlquiler = alquiler.fechaBajaAlquiler;
                        esteAlquiler.idArrendatario = alquiler.idArrendatario;
                        esteAlquiler.idInmueble = alquiler.idInmueble;
                        db.SaveChanges();
                        alquiler2.fechaAltaAlquiler = alquiler.fechaAltaAlquiler;
                        alquiler2.fechaBajaAlquiler = alquiler.fechaBajaAlquiler;
                        alquiler2.idArrendatario = alquiler.idArrendatario;
                        alquiler2.idInmueble = alquiler.idInmueble;
                    }

                    return alquiler2;
                }
            }
        }


        public void EliminarAlquiler(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var alquiler1 = db.Alquiler.Where(x => x.idAlquiler == idAlquiler).FirstOrDefault();
                if (alquiler1 != null)
                {
                    db.Alquiler.Remove(alquiler1);
                    db.SaveChanges();
                }
            }
        }

        public AlquileresViewModel ObtenerAlquiler(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                AlquileresViewModel alquiler = (from i in db.Alquiler
                                                where i.idAlquiler == idAlquiler
                                                select new AlquileresViewModel
                                                {
                                                    idAlquiler = i.idAlquiler,
                                                    fechaAltaAlquiler = i.fechaAltaAlquiler,
                                                    fechaBajaAlquiler = i.fechaBajaAlquiler,
                                                    idArrendatario = i.idArrendatario,
                                                    idInmueble = i.idInmueble
                                                }).FirstOrDefault();
                return alquiler;
            }
        }
    }
}



