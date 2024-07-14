using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class Empleado:Usuario
    {
        public int IDEmpleado {  get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Puesto { get; set; }
        public decimal Salario { get; set; }
        public string Estado { get; set; }
        public Empleado()
        {
            IDEmpleado = 0;
            IDUsuario = 0;
            Puesto = string.Empty;
            Estado = string.Empty;
            Salario = 0;
        }
    }
}
