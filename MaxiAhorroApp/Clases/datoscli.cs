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
