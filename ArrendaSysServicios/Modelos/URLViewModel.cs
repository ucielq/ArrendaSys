using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class URLViewModel
    {
        public int? idUrl { get; set; }
        public string nombreUrl { get; set; }
        public string descripcion { get; set; }
        public int? posicion { get; set; }
        public string codigo { get; set; }
        public string linkUrl { get; set; }
        public int? codigoRetorno { get; set; }
        public string iconClass { get; set; }
        public int? idPermisoRol { get; set; }
        public bool? lectura { get; set; }
        public bool? edicion { get; set; }
        public bool? eliminacion { get; set; }

    }
}
