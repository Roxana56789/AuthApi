using AuthApi.Entidades;

namespace AuthApi.Interfaces
{
    public interface ICategoriaRJRepository

    {
        Task<IEnumerable<CategoriaRJ>> GetAllAsync();
        Task<CategoriaRJ?> GetByIdAsync(int id);
        Task AddAsync(CategoriaRJ categoria);
        Task UpdateAsync(CategoriaRJ categoria);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
