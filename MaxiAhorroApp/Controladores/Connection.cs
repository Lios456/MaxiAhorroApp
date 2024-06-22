using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class Connection
    {
        private static String cns = "server=localhost;user=root;password=root;database=Minimarket";
        protected MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection(cns);
        public Connection()
        {
            try
            {
                cn.Open();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
