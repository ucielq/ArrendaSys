//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArrendaSysModelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inmueble
    {
        public int idInmueble { get; set; }
        public Nullable<int> cantAmbientes { get; set; }
        public Nullable<int> cantBanos { get; set; }
        public Nullable<int> cantHabitaciones { get; set; }
        public Nullable<bool> cochera { get; set; }
        public string descripcionInmueble { get; set; }
        public Nullable<bool> incluyeExpensas { get; set; }
        public Nullable<int> mtsCuadrados { get; set; }
        public Nullable<int> mtsCuadradosInt { get; set; }
        public Nullable<bool> permiteMascota { get; set; }
        public Nullable<int> tipoArrendador { get; set; }
        public Nullable<int> idArrendador { get; set; }
        public Nullable<int> idDireccion { get; set; }
    }
}
