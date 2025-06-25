using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Identity.Client; // Esta línea no es necesaria para este controlador y puede eliminarse si no se usa en otra parte del proyecto
using TareasAPI.Models; // Asegúrate de que este namespace coincida con tu proyecto (TareasApi o TareasAPI)

namespace TareasApi.Controllers // Asegúrate de que este namespace coincida con tu proyecto (TareasApi o TareasAPI)
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        // Variable de contexto (comentario original: agregar de contexto)
        private readonly Bdtareas904Context _baseDatos;

        public TareasController(Bdtareas904Context baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // Metodo GET ListaTareas
        [HttpGet]
        [Route("ListaTareas")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas = await
                _baseDatos.Tareas.ToListAsync();
            return Ok(listaTareas);
        }

        // Metodo POST agregar tarea (comentario original: Metodo POST agregar tarea )
        [HttpPost] // ¡CORREGIDO! Usar POST para agregar recursos.
        [Route("AgregarTarea")] // Renombrado a "AgregarTarea" para consistencia, aunque "Agregar" también funcionaría.
        public async Task<IActionResult> Agregar([FromBody] 
        Tarea request)
        {
            await _baseDatos.Tareas.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        // Metodo PUT ModificarTareas (comentario original: Metodo PUT  ModificarTareas)
        [HttpPut] // ¡CORREGIDO! Usar PUT para modificar recursos.
        [Route("ModificarTarea/{id:int}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Tarea request)
        {
            var tareaModificar = await
                _baseDatos.Tareas.FindAsync(id);

            if (tareaModificar == null)
            {
                return BadRequest("No existe la tarea");
            }

            tareaModificar.Nombre = request.Nombre;

            try
            {
                await _baseDatos.SaveChangesAsync();
            }
            catch (Exception e) // Captura la excepción para un manejo adecuado.
            {
                // Considera loguear la excepción 'e' para depuración.
                return NotFound(); // Devolver NotFound() en caso de error al guardar puede ser ambiguo.
                                   // Un 500 Internal Server Error (StatusCode(500)) podría ser más apropiado si es un error inesperado del servidor.
            }

            return Ok();
        }

        // Metodo DELETE eliminar tarea (comentario original: metodo DELTE eliminar tarea)
        [HttpDelete]
        [Route("EliminarTarea/{id:int}")] // Asegúrate del espacio después de ':' si lo tenías en el original, o quítalo para consistencia.
        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEliminar = await
            _baseDatos.Tareas.FindAsync(id);

            if (tareaEliminar == null)
            {
                return BadRequest("No existe la tarea");
            }

            _baseDatos.Tareas.Remove(tareaEliminar);
            await _baseDatos.SaveChangesAsync();
            return Ok();
        }
    }
}