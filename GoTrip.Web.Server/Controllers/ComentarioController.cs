using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ComentarioController : GenericController<IComentarioService, ComentarioDto>
    {
        private readonly IComentarioService _comentarioService;


        public ComentarioController(IComentarioService comentarioService)
            : base(comentarioService)
        {
            _comentarioService = comentarioService;
        }
    }
}
