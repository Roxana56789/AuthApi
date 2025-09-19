using AuthApi.Interfaces;

namespace AuthApi.Servicios
{
    public class UsuarioService 
    {
        public async Task<IEnumerable<string>> ObtenerUsuariosAsync()
        {
           
            await Task.Delay(10);
            return new List<string> { "Caballero", "Castro" };
        }

        public async Task<string> ObtenerUsuarioPorIdAsync(int id)
        {
            await Task.Delay(10);
            
            return $"Usuario {id}";
        }

        public async Task CrearUsuarioAsync(string nombre)
        {
            await Task.Delay(10);
        }
    }
}

