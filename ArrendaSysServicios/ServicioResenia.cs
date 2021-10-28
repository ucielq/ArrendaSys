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
        public int AgregarResenia(ReseniaViewModel resenia)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                ReseñaArrendadorArrendatario resenia1 = new ReseñaArrendadorArrendatario();


                resenia1.fechaAltaReseñaArAo= resenia.fechaAltaReseñaArAo;
                resenia1.fechaBajaReseñaArAo = resenia.fechaBajaReseñaArAo;
                resenia1.idAlquiler = resenia.idAlquiler;
                resenia1.idReseñaArAo = resenia.idReseñaAoAr;
                resenia1.puntuacionReseñaArAo = resenia.puntuacionReseñaAoAr;
                resenia1.descripcionReseñaArAo = resenia.descripcionReseñaArAo;

                db.ReseñaArrendadorArrendatario.Add(resenia1);

                db.SaveChanges();

                return 1;

            }
        }
    }
}
