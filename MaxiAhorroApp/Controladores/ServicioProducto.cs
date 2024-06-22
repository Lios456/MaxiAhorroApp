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
                base.cn.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return productos;
        }

        public Producto ConsultarPorId(int id)
        {
            base.cn.Open();
            base.cn.Close();
            return productos.Find(p => p.Id == id);
        }

        public void Modificar(Producto item)
        {
            base.cn.Open();
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
            base.cn.Open();
            base.cn.Close();
            productos.Add(item);
        }

        public void Eliminar(Producto item)
        {
            base.cn.Open();
            base.cn.Close();
            productos.Remove(item);
        }
    }
}
