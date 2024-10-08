﻿using Dapper;
using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using Stimulsoft.Data.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stimulsoft.Base.Dashboard.StiElementConsts.Table;

namespace MaxiAhorroApp.Vistas
{
    public partial class Venta : Form
    {
        private BindingList<Producto> productos = new BindingList<Producto>();
        private Connection con = new Connection();
        public Venta()
        {
            InitializeComponent();            
            tbproductos.AutoGenerateColumns = false;
            this.productos_agregados.AutoGenerateColumns = false;
            this.tbproductos.DataSource = new ServicioProducto().Consultar();
            this.productos_agregados.DataSource = productos;
            this.tipopago.SelectedIndex = 0;
            this.numfactu.Text = (con.cn.Query<int>("SELECT COALESCE((SELECT max(id) from facturas),0)").FirstOrDefault() + 1).ToString();
            this.nomcli.Text = "Consumidor";
            apelcli.Text = "Final";
            cedcli.Text = "9999999999";
            dircli.Text = "Ecuador";
            telcli.Text = "0999999999";
            totalpag.Text = "0";
        }

        private void bt_agregar_producto_Click(object sender, EventArgs e)
        {
            List<Producto> productosParaEliminar = new List<Producto>();
            decimal total = 0;
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

                                foreach (DataGridViewRow f in productos_agregados.Rows)
                                {
                                    if ((int)f.Cells[0].Value == produ.Id)
                                    {
                                        f.Cells[2].Value = this.cantidad.Value;
                                        f.Cells[4].Value = this.cantidad.Value * (decimal)produ.precio;
                                        total += this.cantidad.Value * (decimal)produ.precio;
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
            this.totalpag.Text = total.ToString();
        }

        private void numfactura_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = numfactu.SelectionStart;
            string filteredText = new string(numfactu.Text.Where(char.IsDigit).ToArray());

            if (filteredText.Length > 10)
            {
                filteredText = filteredText.Substring(0, 10);
            }

            numfactu.Text = filteredText;
            numfactu.SelectionStart = Math.Min(cursorPosition, numfactu.Text.Length);
        }

        private void cedcli_TextChanged(object sender, EventArgs e)
        {
            string cedula = cedcli.Text;

            // Filtrar para obtener solo dígitos y asegurar que la cédula tenga exactamente 10 dígitos
            string filteredCedula = new string(cedula.Where(char.IsDigit).ToArray());

            if (filteredCedula.Length == 10)
            {
                if (EsCedulaEcuatorianaValida(filteredCedula))
                {
                    // Cédula válida, completar los datos
                    ventascliente controlador = new ventascliente();
                    MessageBox.Show("Cédula correcta.");
                }
                else
                {
                    MessageBox.Show("Cédula ecuatoriana inválida. Verifique e intente nuevamente.");
                }
            }            

            // Actualizar el texto de la cédula
            cedcli.Text = filteredCedula;

        }

        private bool EsCedulaEcuatorianaValida(string cedula)
        {
            if(cedula != "9999999999")
            {
                int total = 0;
                int tamanoLongitudCedula = 10;
                int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
                int provincia = int.Parse(cedula.Substring(0, 2));
                int tercerDigito = int.Parse(cedula.Substring(2, 1));

                if (provincia < 1 || provincia > 24)
                {
                    return false;
                }

                if (tercerDigito >= 6)
                {
                    return false;
                }

                for (int i = 0; i < coeficientes.Length; i++)
                {
                    int valor = coeficientes[i] * int.Parse(cedula[i].ToString());
                    total += valor > 9 ? valor - 9 : valor;
                }

                int digitoVerificador = (total % 10) == 0 ? 0 : 10 - (total % 10);
                return digitoVerificador == int.Parse(cedula[9].ToString());
            }
            else if(cedula == "9999999999")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void telcli_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = telcli.SelectionStart;
            string filteredText = new string(telcli.Text.Where(char.IsDigit).ToArray());

            if (filteredText.Length > 10)
            {
                filteredText = filteredText.Substring(0, 10);
            }

            telcli.Text = filteredText;
            telcli.SelectionStart = Math.Min(cursorPosition, telcli.Text.Length);
        }

        private void nomcli_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = nomcli.SelectionStart;

            string filteredText = new string(nomcli.Text
                .Where(c => char.IsLetter(c) || c == ' ')
                .ToArray());

            if (filteredText.Length > 15)
            {
                filteredText = filteredText.Substring(0, 15);
            }

            filteredText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filteredText.ToLower());
            nomcli.Text = filteredText;
            nomcli.SelectionStart = Math.Min(cursorPosition, nomcli.Text.Length);
        }

        private void dircli_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = dircli.SelectionStart;

