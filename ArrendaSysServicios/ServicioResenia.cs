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
        public int AgregarReseña(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendadorArrendatario reseña1 = new ReseñaArrendadorArrendatario();


                reseña1.fechaAltaReseñaArAo= resenia.fechaAltaReseñaArAo;
                reseña1.fechaBajaReseñaArAo = resenia.fechaBajaReseñaArAo;
                reseña1.idAlquiler = resenia.idAlquiler;
                reseña1.idReseñaArAo = resenia.idReseñaAoAr;
                reseña1.puntuacionReseñaArAo = resenia.puntuacionReseñaAoAr;
                reseña1.descripcionReseñaArAo = resenia.descripcionReseñaArAo;

                db.ReseñaArrendadorArrendatario.Add(reseña1);

                db.SaveChanges();

                return 1;

            }
        }
    }
}
