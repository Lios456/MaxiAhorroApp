using Dapper;
using MaxiAhorroApp.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioMarca: Connection
    {
        public IEnumerable<Marca> Consultar()
        {
            var sql = @"SELECT * FROM minimarket.marcas";
            var marcas = base.cn.Query<Marca>(sql);
            return marcas;
        }
    }
}
