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
    internal class ServicioProveedores: Connection
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public IEnumerable<Proveedor> Consultar()
        {
            try
            {
                return cn.Query<Proveedor>("Select * from proveedores");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
            return proveedores;
        }
    }
}
