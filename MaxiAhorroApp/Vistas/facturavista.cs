﻿using MaxiAhorroApp.Clases;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System;
using System.Windows.Forms;

namespace MaxiAhorroApp.Vistas
{
    public partial class facturavista : Form
    {
        public DatosCli datosfactura = new DatosCli();

        public facturavista()
        {
            InitializeComponent();

            try
            {
                this.factura_Ttal.RegReportDataSources();
                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "factura.mrt");

                if (System.IO.File.Exists(reportPath))
                {
                    this.factura_Ttal.Load(reportPath);
                    this.vista.Report = this.factura_Ttal;
                    factura_Ttal.RegData("datosfactura", "Table1", datosfactura);
                    this.factura_Ttal.Render();
                    this.vista.Refresh();
                }
                else
                {
                    MessageBox.Show("El archivo no se encuentra en la ruta: " + reportPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        public facturavista(DatosCli datos)
        {
            InitializeComponent();
            this.datosfactura = datos;

            try
            {
                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "factura.mrt");

                if (System.IO.File.Exists(reportPath))
                {
                    this.factura_Ttal.Load(reportPath);
                    this.vista.Report = this.factura_Ttal;
                    factura_Ttal.RegData("datosfactura", "Table1", datosfactura);
                    this.factura_Ttal.Render();
                    this.vista.Refresh();
                }
                else
                {
                    MessageBox.Show("El archivo no se encuentra en la ruta: " + reportPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        private void facturavista_Load(object sender, EventArgs e)
        {
            // Lógica adicional si es necesario
        }
    }

}
