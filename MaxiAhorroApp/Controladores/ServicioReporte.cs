﻿using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioReporte : Connection
    {

        public List<Reporte> Consultar()
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
                    attrchart.Add(new Reporte { Label = data.GetString("nombre"), X=con, Y = data.GetInt16("sum(p.cantidad)")});
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

        
    }
}
