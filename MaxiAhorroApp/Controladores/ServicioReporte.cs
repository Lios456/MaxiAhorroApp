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
    public class ServicioReporte : Connection, IRepositorio<Reporte>
    {

        public IList<Reporte> Consultar()
        {
            List<Reporte> attrchart = new List<Reporte>();
            try
            {
                var sql = "call sp_total_productos_por_categoria();";
                var cmd = new MySqlCommand(sql, base.cn);
                var data =  cmd.ExecuteReader();
                var con = 1;
                while(data.Read())
                {
                    attrchart.Add(new Reporte { Label = data.GetString("nombre"), X=con, Y = data.GetInt16("sum(cantidad)")});
                    con++;
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
            return attrchart;
        }

        void IRepositorio<Reporte>.Agregar(Reporte item)
        {
            throw new NotImplementedException();
        }

        Reporte IRepositorio<Reporte>.ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<Reporte>.Eliminar(Reporte item)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<Reporte>.Modificar(Reporte item)
        {
            throw new NotImplementedException();
        }
    }
}
