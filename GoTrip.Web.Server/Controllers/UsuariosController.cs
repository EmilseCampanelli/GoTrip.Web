using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _entityService;

        public UsuariosController(IUsuarioService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            try
            {
                var result = await _entityService.Get(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult<UsuarioDto>> GetAll()
        {
            try
            {
                var result = await _entityService.GetAll();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("")]
        public virtual async Task<IActionResult> Post([FromBody] UsuarioDto dto)
        {
            try
            {
                if (dto == null) return BadRequest();

                var (isValid, message) = await _entityService.Validate(null, dto);
                if (!isValid) return BadRequest(message);

                return Ok(await _entityService.Save(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] UsuarioDto dto)
        {
            try
            {
                if (dto == null) return BadRequest();
                if (!await _entityService.Exists(id)) return BadRequest();
                if (dto.Id.Equals(0))
                {
                    dto.Id = id;
                }

                var (isValid, message) = await _entityService.Validate(id, dto);
                if (!isValid) return BadRequest(message);

                await _entityService.Save(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPut("{id}/activate")]
        public virtual async Task<IActionResult> PutActivate([FromRoute] int id)
        {
            try
            {
                if (!await _entityService.Exists(id)) return BadRequest();
                await _entityService.Activate(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/inactivate")]
        public virtual async Task<IActionResult> PutInactivate([FromRoute] int id)
        {
            try
            {
                if (!await _entityService.Exists(id)) return BadRequest();
                await _entityService.Inactivate(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
