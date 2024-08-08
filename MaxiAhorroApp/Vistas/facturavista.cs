using Dapper;
using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
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
                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "factura.mrt");

                if (System.IO.File.Exists(reportPath))
                {
                    this.factura_Ttal.Load(reportPath);
                    this.vista.Report = this.factura_Ttal;
                    factura_Ttal.RegData("datosfactura", datosfactura);
                    this.factura_Ttal.Dictionary.Synchronize();
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
                    factura_Ttal.RegData("datosfactura", datosfactura);
                    this.factura_Ttal.Dictionary.Synchronize();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ingresar factura a la base de datos

            ///
            /// USAR datosfactura
            ///
            Connection connection = new Connection();
            try
            {
                
                connection.cn.Execute("sp_insertar_factura", new
                {
                    NumFactura = datosfactura.NumFactura,
                    NombreCliente = datosfactura.NombreCliente,
                    ApellidoCliente = datosfactura.ApellidoCliente,
                    CedulaCliente = datosfactura.CedulaCliente,
                    DireccionCliente = datosfactura.DireccionCliente,
                    TelefonoCliente = datosfactura.TelefonoCliente,
                    TotalPagar = datosfactura.TotalPagar,
                    FormaPago = datosfactura.FormaPago,
                    FechaPago = datosfactura.FechaPago,
                }, commandType: System.Data.CommandType.StoredProcedure);

                foreach (DetalleFactura item in datosfactura.DetallesFactura)
                {
                    connection.cn.Execute("sp_agregar_detalles", new
                    {
                        NumFactura = datosfactura.NumFactura,
                        ProductoId = item.ProductoId,
                        NombreProducto = item.NombreProducto,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.PrecioUnitario,
                        Subtotal = item.Subtotal,
                    }, commandType: System.Data.CommandType.StoredProcedure);
                }
                MessageBox.Show("Registro existoso de la factura","Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.cn.Close();
            }
            
        }
    }

}
