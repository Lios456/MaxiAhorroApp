using Dapper;
using MaxiAhorroApp.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioEmpleado : Connection
    {
        public void Agregar(Empleado e)
        {
            if (e == null)
            {
                MessageBox.Show("Empleado no válido");
            }
            else
            {
                try
                {
                    var sql = @"INSERT INTO minimarket.empleados(Nombre,Apellido,Email,Contraseña,Rol) VALUES" +
                    "(@Nombre," +
                    "@Aellido," +
                    "@Email," +
                    "@Contraseña," +
                    "@Rol)";
                    base.cn.Execute(sql, e);

                    var sql2 = @"INSERT INTO minimarket.empleados (`IDUsuario`, `FechaContratacion`, `Puesto`, `Salario`, `Estado`)
                    VALUES (@IDUsuario, @FechaContratacion, @Puesto, @Salario, @Estado);";
                    base.cn.Execute(sql2, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
