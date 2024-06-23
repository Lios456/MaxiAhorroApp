using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioProducto : Connection, IRepositorio<Producto>
    {
        private List<Producto> productos = new List<Producto>();

        public IList<Producto> Consultar()
        {
            try
            {
                var sql = "SELECT id, nombre,descripcion, proveedor, categoria, precio FROM productos;";
                var command = new MySqlCommand(sql,base.cn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(
                        new Producto
                        {
                            Id = reader.GetInt16("id"),
                            Name = reader.GetString("nombre"),
                            Description = reader.GetString("descripcion"),
                            Prov = new Proveedor { Name = reader.GetString("proveedor") },
                            Cat = new Category { Name = reader.GetString("categoria") },
                            Price = reader.GetFloat("precio")

                        });
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
            
            return productos;
        }

        public Producto ConsultarPorId(int id)
        {
            base.cn.Close();
            return productos.Find(p => p.Id == id);
        }

        public void Modificar(Producto item)
        {   
            base.cn.Close();
            var producto = productos.Find(p => p.Id == item.Id);
            if (producto != null)
            {
                producto.Name = item.Name;
                producto.Price = item.Price;
            }
        }

        public void Agregar(Producto item)
        {
            try
            {
                string sql = "INSERT INTO `minimarket`.`productos` " +
            "(`nombre`, `descripcion`, `categoria`, `precio`, `cantidad`, `fecha_ingreso`, `proveedor`, `codigo_barra`, `fecha_vencimiento`, `marca`, `ubicacion`) " +
            "VALUES (@nombre, @descripcion, @categoria, @precio, @cantidad, @fecha_ingreso, @proveedor, @codigo_barra, @fecha_vencimiento, @marca, @ubicacion);";

                MySqlCommand command = new MySqlCommand(sql, base.cn);
                command.Parameters.AddWithValue("@nombre", item.Name);
                command.Parameters.AddWithValue("@descripcion", item.Description);
                command.Parameters.AddWithValue("@categoria", item.Cat.Name);
                command.Parameters.AddWithValue("@precio", item.Price);
                command.Parameters.AddWithValue("@cantidad", item.Cuantity);
                command.Parameters.AddWithValue("@fecha_ingreso", item.Datein);
                command.Parameters.AddWithValue("@proveedor", item.Prov.Name);
                command.Parameters.AddWithValue("@codigo_barra", item.Barcode);
                command.Parameters.AddWithValue("@fecha_vencimiento", item.Dateex);
                command.Parameters.AddWithValue("@marca", item.Sign);
                command.Parameters.AddWithValue("@ubicacion", item.Location);
                command.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
            
        }

        public void Eliminar(Producto item)
        {
            try
            {
                var sql = "DELETE FROM productos WHERE id = @id";
                var cmd = new MySqlCommand(sql, base.cn);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
                base.cn.Close();
                productos.Remove(item);
            }catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
