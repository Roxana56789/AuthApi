using RestauranteMariscos.DTOs;

namespace RestauranteMariscos.Interfaces
{
    public interface ICategoriaRJService
    {
        Task<IEnumerable<CategoriaRJDto>> GetAllAsync();
        Task<CategoriaRJDto?> GetByIdAsync(int id);
        Task<CategoriaRJDto> AddAsync(CategoriaRJCreateDto dto);
        Task<bool> UpdateAsync(int id, CategoriaRJCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

