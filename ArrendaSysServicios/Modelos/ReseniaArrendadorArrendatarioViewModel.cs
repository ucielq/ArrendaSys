using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaArrendadorArrendatarioViewModel
    {


          public int idReseñaAoAr { get; set; }        
        public string descripcionReseñaAoAr { get; set; }
        public DateTime? fechaAltaReseñaAoAr { get; set; }
        public DateTime? fechaBajaReseñaAoAr { get; set; }
        public decimal? puntuacionReseñaAoAr { get; set; }
        public string respuestaReseñaAoAr { get; set; }
        public int? idAlquiler { get; set; }
     //   public List<ReseniaItemViewModel> listaReseniaItems { get; set; }
         
    }
}
