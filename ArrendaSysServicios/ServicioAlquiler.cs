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
        public object ListarAlquileres()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var alquileres = (from i in db.Alquiler
                                  select new AlquileresViewModel
                                  {
                                      idAlquiler = i.idAlquiler,
                                      fechaAltaAlquiler = i.fechaAltaAlquiler,
                                      fechaBajaAlquiler = i.fechaBajaAlquiler,
                                      idArrendatario = i.idArrendatario,
                                      idInmueble = i.idInmueble
                                  }).ToList();
                object json = new { data = alquileres };
                return json;
            }

        }

        public int AgregarAlquiler(AlquileresViewModel alquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                Alquiler alquiler1 = new Alquiler();


                        alquiler1.fechaAltaAlquiler = alquiler.fechaAltaAlquiler;
                        alquiler1.fechaBajaAlquiler = alquiler.fechaBajaAlquiler;
                        alquiler1.idArrendatario = alquiler.idArrendatario;
                        alquiler1.idInmueble = alquiler.idInmueble;
                    
                    db.Alquiler.Add(alquiler1);

                    db.SaveChanges();
                   
                    return 1;
             
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



