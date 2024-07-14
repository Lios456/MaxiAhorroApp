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
        public ver_Empleados()
        {
            InitializeComponent();
            //this.TopLevel = false;
            this.WindowState = FormWindowState.Maximized;
            this.gridview_empleados.DataSource = new ServicioEmpleado().Consultar();
        }
    }
}
