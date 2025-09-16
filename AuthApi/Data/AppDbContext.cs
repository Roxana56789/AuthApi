using AuthApi.Entidades;
using Microsoft.EntityFrameworkCore;
using RestauranteMariscos.Entidades;

namespace RestauranteMariscos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tu tabla de usuarios
        public DbSet<Usuario> Usuarios { get; set; }

        // Tu tabla de roles
        public DbSet<Rol> Roles { get; set; }

        // Tu tabla de categorías
        public DbSet<CategoriaRJ> CategoriasRJ { get; set; }
    }
}

