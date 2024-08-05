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
using static Stimulsoft.Base.Dashboard.StiElementConsts.Table;

namespace MaxiAhorroApp.Vistas
{
    public partial class Venta : Form
    {
        private BindingList<Producto> productos = new BindingList<Producto>();
        private decimal Totalfactura = 0;
        public Venta()
        {
            InitializeComponent();
            tbproductos.AutoGenerateColumns = false;
            this.productos_agregados.AutoGenerateColumns = false;
            this.tbproductos.DataSource = new ServicioProducto().Consultar();
            this.productos_agregados.DataSource = productos;
        }

        private void bt_agregar_producto_Click(object sender, EventArgs e)
        {
            List<Producto> productosParaEliminar = new List<Producto>();

            foreach (DataGridViewRow fila in tbproductos.Rows)
            {
                var select = fila.Cells[0] as DataGridViewCheckBoxCell;
                if (select != null && select.Value != null)
                {
                    Producto produ = fila.DataBoundItem as Producto;

                    if (produ != null)
                    {
                        bool seleccionado = (bool)select.Value;
                        bool existe = productos.Any(p => p.Id == produ.Id);

                        if (seleccionado)
                        {
                            if (!existe)
                            {
                                productos.Add(produ);
                                // Refrescar precios y total en los productos agregados

                                foreach (DataGridViewRow f in productos_agregados.Rows)
                                {
                                    if ((int)f.Cells[0].Value == produ.Id)
                                    {
                                        f.Cells[2].Value = this.cantidad.Value;
                                        f.Cells[4].Value = this.cantidad.Value * (decimal)produ.precio;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (existe)
                            {
                                productosParaEliminar.Add(produ);
                            }
                        }
                    }
                }
            }

            foreach (var prod in productosParaEliminar)
            {
                productos.Remove(prod);
            }

            

            if (productosParaEliminar.Count > 0)
            {
                string mensaje = "Los siguientes productos fueron eliminados:\n" + string.Join(", ", productosParaEliminar.Select(p => p.nombre));
                MessageBox.Show(mensaje);
            }

            


            this.productos_agregados.Refresh();
        }

    }
}
