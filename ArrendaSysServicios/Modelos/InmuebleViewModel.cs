using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class InmuebleViewModel
    {
        public int? cantAmbientes { get; set; }
        public int? cantBanos { get; set; }
        public int? cantHabitaciones { get; set; }
        public bool? cochera { get; set; }
        public string descripcionInmueble { get; set; }
        public bool? incluyeExpensas { get; set; }
        public int? mtsCuadrados { get; set; }
        public int? mtsCuadradosInt { get; set; }
        public bool? permiteMascota { get; set; }
        public int? idArrendador { get; set; }
        public int? tipoArrendador { get; set; }
        public int? idDireccion { get; set; }
        public int? idInmueble { get; set; }
        public List<ArchivoVM> listaMultimedia { get; set; }
        
    }
}
