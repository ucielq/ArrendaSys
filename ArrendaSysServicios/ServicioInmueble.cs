using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ArrendaSysServicios
{
    public class ServicioInmueble 
    {
        public InmuebleViewModel AgregarInmueble(InmuebleViewModel inmueble)
        {
            ArrendasysEntities db = new ArrendasysEntities();
            if (inmueble.idInmueble == null)
            {

                Direccion dire = new Direccion
                {
                    nombreCalle = inmueble.direccion.nombreCalle,
                    numeroCalle = inmueble.direccion.numeroCalle,
                    nombreBarrio = inmueble.direccion.nombreBarrio,
                    idManzana = inmueble.direccion.idManzana,
                    idLote = inmueble.direccion.idLote,
                    idLocalidad = inmueble.direccion.localidad.idLocalidad
                };
                db.Direccion.Add(dire);
                db.SaveChanges();

                var ultimadireccion = db.Direccion.OrderByDescending(x => x.idDireccion).FirstOrDefault();
                //dire.idDireccion = ultimadireccion.idDireccion;
                                             
                Inmueble inmueble1 = new Inmueble
                {
                    cantAmbientes = inmueble.cantAmbientes,
                    cantBanos = inmueble.cantBanos,
                    cantHabitaciones = inmueble.cantHabitaciones,
                    cochera = inmueble.cochera,
                    descripcionInmueble = inmueble.descripcionInmueble,
                    incluyeExpensas = inmueble.incluyeExpensas,
                    mtsCuadrados = inmueble.mtsCuadrados,
                    mtsCuadradosInt = inmueble.mtsCuadradosInt,
                    permiteMascota = inmueble.permiteMascota,
                    idArrendador = inmueble.idArrendador,
                    tipoArrendador = inmueble.tipoArrendador,
                    idDireccion = ultimadireccion.idDireccion                   
                };

                db.Inmueble.Add(inmueble1);

                db.SaveChanges();
                var ultimo = db.Inmueble.OrderByDescending(x => x.idInmueble).FirstOrDefault();
                inmueble.idInmueble = ultimo.idInmueble;

                InmuebleEstado inmuest = new InmuebleEstado
                {
                    fechaAltaInmuebleEstado = DateTime.Now,
                    fechaBajaInmuebleEstado = null,
                    idEstadoInmueble = 1,
                    idInmueble = inmueble.idInmueble
                };
                db.InmuebleEstado.Add(inmuest);
                db.SaveChanges();

                return inmueble;
            }
            else
            {
                var esteInmu = db.Inmueble.Where(x => x.idInmueble == inmueble.idInmueble).FirstOrDefault();
                
                if (esteInmu != null)                    

                {
                    var direc = db.Direccion.Where(x => x.idDireccion == esteInmu.idDireccion).FirstOrDefault();
                    if (direc != null) {
                        direc.idLocalidad = inmueble.direccion.localidad.idLocalidad;
                        direc.idLote = inmueble.direccion.idLote;
                        direc.idManzana = inmueble.direccion.idManzana;
                        direc.nombreBarrio = inmueble.direccion.nombreBarrio;
                        direc.nombreCalle = inmueble.direccion.nombreCalle;
                        direc.numeroCalle = inmueble.direccion.numeroCalle;                      
                    } 

                    esteInmu.cantAmbientes = inmueble.cantAmbientes;
                    esteInmu.cantBanos = inmueble.cantBanos;
                    esteInmu.cantHabitaciones = inmueble.cantHabitaciones;
                    esteInmu.cochera = inmueble.cochera;
                    esteInmu.descripcionInmueble = inmueble.descripcionInmueble;
                    esteInmu.incluyeExpensas = inmueble.incluyeExpensas;
                    esteInmu.mtsCuadrados = inmueble.mtsCuadrados;
                    esteInmu.mtsCuadradosInt = inmueble.mtsCuadradosInt;
                    esteInmu.permiteMascota = inmueble.permiteMascota;
                    esteInmu.idArrendador = inmueble.idArrendador;
                    esteInmu.tipoArrendador = inmueble.tipoArrendador;                                       
                    db.SaveChanges();                                     
                };
                return inmueble;
            }

        }
        public int GuardarArchivoInmueble(List<ArchivoVM> lista)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                try
                {
                    foreach (var archivo in lista)
                    {
                        MultimediaInmueble multimediaInmueble = new MultimediaInmueble()
                        {
                            urlMultimediaInmueble = archivo.url,
                            idInmueble = archivo.idInmueble
                        };
                        db.MultimediaInmueble.Add(multimediaInmueble);
                        db.SaveChanges();

                    }

                }
                catch (DbEntityValidationException e)
                {
                    return 400;
                }
                return 200;
            }
        }
        public void EliminarInmueble(int idInmueble)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                                               
                var inmu = db.Inmueble.Where(x => x.idInmueble == idInmueble).FirstOrDefault();
                var inmuest = db.InmuebleEstado.Where(x => x.idInmueble == inmu.idInmueble).FirstOrDefault();
                if (inmuest != null)
                {                   
                    inmuest.fechaBajaInmuebleEstado = DateTime.Now;

                    InmuebleEstado inmuEstadoNuevo = new InmuebleEstado
                    {
                        fechaAltaInmuebleEstado = DateTime.Now,
                        fechaBajaInmuebleEstado = null,
                        idEstadoInmueble = 2,
                        idInmueble = inmu.idInmueble
                    };
                    db.InmuebleEstado.Add(inmuEstadoNuevo);
                    db.SaveChanges();                   
                }
            }
        }
        public InmuebleViewModel ObtenerInmueble(int idInmueble)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                InmuebleViewModel inmueble = (from i in db.Inmueble
                                              join d in db.Direccion on i.idDireccion equals d.idDireccion
                                              join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                              join dep in db.Departamento on l.idDepartamento equals dep.idDepartamento
                                              join mult in db.MultimediaInmueble on i.idInmueble equals mult.idInmueble
                                              where i.idInmueble == idInmueble
                                              select new InmuebleViewModel
                                              {
                                                  cantAmbientes = i.cantAmbientes,
                                                  cantBanos = i.cantBanos,
                                                  cantHabitaciones = i.cantHabitaciones,
                                                  cochera = i.cochera,
                                                  mtsCuadrados = i.mtsCuadrados,
                                                  mtsCuadradosInt = i.mtsCuadradosInt,
                                                  permiteMascota = i.permiteMascota,
                                                  descripcionInmueble = i.descripcionInmueble,
                                                  idInmueble = i.idInmueble,
                                                  incluyeExpensas = i.incluyeExpensas,
                                                  idArrendador = i.idArrendador,
                                                  tipoArrendador = i.tipoArrendador,                                                  
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
                                                          departamento= new DepartamentoViewModel
                                                          {
                                                              idDepartamento= dep.idDepartamento,
                                                              nombreDepartamento=dep.nombreDepartamento
                                                          }
                                                      }

                                                  }

                                              }).FirstOrDefault();

                List<ArchivoVM> lista = (from mult in db.MultimediaInmueble
                                         where mult.idInmueble == idInmueble
                                         select new ArchivoVM
                                         {
                                             url= mult.urlMultimediaInmueble,
                                             idMultimediaInmueble= mult.idMultimediaInmueble
                                         }).ToList();
                inmueble.listaMultimedia = lista;

                
                return inmueble;
            }
        }


        public List<InmuebleViewModel> ObtenerInmueblesPropietario(int idPropietario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var inmuebles = (from i in db.Inmueble
                                 join d in db.Direccion on i.idDireccion equals d.idDireccion
                                 join ie in db.InmuebleEstado on i.idInmueble equals ie.idInmueble
                                 join ei in db.EstadoInmueble on ie.idEstadoInmueble equals ei.idEstadoInmueble
                                 join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                 where i.idArrendador == idPropietario
                                 where ie.fechaBajaInmuebleEstado == null && (ie.idEstadoInmueble ==1 || ie.idEstadoInmueble == 3 || ie.idEstadoInmueble == 4)                                  
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
                                     tipoArrendador = 2,
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
                                     },
                                     inmuebleEstado= new InmuebleEstadoViewModel
                                     {
                                         fechaAltaInmuebleEstado= ie.fechaAltaInmuebleEstado,
                                         fechaBajaInmuebleEstado= ie.fechaBajaInmuebleEstado,                                        
                                         nombreEstado= new EstadoInmuebleViewModel
                                         {
                                             descripcionEstadoInmueble = ei.descripcionEstadoInmueble,
                                             nombreEstadoInmueble=ei.nombreEstadoInmueble
                                         }
                                     }

                                 }).ToList();

                foreach (var inmu in inmuebles)
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
                return inmuebles;
            }
        }

        public List<InmuebleViewModel> ObtenerInmueblesInmobiliaria(int idInmobiliaria)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var inmuebles = (from i in db.Inmueble
                                 join d in db.Direccion on i.idDireccion equals d.idDireccion
                                 join ei in db.InmuebleEstado on i.idInmueble equals ei.idInmueble
                                 join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                 where i.idArrendador == idInmobiliaria
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
                                     idArrendador = idInmobiliaria,
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

                foreach (var inmu in inmuebles)
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
                return inmuebles;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public InmuebleViewModel VerInmueble(int idInmueble)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                InmuebleViewModel inmueble = (from i in db.Inmueble
                                              join d in db.Direccion on i.idDireccion equals d.idDireccion
                                              join l in db.Localidad on d.idLocalidad equals l.idLocalidad
                                              join dep in db.Departamento on l.idDepartamento equals dep.idDepartamento
                                              where i.idInmueble == idInmueble
                                              select new InmuebleViewModel
                                              {
                                                  cantAmbientes = i.cantAmbientes,
                                                  cantBanos = i.cantBanos,
                                                  cantHabitaciones = i.cantHabitaciones,
                                                  cochera = i.cochera,
                                                  mtsCuadrados = i.mtsCuadrados,
                                                  mtsCuadradosInt = i.mtsCuadradosInt,
                                                  permiteMascota = i.permiteMascota,
                                                  descripcionInmueble = i.descripcionInmueble,
                                                  idInmueble = i.idInmueble,
                                                  incluyeExpensas = i.incluyeExpensas,
                                                  idArrendador = i.idArrendador,
                                                  tipoArrendador = i.tipoArrendador,
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

                                              }).FirstOrDefault();
                
                    
                    var listaArchivoVM = new List<ArchivoVM>();
                    var archivos = db.MultimediaInmueble.Where(x => x.idInmueble == inmueble.idInmueble).ToList();
                    foreach (var multi in archivos)
                    {
                        var archivoVM = new ArchivoVM
                        {
                            idInmueble = inmueble.idInmueble,
                            url = multi.urlMultimediaInmueble
                        };
                        listaArchivoVM.Add(archivoVM);
                    }
                    inmueble.listaMultimedia = listaArchivoVM;
                
                return inmueble;
            }
        }
    }

    
}

