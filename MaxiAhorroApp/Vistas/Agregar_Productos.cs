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
            List<Marca> marcas = (List<Marca>)new ServicioMarca().Consultar();
            marcas.ForEach(marca => this.signtx.Items.Add(marca));
            List<Ubicacion> ubicaciones = (List<Ubicacion>)new ServicioUbicacion().Consultar();
            ubicaciones.ForEach(ubicacion => this.locationtx.Items.Add(ubicacion));
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
            this.p = pe;
            InitializeComponent();
            ServicioCategoria servicio = new ServicioCategoria();
            List<Category> categories = (List<Category>)servicio.Consultar();
            categories.ForEach(category => this.categorytx.Items.Add(category));
            List<Proveedor> proveedores = (List<Proveedor>)new ServicioProveedores().Consultar();
            proveedores.ForEach(proveedor => this.provetortx.Items.Add(proveedor));
            List<Marca> marcas = (List<Marca>)new ServicioMarca().Consultar();
            marcas.ForEach(marca => this.signtx.Items.Add(marca));
            List<Ubicacion> ubicaciones = (List<Ubicacion>)new ServicioUbicacion().Consultar();
            ubicaciones.ForEach(ubicacion => this.locationtx.Items.Add(ubicacion));
            this.expiretx.MinDate = p.fecha_vencimiento;
            this.expiretx.Value = p.fecha_vencimiento;
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
            //button2_Click(this, EventArgs.Empty);

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
                       && this.descriptiontx.Text != "")
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
            finally
            {
                this.Close();
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
                    this.signtx.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
