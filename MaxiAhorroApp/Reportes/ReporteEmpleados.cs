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

namespace MaxiAhorroApp.Reportes
{
    public partial class ReporteEmpleados : Form
    {
        public ReporteEmpleados()
        {


            InitializeComponent();

            try
            {

                this.empleadosreport.Load("empleadosreport.mrt");
                this.viewer.Report = empleadosreport;

                empleadosreport.Render();
                //productosreport.Show();
                this.viewer.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
