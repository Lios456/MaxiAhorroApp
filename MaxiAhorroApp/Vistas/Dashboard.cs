using MaxiAhorroApp.Controladores;
using MaxiAhorroApp.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MaxiAhorroApp.Vistas
{
    public partial class Dashboard : Form
    {
        private Connection con = new Connection();
        public Dashboard()
        {
            InitializeComponent();
            var datos = new ServicioReporte().Consultar();
            foreach (var item in datos)
            {
                total_pc.Series.Add(item.Label);
                total_pc.Series[item.Label].SetCustomProperty("PixelPointWidth", "100");
                total_pc.Series[item.Label].Points.AddXY(item.X, item.Y);
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Agregar_Productos().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Agregar_Empleado().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ReporteProductos().ShowDialog();
        }
    }

}
