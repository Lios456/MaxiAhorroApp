using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace MaxiAhorroApp.Controladores
{
    public class ventascliente : Connection
    {


        public void insertarventa(DatosCli datoscli)
        {
            base.cn.Execute("sp_insertar_factura", datoscli, commandType: CommandType.StoredProcedure);
            base.cn.Close();
        }

    }
}
