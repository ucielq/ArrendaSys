using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
   public class ArchivoVM
    {
        public int idInmueble { get; set; }
        public string nombreArchivo { get; set; }
        public string url { get; set; }
        public int error { get; set; }
    }
}
