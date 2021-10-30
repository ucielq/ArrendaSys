using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class InmuebleEstadoViewModel
    {
        public DateTime? fechaAltaInmuebleEstado { get; set; }
        public DateTime? fechaBajaInmuebleEstado { get; set; }
        public int idEstadoInmueble { get; set; }
        public int? idInmueble { get; set; }
        public EstadoInmuebleViewModel nombreEstado { get; set; }

    }
}
