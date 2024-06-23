using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioProducto : Connection, IRepositorio<Producto>
    {
        private List<Producto> productos = new List<Producto>();

        public IList<Producto> Consultar()
        {
            try
            {
                var sql = "SELECT * FROM productos;";
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
                            Cat = new Category { Name = reader.GetString("categoria") },
                            Price = (float)reader.GetDecimal("precio"),
                            Cuantity = reader.GetInt16("cantidad"),
                            Datein = reader.GetDateTime("fecha_ingreso"),
                            Prov = new Proveedor { Name = reader.GetString("proveedor") },
                            Barcode = reader.GetString("codigo_barra"),
                            Dateex = reader.GetDateTime("fecha_vencimiento"),
                            Sign = reader.GetString("marca"),
                            Location = reader.GetString("ubicacion")

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
            var p = new Producto();

            try
            {
                var sql = "SELECT * FROM productos WHERE id = @id";
                var command = new MySqlCommand(sql, base.cn);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                p.Id = reader.GetInt16("id");
                p.Name = reader.GetString("nombre");
                p.Description = reader.GetString("descripcion");
                p.Cat = new Category { Name = reader.GetString("categoria") };
                p.Price = (float)reader.GetDecimal("precio");
                p.Cuantity = reader.GetInt16("cantidad");
                p.Datein = reader.GetDateTime("fecha_ingreso");
                p.Prov = new Proveedor { Name = reader.GetString("proveedor") };
                p.Barcode = reader.GetString("codigo_barra");
                p.Dateex = reader.GetDateTime("fecha_vencimiento");
                p.Sign = reader.GetString("marca");
                p.Location = reader.GetString("ubicacion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
            return p;
        }

        public void Modificar(Producto item)
        {
            if (item.Id != 0)
            {
                try
                {
                    var sql = "UPDATE `minimarket`.`productos` SET " +
                              "nombre = @nombre, " +
                              "descripcion = @description, " +
                              "categoria = @categoria, " +
                              "precio = @precio, " +
                              "cantidad = @cantidad, " +
                              "fecha_ingreso = @datein, " +
                              "proveedor = @prov, " +
                              "codigo_barra = @barcode, " +
                              "fecha_vencimiento = @dateex, " +
                              "marca = @marca, " +
                              "ubicacion = @ubi " +
                              "WHERE id = @id";

                    var cmd = new MySqlCommand(sql, base.cn);
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@nombre", item.Name);
                    cmd.Parameters.AddWithValue("@description", item.Description);
                    cmd.Parameters.AddWithValue("@categoria", item.Cat.Id);
                    cmd.Parameters.AddWithValue("@precio", item.Price);
                    cmd.Parameters.AddWithValue("@cantidad", item.Cuantity);
                    cmd.Parameters.AddWithValue("@datein", item.Datein);
                    cmd.Parameters.AddWithValue("@prov", item.Prov.Name);
                    cmd.Parameters.AddWithValue("@barcode", item.Barcode);
                    cmd.Parameters.AddWithValue("@dateex", item.Dateex);
                    cmd.Parameters.AddWithValue("@marca", item.Sign);
                    cmd.Parameters.AddWithValue("@ubi", item.Location);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El producto se ha actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    base.cn.Close();
                }
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
                MessageBox.Show($"El producto se ha guardado correctamente");

            }
            catch(Exception ex)
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
