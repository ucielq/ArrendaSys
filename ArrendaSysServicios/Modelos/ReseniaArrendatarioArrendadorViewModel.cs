using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaArrendatarioArrendadorViewModel
    {


        public int idReseñaArAo { get; set; }
        public string descripcionReseñaArAo { get; set; }
        public DateTime? fechaAltaReseñaArAo { get; set; }
        public DateTime? fechaBajaReseñaArAo { get; set; }
        public decimal? puntuacionReseñaArAo { get; set; }
        public string respuestaReseñaArAo { get; set; }
        public int? idAlquiler { get; set; }
        //public List<ReseniaItemViewModel> listaReseniaItems { get; set; }
         
    }
}
