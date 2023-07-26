using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramacionAvanzada_Proyecto_G2_API.Entities
{
    public class UsuarioEnt
    {
        public long idUsuario { get; set; }
        public string correoElectronico { get; set; }
        public string contrasenna { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string contrasennaNueva { get; set; }
        public string confirmarContrasenna { get; set; }
        public bool estado { get; set; }
        public byte idRol { get; set; }
        public string nombreRol { get; set; }
    }
}