using MySql.Data.MySqlClient;
using Stimulsoft.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiAhorroApp.Clases;
using Dapper;
using Stimulsoft.Report;
using Stimulsoft.Report.Components.Table;
using MaxiAhorroApp.Controladores;

namespace MaxiAhorroApp.Reportes
{
    public partial class ReporteProductos : Form
    {

        public ReporteProductos()
        {
            InitializeComponent();
            try
            {

                this.productosreport.Load("productosreport.mrt");
                this.viewer.Report = productosreport;

                productosreport.Render();
                //productosreport.Show();
                this.viewer.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
