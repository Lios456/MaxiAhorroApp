using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public Category Cat { get; set; }
        public float Price { get; set; }
        public int Cuantity { get; set; }
        public DateTime Datein = DateTime.Now;
        public Proveedor Prov { get; set; }
        public String Barcode { get; set; }
        public DateTime Dateex { get; set; }
        public String Sign { get; set; }
        public String Location { get; set; }
        

    }
}
