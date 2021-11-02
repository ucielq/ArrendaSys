using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ViewModelReseniaAux
    {
        public int? cantidad { get; set; }
        public List<ReseniaViewModel> lista { get; set; }
    }
}
