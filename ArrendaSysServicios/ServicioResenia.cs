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
        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS  ------------
        public object ListarAlquileres(int idAoAr)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                {
                    var idItemReseña = db.ItemReseña.Where(x => x.IR_esAoAr == true).FirstOrDefault().idItemReseña;
                    var idReseña = db.ReseñaArrendatarioArrendador.Where(x => x.idReseñaAoAr == 1 ).FirstOrDefault().idReseñaAoAr;
                    var Items = (from a in db.ItemReseña
                                      join i in db.ReseñaItemAoAr on a.idItemReseña equals i.idItemReseña
                                      join p in db.ReseñaArrendatarioArrendador on i.idReseñaArAo equals p.idReseñaAoAr
                                      where a.IR_esAoAr == true 
                                      select new ItemViewModel
                                      {
                                          idItemReseña = a.idItemReseña,
                                          nombreItemReseña = a.nombreItemReseña

                                      }).ToList();
                    object json = new { data = Items };
                    return json;
                }
                

            }
        }
        public int AgregarReseniaArrendador(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendatarioArrendador resenia1 = new ReseñaArrendatarioArrendador();


                resenia1.fechaAltaReseñaAoAr = DateTime.Now;
                resenia1.fechaBajaReseñaAoAr = resenia.fechaBajaReseñaAoAr;
                resenia1.idAlquiler = resenia.idAlquiler;
                resenia1.idReseñaAoAr = resenia.idReseñaAoAr;
                resenia1.puntuacionReseñaAoAr = resenia.puntuacionReseñaAoAr;
                resenia1.descripcionReseñaAoAr = resenia.descripcionReseñaAoAr;

                db.ReseñaArrendatarioArrendador.Add(resenia1);

                db.SaveChanges();

                return 1;

            }
        }
        public int AgregarReseniaArrendatario(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendadorArrendatario resenia1 = new ReseñaArrendadorArrendatario();


                resenia1.fechaAltaReseñaArAo = DateTime.Now;
                resenia1.fechaBajaReseñaArAo = resenia.fechaBajaReseñaAoAr;
                resenia1.idAlquiler = resenia.idAlquiler;
                resenia1.idReseñaArAo = resenia.idReseñaAoAr;
                resenia1.puntuacionReseñaArAo = resenia.puntuacionReseñaAoAr;
                resenia1.descripcionReseñaArAo = resenia.descripcionReseñaAoAr;

                db.ReseñaArrendadorArrendatario.Add(resenia1);

                db.SaveChanges();

                return 1;

            }
        }
        public int AgregarReseniaInmueble(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendatarioInmueble resenia1 = new ReseñaArrendatarioInmueble();


                resenia1.fechaAltaReseñaAI = DateTime.Now;
                resenia1.fechaBajaReseñaAI = resenia.fechaBajaReseñaAoAr;
                resenia1.idAlquiler = resenia.idAlquiler;
                resenia1.idReseñaAI = resenia.idReseñaAoAr;
                resenia1.puntuacionReseñaAI= resenia.puntuacionReseñaAoAr;
                resenia1.descripcionReseñaAI = resenia.descripcionReseñaAoAr;

                db.ReseñaArrendatarioInmueble.Add(resenia1);

                db.SaveChanges();

                return 1;

            }
        }
    }
}
