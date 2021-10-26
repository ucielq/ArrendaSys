using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaViewModel
    {

        public int idReseñaAoAr { get; set; }
        public DateTime? fechaAltaReseñaArAo { get; set; }
        public DateTime? fechaBajaReseñaArAo { get; set; }
        public int puntuacionReseñaAoAr { get; set; }
        public int? respuestaReseñaAoAr { get; set; }
        public int idAlquiler { get; set; }
        public ItemViewModel item { get; set; }
        public string descripcionReseñaArAo { get; set; }
        //Preguntar
        //   public PropietarioViewModel propietario { get; set; }
        //   public InmobiliariaViewModel inmobiliaria { get; set; }
        //Ver si utiliza el crear o solo visualiza
        //  public ArrendatarioViewModel arrendatario { get; set; }
    }
}
