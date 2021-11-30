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
        public decimal? puntuacionResenia { get; set; }
        public int? idInmueble { get; set; }
        public string nombreAutor { get; set; }
        public int? estadoAlquiler { get; set; }
        public string nombreArrendador { get; set; }
        public int? idCuenta { get; set; }
        public string urlimg { get; set; }
        public List<ArchivoVM> listaArchivo { get; set; }
    }
}
