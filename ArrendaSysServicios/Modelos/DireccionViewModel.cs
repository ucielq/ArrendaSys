using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class DireccionViewModel
    {
        public int? idDireccion { get; set; }
        public int? idLote { get; set; }
        public int? idManzana { get; set; }
        public string nombreBarrio { get; set; }
        public string nombreCalle { get; set; }
        public int? numeroCalle { get; set; }
        public int? idLocalidad { get; set; }
        public LocalidadViewModel localidad {get;set;}

    }
}
