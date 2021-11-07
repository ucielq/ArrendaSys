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
                                      where p.idPropietario == id && ae.fechaBajaAlquilerEstado == null
                                      select new AlquileresViewModel
                                      {
                                          idAlquiler = a.idAlquiler,
                                          fechaAltaAlquiler = a.fechaAltaAlquiler,
                                          fechaBajaAlquiler = a.fechaBajaAlquiler,
                                          idArrendatario = a.idArrendatario,
                                          idInmueble = a.idInmueble,
                                          descripcionEstadoAlquiler = ea.nombreEstadoAlquiler,
                                          idEstadoAlquiler=ea.idEstadoAlquiler,
                                          idAlquilerEstado = ae.idAlquilerEstado
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
                                          descripcionEstadoAlquiler = ea.nombreEstadoAlquiler,
                                          idEstadoAlquiler = ea.idEstadoAlquiler,
                                          idAlquilerEstado = ae.idAlquilerEstado
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
                                          descripcionEstadoAlquiler = ea.nombreEstadoAlquiler,
                                          idEstadoAlquiler = ea.idEstadoAlquiler,
                                          idAlquilerEstado = ae.idAlquilerEstado
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

                var inmu = db.Inmueble.Where(x => x.idInmueble == alquiler.idInmueble).FirstOrDefault();
                var inmuest = db.InmuebleEstado.Where(x => x.idInmueble == inmu.idInmueble && x.fechaBajaInmuebleEstado == null).FirstOrDefault();

                if (inmuest != null)
                {
                    inmuest.fechaBajaInmuebleEstado = DateTime.Now;

                    InmuebleEstado inmuEstadoNuevo = new InmuebleEstado
                    {
                        fechaAltaInmuebleEstado = DateTime.Now,
                        fechaBajaInmuebleEstado = null,
                        idEstadoInmueble = 3,
                        idInmueble = inmu.idInmueble
                    };
                    db.InmuebleEstado.Add(inmuEstadoNuevo);
                    db.SaveChanges();
                }
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

        public AlquileresViewModel ObtenerAlquiler(int idAlquiler, int tipoCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                AlquileresViewModel alquiler = alquiler = (from a in db.Alquiler
                                                           join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                                           join d in db.Direccion on i.idDireccion equals d.idDireccion
                                                           join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                                           where a.idAlquiler == idAlquiler
                                                           select new AlquileresViewModel
                                                           {
                                                               idAlquiler = a.idAlquiler,
                                                               fechaAltaAlquiler = a.fechaAltaAlquiler,
                                                               fechaBajaAlquiler = a.fechaBajaAlquiler,
                                                               idArrendatario = a.idArrendatario,
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
                                                                   idDireccion = i.idDireccion,
                                                                   idInmueble = i.idInmueble,
                                                                   tipoArrendador=i.tipoArrendador,
                                                                   idArrendador=i.idArrendador,
                                                                   direccion = new DireccionViewModel
                                                                   {
                                                                       idDireccion = d.idDireccion,
                                                                       nombreCalle = d.nombreCalle,
                                                                       numeroCalle = d.numeroCalle,
                                                                       localidad = new LocalidadViewModel
                                                                       {
                                                                           idLocalidad = l.idLocalidad,
                                                                           codigopostal = l.codigoPostal,
                                                                           nombreLocalidad = l.nombreLocalidad,
                                                                           idDepartamento = l.idDepartamento
                                                                       }
                                                                   }
                                                               }
                                                           }).FirstOrDefault();
                var listaMultimedia = db.MultimediaInmueble.Where(x => x.idInmueble == alquiler.inmueble.idInmueble).ToList();
                List<ArchivoVM> listaMulti = new List<ArchivoVM>();
                foreach(var item in listaMultimedia)
                {
                    ArchivoVM archivo = new ArchivoVM
                    {
                        url=item.urlMultimediaInmueble                        
                    };
                    listaMulti.Add(archivo);
                }

                alquiler.inmueble.listaMultimedia = listaMulti;
                if (tipoCuenta == 2)
                {
                    if (alquiler.inmueble.tipoArrendador == 3)
                    {
                        var idProp = alquiler.inmueble.idArrendador;
                        var arrendador = db.Propietario.Where(x => x.idPropietario == idProp).FirstOrDefault();
                        alquiler.arrendador = new PropietarioViewModel
                        {
                            nombrePropietario=arrendador.nombrePropietario,
                            apellidoPropietario=arrendador.apellidoPropietario,
                            idPropietario=arrendador.idPropietario,
                            telefonoPropietario=arrendador.telefonoPropietario,
                            numeroDocumentoPropietario=arrendador.numeroDocumentoProp
                        };
                    }
                    else
                    {
                        if(alquiler.inmueble.tipoArrendador == 4)
                        {
                            var idInmo = alquiler.inmueble.idArrendador;
                            var arrendador = db.Inmobiliaria.Where(x => x.idInmobiliaria == idInmo).FirstOrDefault();
                            alquiler.arrendador = new InmobiliariaViewModel
                            {
                                nombreInmobiliaria = arrendador.nombreInmobiliaria,
                                cuitInmobiliaria=arrendador.cuitInmobiliaria,
                                idInmobiliaria = arrendador.idInmobiliaria,
                                telefonoInmobiliaria = arrendador.telefonoInmobiliaria
                            };
                        }
                    }
                }
                else
                {
                    if (tipoCuenta == 3 || tipoCuenta==4)
                    {
                        var idArrendatario = alquiler.idArrendatario;
                        var arrendatario = db.Arrendatario.Where(x => x.idArrendatario == idArrendatario).FirstOrDefault();
                        alquiler.arrendatario = new ArrendatarioViewModel
                        {
                            nombreArrendatario = arrendatario.nombreArrendatario,
                            apellidoArrendatario = arrendatario.apellidoArrendatario,
                            nroTelefono = arrendatario.telefonoArrendatario.ToString(),
                            idArrendatario = arrendatario.idArrendatario,
                            nroDocumento = arrendatario.numeroDocumentoArr,
                        };
                    }
                }
                return alquiler;
            }
        }
        public void ConfirmarAlquiler(int id, int idAlquilerEstado)
        {
            var alquilerestado1=db.AlquilerEstado.Where(x => x.idAlquilerEstado == idAlquilerEstado).FirstOrDefault();
            alquilerestado1.fechaBajaAlquilerEstado = DateTime.Now;

            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 1;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }
        public void CancelarAlquiler(int id, int idAlquilerEstado)
        {
            var alquilerestado1 = db.AlquilerEstado.Where(x => x.idAlquilerEstado == idAlquilerEstado).FirstOrDefault();
            alquilerestado1.fechaBajaAlquilerEstado = DateTime.Now;
            AlquilerEstado alqEstado = new AlquilerEstado();
            alqEstado.fechaAltaAlquilerEstado = DateTime.Now;
            alqEstado.fechaBajaAlquilerEstado = null;
            alqEstado.idEstadoAlquiler = 5;
            alqEstado.idAlquiler = id;
            db.AlquilerEstado.Add(alqEstado);
            db.SaveChanges();
        }





        public List<InmuebleViewModel> ObtenerInmuebles(int idPropietario)
        {
            List<InmuebleViewModel> inmuebles;
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                inmuebles = (from i in db.Inmueble
                             join d in db.Direccion on i.idDireccion equals d.idDireccion
                             join ei in db.InmuebleEstado on i.idInmueble equals ei.idInmueble
                             join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                             where i.idArrendador == idPropietario
                             where ei.idEstadoInmueble == 1 && ei.fechaBajaInmuebleEstado == null
                             select new InmuebleViewModel
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
                                 idArrendador = idPropietario,
                                 tipoArrendador = 4,
                                 idDireccion = i.idDireccion,
                                 idInmueble = i.idInmueble,
                                 direccion = new DireccionViewModel
                                 {
                                     idDireccion = d.idDireccion,
                                     nombreCalle = d.nombreCalle,
                                     numeroCalle = d.numeroCalle,
                                     localidad = new LocalidadViewModel
                                     {
                                         idLocalidad = l.idLocalidad,
                                         codigopostal = l.codigoPostal,
                                         nombreLocalidad = l.nombreLocalidad,
                                         idDepartamento = l.idDepartamento
                                     }
                                 }

                             }).ToList();
            }
            return inmuebles;
        }

        public int verificarDNI(int DniArrendatario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                var arrendatario = (from a in db.Arrendatario
                                    where a.numeroDocumentoArr == DniArrendatario
                                    select new ArrendatarioViewModel
                                    {
                                        idArrendatario = a.idArrendatario

                                    }).FirstOrDefault();
                if(arrendatario != null)
                {
                    return arrendatario.idArrendatario;
                }
                else
                {
                    return 0;
                }
                
            }

        }
        public void EditarAlquiler(AlquileresViewModel alquiler)
        {
            var alquiler1 = db.Alquiler.Where(x => x.idAlquiler == alquiler.idAlquiler).FirstOrDefault();
            alquiler1.fechaBajaAlquiler = alquiler.fechaBajaAlquiler;
            //db.Alquiler.Add(alquiler1);
            db.SaveChanges();
        }

    }
}



