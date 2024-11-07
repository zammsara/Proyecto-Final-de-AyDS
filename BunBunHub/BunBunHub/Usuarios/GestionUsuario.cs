using BunBunHub.Panel_de_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Usuarios
{
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVentanaAnterior_Click(object sender, EventArgs e)
        {
            Administrador administradorForm = new Administrador();
            administradorForm.Show();
            this.Hide();
        }

        private void GestionUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuarioForm = new RegistrarUsuario();
            registrarUsuarioForm.Show();
            this.Hide();
        }

        private void btnUsuariosSistema_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

        }
    }
}
