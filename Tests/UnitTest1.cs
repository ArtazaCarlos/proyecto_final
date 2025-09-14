using System.Net;
using WebApplication1.Models;

namespace Tests
{
    public class UsuarioTests
    {
        [SetUp]
        public void Setup()
        {
            Usuario usuarioPrueba = new Usuario { 
                Id=1, 
                Apellidos="PEREZ", 
                Nombres="AGUSTIN",
                Sexo = "M",
                Dni = "12110011",
                Cuil = "22-121100011-2",
                Cargo = "Auxiliar de compras",
                Domicilio = "Av. Avellaneda 600",
                Telefono = "+112223334",
                DireccionCorreo = "perezagus@gmail.com",
                NombreDeUsuario = "perez001",
                Contrasena = "",
                Bloqueado = false,
                PINTemporal = null,
                UltimoAcceso = "2025-09"
            };
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}