using ProgramacionAvanzada_Proyecto_G2_API.Models;
using ProgramacionAvanzada_Proyecto_G2_API.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;

namespace ProgramacionAvanzada_Proyecto_G2_API.Controllers
{
    public class HabitacionesController : ApiController
    {

        [HttpGet]
        [Route("api/habitacionesRegistradas")]
        public List<HabitacionEnt> habitacionesRegistradas()
        {
            try
            {
                using (var context = new Proyecto_HotelesEntities())
                {
                    var habitaciones = context.Habitaciones.ToList();

                    if (habitaciones == null || habitaciones.Count == 0)
                    {
                        return new List<HabitacionEnt>();
                    }

                    var habitacionesEnt = habitaciones.Select(h => new HabitacionEnt
                    {
                        IdHabitacion = h.idHabitacion,
                        IdCategoria = h.idCategoria,
                        IdHotel = h.idHotel,
                        Descripcion = h.descripcion,
                        Disponible = h.disponible
                    }).ToList();

                    return habitacionesEnt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar las habitaciones: " + ex.Message);
                return new List<HabitacionEnt>();
            }
        }

        [HttpPost]
        [Route("api/insertarHabitacion")]
        public IHttpActionResult InsertarHabitacion([FromBody] HabitacionEnt habitacion)
        {
            try
            {
                if (habitacion == null)
                {
                    return BadRequest("Datos de la habitación no proporcionados");
                }

                if (string.IsNullOrEmpty(habitacion.Descripcion) || habitacion.IdCategoria <= 0 || habitacion.IdHotel <= 0)
                {
                    return BadRequest("Los datos de la habitación no pueden estar vacíos o contener valores negativos");
                }

                using (var context = new Proyecto_HotelesEntities())
                {
                    var nuevaHabitacion = new Habitaciones
                    {
                        idCategoria = habitacion.IdCategoria,
                        idHotel = habitacion.IdHotel,
                        descripcion = habitacion.Descripcion,
                        disponible = habitacion.Disponible
                    };

                    context.Habitaciones.Add(nuevaHabitacion);
                    context.SaveChanges();

                    return Ok("Habitación insertada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("api/eliminarHabitacion/{id}")]
        public IHttpActionResult DeleteHabitacion(int id)
        {
            try
            {
                using (var context = new Proyecto_HotelesEntities())
                {
                    var habitacion = new Habitaciones { idHabitacion = id };
                    context.Entry(habitacion).State = EntityState.Deleted;
                    context.SaveChanges();

                    return Ok("Habitación eliminada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/actualizarHabitacion/{id}")]
        public IHttpActionResult UpdateHabitacion(int id, [FromBody] HabitacionEnt habitacion)
        {
            try
            {
                if (habitacion == null)
                {
                    return BadRequest("Datos de la habitación no proporcionados");
                }

                using (var context = new Proyecto_HotelesEntities())
                {
                    var habitacionExistente = context.Habitaciones.FirstOrDefault(h => h.idHabitacion == id);

                    if (habitacionExistente == null)
                    {
                        return NotFound();
                    }


                    habitacionExistente.idCategoria = habitacion.IdCategoria;
                    habitacionExistente.idHotel = habitacion.IdHotel;
                    habitacionExistente.descripcion = habitacion.Descripcion;
                    habitacionExistente.disponible = habitacion.Disponible;

                    context.SaveChanges();

                    return Ok("Habitación actualizada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



    }
}