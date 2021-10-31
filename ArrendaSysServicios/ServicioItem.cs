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
                                idItemReseña = i.idItemReseña,
                                IR_esAI = i.IR_esAI,
                                IR_esAoAr = i.IR_esAoAr,
                                IR_esArAo = i.IR_esArAo,
                                nombreItemReseña = i.nombreItemReseña
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
                        IR_esAI = item.IR_esAI,
                        IR_esAoAr = item.IR_esAoAr,
                        IR_esArAo = item.IR_esArAo,
                        nombreItemReseña = item.nombreItemReseña
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
                                 IR_esAI = i.IR_esAI,
                                 IR_esAoAr = i.IR_esAoAr,
                                 IR_esArAo = i.IR_esArAo,
                                 nombreItemReseña = i.nombreItemReseña
                             }).ToList();
                foreach (var item in lista)
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
        public List<ItemViewModel> ListarItemsAoAr()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<ItemViewModel> AoAr = (from ir in db.ItemReseña
                        where ir.IR_esAoAr == true
                        select new ItemViewModel
                        {
                            idItemReseña = ir.idItemReseña,
                            nombreItemReseña = ir.nombreItemReseña
                        }).ToList();
                return AoAr;
            }
        }
        public List<ItemViewModel> ListarItemsArAo()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<ItemViewModel> AoAr = (from ir in db.ItemReseña
                                            where ir.IR_esArAo == true
                                            select new ItemViewModel
                                            {
                                                idItemReseña = ir.idItemReseña,
                                                nombreItemReseña = ir.nombreItemReseña
                                            }).ToList();
                return AoAr;
            }
        }
        public List<ItemViewModel> ListarItemsAI()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<ItemViewModel> AoAr = (from ir in db.ItemReseña
                                            where ir.IR_esAI == true
                                            select new ItemViewModel
                                            {
                                                idItemReseña = ir.idItemReseña,
                                                nombreItemReseña = ir.nombreItemReseña
                                            }).ToList();
                return AoAr;
            }
        }

        public List<List<ItemViewModel>> ListarItems(bool esAI, bool esAoAr, bool esArAo)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<List<ItemViewModel>> listaFinal = new List<List<ItemViewModel>>();
                List<ItemViewModel> AI = new List<ItemViewModel>();
                List<ItemViewModel> AoAr = new List<ItemViewModel>();
                List<ItemViewModel> ArAo = new List<ItemViewModel>();
                if (esAI)
                {
                    AI = (from ir in db.ItemReseña
                          where ir.IR_esAI == true
                          select new ItemViewModel
                          {
                              idItemReseña = ir.idItemReseña,
                              nombreItemReseña = ir.nombreItemReseña
                          }).ToList();
                }

                if (esAoAr)
                {
                    AoAr = (from ir in db.ItemReseña
                            where ir.IR_esAoAr == esAoAr 
                            select new ItemViewModel
                            {
                                idItemReseña = ir.idItemReseña,
                                nombreItemReseña = ir.nombreItemReseña
                            }).ToList();
                }

                if (esArAo)
                {
                    ArAo = (from ir in db.ItemReseña
                            where ir.IR_esArAo == esArAo 
                            select new ItemViewModel
                            {
                                idItemReseña = ir.idItemReseña,
                                nombreItemReseña = ir.nombreItemReseña
                            }).ToList();
                }

                listaFinal.Add(AI);
                listaFinal.Add(AoAr);
                listaFinal.Add(ArAo);

                
                return listaFinal;

            }
        }
    }
}
