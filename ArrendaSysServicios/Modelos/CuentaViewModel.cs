using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class CuentaViewModel
    {
        public int? idRol { get; set; }
        public string email { get; set; }
        public int idCuenta { get; set; }
        public DateTime? fechaBajaCuenta { get; set; }
        public DateTime? fechaAltaCuenta { get; set; }
        public int tipoCuenta { get; set; }
        public ArrendatarioViewModel arrendatario { get; set; }
        public PropietarioViewModel propietario { get; set; }
        public string contraseña { get; set; }
        public InmobiliariaViewModel inmobiliaria{get;set;}
    }
}
