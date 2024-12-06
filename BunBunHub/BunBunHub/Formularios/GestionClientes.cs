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
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelColaborador panelColaborador = new PanelColaborador();
            panelColaborador.Show();
            this.Hide();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActualizarRegistro_Click(object sender, EventArgs e)
        {
            ActualizarCliente actualizarCliente = new ActualizarCliente();
            actualizarCliente.Show();
            this.Hide();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            RegistrarCliente cliente = new RegistrarCliente();
            cliente.Show();
            this.Hide();
        }
    }
}
