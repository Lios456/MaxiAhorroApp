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

        public DatosCli() {
            NumFactura = 0;
            NombreCliente = "Juanito";
            ApellidoCliente = "Pérez";
            CedulaCliente = "0504760075";
            DireccionCliente = "Latacunga";
            TelefonoCliente = "0978700978";
            FormaPago = "Efectivo";
            FechaPago = DateTime.Now;
            TotalPagar = 150;
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
    }



    public class DetalleFactura
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float Subtotal => Cantidad * PrecioUnitario;
    }
}
