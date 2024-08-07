using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    internal class datoscli
    {
        public int idcliente { get; set; }
        public int numfactura { get; set; }
        public string nombrecliente { get; set; }
        public string cedulacliente { get; set; }  
        public string direccioncliente { get; set; }
        public string telefonocliente { get; set; }
        public string formapago { get; set; }
        public DateTime fechapago { get; set; }
    }
}
