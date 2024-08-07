using Stimulsoft.Report;
using System;
using System.Windows.Forms;

namespace MaxiAhorroApp.Vistas
{
    public partial class facturavista : Form
    {
        public facturavista()
        {
            InitializeComponent();

            try
            {
                // Combinar el directorio base con la ruta del archivo
                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "factura.mrt");

                // Verificar si el archivo existe en la ruta especificada
                if (System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("Archivo encontrado: " + reportPath);

                    // Cargar el archivo del reporte
                    this.factura_Ttal.Load(reportPath);

                    // Asignar el reporte al control de visualización
                    this.vista.Report = this.factura_Ttal;

                    // Renderizar y actualizar el reporte
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
                // Mostrar cualquier excepción que ocurra
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        // Asegúrate de que este método tiene la firma correcta para el evento Load
        private void facturavista_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica adicional aquí si es necesario
        }
    }
}
