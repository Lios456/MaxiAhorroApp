using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            ServicioCategoria servicio = new ServicioCategoria();
            List<Category> categories = (List<Category>)servicio.Consultar();
            categories.ForEach(category => this.categorytx.Items.Add(category));
            List<Proveedor> proveedores = (List<Proveedor>)new ServicioProveedores().Consultar();
            proveedores.ForEach(proveedor => this.provetortx.Items.Add(proveedor));
            this.expiretx.MinDate = DateTime.Now.AddMonths(5);
            button2_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Se proporciona un producto al constructor del formulario
        /// se establece como fecha mínima en expiración 
        /// la expiración del producto enviado como parámetro
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public Agregar_Productos(Producto pe)
        {
            
            InitializeComponent();
            ServicioCategoria servicio = new ServicioCategoria();
            List<Category> categories = (List<Category>)servicio.Consultar();
            categories.ForEach(category => this.categorytx.Items.Add(category));
            this.expiretx.MinDate = pe.fecha_vencimiento;
            //button2_Click(this, EventArgs.Empty);
            this.p.Id = pe.Id;
            this.nombretx.Text = pe.nombre;
            this.descriptiontx.Text = pe.descripcion;
            this.categorytx.SelectedIndex = Convert.ToInt16(pe.categoria_id.Nombre) -1;
            this.pricetx.Text = pe.proveedor_id.ToString();
            this.cuantitytx.Text = pe.cantidad.ToString();
            this.provetortx.SelectedItem = pe.proveedor_id.Nombre;
            this.barcodetx.Text = pe.codigo_barra;
            this.expiretx.Value = pe.fecha_ingreso;
            //this.signtx.Text = pe.Sign;
            //this.locationtx.Text = pe.Location;

        }

        /// <summary>
        /// Registra el nuevo producto en la bdd
        /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.SetProducto();
                if (this.nombretx.Text != ""
                       && this.descriptiontx.Text != ""
                       && this.signtx.Text != ""
                       && this.locationtx.Text != "")
                {
                    if (this.barcodetx.Text == String.Empty)
                    {
                        MessageBox.Show("Código de barras no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            this.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Datos incorrectos, por favor vuelva a ingresar");
                }
                
                
                
            }catch (Exception ex)
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
            p.fecha_ingreso = this.expiretx.Value;
            p.marca_id = Convert.ToInt16(this.signtx.Text);
            p.ubicacion_id = Convert.ToInt16(this.locationtx.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nombretx.Text = "";
            this.descriptiontx.Text = "";
            this.categorytx.SelectedIndex = 0;
            this.pricetx.Value = 0.5m;
            this.cuantitytx.Value = 1;
            this.provetortx.SelectedIndex = 0;
            this.barcodetx.Text = "";
            this.expiretx.Value = DateTime.Now.AddMonths(5);
            this.signtx.Text = "";
            this.locationtx.Text = "";

        }
    }
}
