//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramacionAvanzada_Proyecto_G2_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calificaciones()
        {
            this.Hoteles = new HashSet<Hoteles>();
        }
    
        public int idCalificacion { get; set; }
        public long idUsuario { get; set; }
        public int calificacion { get; set; }
        public string descripcion { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoteles> Hoteles { get; set; }
    }
}
