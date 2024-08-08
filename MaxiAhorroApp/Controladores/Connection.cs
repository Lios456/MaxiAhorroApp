using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class Connection
    {
        private static String cns = "server=localhost;user=root;password=root";
        private string sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scriptbdd.sql");
        public MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection(cns);
        public Connection()
        { 
            try
            {
                string script = File.ReadAllText(sqlFilePath);
                cn.Open();
                new MySqlCommand(script, cn).ExecuteNonQuery();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
