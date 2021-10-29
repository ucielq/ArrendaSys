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
using System.Globalization;

namespace ArrendaSysServicios
{
    public class ServicioAlquiler
    {
        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS  ------------
        public object ListarAlquileres(int idCuenta, int tipoCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                
                if (tipoCuenta == 3)
                {
                    var id = db.Propietario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idPropietario;
                    var alquileres = (from a in db.Alquiler
                                      join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                      join p in db.Propietario on i.idArrendador equals p.idPropietario
                                      join ae in db.AlquilerEstado on a.idAlquiler equals ae.idAlquiler
                                      join ea in db.EstadoAlquiler on ae.idEstadoAlquiler equals ea.idEstadoAlquiler
                                      where p.idPropietario == id && ae.fechaBajaAlquilerEstado==null
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler =a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble,
                                          descripcionEstadoAlquiler = ea.nombreEstadoAlquiler
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }
                else if (tipoCuenta == 4)
                {
                    var id = db.Inmobiliaria.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idInmobiliaria;
                    var alquileres = (from a in db.Alquiler
                                      join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                      join p in db.Inmobiliaria on i.idArrendador equals p.idInmobiliaria
                                      join ae in db.AlquilerEstado on a.idAlquiler equals ae.idAlquiler
                                      join ea in db.EstadoAlquiler on ae.idEstadoAlquiler equals ea.idEstadoAlquiler
                                      where p.idInmobiliaria == idCuenta && ae.fechaBajaAlquilerEstado == null
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble,
                                          descripcionEstadoAlquiler = ea.nombreEstadoAlquiler
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }
                else
                {

                    //
                    var id = db.Arrendatario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idArrendatario;
                    var alquileres = (from a in db.Alquiler
                                      join ae in db.AlquilerEstado on a.idAlquiler equals ae.idAlquiler
                                      join ea in db.EstadoAlquiler on ae.idEstadoAlquiler equals ea.idEstadoAlquiler
                                      where a.idArrendatario == id && ae.fechaBajaAlquilerEstado == null
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble,
                                          descripcionEstadoAlquiler=ea.nombreEstadoAlquiler
                                      }).ToList();
                    object json = new { data = alquileres };
                    return json;
                }

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
                //var ultimoGuardado = db.Alquiler.OrderByDescending(x => x.idAlquiler).FirstOrDefault();
                CrearAlquilerEstado(alquiler1.idAlquiler);
                return 1;

            }
        }
        public void CrearAlquilerEstado(int? id)
        {
            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 3;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }
        public void CrearInmuebleEstado(int? id)
        {
            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 3;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }


        public void EliminarAlquiler(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var alquiler1 = db.Alquiler.Where(x => x.idAlquiler == idAlquiler).FirstOrDefault();
                if (alquiler1 != null)
                {

                    var alquilerEstado = db.AlquilerEstado.Where(x => x.idAlquiler == idAlquiler && x.fechaBajaAlquilerEstado == null).FirstOrDefault();
                    alquilerEstado.fechaBajaAlquilerEstado = DateTime.Now;
                    AlquilerEstado nuevoEstado = new AlquilerEstado();
                    nuevoEstado.fechaAltaAlquilerEstado = DateTime.Now;
                    nuevoEstado.idEstadoAlquiler = 2;
                    nuevoEstado.idAlquiler = idAlquiler;
                    db.AlquilerEstado.Add(nuevoEstado);              
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
        public void ConfirmarAlquiler(int? id)
        {
            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 1;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }
        public void CancelarAlquiler(int? id)
        {
            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 3;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }





    }
}



