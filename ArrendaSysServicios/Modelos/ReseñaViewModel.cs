using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    class ReseñaViewModel
    {

        public int idAlquiler { get; set; }
        public DateTime? fechaAltaReseñaArAo { get; set; }
        public DateTime? fechaBajaReseñaArAo { get; set; }
        public int? idArrendatario { get; set; }
        public int? idInmueble { get; set; }
        //Preguntar
        //   public PropietarioViewModel propietario { get; set; }
        //   public InmobiliariaViewModel inmobiliaria { get; set; }
        //Ver si utiliza el crear o solo visualiza
        //  public ArrendatarioViewModel arrendatario { get; set; }
    }
}
