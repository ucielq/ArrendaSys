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
        public ItemViewModel ConsultarItem(int idItem)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var item = (from i in db.ItemReseña
                            where i.idItemReseña == idItem
                            select new ItemViewModel
                            {
                                idItemReseña=i.idItemReseña,
                                IR_esAI=i.IR_esAI,
                                IR_esAoAr=i.IR_esAoAr,
                                IR_esArAo=i.IR_esArAo,
                                nombreItemReseña=i.nombreItemReseña
                            }).FirstOrDefault();
                return item;
            }
        }
        public int GuardarItem(ItemViewModel item)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                if (item.idItemReseña == null)//Creo nuevo item
                {
                    ItemReseña itemReseña = new ItemReseña
                    {
                        IR_esAI=item.IR_esAI,
                        IR_esAoAr=item.IR_esAoAr,
                        IR_esArAo=item.IR_esArAo,
                        nombreItemReseña=item.nombreItemReseña
                    };
                    db.ItemReseña.Add(itemReseña);
                    db.SaveChanges();
                }
                else //Edito uno que ya existe
                {
                    var esteItem = db.ItemReseña.Where(x => x.idItemReseña == item.idItemReseña).FirstOrDefault();
                    if (esteItem != null)
                    {
                        esteItem.IR_esAI = item.IR_esAI;
                        esteItem.IR_esAoAr = item.IR_esAoAr;
                        esteItem.IR_esArAo = item.IR_esArAo;
                        esteItem.nombreItemReseña = item.nombreItemReseña;
                        db.SaveChanges();
                    }
                }
                return 1;
            }
        }
        
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
