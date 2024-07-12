﻿using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Vistas
{
    public partial class Agregar_Productos : Form
    {
        private Producto p = new Producto();
        public Agregar_Productos()
        {
            InitializeComponent();
            ServicioCategoria servicio = new ServicioCategoria();
            List<Category> categories = (List<Category>)servicio.Consultar();
            categories.ForEach(category => this.categorytx.Items.Add(category));
            this.expiretx.MinDate = DateTime.Now;
            button2_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Se proporciona un producto al constructor del formulario
        /// se establece como fecha mínima en expiración 
        /// la expiración del producto enviado como parámetro
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public Agregar_Productos(Producto pe)
        {
            
            InitializeComponent();
            ServicioCategoria servicio = new ServicioCategoria();
            List<Category> categories = (List<Category>)servicio.Consultar();
            categories.ForEach(category => this.categorytx.Items.Add(category));
            this.expiretx.MinDate = pe.Dateex;
            //button2_Click(this, EventArgs.Empty);
            this.p.Id = pe.Id;
            this.nombretx.Text = pe.Name;
            this.descriptiontx.Text = pe.Description;
            this.categorytx.SelectedItem = pe.Cat.Name;
            this.pricetx.Text = pe.Price.ToString();
            this.cuantitytx.Text = pe.Cuantity.ToString();
            this.provetortx.SelectedItem = pe.Prov.Name;
            this.barcodetx.Text = pe.Barcode;
            this.expiretx.Value = pe.Dateex;
            this.signtx.Text = pe.Sign;
            this.locationtx.Text = pe.Location;

        }

        /// <summary>
        /// Registra el nuevo producto en la bdd
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.SetProducto();
                if (this.nombretx.Text != ""
                       && this.descriptiontx.Text != ""
                       && this.signtx.Text != ""
                       && this.locationtx.Text != "")
                {
                    if (this.barcodetx.Text == String.Empty)
                    {
                        MessageBox.Show("Código de barras no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (this.p.Id == 0)
                        {
                            new ServicioProducto().Agregar(p);
                            button2_Click(sender, e);
                        }
                        else
                        {
                            new ServicioProducto().Modificar(p);
                            this.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Datos incorrectos, por favor vuelva a ingresar");
                }
                
                
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SetProducto()
        {
            p.Name = this.nombretx.Text;
            p.Description = this.descriptiontx.Text;
            p.Cat = (Category)categorytx.SelectedItem;
            p.Price = float.Parse(this.pricetx.Text);
            p.Cuantity = Convert.ToInt16(this.cuantitytx.Text);
            p.Prov = new Proveedor { Name = this.provetortx.SelectedItem.ToString() };
            p.Barcode = this.barcodetx.Text;
            p.Dateex = this.expiretx.Value;
            p.Sign = this.signtx.Text;
            p.Location = this.locationtx.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nombretx.Text = "";
            this.descriptiontx.Text = "";
            this.categorytx.SelectedIndex = 0;
            this.pricetx.Value = 0.5m;
            this.cuantitytx.Value = 1;
            this.provetortx.SelectedIndex = 0;
            this.barcodetx.Text = "";
            this.expiretx.Value = DateTime.Now;
            this.signtx.Text = "";
            this.locationtx.Text = "";

        }
    }
}
