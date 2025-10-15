using AuthApi.Entidades;
using AuthApi.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.TestXunit
{
    public class UsuarioRepositoryTest
    {
        private IEnumerable lista;

        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: $"TestDB_{Guid.NewGuid()}").Options;

            var context = new AppDbContext(options);

            context.Roles.Add(
                new Entidades.Rol { Id = 1, Nombre = "Admin" }
            );

            context.Usuarios.Add(
                new Entidades.Usuario
                {
                    Id = 2,
                    Nombre = "Roxana",
                    Email = "Roxana@test.com",
                    password = "123",
                    RolId = 1
                }
            );
            context.SaveChanges();
            return context;
        }
        [Fact]
        public async Task GetByEmailAsync_RetornarUsuarioExistente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            // Act
            var Usuario = await repo.GetByEmailAsync("Roxana@test.com");

            // Assert
            Assert.NotNull(Usuario);
            Assert.Equal("Roxana", Usuario.Nombre);
            Assert.Equal("Admin", Usuario.Rol.Nombre);
        }

        [Fact]
        public async Task AddAsync_AgregarUsuario()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);
            // Act
            var nuevousuario = new Usuario
            {
                Nombre = "Juan",
                Email = "Juan@test.com",
                password = "456",
                RolId = 1
            };

            await repo.AddAsync(nuevousuario);  
            
            var usuarioGuardado = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == "Juan@test.com");
            // Assert
            Assert.NotNull(usuarioGuardado);
            Assert.Equal("Juan", usuarioGuardado.Nombre);
        }

         [Fact]
         public async Task GetAllUsuariosAsync_RetornarListaUsuarios()
         {
             // Arrange
             var context = GetInMemoryDbContext();
             var repo = new UsuarioRepository(context);

             // Act
             var lista = await repo.GetAllUsuariosAsync();

             // Assert
             Assert.NotEmpty(lista);
             Assert.Contains(lista, u => u.Email == "Roxana@test.com");
         }   



    }

}   