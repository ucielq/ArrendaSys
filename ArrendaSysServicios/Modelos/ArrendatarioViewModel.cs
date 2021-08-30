using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ArrendatarioViewModel
    {
        public int tipoCuenta { get; set; }
        public int nroDocumento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string fechaNacimientoStr { get; set; }
        public string tipoDocumento { get; set; }
        public int nroTelefono { get; set; }
        public string nombreArrendatario { get; set; }
        public string apellidoArrendatario { get; set; }

    }
}

