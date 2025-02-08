using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuntoTuristicoController : GenericController<IPuntoTuristicoService, PuntoTuristicoDto>
    {
        private readonly IPuntoTuristicoService _puntoTuristicoService;

        public PuntoTuristicoController(IPuntoTuristicoService puntoTuristicoService)
            : base(puntoTuristicoService)
        {
            _puntoTuristicoService = puntoTuristicoService;
        }

        [HttpPost("PutImages")]
        public async Task<IActionResult> PutImages([FromForm] List<IFormFile> images, int id)
        {
            return Ok(await _puntoTuristicoService.PutImage(images, id));
        }

    }
}
