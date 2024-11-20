using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Formularios
{
    public partial class ActualizarRegistro : Form
    {
        public ActualizarRegistro()
        {
            InitializeComponent();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tlsbtnVolver_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }

        private void tlsbtnHome_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void tlsVolverBtn_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }

        private void tlsHomeBtn_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }
    }
}
