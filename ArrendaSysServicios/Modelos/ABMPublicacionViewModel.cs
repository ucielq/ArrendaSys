using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class ABMPublicacionViewModel
    {

        public int idPublicacion { get; set; }

        public string descripcionPublicacion { get; set; }
        public DateTime? fechaAltaPublicacion { get; set; }
        public DateTime? fechaBajaPublicacion { get; set; }
        public decimal? precioAlquiler { get; set; }
        public string tituloPublicacion { get; set; }
        public int? idInmueble { get; set; }

        public int? idPublicacionEstado { get; set; }
        public string descripcionEstadoPublicacion { get; set; }

        public InmuebleViewModel inmueble { get; set; }
        public List<ArchivoVM> listaMultimedia { get; set; }
        public PropietarioViewModel propietario{ get; set; }
        public InmobiliariaViewModel inmobiliaria { get; set; }


    }
}
