using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    internal class TestRegitroProducto
    {
        private Mock<ServicioProducto> _mockServicioProducto;
        private Agregar_Productos _formAgregarProductos; 

        [SetUp]
        public void SetUp()
        {
            _mockServicioProducto = new Mock<ServicioProducto>();
            _formAgregarProductos = new Agregar_Productos();
        }
        [Test]
        public void Button1_Click_ShouldCallAgregarMethod_WhenIdIsZero()
        {
            // Arrange
            _formAgregarProductos.nombretx.Text = "TestProduct";
            _formAgregarProductos.descriptiontx.Text = "TestDescription";
            _formAgregarProductos.categorytx.SelectedIndex = 0;
            _formAgregarProductos.pricetx.Text = "10.0";
            _formAgregarProductos.cuantitytx.Text = "100";
            _formAgregarProductos.provetortx.SelectedItem = "TestProveedor";
            _formAgregarProductos.barcodetx.Text = "7895426548";
            _formAgregarProductos.expiretx.Value = DateTime.Now.AddYears(1);
            _formAgregarProductos.signtx.Text = "TestMarca";
            _formAgregarProductos.locationtx.Text = "TestLocation";
            _formAgregarProductos.p.Id = 0; 

            // Act
            _formAgregarProductos.button1_Click(this, EventArgs.Empty);

            // Assert
            _mockServicioProducto.Verify(mock => mock.Agregar(It.IsAny<Producto>()), Times.Never);

        }
    }
}
