using AuthApi.DTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;

namespace AuthApi.Servicios
{
    public class CategoriaRJService 
    {
        private readonly ICategoriaRJRepository _repository;

        public CategoriaRJService(ICategoriaRJRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoriaRJDto>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            return categorias.Select(c => new CategoriaRJDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            });
        }

        public async Task<CategoriaRJDto?> GetByIdAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaRJDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<CategoriaRJDto> AddAsync(CategoriaRJCreateDto dto)
        {
            var categoria = new CategoriaRJ
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _repository.AddAsync(categoria);
            await _repository.SaveChangesAsync();

            return new CategoriaRJDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaRJCreateDto dto)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return false;

            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;

            await _repository.UpdateAsync(categoria);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveChangesAsync();
        }
    }
}

