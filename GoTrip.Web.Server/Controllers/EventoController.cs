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

    }
}
