using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MaxiAhorroApp.Clases
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Category categoria_id { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public Proveedor proveedor_id { get; set; }
        public string codigo_barra { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public Marca marca_id { get; set; }
        public Ubicacion ubicacion_id { get; set; }

    }

}
