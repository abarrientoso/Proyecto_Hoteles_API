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
    
    public partial class Hoteles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoteles()
        {
            this.Habitaciones = new HashSet<Habitaciones>();
        }
    
        public int idHotel { get; set; }
        public string ubicacion { get; set; }
        public int idCalificacion { get; set; }
    
        public virtual Calificaciones Calificaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
