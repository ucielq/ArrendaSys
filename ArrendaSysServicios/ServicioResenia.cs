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
                
        public int CrearReseniaAorAr(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                ReseñaArrendadorArrendatario reseña = new ReseñaArrendadorArrendatario
                {
                    descripcionReseñaAoAr=resenia.descripcionResenia,
                    fechaAltaReseñaAoAr = DateTime.Now,
                    fechaBajaReseñaAoAr = null,
                    respuestaReseñaAoAr = null,
                    idAlquiler=resenia.idAlquiler
                };
                db.ReseñaArrendadorArrendatario.Add(reseña);
                db.SaveChanges();
                int? tot = 0;
                
                foreach (var item in resenia.listaReseniaItems)
                {
                    tot += item.puntuacionReseniaItem;
                    ReseñaItemAoAr reseñaItemAoAr = new ReseñaItemAoAr
                    {
                        idItemReseña=item.idItemResenia,
                        puntuacionReseñaItemAoAr=item.puntuacionReseniaItem,
                        idReseñaAoAr=reseña.idReseñaAoAr
                    };
                    db.ReseñaItemAoAr.Add(reseñaItemAoAr);
                    db.SaveChanges();
                }
                decimal prom = ((decimal)tot) / ((decimal)resenia.listaReseniaItems.Count);
                reseña.puntuacionReseñaAoAr = prom;
                db.SaveChanges();
                return 1;
            }
        }
        public int CrearReseniaArAo(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                ReseñaArrendatarioArrendador reseña = new ReseñaArrendatarioArrendador
                {
                    descripcionReseñaArAo = resenia.descripcionResenia,
                    fechaAltaReseñaArAo = DateTime.Now,
                    fechaBajaReseñaArAo = null,
                    respuestaReseñaArAo = null,
                    idAlquiler = resenia.idAlquiler
                };
                db.ReseñaArrendatarioArrendador.Add(reseña);
                db.SaveChanges();
                int? tot = 0;

                foreach (var item in resenia.listaReseniaItems)
                {
                    tot += item.puntuacionReseniaItem;
                    ReseñaItemArAo reseñaItemAoAr = new ReseñaItemArAo
                    {
                        idItemReseña = item.idItemResenia,
                        puntuacionReseñaItemArAo = item.puntuacionReseniaItem,
                        idReseñaArAo = reseña.idReseñaArAo
                    };
                    db.ReseñaItemArAo.Add(reseñaItemAoAr);
                    db.SaveChanges();
                }
                decimal prom = ((decimal)tot) / ((decimal)resenia.listaReseniaItems.Count);
                reseña.puntuacionReseñaArAo = prom;
                db.SaveChanges();
                return 1;
            }
        }
        public int CrearReseniaAI(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                ReseñaArrendatarioInmueble reseña = new ReseñaArrendatarioInmueble
                {
                    descripcionReseñaAI = resenia.descripcionResenia,
                    fechaAltaReseñaAI = DateTime.Now,
                    fechaBajaReseñaAI = null,
                    respuestaReseñaAI = null,
                    idAlquiler = resenia.idAlquiler
                };
                db.ReseñaArrendatarioInmueble.Add(reseña);
                db.SaveChanges();
                int? tot = 0;

                foreach (var item in resenia.listaReseniaItems)
                {
                    tot += item.puntuacionReseniaItem;
                    ReseñaItemAoAr reseñaItemAoAr = new ReseñaItemAoAr
                    {
                        idItemReseña = item.idItemResenia,
                        puntuacionReseñaItemAoAr = item.puntuacionReseniaItem,
                        idReseñaAoAr = reseña.idReseñaAI
                    };
                    db.ReseñaItemAoAr.Add(reseñaItemAoAr);
                    db.SaveChanges();
                }
                decimal prom = ((decimal)tot) / ((decimal)resenia.listaReseniaItems.Count);
                reseña.puntuacionReseñaAI = prom;
                db.SaveChanges();
                return 1;
            }
        }

        //Listar Reseñas
        public object ListarReseniasAoAr(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                var reseniaAoAr1 = (from re in db.ReseñaArrendadorArrendatario
                                    join a in db.Alquiler on re.idAlquiler equals a.idAlquiler
                                    where a.idAlquiler == idAlquiler
                                    select new ReseniaArrendadorArrendatarioViewModel
                                      {
                                          idReseñaAoAr = re.idReseñaAoAr,
                                          descripcionReseñaAoAr = re.descripcionReseñaAoAr,
                                          fechaAltaReseñaAoAr = re.fechaAltaReseñaAoAr,
                                          fechaBajaReseñaAoAr = re.fechaBajaReseñaAoAr,
                                          puntuacionReseñaAoAr = re.puntuacionReseñaAoAr,
                                          respuestaReseñaAoAr = re.respuestaReseñaAoAr,
                                          idAlquiler = re.idAlquiler
                                      }).ToList();
                object json = new { data = reseniaAoAr1 };
                return json;

            }

        }

        public object ListarReseniasArAo(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                    var reseniaArAo1 = (from re in db.ReseñaArrendatarioArrendador
                                        join a in db.Alquiler on re.idAlquiler equals a.idAlquiler
                                        where a.idAlquiler == idAlquiler
                                        select new ReseniaArrendatarioArrendadorViewModel
                                        {
                                            idReseñaArAo = re.idReseñaArAo,
                                            descripcionReseñaArAo = re.descripcionReseñaArAo,
                                            fechaAltaReseñaArAo = re.fechaAltaReseñaArAo,
                                            fechaBajaReseñaArAo = re.fechaBajaReseñaArAo,
                                            puntuacionReseñaArAo = re.puntuacionReseñaArAo,
                                            respuestaReseñaArAo = re.respuestaReseñaArAo,
                                            idAlquiler = re.idAlquiler
                                        }).ToList();
                    object json = new { data = reseniaArAo1 };
                    return json;
            }
        }
        public object ListarReseniasAI(int idAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var reseniaAI1 = (from re in db.ReseñaArrendatarioInmueble
                                    join a in db.Alquiler on re.idAlquiler equals a.idAlquiler
                                    where a.idAlquiler == idAlquiler
                                    select new ReseñaArrendatarioInmueble
                                    {
                                        idReseñaAI = re.idReseñaAI,
                                        descripcionReseñaAI = re.descripcionReseñaAI,
                                        fechaAltaReseñaAI = re.fechaAltaReseñaAI,
                                        fechaBajaReseñaAI = re.fechaBajaReseñaAI,
                                        puntuacionReseñaAI = re.puntuacionReseñaAI,
                                        respuestaReseñaAI = re.respuestaReseñaAI,
                                        idAlquiler = re.idAlquiler
                                    }).ToList();
                object json = new { data = reseniaAI1 };
                return json;
            }
        }
        public ViewModelReseniaAux obtenerResenias(int tipoCuenta, int id, int pag, string fechaDesde, string fechaHasta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                DateTime desde = Convert.ToDateTime(fechaDesde);
                DateTime hasta = Convert.ToDateTime(fechaHasta);
                List<ReseniaViewModel> listaFinal = new List<ReseniaViewModel>();
                var tot = 0;
                if (tipoCuenta == 2) //Arrendatario
                {
                    var lista = (from r in db.ReseñaArrendadorArrendatario
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 where a.idArrendatario == id && r.fechaAltaReseñaAoAr>=desde && r.fechaAltaReseñaAoAr<=hasta
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia=r.descripcionReseñaAoAr,
                                     fechaAltaReseña=r.fechaAltaReseñaAoAr,
                                     puntuacionResenia=r.puntuacionReseñaAoAr,
                                     idResenia=r.idReseñaAoAr,
                                     idAlquiler=r.idAlquiler,
                                     idInmueble=a.idInmueble
                                 }).ToList();

                    foreach(var re in lista)
                    {
                        var inmu = db.Inmueble.Where(x => x.idInmueble == re.idInmueble).FirstOrDefault();
                        if (inmu.tipoArrendador == 3) //Propietario
                        {
                            var prop = db.Propietario.Where(x => x.idPropietario == inmu.idArrendador).FirstOrDefault();
                            re.nombreAutor = prop.apellidoPropietario + " " + prop.nombrePropietario;
                        }
                        if (inmu.tipoArrendador == 4)
                        {
                            var inmo = db.Inmobiliaria.Where(x => x.idInmobiliaria == inmu.idArrendador).FirstOrDefault();
                            re.nombreAutor = inmo.nombreInmobiliaria;
                        }
                    }
                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x=>x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag-1) * 6).Take(6).ToList();
                }
                if (tipoCuenta == 3) //Propietario
                {
                    var lista = (from r in db.ReseñaArrendatarioArrendador
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 join ar in db.Arrendatario on a.idArrendatario equals ar.idArrendatario
                                 where i.tipoArrendador == 3 && i.idArrendador == id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia = r.descripcionReseñaArAo,
                                     fechaAltaReseña = r.fechaAltaReseñaArAo,
                                     puntuacionResenia = r.puntuacionReseñaArAo,
                                     idResenia = r.idReseñaArAo,
                                     idAlquiler = r.idAlquiler,
                                     idInmueble = a.idInmueble,
                                     nombreAutor = ar.apellidoArrendatario + " " + ar.nombreArrendatario
                                 }).ToList();
                    
                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x => x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag - 1) * 6).Take(6).ToList();
                }
                if (tipoCuenta == 4) //Inmobiliaria
                {
                    var lista = (from r in db.ReseñaArrendatarioArrendador
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 join ar in db.Arrendatario on a.idArrendatario equals ar.idArrendatario
                                 where i.tipoArrendador == 4 && i.idArrendador == id && r.fechaAltaReseñaArAo >= desde && r.fechaAltaReseñaArAo <= hasta
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia = r.descripcionReseñaArAo,
                                     fechaAltaReseña = r.fechaAltaReseñaArAo,
                                     puntuacionResenia = r.puntuacionReseñaArAo,
                                     idResenia = r.idReseñaArAo,
                                     idAlquiler = r.idAlquiler,
                                     idInmueble = a.idInmueble,
                                     nombreAutor = ar.apellidoArrendatario + " " + ar.nombreArrendatario
                                 }).ToList();

                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x => x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag - 1) * 6).Take(6).ToList();
                }
                ViewModelReseniaAux response = new ViewModelReseniaAux
                {
                    cantidad = tot,
                    lista = listaFinal
                };
                return response;
            }
        }

        public ViewModelReseniaAux obtenerReseniasAlquiler(int tipoCuenta, int id, int pag, int IdAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<ReseniaViewModel> listaFinal = new List<ReseniaViewModel>();
                var tot = 0;
                if (tipoCuenta == 3 || tipoCuenta == 4) //Soy Propietario o Inmobiliaria, quiero ver las reseñas que he hecho
                {
                    var lista = (from r in db.ReseñaArrendadorArrendatario
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 where a.idAlquiler == IdAlquiler && i.idArrendador == id
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia = r.descripcionReseñaAoAr,
                                     fechaAltaReseña = r.fechaAltaReseñaAoAr,
                                     puntuacionResenia = r.puntuacionReseñaAoAr,
                                     idResenia = r.idReseñaAoAr,
                                     idAlquiler = r.idAlquiler,
                                     idInmueble = a.idInmueble
                                 }).ToList();

                    foreach (var re in lista)
                    {
                        var inmu = db.Inmueble.Where(x => x.idInmueble == re.idInmueble).FirstOrDefault();
                        if (inmu.tipoArrendador == 3) //Propietario
                        {
                            var prop = db.Propietario.Where(x => x.idPropietario == inmu.idArrendador).FirstOrDefault();
                            re.nombreAutor = prop.apellidoPropietario + " " + prop.nombrePropietario;
                        }
                        if (inmu.tipoArrendador == 4)
                        {
                            var inmo = db.Inmobiliaria.Where(x => x.idInmobiliaria == inmu.idArrendador).FirstOrDefault();
                            re.nombreAutor = inmo.nombreInmobiliaria;
                        }
                    }
                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x => x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag - 1) * 6).Take(6).ToList();
                }
                if (tipoCuenta == 2) //Soy Arrendatario, quiero ver las reseñas que he hecho
                {
                    var lista = (from r in db.ReseñaArrendatarioArrendador
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 join ar in db.Arrendatario on a.idArrendatario equals ar.idArrendatario
                                 where a.idAlquiler == IdAlquiler && a.idArrendatario == id
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia = r.descripcionReseñaArAo,
                                     fechaAltaReseña = r.fechaAltaReseñaArAo,
                                     puntuacionResenia = r.puntuacionReseñaArAo,
                                     idResenia = r.idReseñaArAo,
                                     idAlquiler = r.idAlquiler,
                                     idInmueble = a.idInmueble,
                                     nombreAutor = ar.apellidoArrendatario + " " + ar.nombreArrendatario
                                 }).ToList();

                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x => x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag - 1) * 6).Take(6).ToList();
                }

        

                ViewModelReseniaAux response = new ViewModelReseniaAux
                {
                    cantidad = tot,
                    lista = listaFinal
                };
                return response;


            }
        }

        public ViewModelReseniaAux obtenerReseniasAlquilerInmueble(int tipoCuenta, int id, int pag, int IdAlquiler)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<ReseniaViewModel> listaFinal = new List<ReseniaViewModel>();
                var tot = 0;
                if (tipoCuenta == 2) //Soy Arrendatario, quiero ver las reseñas que he hecho
                {
                    var lista = (from r in db.ReseñaArrendatarioInmueble
                                 join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                                 join i in db.Inmueble on a.idInmueble equals i.idInmueble
                                 join ar in db.Arrendatario on a.idArrendatario equals ar.idArrendatario
                                 where a.idAlquiler == IdAlquiler && a.idArrendatario == id
                                 select new ReseniaViewModel
                                 {
                                     descripcionResenia = r.descripcionReseñaAI,
                                     fechaAltaReseña = r.fechaAltaReseñaAI,
                                     puntuacionResenia = r.puntuacionReseñaAI,
                                     idResenia = r.idReseñaAI,
                                     idAlquiler = r.idAlquiler,
                                     idInmueble = a.idInmueble,
                                     nombreAutor = ar.apellidoArrendatario + " " + ar.nombreArrendatario
                                 }).ToList();

                    tot = lista.Count;
                    listaFinal = lista.OrderByDescending(x => x.fechaAltaReseña).ToList();
                    listaFinal = listaFinal.Skip((pag - 1) * 6).Take(6).ToList();
                }



                ViewModelReseniaAux response = new ViewModelReseniaAux
                {
                    cantidad = tot,
                    lista = listaFinal
                };
                return response;


            }
        }
    }
}
