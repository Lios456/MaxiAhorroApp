﻿using MaxiAhorroApp.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MaxiAhorroApp.Vistas
{
    public partial class Dashboard : Form
    {
        private Connection con = new Connection();
        public Dashboard()
        {
            InitializeComponent();
            var datos = new ServicioReporte().Consultar();
            foreach (var item in datos)
            {
                total_pc.Series.Add(item.Label);
                
                total_pc.Series[item.Label].Points.AddXY(item.X, item.Y);
                total_pc.Series[item.Label].BorderWidth = 5;
            }
            
        }

    }

}
