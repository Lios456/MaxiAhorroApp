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
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stimulsoft.Base.Dashboard.StiElementConsts.Table;

namespace MaxiAhorroApp.Vistas
{
    public partial class Venta : Form
    {
        private BindingList<Producto> productos = new BindingList<Producto>();
        private decimal Totalfactura = 0;
        public Venta()
        {
            InitializeComponent();
            tbproductos.AutoGenerateColumns = false;
            this.productos_agregados.AutoGenerateColumns = false;
            this.tbproductos.DataSource = new ServicioProducto().Consultar();
            this.productos_agregados.DataSource = productos;
        }

        private void bt_agregar_producto_Click(object sender, EventArgs e)
        {
            List<Producto> productosParaEliminar = new List<Producto>();

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
                                // Refrescar precios y total en los productos agregados

                                foreach (DataGridViewRow f in productos_agregados.Rows)
                                {
                                    if ((int)f.Cells[0].Value == produ.Id)
                                    {
                                        f.Cells[2].Value = this.cantidad.Value;
                                        f.Cells[4].Value = this.cantidad.Value * (decimal)produ.precio;
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
        }

        private void numfactura_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = numfactu.SelectionStart;

            // Filtrar el texto para que solo contenga caracteres numéricos
            string filteredText = new string(numfactu.Text.Where(char.IsDigit).ToArray());

            // Limitar el texto a un máximo de 10 dígitos (o ajusta según sea necesario)
            if (filteredText.Length > 10)
            {
                filteredText = filteredText.Substring(0, 10);
            }

            // Asignar el texto filtrado de nuevo al TextBox
            numfactu.Text = filteredText;

            // Restaurar la posición del cursor
            numfactu.SelectionStart = Math.Min(cursorPosition, numfactu.Text.Length);
        }

        private void cedcli_TextChanged(object sender, EventArgs e)
        {
            // Validación del campo de cédula como lo hiciste antes
            int cursorPosition = cedcli.SelectionStart;
            string filteredText = new string(cedcli.Text.Where(char.IsDigit).ToArray());

            if (filteredText.Length > 10)
            {
                filteredText = filteredText.Substring(0, 10);
                // Validar si existe

            }

            cedcli.Text = filteredText;
            cedcli.SelectionStart = Math.Min(cursorPosition, cedcli.Text.Length);

            // Verificación de la longitud de la cédula
            if (filteredText.Length == 10)
            {
                if (EsCedulaEcuatorianaValida(filteredText))
                {
                    // Obtener los datos del cliente
                    ventascliente controlador = new ventascliente();
                    datoscli datos = controlador.completarporcedula(filteredText);

                    if (datos != null)
                    {
                        // Completar los campos en el formulario y hacerlos ReadOnly
                        nomcli.Text = datos.nombrecliente;
                        nomcli.ReadOnly = true;

                        dircli.Text = datos.direccioncliente;
                        dircli.ReadOnly = true;

                        telcli.Text = datos.telefonocliente;
                        telcli.ReadOnly = true;
                    }
                    else
                    {
                        // Si no se encuentran datos, puedes dejar los campos editables
                        nomcli.ReadOnly = false;
                        dircli.ReadOnly = false;
                        telcli.ReadOnly = false;
                    }
                }
                else
                {
                    MessageBox.Show("Cédula ecuatoriana inválida. Verifique e intente nuevamente.");
                }
            }
            else
            {
                // Si la cédula no tiene 10 dígitos, los campos deben ser editables
                nomcli.ReadOnly = false;
                dircli.ReadOnly = false;
                telcli.ReadOnly = false;

                // Limpiar los campos si el usuario borra la cédula parcial
                nomcli.Clear();
                dircli.Clear();
                telcli.Clear();
            }


        }

        private bool EsCedulaEcuatorianaValida(string cedula)
        {
            int total = 0;
            int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int provincia = int.Parse(cedula.Substring(0, 2));
            int tercerDigito = int.Parse(cedula.Substring(2, 1));

            // Verificar si la provincia está entre 01 y 24
            if (provincia < 1 || provincia > 24)
            {
                return false;
            }

            // El tercer dígito debe ser menor a 6 para personas naturales
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

            // El último dígito de la cédula debe coincidir con el dígito verificador
            return digitoVerificador == int.Parse(cedula[9].ToString());
        }


        private void telcli_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = telcli.SelectionStart;

            // Filtrar el texto para que solo contenga caracteres numéricos
            string filteredText = new string(telcli.Text.Where(char.IsDigit).ToArray());

            // Limitar el texto a un máximo de 10 dígitos
            if (filteredText.Length > 10)
            {
                filteredText = filteredText.Substring(0, 10);
            }

            // Asignar el texto filtrado de nuevo al TextBox
            telcli.Text = filteredText;

            // Restaurar la posición del cursor
            telcli.SelectionStart = Math.Min(cursorPosition, telcli.Text.Length);
        }

