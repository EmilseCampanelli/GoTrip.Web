using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Implementacion;
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

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult<PlanViajeDto>> GetAll()
        {
            try
            {
                var result = await _planViajeService.GetAll();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("GetActive")]
        public virtual ActionResult<PlanViajeDto> GetActive(int usuarioId)
        {
            try
            {
                var result =  _planViajeService.GetActives(usuarioId);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("GetAllByUser")]
        public virtual ActionResult<PlanViajeDto> GetAllByUser(int usuarioId)
        {
            try
            {
                var result = _planViajeService.GetAllByUser(usuarioId);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
