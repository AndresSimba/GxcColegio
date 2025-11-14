using Dominio.Entities;
using Infraestructura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColegioController : ControllerBase
    {
        private readonly ColegioRepository _repo;

        public ColegioController(ColegioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colegios = await _repo.ListarAsync();
            return Ok(colegios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colegio = await _repo.ObtenerPorIdAsync(id);
            return colegio is null ? NotFound() : Ok(colegio);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Colegio colegio)
        {
            await _repo.AgregarAsync(colegio);
            return CreatedAtAction(nameof(GetById), new { id = colegio.Id }, colegio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Colegio colegio)
        {
            if (id != colegio.Id) return BadRequest();
            await _repo.ActualizarAsync(colegio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.EliminarAsync(id);
            return NoContent();
        }
    }
}
