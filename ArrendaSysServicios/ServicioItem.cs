using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioItem
    {
        public object ObtenerItems()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                var lista = (from i in db.ItemReseña
                             select new ItemViewModel
                             {
                                 idItemReseña = i.idItemReseña,
                                 IR_esAI=i.IR_esAI,
                                 IR_esAoAr=i.IR_esAoAr,
                                 IR_esArAo=i.IR_esArAo,
                                 nombreItemReseña=i.nombreItemReseña
                             }).ToList();
                foreach(var item in lista)
                {
                    var descripcion = "Item utilizado para calificar:";
                    if ((bool)item.IR_esAI)
                    {
                        descripcion += "<br/>    -Arrendatario a Inmueble";
                    }
                    if ((bool)item.IR_esAoAr)
                    {
                        descripcion += "<br/>    -Arrendador a Arrendatario";
                    }
                    if ((bool)item.IR_esArAo)
                    {
                        descripcion += "<br/>    -Arrendatario a Arrendador";
                    }
                    item.descripcion = descripcion;
                }
                object json = new { data = lista };
                return json;


            }
        }
    }
}
