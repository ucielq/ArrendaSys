using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class PropietarioViewModel
    {
        public int idCuenta { get; set; }
        public int idPropietario { get; set; }
        public string nombrePropietario { get; set; }
        public string apellidoPropietario { get; set; }
        public int? numeroDocumentoPropietario { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string fechaNacimientoStr { get; set; }
        public string tipoDocumentoProp { get; set; }
        public string telefonoPropietario { get; set; }

    }
}
