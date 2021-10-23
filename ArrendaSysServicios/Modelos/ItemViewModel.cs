using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ItemViewModel
    {
        public int? idItemReseña { get; set; }
        public bool? IR_esAI { get; set; }
        public bool? IR_esAoAr { get; set; }
        public bool? IR_esArAo { get; set; }
        public string nombreItemReseña { get; set; }
        public string descripcion { get; set; }
    }
}
