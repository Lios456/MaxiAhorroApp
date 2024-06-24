﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Controladores
{
    internal interface IRepositorio<T>
    {
        IList<T> Consultar();
        T ConsultarPorId(int id);
        void Modificar(T item);
        void Agregar(T item);
        void Eliminar(T item);
    }
}