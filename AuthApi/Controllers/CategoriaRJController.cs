using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteMariscos.DTOs;
using RestauranteMariscos.Interfaces;

namespace RestauranteMariscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 protege todos los endpoints
    public class CategoriaRJController : ControllerBase
    {
        private readonly ICategoriaRJService _service;

        public CategoriaRJController(ICategoriaRJService service)
        {
            _service = service;
        }

        // GET: api/CategoriaRJ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaRJDto>>> GetAll()
        {
            var categorias = await _service.GetAllAsync();
            return Ok(categorias);
        }

        // GET: api/CategoriaRJ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaRJDto>> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        // POST: api/CategoriaRJ
        [HttpPost]
        public async Task<ActionResult<CategoriaRJDto>> Create(CategoriaRJCreateDto dto)
        {
            var nuevaCategoria = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevaCategoria.Id }, nuevaCategoria);
        }

        // PUT: api/CategoriaRJ/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoriaRJCreateDto dto)
        {
            var actualizado = await _service.UpdateAsync(id, dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/CategoriaRJ/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
