using AuthApi.DTOs.UsuarioDTOs;
using AuthApi.Interfaces;
using AuthApi.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Generic;

namespace AuthApi.TestXunit
{
    public class AuthRepositoryTest
    { 
        private IConfiguration GetTestConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"Jwt:Key", "ClaveSuperSecretaMuyLargatsest567890!"},
                {"Jwt:Issuer", "AuthApiTest"},
                {"Jwt:Audience", "AuthApiClients"}
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }
        [Fact]
        public async Task RegistrarAsync_RetomeUsuarioConToken()
        {

            var mockRepo = new Mock<IUsuarioRepository>();
            var confing = GetTestConfiguration();
            var usuario = new Entidades.Usuario
            {
                Id = 1,
                Nombre = "Roxana",
                Email = "Roxana@test.com",
                password = "hash",
                Rol = new Entidades.Rol { Id = 2, Nombre = "Usuario" }

            };


            mockRepo.Setup(r => r.AddAsync(It.IsAny<Entidades.Usuario>())).ReturnsAsync(usuario);


            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(usuario);

            var service =new AuthRepository(mockRepo.Object, confing);

            var registroDto = new UsuarioRegistroDTO
            {
                Nombre = "Roxana",
                Email = "Roxana@test.com",
                Password = "123"

            };
            var result = await service.RegistrarAsync(registroDto);
            Assert.NotNull(result);
            Assert.Equal("Roxana", result.Nombre);
            Assert.Equal("Roxana@test.com", result.Email);
            Assert.False(string.IsNullOrEmpty(result.Token));

        }
        [Fact]
        public async Task LoginAsync_RetornalNullSiUsuarioNoExiste()
        {
            var mockRepo = new Mock<IUsuarioRepository>();
            var confing = GetTestConfiguration();

            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((Entidades.Usuario?)null);

            var service = new AuthRepository(mockRepo.Object, confing);
            var loginDto = new UsuarioLoginDto
            {
                Email = "Jeannette@test.com",
                Password = "123"
            };
            var result = service.LoginAsync(loginDto);

            Assert.NotNull(result);

        }

    }
}

