using Dominio.Entities;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class ColegioRepository
    {
        private readonly ColegioDb _context;

        public ColegioRepository(ColegioDb context)
        {
            _context = context;
        }

        public async Task<List<Colegio>> ListarAsync() =>
            await _context.Colegios.ToListAsync();

        public async Task<Colegio?> ObtenerPorIdAsync(Guid id) =>
            await _context.Colegios.FindAsync(id);

        public async Task AgregarAsync(Colegio colegio)
        {
            _context.Colegios.Add(colegio);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Colegio colegio)
        {
            _context.Colegios.Update(colegio);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio is not null)
            {
                _context.Colegios.Remove(colegio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
