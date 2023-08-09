using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProgramacionAvanzada_Proyecto_G2_API.Models.ViewModel;
using ProgramacionAvanzada_Proyecto_G2_API.Entities;
using System.Text;
using ProgramacionAvanzada_Proyecto_G2_API.Models;

namespace ProgramacionAvanzada_Proyecto_G2_API.Controllers
{
    public class UsuarioController : ApiController
    {
        UtilitariosViewModel model = new UtilitariosViewModel();

        [HttpPost]
        [Route("api/IniciarSesion")]
        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var bd = new Proyecto_HotelesEntities())
            {
                var datos = (from x in bd.Usuarios
                             join r in bd.Roles on x.idRol equals r.idRol
                             where x.correoElectronico == entidad.correoElectronico
                             && x.contrasenna == entidad.contrasenna
                             && x.estado == true
                             select new
                             {
                                 x.UsaClaveTemporal,
                                 x.FechaCaducidad,
                                 x.correoElectronico,
                                 x.nombre,
                                 x.identificacion,
                                 x.estado,
                                 x.idRol,
                                 r.nombreRol,
                                 x.idUsuario
                             }).FirstOrDefault();

                if (datos != null)
                {
                    if (datos.UsaClaveTemporal && datos.FechaCaducidad < DateTime.Now)
                        return null;

                    UsuarioEnt resp = new UsuarioEnt();
                    resp.correoElectronico = datos.correoElectronico;
                    resp.nombre = datos.nombre;
                    resp.identificacion = datos.identificacion;
                    resp.estado = datos.estado;
                    resp.idRol = datos.idRol;
                    resp.nombreRol = datos.nombreRol;
                    resp.idUsuario = datos.idUsuario;
                    return resp;
                }

                return null;
            }


        }
        [HttpPost]
        [Route("api/Registrarse")]
        public int Registrarse(UsuarioEnt entidad)
        {
            using (var bd = new Proyecto_HotelesEntities())
            {
                Usuarios tabla = new Usuarios();
                tabla.correoElectronico = entidad.correoElectronico;
                tabla.contrasenna = entidad.contrasenna;
                tabla.identificacion = entidad.identificacion;
                tabla.nombre = entidad.nombre;
                tabla.estado = entidad.estado;
                tabla.idRol = entidad.idRol;
                tabla.FechaCaducidad = DateTime.Now;


                bd.Usuarios.Add(tabla);
                return bd.SaveChanges();
            }

        }
        [HttpPost]
        [Route("api/RecuperarContrasenna")]
        public bool RecuperarContrasenna(UsuarioEnt entidad)
        {
            using (var bd = new Proyecto_HotelesEntities())
            {
                var datos = (from x in bd.Usuarios
                             where x.correoElectronico == entidad.correoElectronico
                             && x.estado == true
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    string password = model.CreatePassword();

                    datos.contrasenna = password;
                    datos.UsaClaveTemporal = true;
                    datos.FechaCaducidad = DateTime.Now.AddMinutes(30);
                    bd.SaveChanges();

                    StringBuilder mensaje = new StringBuilder();
                    mensaje.Append("<html><head></head><body>");
                    mensaje.Append("Estimado(a) " + datos.nombre + "<br/><br/>");
                    mensaje.Append("Se ha generado el siguiente código temporal para que ingrese al sistema de Tico Hotel: <b>" + password + "</b><br/><br/>");
                    mensaje.Append("El código generado tiene 30 minutos de validez, por favor ingrese al sistema para establecer su nueva contraseña <br/><br/>");
                    mensaje.Append("Este correo se ha generado de manera automática del el sistema <br/><br/>");
                    mensaje.Append("Muchas Gracias <br/><br/>");
                    mensaje.Append("<a href='https://localhost:44396/>Tico Hotel</a>");
                    mensaje.Append("</body></html>");

                    model.SendEmail(datos.correoElectronico, "Recuperar Contraseña", mensaje.ToString());
                    return true;
                }

            }
            return false;
        }
        [HttpPut]
        [Route("api/CambiarContrasenna")]
        public int CambiarContrasenna(UsuarioEnt entidad)
        {
            using (var bd = new Proyecto_HotelesEntities())
            {
                var datos = (from x in bd.Usuarios
                             where x.idUsuario == entidad.idUsuario
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.contrasenna = entidad.contrasennaNueva;
                    datos.UsaClaveTemporal = false;
                    datos.FechaCaducidad = DateTime.Now;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }


    }
}