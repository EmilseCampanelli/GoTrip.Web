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

    }
}
