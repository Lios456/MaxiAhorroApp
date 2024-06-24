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
    public partial class Main : Form
    {
        private Form current;
        public Main()
        {
            InitializeComponent();
            current = new Dashboard();
            poneForm(current);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarPanel();
            current = new Ver_Productos();
            poneForm(current);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarPanel();
            current = new Dashboard();
            poneForm(current);
        }

        private void limpiarPanel()
        {
            if (this.current != null)
            {
                current.Close();
                current.Dispose();
                current = null;
            }
            this.mainpanel.Controls.Clear();
        }
        private void poneForm(Form f)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            f.Show();
        }
    }
}
