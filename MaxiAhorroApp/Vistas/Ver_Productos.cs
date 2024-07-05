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
            productostb.DataSource = new ServicioProducto().Consultar();
        }

        /*
         OBTENER LOS DATOS DE LOS ATRIBUTOS DE PRODCUTO QUE SON UNA CLASE
         */

        private void productostb_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (productostb.Columns[e.ColumnIndex].Name == "prov_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.Prov != null)
                {
                    e.Value = producto.Prov.Name;
                }
            }
            if (productostb.Columns[e.ColumnIndex].Name == "cat_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.Cat != null)
                {
                    e.Value = producto.Cat.Name;
                }
            }
            if (productostb.Columns[e.ColumnIndex].Name == "datein_cl")
            {
                var producto = productostb.Rows[e.RowIndex].DataBoundItem as Producto;
                if (producto != null && producto.Cat != null)
                {
                    e.Value = producto.Datein.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*--------------------Agregar un nuevo producto------------------------*/
            button1.Enabled = false;
            new Agregar_Productos().ShowDialog();
            button4_Click(sender, e);
            button1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*--------------------Consulta de Todos los productos------------------------*/
            productostb.DataSource = new ServicioProducto().Consultar();
        }

        private void productostb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*--------------------Seleccionar un producto------------------------*/
            var fila = e.RowIndex;
            p.Id = Convert.ToInt16(productostb.Rows[fila].Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*--------------------Eliminar productos------------------------*/
            if (MessageBox.Show("¿De verdad quiere eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new ServicioProducto().Eliminar(p);
                button4_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*--------------------Actualizar productos------------------------*/
            if(p.Id != 0) 
            {
                p = new ServicioProducto().ConsultarPorId(p.Id);
                button3.Enabled = false;
                new Agregar_Productos(p).ShowDialog();
                button3.Enabled = true;
                button4_Click(sender, e);
            }
        }
    }
}
