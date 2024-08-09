using MaxiAhorroApp.Clases;
using MaxiAhorroApp.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiAhorroApp.Vistas
{
    public partial class Agregar_Empleado : Form
    {
        public Empleado em = new Empleado();
        public Empleado emanterior = new Empleado();
        public Agregar_Empleado()
        {
            InitializeComponent();
            this.txfechacontratacioin.MaxDate = DateTime.Today;
            button2_Click(this, EventArgs.Empty);
        }

        public Agregar_Empleado(Empleado emp)
        {
            //Inicializo el empleado anterior
            emanterior.IDEmpleado = emp.IDEmpleado;
            emanterior.Estado = emp.Estado;
            emanterior.Salario = emp.Salario;
            emanterior.FechaContratacion = emp.FechaContratacion;
            emanterior.Rol = emp.Rol;
            emanterior.Apellido = emp.Apellido;
            emanterior.Nombre = emp.Nombre;
            emanterior.Email = emp.Email;
            
            InitializeComponent();
            this.txfechacontratacioin.MinDate = emp.FechaContratacion;
            this.txfechacontratacioin.MaxDate= DateTime.Today;
            em = emp;
            this.txestado.Text = em.Estado;
            this.txsalario.Value = em.Salario;
            this.txfechacontratacioin.Value = em.FechaContratacion;
            this.txrol.Text = em.Rol;
            //this.txcontrasenia.Text = em.Contraseña;
            this.txapellido.Text = em.Apellido;
            this.txnombre.Text = em.Nombre;
            this.txemail.Text = em.Email;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txnombre.Text = "";
            this.txapellido.Text = "";
            this.txemail.Text = "";
            this.txcontrasenia.Text = "";
            this.txrol.SelectedIndex = 0;
            this.txfechacontratacioin.Value = DateTime.Today;
            this.txsalario.Value = this.txsalario.Minimum;
            this.txestado.SelectedIndex = 0;
        }

        public bool setEmpleado()
        {
            bool valido = false;
            em.Email = this.txemail.Text;
            if (ValidarEmail(em.Email))
            {
                string pattern = @"^[A-Z]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(this.txnombre.Text))
                {
                    em.Nombre = this.txnombre.Text;
                }
                else
                {
                    MessageBox.Show("El nombre debe estar en mayúsculas y contener solo letras.");
                }

                if (regex.IsMatch(this.txapellido.Text))
                {
                    em.Apellido = this.txapellido.Text;
                }
                else
                {
                    MessageBox.Show("El apellido debe estar en mayúsculas y contener solo letras.");
                }

                em.Contraseña = this.txcontrasenia.Text;
                em.Rol = this.txrol.Text;
                em.FechaContratacion = this.txfechacontratacioin.Value;
                em.Puesto = this.txrol.Text;
                em.Salario = this.txsalario.Value;
                em.Estado = this.txestado.Text;

                valido = true;

            }
            return valido;
            
        }


        private bool ValidarEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            bool valido = regex.IsMatch(email);
            return valido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(em.IDEmpleado == 0)
                {
                    if (setEmpleado())
                    {
                        new ServicioEmpleado().Agregar(em);
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados son erroneos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    if (setEmpleado())
                    {
                        new ServicioEmpleado().Modificar(em, emanterior);
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados son erroneos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
