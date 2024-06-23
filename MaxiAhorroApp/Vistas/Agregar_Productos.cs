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
        private Producto p = new Producto();
        public Agregar_Productos()
        {
            InitializeComponent();
            this.expiretx.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.SetProducto();
                new ServicioProducto().Agregar(p);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SetProducto()
        {
            p.Name = this.nombretx.Text;
            p.Description = this.descriptiontx.Text;
            p.Cat = new Category { Name = this.categorytx.SelectedItem.ToString() };
            p.Price = float.Parse(this.pricetx.Text);
            p.Cuantity = Convert.ToInt16(this.cuantitytx.Text);
            p.Prov = new Proveedor { Name = this.provetortx.SelectedItem.ToString() };
            p.Barcode = this.barcodetx.Text;
            p.Dateex = this.expiretx.Value;
            p.Sign = this.signtx.Text;
            p.Location = this.locationtx.Text;
        }
    }
}
