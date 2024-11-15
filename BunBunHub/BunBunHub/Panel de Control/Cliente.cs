using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Panel_de_Control
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Acceso iniciarSesion = new Acceso();
            iniciarSesion.Show();
            this.Hide();
        }

        private void lblAdministrador_Click(object sender, EventArgs e)
        {

        }
    }
}
