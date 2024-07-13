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
    public partial class Ver_Productos : Form
    {
        private Producto p = new Producto();
        public Ver_Productos()
        {
            InitializeComponent();
            productostb.AutoGenerateColumns = false;
            button4_Click(this, new EventArgs());
        }

        /*
         OBTENER LOS DATOS DE LOS ATRIBUTOS DE PRODUCTO QUE SON UNA CLASE
         private void productostb_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (productostb.Columns[e.ColumnIndex].Name == "prov_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.proveedor_id != null)
                {
                    e.Value = producto.proveedor_id.Name;
                }
            }
            if (productostb.Columns[e.ColumnIndex].Name == "cat_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.categoria_id != null)
                {
                    e.Value = producto.categoria_id.Nombre;
                }
            }
            if (productostb.Columns[e.ColumnIndex].Name == "datein_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.categoria_id != null)
                {
                    e.Value = producto.fecha_ingreso.ToString();
                }
            }
        }
         */



        private void button1_Click(object sender, EventArgs e)
        {
            /*--------------------Agregar un nuevo producto------------------------*/
            button1.Enabled = false;
            new Agregar_Productos().ShowDialog();
            productostb.DataSource = new ServicioProducto().Consultar();
            button1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*--------------------Consulta de Todos los productos------------------------*/
            productostb.DataSource = new ServicioProducto().Consultar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*--------------------Eliminar productos------------------------*/

            if(p.Id!=0){
                if (MessageBox.Show($"¿De verdad quiere eliminar el producto?\n{p.nombre}", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new ServicioProducto().Eliminar(p);
                    button4_Click(sender, e);
                    p.Id = 0;
                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*--------------------Actualizar productos------------------------*/
            if(p.Id != 0) 
            {
                p = new ServicioProducto().ConsultarPorId(p);
                button3.Enabled = false;
                new Agregar_Productos(p).Show();
                button3.Enabled = true;
                button4_Click(sender, e);
            }
        }

        private void productostb_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*--------------------Seleccionar un producto------------------------*/
            try
            {
                var fila = e.RowIndex;
                p.Id = Convert.ToInt16(productostb.Rows[fila].Cells[0].Value);
            }catch(Exception) {
                
            }

        }

        private void tx_buscar_TextChanged(object sender, EventArgs e)
        {
            productostb.DataSource = new ServicioProducto().Consultar(this.tx_buscar.Text);
        }
    }
}
