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
    public partial class ver_Empleados : Form
    {
        private Empleado empleadoseleccionado = new Empleado();
        public ver_Empleados()
        {
            InitializeComponent();
            //this.TopLevel = false;
            this.WindowState = FormWindowState.Maximized;
            this.gridview_empleados.AutoGenerateColumns = false;
            button4_Click(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Agregar_Empleado().ShowDialog();
            button4_Click(this, EventArgs.Empty);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.gridview_empleados.DataSource = new ServicioEmpleado().Consultar();
        }

        private void gridview_empleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = e.RowIndex;
            this.empleadoseleccionado = (Empleado)gridview_empleados.Rows[fila].DataBoundItem;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Agregar_Empleado(empleadoseleccionado).ShowDialog();
            button4_Click(this, EventArgs.Empty);
        }
    }
}
