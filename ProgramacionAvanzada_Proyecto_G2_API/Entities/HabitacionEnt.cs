using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramacionAvanzada_Proyecto_G2_API.Entities
{
    public class HabitacionEnt
    {

        public int IdHabitacion { get; set; }
        public int IdCategoria { get; set; }
        public int IdHotel { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }

    }
}