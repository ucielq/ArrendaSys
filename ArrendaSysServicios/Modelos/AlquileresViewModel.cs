using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class AlquileresViewModel
    {

        public int idAlquiler { get; set; }

    //   [Display(Name = "Fecha Alta")]
   //    [DataType(DataType.Date)]
    //   [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechaAltaAlquiler { get; set; }
        public DateTime? fechaBajaAlquiler { get; set; }
        public int? idArrendatario { get; set; }
        public int? idInmueble { get; set; }
        public int? idEstadoAlquiler { get; set; }
        public int? idAlquilerEstado { get; set; }
        public InmuebleViewModel inmueble{get;set;}
        public ArrendatarioViewModel arrendatario { get; set; }
        public object arrendador { get; set; }
        public string descripcionEstadoAlquiler { get; set; }
    }
}
