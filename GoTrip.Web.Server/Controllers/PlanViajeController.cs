using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanViajeController : GenericController<IPlanViajeService, PlanViajeDto>
    {
        private readonly IPlanViajeService _planViajeService;

        public PlanViajeController(IPlanViajeService entityService) : base(entityService)
        {
            _planViajeService = entityService;
        }        
    }
}
