using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class DatosCli
    {
        public int NumFactura { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public float TotalPagar { get; set; }

        // Relación con los productos comprados (detalles de factura)
        public List<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();
        public string detallestring { get; set; }

        public DatosCli() {
            NumFactura = 0;
            NombreCliente = "Juanito";
            ApellidoCliente = "Pérez";
            CedulaCliente = "0504760075";
            DireccionCliente = "Latacunga";
            TelefonoCliente = "0978700978";
            FormaPago = "Efectivo";
            FechaPago = DateTime.Now;
            TotalPagar = 0;
            detallestring = obtenerdetalles();
        }
        public DatosCli(int numFactura, string nombreCliente, string apellidoCliente, string cedulaCliente, string direccionCliente, string telefonoCliente, string formaPago, DateTime fechaPago, float totalPagar, List<DetalleFactura> detallesFactura)
        {
            NumFactura = numFactura;
            NombreCliente = nombreCliente;
            ApellidoCliente = apellidoCliente;
            CedulaCliente = cedulaCliente;
            DireccionCliente = direccionCliente;
            TelefonoCliente = telefonoCliente;
            FormaPago = formaPago;
            FechaPago = fechaPago;
            TotalPagar = totalPagar;
            DetallesFactura = detallesFactura;
        }

        public string obtenerdetalles()
        {
            string head = string.Format("{0,10}|{1,-50}|{2,-20}|{3,-20}|{4,-20}",
                         formatear("Id", 10),
                         formatear("Nombre", 50),
                         formatear("Cantidad", 20),
                         formatear("Precio c/u".ToString(), 20),
                         formatear("Subtotal", 20));
            string separator = new string('-', head.Length);
            string det = "";

            if (DetallesFactura.Count > 0)
            {
                foreach (DetalleFactura item in DetallesFactura)
                {
                    det += $"\n{item.ToString()}";
                }
            }

            return head + $"\n" + separator + det;
        }

        public string formatear(string cadena, int largo)
        {
            string cadenaformateada = cadena;
            while (cadenaformateada.Length < largo)
            {
                cadenaformateada += " ";
            }
            return cadenaformateada;
        }
    }



    public class DetalleFactura
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float Subtotal => Cantidad * PrecioUnitario;

        public override string ToString()
        {
            
            return string.Format("{0,10}|{1,-50}|{2,-20}|{3,-20}|{4,-20}",
                         formatear(this.ProductoId.ToString(),10), 
                         formatear(this.NombreProducto,50),
                         formatear(this.Cantidad.ToString(),20),
                         formatear(this.PrecioUnitario.ToString(),20),
                         formatear(this.Subtotal.ToString(),20));
        }

        public string formatear(string cadena, int largo)
        {
            string cadenaformateada = cadena;
            while (cadenaformateada.Length < largo)
            {
                cadenaformateada += " ";
            }
            return cadenaformateada;
        }
    }
}
