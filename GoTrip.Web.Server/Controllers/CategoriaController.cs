using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTrip.Web.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : GenericController<ICategoriaService, CategoriaDto>
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
            : base(categoriaService)
        {
            _categoriaService = categoriaService;
        }


        // Endpoint de alta para crear una categoría
        [HttpPost("alta")]
        public async Task<IActionResult> CrearCategoria([FromBody] CategoriaDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Descripcion))
                {
                    return BadRequest("Datos inválidos.");
                }


                var nuevaCategoria = new CategoriaDto
                {
                    Descripcion = dto.Descripcion
                };

                await _categoriaService.Save(nuevaCategoria);

                return Ok("Categoría creada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] CategoriaDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Descripcion))
                {
                    return BadRequest("Datos inválidos.");
                }


                var existeCategoria = await _categoriaService.Exists(id);
                if (!existeCategoria)
                {
                    return NotFound("Categoría no encontrada.");
                }

                await _categoriaService.Save(dto);

                return Ok("Categoría actualizada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                var existeCategoria = await _categoriaService.Exists(id);
                if (!existeCategoria)
                {
                    return NotFound("Categoría no encontrada.");
                }

                await _categoriaService.Delete(id);

                return Ok("Categoría eliminada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("active")]
        public async Task<IActionResult> ListarCategoriasActivas()
        {
            try
            {
                var categoriasActivas = await _categoriaService.GetActiveCategories();

                if (categoriasActivas == null || !categoriasActivas.Any())
                {
                    return NotFound("No hay categorías activas.");
                }

                return Ok(categoriasActivas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
