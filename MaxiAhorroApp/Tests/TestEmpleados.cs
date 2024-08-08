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
using System.Windows.Forms;

namespace MaxiAhorroApp.Tests
{
    [TestFixture]
    internal class TestEmpleados
    {
        private Empleado e;
        private Mock<ServicioEmpleado> _servicioempleado;
        [SetUp]
        public void SetUp()
        {
            e = new Empleado();
            _servicioempleado = new Mock<ServicioEmpleado>();
        }
        [Test]
        public void Agregar_Empleado_Valido()
        {
            // Arrange
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now;
            e.Puesto = "Administrador";
            e.Salario = 800;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Agregar(e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }

        [Test]
        public void Agregar_Empleado_NoValido()
        {
            // Arrange
            e.Nombre = "Marlon";
            e.Apellido = "Valdiviezo";
            e.Email = "marlon@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now.AddMonths(4);
            e.Puesto = "Administrador";
            e.Salario = 800;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Agregar(e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once());
        }

        [Test]
        public void Consultar_Empleados()
        {
            //Arrange
            List<Empleado> empleados = new List<Empleado>();
            //Act
            empleados = _servicioempleado.Object.Consultar();

            empleados.ForEach(e => Console.WriteLine(e.Nombre));
        }

        [Test]
        public void Insertar_Usuario_Repetido()
        {
            // Arrange
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki1@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now;
            e.Puesto = "Administrador";
            e.Salario = 800;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Agregar(e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }
        [Test]
        public void Modificar_Empleado_Bien()
        {
            // Arrange
            e.IDEmpleado = 3;
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now;
            e.Puesto = "Administrador";
            e.Salario = 100;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Modificar(e, e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }
        [Test]
        public void Modificar_Empleado_Mal_Contrato()
        {
            // Arrange
            e.IDEmpleado = 3;
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = new DateTime(year: 1999, month: 05, day: 1);
            e.Puesto = "Administrador";
            e.Salario = 100;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Modificar(e, e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }
        [Test]
        public void Modificar_Empleado_Mal_Salario()
        {
            // Arrange
            e.IDEmpleado = 3;
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = DateTime.Now;
            e.Puesto = "Administrador";
            e.Salario = -100;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Modificar(e, e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }
        [Test]
        public void Modificar_Empleado_Mal_Contrato_Salario()
        {
            // Arrange
            e.IDEmpleado = 3;
            e.Nombre = "Yuki";
            e.Apellido = "Valdiviezo";
            e.Email = "Yuki@gmail.com";
            e.Contraseña = "12345";
            e.Rol = "Administrador";
            e.FechaContratacion = new DateTime(year: 1999, month: 05, day: 1);
            e.Puesto = "Administrador";
            e.Salario = -100;
            e.Estado = "Activo";
            // Act
            _servicioempleado.Object.Modificar(e, e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }
        [Test]
        public void Eliminar_Empleado()
        {
            // Arrange
            e.IDEmpleado = 3;
            
            // Act
            _servicioempleado.Object.Eliminar(e);
            // Assert
            //_servicioempleado.Verify(mock => mock.Agregar(It.IsAny<Empleado>()), Times.Once);
        }


    }
}
