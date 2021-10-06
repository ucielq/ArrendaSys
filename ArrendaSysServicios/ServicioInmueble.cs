using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrendaSysServicios
{
    public class ServicioInmueble : IDisposable
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

                return inmueble;
            }
            else
            {
                var esteInmu = db.Inmueble.Where(x => x.idInmueble == inmueble.idInmueble).FirstOrDefault();
                InmuebleViewModel inmu = new InmuebleViewModel();
                if (esteInmu != null)
                {
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
                    esteInmu.idDireccion = inmueble.idDireccion;
                    
                    db.SaveChanges();
                    inmu.cantAmbientes = inmueble.cantAmbientes;
                    inmu.cantBanos = inmueble.cantBanos;
                    inmu.cantHabitaciones = inmueble.cantHabitaciones;
                    inmu.cochera = inmueble.cochera;
                    inmu.descripcionInmueble = inmueble.descripcionInmueble;
                    inmu.incluyeExpensas = inmueble.incluyeExpensas;
                    inmu.mtsCuadrados = inmueble.mtsCuadrados;
                    inmu.mtsCuadradosInt = inmueble.mtsCuadradosInt;
                    inmu.permiteMascota = inmueble.permiteMascota;
                    inmu.idArrendador = inmueble.idArrendador;
                    inmu.tipoArrendador = inmueble.tipoArrendador;
                    inmu.idDireccion = inmueble.idDireccion;
                    inmu.idInmueble = inmueble.idInmueble;
                    //inmu.direccion.idDireccion = inmueble.direccion.idDireccion;

                    //inmu.direccion.nombreCalle = inmueble.direccion.nombreCalle;
                    //inmu.direccion.numeroCalle = inmueble.direccion.numeroCalle;
                    //inmu.direccion.nombreBarrio = inmueble.direccion.nombreBarrio;
                    //inmu.direccion.idManzana = inmueble.direccion.idManzana;
                    //inmu.direccion.idLote = inmueble.direccion.idLote;
                    //inmu.direccion.idLocalidad = inmueble.direccion.localidad.idLocalidad;


                };

                return inmu;
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
                catch (Exception e)
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
                if (inmu != null)
                {
                    db.Inmueble.Remove(inmu);
                    var multi = db.MultimediaInmueble.Where(x => x.idInmueble == idInmueble).ToList();
                    foreach (var i in multi)
                    {
                        db.MultimediaInmueble.Remove(i);
                        db.SaveChanges();
                        //Aca borrar las imagenes de la tempFolder
                    }
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
                return inmueble;
            }
        }


        public List<InmuebleViewModel> ObtenerInmueblesPropietario(int idPropietario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var inmuebles = (from i in db.Inmueble
                                 where i.idArrendador == idPropietario
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
                                     idInmueble = i.idInmueble
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
                                 where i.idArrendador == idInmobiliaria
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
                                     idInmueble = i.idInmueble

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
    }
}
