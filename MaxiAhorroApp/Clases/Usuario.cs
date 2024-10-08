﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol {  get; set; }
        public Usuario() {
            IDUsuario = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Contraseña = string.Empty;
            Rol = string.Empty;
        }
    }
}
