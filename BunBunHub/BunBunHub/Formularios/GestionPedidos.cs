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
    public partial class GestionPedidos : Form
    {
        public GestionPedidos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            RegistrarPedido registrarPedido = new RegistrarPedido();
            registrarPedido.Show();
            this.Hide();
        }

        private void btnActualizarPedido_Click(object sender, EventArgs e)
        {
            ActualizarPedido actualizarPedido = new ActualizarPedido();
            actualizarPedido.Show();
            this.Hide();
        }
    }
}
