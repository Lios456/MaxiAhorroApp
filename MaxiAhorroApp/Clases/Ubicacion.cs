﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Clases
{
    public class Ubicacion
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}