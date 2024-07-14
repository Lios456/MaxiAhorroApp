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
                MessageBox.Show("Empleado no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (e.Nombre != "" && e.Apellido != "" && e.Email != "" && e.Contraseña != "" && e.Rol != "")
                    {
                        var sql = @"INSERT IGNORE INTO minimarket.usuarios(Nombre,Apellido,Email,Contraseña,Rol) VALUES" +
                    "(@Nombre," +
                    "@Apellido," +
                    "@Email," +
                    "@Contraseña," +
                    "@Rol)";
                        base.cn.Execute(sql, e);
                    }

                    var u = ConsultarUsuario(e);
                    if (u != null) {
                        e.IDUsuario = u.IDUsuario;

                        var sql2 = @"INSERT IGNORE INTO minimarket.empleados (`IDUsuario`, `FechaContratacion`, `Puesto`, `Salario`, `Estado`)
                    VALUES (@IDUsuario, @FechaContratacion, @Puesto, @Salario, @Estado);";
                        base.cn.Execute(sql2, e);
                        MessageBox.Show("El Empleado se ha guardado correctamente", "Regitro de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Empleado no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Usuario ConsultarUsuario(Empleado em)
        {
            Usuario u = null;
            if (em != null)
            {
                try
                {
                    if (em.Nombre != String.Empty && em.Apellido != String.Empty && em.Email != String.Empty && em.Rol != String.Empty)
                    {
                        var sql = @"SELECT * FROM minimarket.usuarios WHERE Nombre = @Nombre AND Apellido = @Apellido AND Email = @Email AND Rol = @Rol";
                        u = (Usuario)base.cn.Query<Usuario>(sql, em).First();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            return u;
        }

        public List<Empleado> Consultar()
        {
            try
            {
                var sql = @"SELECT * FROM minimarket.usuarios u 
                        INNER JOIN minimarket.empleados e 
                        ON e.IDUsuario = u.IDUsuario
                        WHERE e.Estado = 'Activo'";
                return base.cn.Query<Empleado>(sql).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Empleado>(); 
            }
        }

        public void Modificar(Empleado em)
        {
            try
            {
                var sql = @"SELECT IDUsuario FROM minimarket.usuarios
            WHERE Nombre = @Nombre AND Apellido = @Apellido AND Email = @Email";
                var usuario = base.cn.Query<int>(sql, em).First();
                em.IDUsuario = usuario;

                var sql1 = @"UPDATE minimarket.usuarios
            SET Nombre = @Nombre, 
            Apellido = @Apellido,
            Email = @Email,
            Contraseña = @Contraseña,
            Rol = @Rol
            WHERE IDUsuario = @IDUsuario";

                base.cn.Execute(sql1, em);

                var sql2 = @"UPDATE minimarket.empleados
            SET Puesto = @Puesto,
            Salario = @Salario,
            Estado = @Estado,
            FechaContratacion = @FechaContratacion
            WHERE IDEmpleado = @IDEmpleado"
            ;

                base.cn.Execute(sql2, em);
                MessageBox.Show("Empleado Actualizado correctamente","Actualización de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Eliminar(Empleado em)
        {
            var sql = @"Update minimarket.empleados
            SET Estado = 'Inactivo' WHERE IdEmpleado = @IDEmpleado";
            base.cn.Execute(sql, em);
            MessageBox.Show("El empleado ha sido eliminado exitosamente", "Eliminación de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
    }
}
