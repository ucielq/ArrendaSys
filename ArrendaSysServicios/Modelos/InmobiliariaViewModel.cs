using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class InmobiliariaViewModel
    {
        public DateTime altaInscripcion { get; set; }
        public string altaInscripcionStr { get; set; }
        public string nombreInmobiliaria { get; set; }
        public string telefonoInmobiliariaStr { get; set; }
        public string telefonoInmobiliaria { get; set; }
        public string cuitInmobiliaria { get; set; }
        public int idCuenta { get; set; }
        public int idInmobiliaria { get; set; }
        public string direccion { get; set; }
        public string foto { get; set; }
        public int idRol { get; set; }
    }
}
