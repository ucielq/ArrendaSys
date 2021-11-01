using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaArrendatarioInmuebleViewModel
    {

         
        public int idReseñaAI { get; set; }
        public string descripcionReseñaAI { get; set; }
        public DateTime? fechaAltaReseñaAI { get; set; }
        public DateTime? fechaBajaReseñaAI { get; set; }
          public decimal? puntuacionReseñaAI { get; set; }
        public string respuestaReseñaAI { get; set; }
        public int? idAlquiler { get; set; }
    //    public List<ReseniaItemViewModel> listaReseniaItems { get; set; }
         
      


    }
}
