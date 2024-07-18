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
    internal class TestAgregarProductos
    {
        private Mock<ServicioProducto> _mockServicioProducto;
        private Agregar_Productos _form;
        [SetUp]
        public void SetUp()
        {
            _mockServicioProducto = new Mock<ServicioProducto>();
           _form = new Agregar_Productos();
        }
        [Test]
        public void Should_be_valid() {
            // Arrange
            _form.nombretx.Text = "Deja";
            _form.descriptiontx.Text = "Caja 5 sobres";
            _form.cuantitytx.Value = 100;
            _form.categorytx.SelectedIndex = 5;
            _form.barcodetx.Text = "DEJA123";
            _form.expiretx.Value = DateTime.Now.AddYears(2);
            _form.signtx.Text = "5";
            _form.pricetx.Value = 0.75m;
            _form.provetortx.SelectedIndex = 1;
            _form.locationtx.SelectedIndex = 1;
            // Act
            _form.SetProducto();

            _form.button1_Click(this, EventArgs.Empty);
            // Assert
            //_mockServicioProducto.Verify(mock => mock.Agregar(It.IsAny<Producto>()), Times.Once);
        }

        [Test]
        public void Should_be_invalid()
        {
            // Arrange
            _form.nombretx.Text = "Té de Manzanilla";
            _form.descriptiontx.Text = "Caja 5 sobres";
            _form.cuantitytx.Value = 100;
            _form.categorytx.SelectedIndex = 5;
            _form.barcodetx.Text = "TEMAN";
            _form.expiretx.Value = DateTime.Now.AddYears(2);
            _form.signtx.Text = "5";
            _form.pricetx.Value = 0.75m;
            _form.provetortx.SelectedIndex = 1;
            _form.locationtx.SelectedIndex = 1;
            // Act
            _form.SetProducto();

            _form.button1_Click(this, EventArgs.Empty);
            // Assert
            //_mockServicioProducto.Verify(mock => mock.Agregar(It.IsAny<Producto>()), Times.Once);
        }

    }
}
