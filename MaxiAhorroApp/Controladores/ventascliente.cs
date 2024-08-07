using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Vistas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MaxiAhorroApp.Controladores
{
    public class ventascliente:Connection
    {
        public void insertarventa(datoscli datoscli)
        {
            base.cn.Execute("sp_insertar_factura", datoscli, commandType: CommandType.StoredProcedure);
            base.cn.Close();    
        }
    }
}
