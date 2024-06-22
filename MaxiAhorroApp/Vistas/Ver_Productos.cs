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
        }
    }
}
