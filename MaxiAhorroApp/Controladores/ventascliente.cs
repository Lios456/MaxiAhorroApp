using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace MaxiAhorroApp.Controladores
{
    public class ventascliente : Connection
    {
        public void insertarventa(datoscli datoscli)
        {
            base.cn.Execute("sp_insertar_factura", datoscli, commandType: CommandType.StoredProcedure);
            base.cn.Close();
        }

        public datoscli completarporcedula(string cedula)
        {
            var query = "SELECT nombrecliente, direccioncliente, telefonocliente FROM minimarket.factura WHERE cedulacliente = @Cedula";
            return base.cn.QueryFirstOrDefault<datoscli>(query, new { Cedula = cedula });
        }
    }
}
