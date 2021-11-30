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
        public int idPropio { get; set; }
        public string rutaFoto { get; set; }
        public string premium { get; set; }
        public int? codigoConfirmacion { get; set; }
        public string direccion { get; set; }
        public string nombreRol { get; set; }
    }
}
