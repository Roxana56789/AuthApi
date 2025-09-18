using AuthApi.Interfaces;

namespace AuthApi.Servicios
{
    public class UsuarioService 
    {
        // Aquí podrías inyectar un repositorio si usas base de datos:
        // private readonly IUsuarioRepository _repo;
        // public UsuarioService(IUsuarioRepository repo) { _repo = repo; }

        public async Task<IEnumerable<string>> ObtenerUsuariosAsync()
        {
            // Ejemplo: datos simulados
            await Task.Delay(10);
            return new List<string> { "Alice", "Bob", "Charlie" };
        }

        public async Task<string> ObtenerUsuarioPorIdAsync(int id)
        {
            await Task.Delay(10);
            // Ejemplo simple
            return $"Usuario {id}";
        }

        public async Task CrearUsuarioAsync(string nombre)
        {
            await Task.Delay(10);
            // Aquí iría la lógica para guardar el usuario
        }
    }
}

