using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using MaxiAhorroApp.Vistas;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Tests
{
    [TestFixture]
    internal class TestAgregarEmpleado
    {
        private Empleado e = new Empleado();
        private Mock<ServicioEmpleado> _servicioempleado;
        [SetUp]
        public void SetUp()
        {
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now;
            e.Puesto = "Administrador";
            e.Salario = 800;
            e.Estado = "Activo";
        }
        [Test]
        public void Should_be_valid()
        {
            // Arrange

            // Act
            _servicioempleado.Object.Agregar(e);
            // Assert
            _servicioempleado.Verify(mock =>  mock.Agregar(e), Times.Once);
        }
    }
}
