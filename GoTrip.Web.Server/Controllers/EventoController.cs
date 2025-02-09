using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : GenericController<IEventoService, EventoDto>
    {
        private readonly IEventoService _eventoService;
        private readonly IUbicacionService _ubicacionService;

        public EventoController(IEventoService eventoService, IUbicacionService ubicacionService)
            : base(eventoService)
        {
            _eventoService = eventoService;
            _ubicacionService = ubicacionService;
        }

        // Endpoint de alta para crear un evento con ubicación
        [HttpPost("alta")]
        public async Task<IActionResult> CrearEventoConUbicacion([FromBody] EventoConUbicacionDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Evento.Descripcion) || dto.Ubicacion == null)
            {
                return BadRequest("Datos inválidos.");
            }

            // Crear ubicación y obtener su ID
            var nuevaUbicacion = new UbicacionDto
            {
                Descripcion = dto.Ubicacion.Descripcion,
                Longitud = dto.Ubicacion.Longitud,
                Latitud = dto.Ubicacion.Latitud,
                Localidad = dto.Ubicacion.Localidad,
                Provincia = dto.Ubicacion.Provincia,
                Pais = dto.Ubicacion.Pais
            };

            var ubicacionId = await _ubicacionService.Save(nuevaUbicacion);

            if (ubicacionId == 0) // Valida si la ubicación no se creó correctamente
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la ubicación.");
            }

            // Crear evento con el ID de ubicación obtenido
            var nuevoEvento = new EventoDto
            {
                Descripcion = dto.Evento.Descripcion,
                FechaInicio = dto.Evento.FechaInicio,
                FechaFin = dto.Evento.FechaFin,
                PathImagen = dto.Evento.PathImagen,
                UbicacionId = ubicacionId, // Asigna el ID de la ubicación creada
                CategoriaId = dto.Evento.CategoriaId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                State = dto.Evento.State
            };

            await _eventoService.Save(nuevoEvento);

            return Ok("Evento creado exitosamente con su ubicación.");
        }
    }
}
