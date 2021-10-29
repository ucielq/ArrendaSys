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
using System.Globalization;

namespace ArrendaSysServicios
{
    public class ServicioNotificaciones
    {

        public ArrendasysEntities db = new ArrendasysEntities();
        // ----------------------METODOS  ------------

        public object ListarNotificaciones(int idCuenta1)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                    var id = db.Notificacion.Where(x => x.idCuenta == idCuenta1).FirstOrDefault().idPropietario;
                    var notificaciones = (from n in db.Notificacion
                                         join c in db.Cuenta on n.idCuenta equals c.idCuenta
                                         where n.idCuenta == id 
                                         select new NotificacionesViewModel
                                         {
                                             idNotificacion = n.idNotificacion,
                                             fechaNotificacion = n.fechaNotificacion,
                                             nombreNotificacion = n.nombreNotificacion,
                                             descripcionNotificacion = n.descripcionNotificacion,
                                             leido = n.leido,
                                             idCuenta = n.idCuenta
                                         }).ToList();
                    object json = new { data = notificaciones };
                    return json;
            }
               
               // return new object { };
                        
        }

        public void EliminarNotificaciones(int idNotificacion)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var notificacion1 = db.Notificacion.Where(x => x.idNotificacion == idNotificacion).FirstOrDefault();

                db.Notificacion.Remove(notificacion1);
               db.SaveChanges();                   
               
            }
        }

        public void VistoNotificacion(int id)
        {
           
              using (ArrendasysEntities db = new ArrendasysEntities())
            {
                    var notificacion1 = db.Notificacion.Where(x => x.idNotificacion == id).FirstOrDefault();                   
                    notificacion1.leido = true;
                    db.SaveChanges();
                
            } 
        }



    }
}
