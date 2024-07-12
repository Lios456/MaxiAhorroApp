using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using MaxiAhorroApp.Vistas;
using Moq;
using NUnit.Framework;

namespace MaxiAhorroApp
{
    [TestFixture]
    internal class TestListarProductos
    {
        private Mock<ServicioProducto> _mockServicioProducto;
        private IList<Producto> _listarProductos;

        [SetUp]
        public void SetUp()
        {
            _mockServicioProducto = new Mock<ServicioProducto>();
        }
        [Test]
        public void ListarProductosCorrecto()
        {
            // Arrange

            // Act
            _listarProductos = new ServicioProducto().Consultar();

            // Assert
            _mockServicioProducto.Verify(mock => mock.Consultar(), Times.Never);

        }
    }
}
