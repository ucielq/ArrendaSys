﻿using System;
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
                    ReseñaItemAoAr reseñaItemAoAr = new ReseñaItemAoAr
                    {
                        idItemReseña = item.idItemResenia,
                        puntuacionReseñaItemAoAr = item.puntuacionReseniaItem,
                        idReseñaAoAr = reseña.idReseñaArAo
                    };
                    db.ReseñaItemAoAr.Add(reseñaItemAoAr);
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



    }

}
