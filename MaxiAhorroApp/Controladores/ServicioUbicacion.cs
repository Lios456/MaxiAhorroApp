using Dapper;
using MaxiAhorroApp.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioUbicacion: Connection
    {
        public IEnumerable<Ubicacion> Consultar()
        {
            var sql = @"SELECT * FROM minimarket.ubicaciones;";
            var ubicaciones = base.cn.Query<Ubicacion>(sql);
            return ubicaciones;
        }
    }
}
