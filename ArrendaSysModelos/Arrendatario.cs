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
    
    public partial class Arrendatario
    {
        public DateTime fechaNacimArrendatario;

        public int idArrendatario { get; set; }
        public string apellidoArrendatario { get; set; }
        public string nombreArrendatario { get; set; }
        public Nullable<int> numeroDocumentoArr { get; set; }
        public Nullable<int> telefonoArrendatario { get; set; }
        public string tipoDocumentoArr { get; set; }
        public Nullable<int> idCuenta { get; set; }
    }
}
