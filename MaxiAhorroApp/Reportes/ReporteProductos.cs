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

        private static String cns = "server=localhost;user=root;password=root;database=minimarket";
        protected MySqlConnection cn = new MySqlConnection(cns);

        public ReporteProductos()
        {
            InitializeComponent();
            try
            {

                this.productosreport.Load("Report.mrt");
                cn.Open();
                this.productosreport.RegData("Productos", new ServicioProducto().Consultar());
                cn.Close();
                this.viewer.Report = productosreport;
                //productosreport.Render();
                productosreport.Show();
                //this.viewer.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


    }
}
