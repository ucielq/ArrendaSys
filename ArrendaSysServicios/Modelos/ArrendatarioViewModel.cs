using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ArrendatarioViewModel
    {
        
        public int idArrendatario { get; set; }
        public string nombreArrendatario { get; set; }
        public string apellidoArrendatario { get; set; }
        public int numeroDocumentoArr { get; set; }
        public string tipoDocumentoArr { get; set; }
        public int telefonoArrendatario { get; set; }
        public DateTime fechaNacimArrendatario { get; set; }

    }
}

