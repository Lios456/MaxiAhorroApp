using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Vistas
{
    public partial class Agregar_Productos : Form
    {
        public Producto p = new Producto();

        public Agregar_Productos()
        {
            InitializeComponent();
            CargarCombos();
            this.expiretx.MinDate = DateTime.Now.AddMonths(5);
            button2_Click(this, EventArgs.Empty);

            this.nombretx.TextChanged += nombretx_TextChanged;
            this.descriptiontx.TextChanged += descriptiontx_TextChanged;
        }

        public Agregar_Productos(Producto pe)
        {
            this.p = pe;
            InitializeComponent();
            CargarCombos();
            this.expiretx.MinDate = p.fecha_vencimiento;
            this.expiretx.Value = p.fecha_vencimiento;
            CargarDatosProducto();
        }

        private void CargarCombos()
        {
            // Cargar categorías
            ServicioCategoria servicioCategoria = new ServicioCategoria();
            List<Category> categorias = (List<Category>)servicioCategoria.Consultar();
            categorias.ForEach(categoria => this.categorytx.Items.Add(categoria));

            // Cargar proveedores
            ServicioProveedores servicioProveedores = new ServicioProveedores();
            List<Proveedor> proveedores = (List<Proveedor>)servicioProveedores.Consultar();
            proveedores.ForEach(proveedor => this.provetortx.Items.Add(proveedor));

            // Cargar marcas
            ServicioMarca servicioMarca = new ServicioMarca();
            List<Marca> marcas = (List<Marca>)servicioMarca.Consultar();
            marcas.ForEach(marca => this.signtx.Items.Add(marca));

            // Cargar ubicaciones
            ServicioUbicacion servicioUbicacion = new ServicioUbicacion();
            List<Ubicacion> ubicaciones = (List<Ubicacion>)servicioUbicacion.Consultar();
            ubicaciones.ForEach(ubicacion => this.locationtx.Items.Add(ubicacion));
        }

        private void CargarDatosProducto()
        {
            foreach (var item in this.categorytx.Items)
            {
                if (((Category)item).Id == p.categoria_id.Id)
                {
                    this.categorytx.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in this.provetortx.Items)
            {
                if (((Proveedor)item).Id == p.proveedor_id.Id)
                {
                    this.provetortx.SelectedItem = item;
                    break;
                }
            }

            this.nombretx.Text = p.nombre;
            this.descriptiontx.Text = p.descripcion;
            this.pricetx.Value = (decimal)p.precio;
            this.cuantitytx.Value = p.cantidad;
            this.barcodetx.Text = p.codigo_barra;
            this.signtx.Text = p.marca_id.ToString();
            this.locationtx.Text = p.ubicacion_id.ToString();
        }

        private bool ValidarNombre(string nombre)
        {
            // Validar que la primera letra sea mayúscula
            if (!char.IsUpper(nombre[0]))
            {
                return false;
            }

            // Validar que el nombre solo contenga letras
            foreach (char c in nombre)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarDescripcion(string descripcion)
        {
            // Validar que la descripción no contenga símbolos
            string pattern = @"^[a-zA-Z0-9\s]+$";
            return Regex.IsMatch(descripcion, pattern);
        }

        private bool ValidarCodigoBarras(string codigoBarras)
        {
            if (codigoBarras.Length != 13 || !codigoBarras.All(char.IsDigit))
            {
                return false;
            }

            int suma = 0;
            for (int i = 0; i < 12; i++)
            {
                int num = int.Parse(codigoBarras[i].ToString());
                suma += (i % 2 == 0) ? num : num * 3;
            }
            int digitoVerificador = (10 - (suma % 10)) % 10;
            return digitoVerificador == int.Parse(codigoBarras[12].ToString());
        }

        public bool ExisteCodigoBarrasEnUso(string codigoBarras)
        {
            // Lógica para verificar si el código de barras está en uso
            // por ejemplo, consultando la base de datos o alguna colección de productos
            // Retorna true si el código de barras está en uso, false si no está en uso.
            // Aquí un ejemplo básico para demostración:
            List<Producto> productos = ConsultarProductos(); // Método ficticio para obtener productos
            return productos.Any(p => p.codigo_barra == codigoBarras);
        }

        // Método ficticio para obtener productos (debes ajustarlo según tu implementación)
        private List<Producto> ConsultarProductos()
        {
            // Aquí simularías la consulta a tu base de datos o servicio
            // y devolverías una lista de productos
            return new List<Producto>();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetProducto();
                if (!string.IsNullOrEmpty(this.nombretx.Text) &&
                    !string.IsNullOrEmpty(this.descriptiontx.Text))
                {
                    if (!ValidarNombre(this.nombretx.Text))
                    {
                        MessageBox.Show("El nombre debe comenzar con una letra mayúscula y no debe contener números ni signos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!ValidarDescripcion(this.descriptiontx.Text))
                    {
                        MessageBox.Show("La descripción no debe contener símbolos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!ValidarCodigoBarras(this.barcodetx.Text))
                    {
                        MessageBox.Show("Código de barras no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ExisteCodigoBarrasEnUso(this.barcodetx.Text))
                    {
                        MessageBox.Show("Código de barras repetido. Por favor ingrese otro código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (this.p.Id == 0)
                        {
                            new ServicioProducto().Agregar(p);
                        }
                        else
                        {
                            new ServicioProducto().Modificar(p);
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos, por favor vuelva a ingresar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetProducto()
        {
            p.nombre = this.nombretx.Text;
            p.descripcion = this.descriptiontx.Text;
            p.categoria_id = (Category)categorytx.SelectedItem;
            p.precio = float.Parse(this.pricetx.Text);
            p.cantidad = Convert.ToInt16(this.cuantitytx.Text);
            p.proveedor_id = (Proveedor)provetortx.SelectedItem;
            p.codigo_barra = this.barcodetx.Text;
            p.fecha_vencimiento = this.expiretx.Value;
            p.marca_id = (Marca)this.signtx.SelectedItem;
            p.ubicacion_id = (Ubicacion)this.locationtx.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (p.Id == 0)
                {
                    this.expiretx.Value = DateTime.Now.AddMonths(5);
                    this.categorytx.SelectedIndex = 0;
                    this.provetortx.SelectedIndex = 0;
                    this.signtx.SelectedIndex = 0;
                    this.locationtx.SelectedIndex = 0;
                    this.nombretx.Text = "";
                    this.descriptiontx.Text = "";
                    this.pricetx.Value = 0.5m;
                    this.cuantitytx.Value = 1;
                    this.barcodetx.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nombretx_TextChanged(object sender, EventArgs e)
        {
            if (!ValidarNombre(this.nombretx.Text))
            {
                this.nombretx.BackColor = Color.LightCoral;
            }
            else
            {
                this.nombretx.BackColor = Color.White;
            }
        }

        private void descriptiontx_TextChanged(object sender, EventArgs e)
        {
            if (!ValidarDescripcion(this.descriptiontx.Text))
            {
                this.descriptiontx.BackColor = Color.LightCoral;
            }
            else
            {
                this.descriptiontx.BackColor = Color.White;
            }
        }
    }
}
