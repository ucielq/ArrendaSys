using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class LocalidadViewModel
    {
        public int? idLocalidad { get; set; }
        public int? codigopostal { get; set; }
        public string nombreLocalidad { get; set; }
        public int? idDepartamento { get; set; }
        public DepartamentoViewModel departamento { get; set; }

    }
}
