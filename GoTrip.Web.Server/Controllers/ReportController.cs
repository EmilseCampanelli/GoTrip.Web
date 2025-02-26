using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReportController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }


        [HttpGet("obtenerReporte")]
        public ActionResult<ReporteDto> ObtenerReporte()
        {
            try
            {
                var result = _reporteService.ObtenerReporte();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
