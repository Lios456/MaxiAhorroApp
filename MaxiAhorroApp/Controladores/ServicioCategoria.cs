using Dapper;
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

        public IEnumerable<Category> Consultar()
        {
            try
            {
                return cn.Query<Category>("Select * from categorias");
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