        private void nomcli_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = nomcli.SelectionStart;

            // Filtrar el texto para permitir solo letras (incluyendo tildes y "ñ") y espacios
            string filteredText = new string(nomcli.Text
                .Where(c => char.IsLetter(c) || c == ' ')
                .ToArray());

            // Limitar el texto a un máximo de 31 caracteres (15 para nombre + 1 espacio + 15 para apellido)
            if (filteredText.Length > 31)
            {
                filteredText = filteredText.Substring(0, 31);
            }

            // Convertir las primeras letras de cada palabra a mayúsculas
            filteredText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filteredText.ToLower());

            // Asignar el texto filtrado de nuevo al TextBox
            nomcli.Text = filteredText;

            // Restaurar la posición del cursor
            nomcli.SelectionStart = Math.Min(cursorPosition, nomcli.Text.Length);
        }

        private void dircli_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = dircli.SelectionStart;

            // Filtrar el texto para permitir letras, números, espacios y ciertos caracteres especiales
            string filteredText = new string(dircli.Text
                .Where(c => char.IsLetterOrDigit(c) || c == ' ' || c == '.' || c == '#' || c == '-' || c == ',')
                .ToArray());

            // Convertir las primeras letras de cada palabra a mayúsculas
            filteredText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filteredText.ToLower());

            // Asignar el texto filtrado de nuevo al TextBox
            dircli.Text = filteredText;

            // Restaurar la posición del cursor
            dircli.SelectionStart = Math.Min(cursorPosition, dircli.Text.Length);
        }

        private void totalpagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                datoscli datoscli = new datoscli();
                datoscli.numfactura = Convert.ToInt32(numfactu.Text);
                datoscli.nombrecliente = nomcli.Text;
                datoscli.cedulacliente = cedcli.Text;
                datoscli.direccioncliente = dircli.Text;
                datoscli.telefonocliente = telcli.Text;
                datoscli.totalpagar = Convert.ToInt32(totalpag.Text.Length);
                datoscli.formapago = tipopago.Text;

                new ventascliente().insertarventa(datoscli);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            // Limpiar los TextBox
            numfactu.Clear();
            nomcli.Clear();
            cedcli.Clear();
            dircli.Clear();
            telcli.Clear();
            totalpag.Clear(); // Si totalpag es un TextBox, se debe limpiar

            // Reiniciar el DataGridView
            productos.Clear(); // Limpiar la lista de productos
            productos_agregados.DataSource = null; // Reiniciar el DataSource
            productos_agregados.DataSource = productos; // Volver a enlazar la lista vacía

            // Restablecer el estado de los controles de cantidad y tipo de pago
            cantidad.Value = 1; // Asumiendo que 'cantidad' es un NumericUpDown, ajusta según corresponda
            tipopago.SelectedIndex = -1; // Si 'tipopago' es un ComboBox, reiniciar la selección

            // Opcional: Reiniciar el estado de otras variables si es necesario
            Totalfactura = 0; // Restablecer el total de la factura si es necesario
        }
    }
}
