using MaxiAhorroApp.Clases;
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
    public partial class Agregar_Empleado : Form
    {
        public Empleado em = new Empleado();
        public Agregar_Empleado()
        {
            InitializeComponent();
            this.txfechacontratacioin.MaxDate = DateTime.Today;
            button2_Click(this, EventArgs.Empty);
        }

        public Agregar_Empleado(Empleado emp)
        {
            InitializeComponent();
            this.txfechacontratacioin.MaxDate= DateTime.Today;
            em = emp;
            this.txestado.Text = em.Estado;
            this.txsalario.Value = em.Salario;
            this.txpuesto.Text = em.Puesto;
            this.txfechacontratacioin.Value = em.FechaContratacion;
            this.txrol.Text = em.Rol;
            this.txcontrasenia.Text = em.Contraseña;
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
            this.txpuesto.SelectedIndex = 0;
            this.txsalario.Value = 10;
            this.txestado.SelectedIndex = 0;
        }

        public void setEmpleado()
        {
            if (this.txemail.Text.Contains("@"))
            {
                em.Email = this.txemail.Text;
                em.Nombre = this.txnombre.Text;
                em.Apellido = this.txapellido.Text;
                em.Contraseña = this.txcontrasenia.Text;
                em.Rol = this.txrol.Text;
                em.FechaContratacion = this.txfechacontratacioin.Value;
                em.Puesto = this.txpuesto.Text;
                em.Salario = this.txsalario.Value;
                em.Estado = this.txestado.Text;
            }
            else
            {
                em = null;
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                setEmpleado();
                if(em.IDEmpleado == 0)
                {
                    new ServicioEmpleado().Agregar(em);
                }
                else
                {
                    new ServicioEmpleado().Modificar(em);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
