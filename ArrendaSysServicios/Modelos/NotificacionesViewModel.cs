using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class NotificacionesViewModel
    {
         
        public int idNotificacion { get; set; }
        public string descripcionNotificacion { get; set; }
        public string nombreNotificacion { get; set; }

        public DateTime? fechaNotificacion { get; set; }
        public int? idCuenta { get; set; }

        public bool leido { get; set; }

    }
}
