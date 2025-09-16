using Microsoft.EntityFrameworkCore;
using RestauranteMariscos.Data;
using RestauranteMariscos.Entidades;
using RestauranteMariscos.Interfaces;

namespace RestauranteMariscos.Repositorios
{
    public class CategoriaRJRepository : ICategoriaRJRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRJRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaRJ>> GetAllAsync()
        {
            return await _context.CategoriasRJ.ToListAsync();
        }

        public async Task<CategoriaRJ?> GetByIdAsync(int id)
        {
            return await _context.CategoriasRJ.FindAsync(id);
        }

        public async Task AddAsync(CategoriaRJ categoria)
        {
            await _context.CategoriasRJ.AddAsync(categoria);
        }

        public async Task UpdateAsync(CategoriaRJ categoria)
        {
            _context.CategoriasRJ.Update(categoria);
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await GetByIdAsync(id);
            if (categoria != null)
            {
                _context.CategoriasRJ.Remove(categoria);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

