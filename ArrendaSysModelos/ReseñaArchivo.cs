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
    
    public partial class ReseñaArchivo
    {
        public int idReseñaArchivo { get; set; }
        public Nullable<bool> RA_esAI { get; set; }
        public Nullable<bool> RA_esAoAr { get; set; }
        public Nullable<bool> RA_esArAo { get; set; }
        public string urlMultimediaReseñaArchivo { get; set; }
        public string urlReseñaArchivo { get; set; }
        public Nullable<int> idTipoReseña { get; set; }
    }
}
