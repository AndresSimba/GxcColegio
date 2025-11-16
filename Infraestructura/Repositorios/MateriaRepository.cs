using Dominio.Entities;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

public class MateriaRepository
{
    private readonly ColegioDb _context;

    public MateriaRepository(ColegioDb context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Materia>> ObtenerTodosAsync()
        => await _context.Materias.ToListAsync();

    public async Task<Materia?> ObtenerPorIdAsync(int id)
        => await _context.Materias.FindAsync(id);

    public async Task AgregarAsync(Materia materia)
    {
        _context.Materias.Add(materia);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Materia materia)
    {
        _context.Materias.Update(materia);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var materia = await _context.Materias.FindAsync(id);
        if (materia != null)
        {
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
        }
    }
}
