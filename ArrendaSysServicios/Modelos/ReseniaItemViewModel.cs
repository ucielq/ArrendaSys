using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaItemViewModel
    {
        public int idReseniaItem { get; set; }
        public int? puntuacionReseniaItem { get; set; }
        public int? idResenia { get; set; }
        public int? idItemResenia { get; set; }
    }
}
