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
        public DateTime? fechaAltaAlquiler { get; set; }
        public DateTime? fechaBajaAlquiler { get; set; }
        public int? idArrendatario { get; set; }
        public int? idInmueble { get; set; }
        //Preguntar
        public PropietarioViewModel propietario { get; set; }
        public InmobiliariaViewModel inmobiliaria { get; set; }
        //Ver si utiliza el crear o solo visualiza
        public ArrendatarioViewModel arrendatario { get; set; }


    }
}
