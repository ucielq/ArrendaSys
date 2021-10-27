using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class AlquileresViewModel
    {
        public int idAlquiler { get; set; }
        public DateTime? fechaAltaAlquiler { get; set; }
        public DateTime? fechaBajaAlquiler { get; set; }
        public int? idArrendatario { get; set; }
        public int? idInmueble { get; set; }
        public InmuebleViewModel inmueble{get;set;}
        public ArrendatarioViewModel arrendatario { get; set; }
        public object arrendador { get; set; }
        public string descripcionEstadoAlquiler { get; set; }
    }
}
