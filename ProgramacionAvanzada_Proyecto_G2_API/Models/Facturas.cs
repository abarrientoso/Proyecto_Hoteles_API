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
    
    public partial class Facturas
    {
        public string idFactura { get; set; }
        public int idReserva { get; set; }
        public int precio { get; set; }
        public decimal IVA { get; set; }
        public decimal total { get; set; }
    
        public virtual Reservas Reservas { get; set; }
    }
}