            string filteredText = new string(dircli.Text
                .Where(c => char.IsLetterOrDigit(c) || c == ' ' || c == '.' || c == '#' || c == '-' || c == ',')
                .ToArray());

            filteredText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filteredText.ToLower());
            dircli.Text = filteredText;
            dircli.SelectionStart = Math.Min(cursorPosition, dircli.Text.Length);
        }

        private bool validarsololetras(string texto)
        {
            string pattern = @"^[A-Z][a-z]+$";
            bool isValid = false;
            isValid = Regex.IsMatch(texto, pattern);
            return isValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (validarsololetras(nomcli.Text) && 
                    validarsololetras(apelcli.Text) && 
                    cedcli.Text.Length == 10 && 
                    telcli.Text.Length == 10 
                    )
                {
                    DatosCli DatosCli = new DatosCli();
                    DatosCli.NumFactura = Convert.ToInt32(numfactu.Text);
                    DatosCli.NombreCliente = nomcli.Text;
                    DatosCli.ApellidoCliente = apelcli.Text;
                    DatosCli.CedulaCliente = cedcli.Text;
                    DatosCli.DireccionCliente = dircli.Text;
                    DatosCli.TelefonoCliente = telcli.Text;
                    DatosCli.FormaPago = tipopago.Text;
                    DatosCli.FechaPago = DateTime.Now;
                    float total = 0;

                    foreach (DataGridViewRow fila in productos_agregados.Rows)
                    {
                        DetalleFactura det = new DetalleFactura();
                        det.ProductoId = (int)fila.Cells[0].Value;
                        det.NombreProducto = fila.Cells[1].Value.ToString();
                        det.Cantidad = (int)Convert.ToInt64(fila.Cells[2].Value);
                        det.PrecioUnitario = (float)fila.Cells[3].Value;
                        total += det.PrecioUnitario * (float)det.Cantidad;
                        DatosCli.DetallesFactura.Add(det);
                        Console.WriteLine(det);
                    }
                    DatosCli.TotalPagar = (float)Math.Round(total, 2);
                    DatosCli.detallestring = DatosCli.obtenerdetalles();

                    // Llamada al método para insertar la venta
                    new facturavista(DatosCli).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Datos no válidos, por favor, revíselos","Error", MessageBoxButtons.OK);
                }

                

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void totalpag_TextChanged(object sender, EventArgs e)
        {
            //NO BORRAR, ES IMPORTANTE.
        }
        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            numfactu.Clear();
            nomcli.Clear();
            cedcli.Clear();
            dircli.Clear();
            telcli.Clear();
            totalpag.Clear();
            productos.Clear();
            productos_agregados.DataSource = null;
            productos_agregados.DataSource = productos;

            cantidad.Value = 1;
            tipopago.SelectedIndex = -1;

        }

        private void apelcli_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = apelcli.SelectionStart;

            string filteredText = new string(apelcli.Text
                .Where(c => char.IsLetter(c) || c == ' ')
                .ToArray());

            if (filteredText.Length > 15)
            {
                filteredText = filteredText.Substring(0, 15);
            }

            filteredText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filteredText.ToLower());
            apelcli.Text = filteredText;
            apelcli.SelectionStart = Math.Min(cursorPosition, apelcli.Text.Length);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = @"
            SELECT 
                p.Id, p.nombre, p.descripcion, p.precio, p.cantidad, p.fecha_ingreso, 
                p.codigo_barra, p.fecha_vencimiento,
                c.Id as Id, c.Nombre as Nombre,
                pr.Id as Id, pr.Nombre as Nombre,
                m.Id as Id, m.Nombre as Nombre,
                u.Id as Id, u.Nombre as Nombre
            FROM minimarket.productos p
            INNER JOIN minimarket.categorias c ON p.categoria_id = c.Id
            INNER JOIN minimarket.proveedores pr ON p.proveedor_id = pr.Id
            INNER JOIN minimarket.marcas m ON p.marca_id = m.Id
            INNER JOIN minimarket.ubicaciones u ON p.ubicacion_id = u.Id
            WHERE estado = 'Activo'" + $"AND p.nombre LIKE '{productobusqueda.Text}%';";

                tbproductos.DataSource = new Connection().cn.Query<Producto, Category, Proveedor, Marca, Ubicacion, Producto>(sql,
                    (producto, categoria, proveedor, marca, ubicacion) =>
                    {
                        producto.categoria_id = categoria;
                        producto.proveedor_id = proveedor;
                        producto.marca_id = marca;
                        producto.ubicacion_id = ubicacion;
                        return producto;
                    },
                    splitOn: "Id,Id,Id,Id"
                    );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }
    }
}