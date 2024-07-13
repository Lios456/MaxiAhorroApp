using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class Administrador: Usuario
    {
        public int IdAdministrador { get; set; }
        public int IdEmpleado { get; set; }
        public int NivelAcceso { get; set; }
    }
}
