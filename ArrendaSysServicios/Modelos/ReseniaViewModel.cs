using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ReseniaViewModel
    {

        public int idResenia { get; set; }
        public DateTime? fechaAltaReseña { get; set; }
        public DateTime? fechaBajaReseña { get; set; }
        public string respuestaReseñaAoAr { get; set; }
        public int? idAlquiler { get; set; }
        public List<ReseniaItemViewModel> listaReseniaItems { get; set; }
        public string descripcionResenia { get; set; }
    }
}
