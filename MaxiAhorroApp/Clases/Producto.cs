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
        public Proveedor Prov { get; set; }
        public Category Cat { get; set; }
        public float Price { get; set; }

    }
}
