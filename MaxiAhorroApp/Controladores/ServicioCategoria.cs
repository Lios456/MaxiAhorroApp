using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioCategoria : Connection, IRepositorio<Category>
    {
        private List<Category> categories = new List<Category>();
        public void Agregar(Category item)
        {
            throw new NotImplementedException();
        }

        public IList<Category> Consultar()
        {
            try
            {
                var sql = "SELECT * FROM minimarket.categorias";
                var cmd = new MySqlCommand(sql, base.cn);
                var data = cmd.ExecuteReader();
                while (data.Read())
                {
                    categories.Add(new Category()
                    {
                        Id = data.GetInt32("id"),
                        Name = data.GetString("nombre"),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
            return categories;
        }

        public Category ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Category item)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
