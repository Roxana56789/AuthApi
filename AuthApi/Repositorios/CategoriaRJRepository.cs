using Microsoft.EntityFrameworkCore;
using AuthApi.Interfaces;
using AuthApi.Entidades;

namespace AuthApi.Repositorios
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
            return await _context.Categoria.ToListAsync();
        }

        public async Task<CategoriaRJ?> GetByIdAsync(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }

        public async Task AddAsync(CategoriaRJ categoria)
        {
            await _context.Categoria.AddAsync(categoria);
        }

        public async Task UpdateAsync(CategoriaRJ categoria)
        {
            _context.Categoria.Update(categoria);
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await GetByIdAsync(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
