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
    
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            this.Cuenta = new HashSet<Cuenta>();
        }
    
        public int idRol { get; set; }
        public string descripcionRol { get; set; }
        public Nullable<System.DateTime> fechaAltaRol { get; set; }
        public Nullable<System.DateTime> fechaBajaRol { get; set; }
        public string nombreRol { get; set; }
        public Nullable<int> idPermisoRol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual PermisoRol PermisoRol { get; set; }
    }
}