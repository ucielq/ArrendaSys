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
    public class ServicioABMPublicacion
    {


        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS  ------------
        public object ListarPublicaciones(int idCuenta, int tipoCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                if (tipoCuenta == 3)
                {
                    var id = db.Propietario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idPropietario;
                    var publicaciones = (from p in db.Publicacion
                                         join i in db.Inmueble on p.idInmueble equals i.idInmueble
                                         join pr in db.Propietario on i.idArrendador equals pr.idPropietario
                                         join pe in db.PublicacionEstado on p.idPublicacion equals pe.idPublicacion
                                      join ep in db.EstadoPublicacion on pe.idEstadoPublicacion equals ep.idEstadoPublicacion
                                         where pr.idPropietario == id && pe.fechaBajaPublicacionEstado == null
                                      select new ABMPublicacionViewModel
                                      {
                                          idPublicacion = p.idPublicacion,
                                          tituloPublicacion = p.tituloPublicacion,
                                          fechaAltaPublicacion = p.fechaAltaPublicacion,
                                          fechaBajaPublicacion = p.fechaBajaPublicacion,
                                          precioAlquiler = p.precioAlquiler,
                                          idInmueble = p.idInmueble,
                                          descripcionEstadoPublicacion = ep.nombreEstadoPublicacion,
                                          descripcionPublicacion=p.descripcionPublicacion
                                      }).ToList();
                    object json = new { data = publicaciones };
                    return json;
                }
                else if (tipoCuenta == 4)
                {
                    var id = db.Inmobiliaria.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idInmobiliaria;
                    var publicaciones = (from p in db.Publicacion
                                         join i in db.Inmueble on p.idInmueble equals i.idInmueble
                                         join pr in db.Inmobiliaria on i.idArrendador equals pr.idInmobiliaria
                                         join pe in db.PublicacionEstado on p.idPublicacion equals pe.idPublicacion
                                         join ep in db.EstadoPublicacion on pe.idEstadoPublicacion equals ep.idEstadoPublicacion
                                         where pr.idInmobiliaria == id && pe.fechaBajaPublicacionEstado == null
                                      select new ABMPublicacionViewModel
                                      {
                                          idPublicacion = p.idPublicacion,
                                          tituloPublicacion = p.tituloPublicacion,
                                          fechaAltaPublicacion = p.fechaAltaPublicacion,
                                          fechaBajaPublicacion = p.fechaBajaPublicacion,
                                          precioAlquiler = p.precioAlquiler,
                                          idInmueble = p.idInmueble,
                                          descripcionEstadoPublicacion = ep.nombreEstadoPublicacion
                                      }).ToList();
                    object json = new { data = publicaciones };
                    return json;
                }
                return new object { };
                //else
                //{

                //    //
                //    var id = db.Arrendatario.Where(x => x.idCuenta == idCuenta).FirstOrDefault().idArrendatario;
                //    var publicaciones = (from p in db.Publicacion
                //                         join pe in db.PublicacionEstado on p.idPublicacion equals pe.idPublicacion
                //                         join ep in db.EstadoPublicacion on pe.idEstadoPublicacion equals ep.idEstadoPublicacion
                //                         where a.idArrendatario == id && pe.fechaBajaPublicacionEstado == null
                //                      select new ABMPublicacionViewModel
                //                      {
                //                          idPublicacion = p.idPublicacion,
                //                          tituloPublicacion = p.tituloPublicacion,
                //                          fechaAltaPublicacion = p.fechaAltaAlquiler,
                //                          fechaBajaPublicacion = p.fechaBajaAlquiler,
                //                          precioAlquiler = p.precioAlquiler,
                //                          idInmueble = p.idInmueble,
                //                          descripcionEstadoPublicacion = ep.nombreEstadoPublicacion
                //                      }).ToList();
                //    object json = new { data = publicaciones };
                //    return json;
                //}

            }
        }



        public int AgregarPublicacion(ABMPublicacionViewModel publicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                Publicacion publicacion1 = new Publicacion();

                publicacion1.descripcionPublicacion = publicacion.descripcionPublicacion;
                publicacion1.fechaAltaPublicacion = publicacion.fechaAltaPublicacion;
                publicacion1.fechaBajaPublicacion = publicacion.fechaBajaPublicacion;
                publicacion1.precioAlquiler = publicacion.precioAlquiler;
                publicacion1.tituloPublicacion = publicacion.tituloPublicacion;
                publicacion1.idInmueble = publicacion.idInmueble;

                db.Publicacion.Add(publicacion1);

                var inmu = db.Inmueble.Where(x => x.idInmueble == publicacion.idInmueble).FirstOrDefault();
                var inmuest = db.InmuebleEstado.Where(x => x.idInmueble == inmu.idInmueble && x.fechaBajaInmuebleEstado == null).FirstOrDefault();
                if (inmuest != null)
                {
                    inmuest.fechaBajaInmuebleEstado = DateTime.Now;

                    InmuebleEstado inmuEstadoNuevo = new InmuebleEstado
                    {
                        fechaAltaInmuebleEstado = DateTime.Now,
                        fechaBajaInmuebleEstado = null,
                        idEstadoInmueble = 4,
                        idInmueble = inmu.idInmueble
                    };
                    db.InmuebleEstado.Add(inmuEstadoNuevo);
                    db.SaveChanges();
                }

                db.SaveChanges();
                //var ultimoGuardado = db.Alquiler.OrderByDescending(x => x.idAlquiler).FirstOrDefault();
                CrearPublicacionEstado(publicacion1.idPublicacion);
                return 1;

            }
        }


        public void CrearPublicacionEstado(int? id)
        {
            PublicacionEstado publiEstado = new PublicacionEstado();
            publiEstado.fechaAltaPublicacionEstado = DateTime.Now;
            publiEstado.fechaBajaPublicacionEstado = null;
            publiEstado.idEstadoPublicacion = 1;
            publiEstado.idPublicacion = id;
            db.PublicacionEstado.Add(publiEstado);
            db.SaveChanges();
        }
      


        public void EliminarPublicacion(int idPublicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var publicacion1 = db.Publicacion.Where(x => x.idPublicacion == idPublicacion).FirstOrDefault();
                if (publicacion1 != null)
                {

                    var publicacionEstado = db.PublicacionEstado.Where(x => x.idPublicacion == idPublicacion && x.fechaBajaPublicacionEstado == null).FirstOrDefault();
                    publicacionEstado.fechaBajaPublicacionEstado = DateTime.Now;
                    PublicacionEstado nuevoEstado = new PublicacionEstado();
                    nuevoEstado.fechaAltaPublicacionEstado = DateTime.Now;
                    nuevoEstado.idEstadoPublicacion = 2;
                    nuevoEstado.idPublicacion = idPublicacion;
                    db.PublicacionEstado.Add(nuevoEstado);
                    db.SaveChanges();

                    var inmu = db.Inmueble.Where(x => x.idInmueble == publicacion1.idInmueble).FirstOrDefault();
                    var inmuest = db.InmuebleEstado.Where(x => x.idInmueble == inmu.idInmueble && x.fechaBajaInmuebleEstado==null).FirstOrDefault();
                    if (inmuest != null)
                    {
                        inmuest.fechaBajaInmuebleEstado = DateTime.Now;

                        InmuebleEstado inmuEstadoNuevo = new InmuebleEstado
                        {
                            fechaAltaInmuebleEstado = DateTime.Now,
                            fechaBajaInmuebleEstado = null,
                            idEstadoInmueble = 1,
                            idInmueble = inmu.idInmueble
                        };
                        db.InmuebleEstado.Add(inmuEstadoNuevo);
                        db.SaveChanges();
                    }
                }
            }
        }

        
         public int EditarPublicacion(ABMPublicacionViewModel publicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var publi = db.Publicacion.Where(x => x.idPublicacion== publicacion.idPublicacion).FirstOrDefault();

                publi.descripcionPublicacion = publicacion.descripcionPublicacion;
                publi.fechaAltaPublicacion = publicacion.fechaAltaPublicacion;
                publi.fechaBajaPublicacion = publicacion.fechaBajaPublicacion;
                publi.precioAlquiler = publicacion.precioAlquiler;
                publi.tituloPublicacion = publicacion.tituloPublicacion;
                publi.idInmueble = publicacion.idInmueble;
                db.Publicacion.Add(publi);
                db.SaveChanges();
            }

                db.SaveChanges();
                return 1;

         }            
    
    }
}
