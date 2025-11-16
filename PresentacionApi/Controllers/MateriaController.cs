using Dominio.Entities;
using Infraestructura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionApi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaRepository _repo;

        public MateriaController(MateriaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> Get()
            => Ok(await _repo.ObtenerTodosAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetById(int id)
        {
            var materia = await _repo.ObtenerPorIdAsync(id);
            if (materia == null) return NotFound();
            return Ok(materia);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Materia materia)
        {
            await _repo.AgregarAsync(materia);
            return CreatedAtAction(nameof(GetById), new { id = materia.Id }, materia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Materia materia)
        {
            if (id != materia.Id) return BadRequest();
            await _repo.ActualizarAsync(materia);
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
