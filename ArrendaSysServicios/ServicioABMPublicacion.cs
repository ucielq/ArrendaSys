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
                                          fechaAltaPublicacion = p.fechaAltaPublicacion,
                                          fechaBajaPublicacion = p.fechaBajaPublicacion,
                                          precioAlquiler = p.precioAlquiler,
                                          idInmueble = p.idInmueble,
                                          idPublicacionEstado = pe.idPublicacionEstado,
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
                                          fechaAltaPublicacion = p.fechaAltaPublicacion,
                                          fechaBajaPublicacion = p.fechaBajaPublicacion,
                                          precioAlquiler = p.precioAlquiler,
                                          idInmueble = p.idInmueble,
                                          idPublicacionEstado = pe.idPublicacionEstado,
                                          descripcionEstadoPublicacion = ep.nombreEstadoPublicacion,
                                          descripcionPublicacion = p.descripcionPublicacion
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



        public void AgregarPublicacion(ABMPublicacionViewModel publicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                Publicacion publicacion1 = new Publicacion();
                publicacion1.descripcionPublicacion = publicacion.descripcionPublicacion;
                publicacion1.fechaAltaPublicacion = publicacion.fechaAltaPublicacion;
                publicacion1.fechaBajaPublicacion = publicacion.fechaBajaPublicacion;
                publicacion1.precioAlquiler = publicacion.precioAlquiler;
                publicacion1.idInmueble = publicacion.idInmueble;                
                db.Publicacion.Add(publicacion1);
                db.SaveChanges();

                var inmu = db.Inmueble.Where(x => x.idInmueble == publicacion.idInmueble).FirstOrDefault();
                var inmuest = db.InmuebleEstado.Where(x => x.idInmueble == inmu.idInmueble && x.fechaBajaInmuebleEstado == null).FirstOrDefault();
                inmuest.fechaBajaInmuebleEstado = DateTime.Now;
                db.SaveChanges();
                InmuebleEstado inmuEstadoNuevo = new InmuebleEstado();
                    inmuEstadoNuevo.fechaAltaInmuebleEstado = DateTime.Now;
                    inmuEstadoNuevo.fechaBajaInmuebleEstado = null;
                    inmuEstadoNuevo.idEstadoInmueble = 4;
                    inmuEstadoNuevo.idInmueble = inmu.idInmueble;                    
                    db.InmuebleEstado.Add(inmuEstadoNuevo);
                    db.SaveChanges();
                

                var ultimoGuardado = db.Publicacion.OrderByDescending(x => x.idPublicacion).FirstOrDefault();
               
                PublicacionEstado publiEstado = new PublicacionEstado();
                publiEstado.fechaAltaPublicacionEstado = DateTime.Now;
                publiEstado.fechaBajaPublicacionEstado = null;
                publiEstado.idEstadoPublicacion = 1;
                publiEstado.idPublicacion = ultimoGuardado.idPublicacion;
                db.PublicacionEstado.Add(publiEstado);
                db.SaveChanges();

            }
        }


      


        public void EliminarPublicacion(ABMPublicacionViewModel publicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var publicacion1 = db.Publicacion.Where(x => x.idPublicacion == publicacion.idPublicacion).FirstOrDefault();
                
                if (publicacion1 != null)
                {

                    var publicacionEstado = db.PublicacionEstado.Where(x => x.idPublicacion == publicacion.idPublicacion && x.fechaBajaPublicacionEstado == null).FirstOrDefault();
                    publicacionEstado.fechaBajaPublicacionEstado = DateTime.Now;
                    PublicacionEstado nuevoEstado = new PublicacionEstado();
                    nuevoEstado.fechaAltaPublicacionEstado = DateTime.Now;
                    nuevoEstado.fechaBajaPublicacionEstado= DateTime.Now;
                    nuevoEstado.idEstadoPublicacion = 2;
                    nuevoEstado.idPublicacion = publicacion.idPublicacion;
                    db.PublicacionEstado.Add(nuevoEstado);
                    db.SaveChanges();

                    var inmu = db.Inmueble.Where(x => x.idInmueble == publicacion.idInmueble).FirstOrDefault();
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

                   

                    db.Publicacion.Remove(publicacion1);
                    db.SaveChanges();


                }
            }
        }

        public List<ABMPublicacionViewModel> TraerPublicaciones(int idDepto, int hab, int banios, int coch, int masc, int exp)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var publicaciones = (from p in db.Publicacion                                                                        
                                     join pe in db.PublicacionEstado on p.idPublicacion equals pe.idPublicacion
                                     join i in db.Inmueble on p.idInmueble equals i.idInmueble
                                     join d in db.Direccion on i.idDireccion equals d.idDireccion
                                     join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                     join dep in db.Departamento on l.idDepartamento equals dep.idDepartamento                                    
                                     where pe.fechaBajaPublicacionEstado == null && pe.idEstadoPublicacion==1 
                                     select new ABMPublicacionViewModel
                                     {
                                         idPublicacion = p.idPublicacion,
                                         fechaAltaPublicacion = p.fechaAltaPublicacion,
                                         fechaBajaPublicacion = p.fechaBajaPublicacion,
                                         precioAlquiler = p.precioAlquiler,
                                         idInmueble = p.idInmueble,
                                         descripcionPublicacion= p.descripcionPublicacion,
                                         inmueble = new InmuebleViewModel
                                         {
                                             cantAmbientes= i.cantAmbientes,
                                             cantBanos=i.cantBanos,
                                             cantHabitaciones=i.cantHabitaciones,
                                             cochera=i.cochera,
                                             descripcionInmueble= i.descripcionInmueble,
                                             incluyeExpensas=i.incluyeExpensas,
                                             mtsCuadrados=i.mtsCuadrados,
                                             mtsCuadradosInt=i.mtsCuadradosInt,
                                             permiteMascota=i.permiteMascota,                                                                                       
                                             direccion = new DireccionViewModel
                                             {
                                                 idDireccion = d.idDireccion,
                                                 idLote = d.idLote,
                                                 idManzana = d.idManzana,
                                                 nombreBarrio = d.nombreBarrio,
                                                 nombreCalle = d.nombreCalle,
                                                 numeroCalle = d.numeroCalle,
                                                 idLocalidad = d.idLocalidad,
                                                 localidad = new LocalidadViewModel
                                                 {
                                                     idLocalidad = l.idLocalidad,
                                                     codigopostal = l.codigoPostal,
                                                     nombreLocalidad = l.nombreLocalidad,
                                                     idDepartamento = l.idDepartamento,
                                                     departamento = new DepartamentoViewModel
                                                     {
                                                         idDepartamento = dep.idDepartamento,
                                                         nombreDepartamento = dep.nombreDepartamento
                                                     }
                                                 }
                                             }
                                         }
                                                                             
                                     });
                if(idDepto!= -1)
                {
                    publicaciones = publicaciones.Where(x => x.inmueble.direccion.localidad.departamento.idDepartamento == idDepto);
                }
                if (hab != -1)
                {
                    publicaciones = publicaciones.Where(x => x.inmueble.cantHabitaciones == hab);
                }
                if (banios != -1)
                {
                    publicaciones = publicaciones.Where(x => x.inmueble.cantBanos == banios);
                }
                if (coch != -1)
                {
                    if (coch == 1) {
                        publicaciones = publicaciones.Where(x => x.inmueble.cochera == true); 
                    }else { 
                        publicaciones = publicaciones.Where(x => x.inmueble.cochera == false); 
                    }
                }
                if (masc != -1)
                {
                    if (masc == 1)
                    {
                        publicaciones = publicaciones.Where(x => x.inmueble.permiteMascota == true);
                    }
                    else
                    {
                        publicaciones = publicaciones.Where(x => x.inmueble.permiteMascota == false);
                    }
                }
                if (exp != -1)
                {
                    if (exp == 1)
                    {
                        publicaciones = publicaciones.Where(x => x.inmueble.incluyeExpensas == true);
                    }
                    else
                    {
                        publicaciones = publicaciones.Where(x => x.inmueble.incluyeExpensas == false);
                    }
                }


                var lista = publicaciones.ToList();

                foreach (var inmu in lista)
                {
                    var listaArchivoVM = new List<ArchivoVM>();
                    var archivos = db.MultimediaInmueble.Where(x => x.idInmueble == inmu.idInmueble).ToList();
                    foreach (var multi in archivos)
                    {
                        var archivoVM = new ArchivoVM
                        {
                            idInmueble = inmu.idInmueble,
                            url = multi.urlMultimediaInmueble
                        };
                        listaArchivoVM.Add(archivoVM);
                    }
                    inmu.listaMultimedia = listaArchivoVM;
                }

                //var inmu = db.Inmueble.Where(x => x.idInmueble == publicaciones.idInmueble).FirstOrDefault();
                return lista ;

                
             
            }
        }
        
         public void EditarPublicacion(ABMPublicacionViewModel publicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var publi = db.Publicacion.Where(x => x.idPublicacion== publicacion.idPublicacion).FirstOrDefault();

                publi.descripcionPublicacion = publicacion.descripcionPublicacion;
                publi.fechaAltaPublicacion = publicacion.fechaAltaPublicacion;
                publi.fechaBajaPublicacion = publicacion.fechaBajaPublicacion;
                publi.precioAlquiler = publicacion.precioAlquiler;
                db.SaveChanges();
            }

               

         }



        public ABMPublicacionViewModel VerPublicacion(int idPublicacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                ABMPublicacionViewModel publicacion = (from p in db.Publicacion
                                     join pe in db.PublicacionEstado on p.idPublicacion equals pe.idPublicacion
                                     join i in db.Inmueble on p.idInmueble equals i.idInmueble
                                     join d in db.Direccion on i.idDireccion equals d.idDireccion
                                     join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                     join dep in db.Departamento on l.idDepartamento equals dep.idDepartamento
                                     where p.idPublicacion== idPublicacion
                                     select new ABMPublicacionViewModel
                                     {
                                         idPublicacion = p.idPublicacion,
                                         fechaAltaPublicacion = p.fechaAltaPublicacion,
                                         fechaBajaPublicacion = p.fechaBajaPublicacion,
                                         precioAlquiler = p.precioAlquiler,
                                         idInmueble = p.idInmueble,
                                         descripcionPublicacion = p.descripcionPublicacion,
                                         inmueble = new InmuebleViewModel
                                         {
                                             cantAmbientes = i.cantAmbientes,
                                             cantBanos = i.cantBanos,
                                             cantHabitaciones = i.cantHabitaciones,
                                             cochera = i.cochera,
                                             descripcionInmueble = i.descripcionInmueble,
                                             incluyeExpensas = i.incluyeExpensas,
                                             mtsCuadrados = i.mtsCuadrados,
                                             mtsCuadradosInt = i.mtsCuadradosInt,
                                             permiteMascota = i.permiteMascota,
                                             direccion = new DireccionViewModel
                                             {
                                                 idDireccion = d.idDireccion,
                                                 idLote = d.idLote,
                                                 idManzana = d.idManzana,
                                                 nombreBarrio = d.nombreBarrio,
                                                 nombreCalle = d.nombreCalle,
                                                 numeroCalle = d.numeroCalle,
                                                 idLocalidad = d.idLocalidad,
                                                 localidad = new LocalidadViewModel
                                                 {
                                                     idLocalidad = l.idLocalidad,
                                                     codigopostal = l.codigoPostal,
                                                     nombreLocalidad = l.nombreLocalidad,
                                                     idDepartamento = l.idDepartamento,
                                                     departamento = new DepartamentoViewModel
                                                     {
                                                         idDepartamento = dep.idDepartamento,
                                                         nombreDepartamento = dep.nombreDepartamento
                                                     }
                                                 }
                                             }
                                         }

                                     }).FirstOrDefault();

                var listaArchivoVM = new List<ArchivoVM>();
                var archivos = db.MultimediaInmueble.Where(x => x.idInmueble == publicacion.idInmueble).ToList();
                foreach (var multi in archivos)
                {
                    var archivoVM = new ArchivoVM
                    {
                        idInmueble = publicacion.idInmueble,
                        url = multi.urlMultimediaInmueble
                    };
                    listaArchivoVM.Add(archivoVM);
                }
                publicacion.listaMultimedia = listaArchivoVM;


                //var inmu = db.Inmueble.Where(x => x.idInmueble == publicaciones.idInmueble).FirstOrDefault();
                return publicacion;



            }
        }

    }
}
