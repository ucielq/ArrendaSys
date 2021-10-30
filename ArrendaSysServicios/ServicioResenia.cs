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
    }

}
