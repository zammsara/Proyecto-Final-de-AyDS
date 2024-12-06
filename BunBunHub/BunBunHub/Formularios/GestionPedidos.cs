using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class GestionPedidos : Form
    {
        public string Rol { get; set; }
        private string rolUsuario;
        public GestionPedidos()
        {
            InitializeComponent();
            rolUsuario = UsuarioSesion.RolUsuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Verificar el rol y abrir el panel correspondiente
            if (Rol == "Colaborador")
            {
                PanelColaborador panelColaborador = new PanelColaborador();
                panelColaborador.Show();
                this.Hide();  // Ocultar el formulario actual
            }
            else
            {
                PanelAdministrador panelAdministrador = new PanelAdministrador();
                panelAdministrador.Show();
                this.Hide();  // Ocultar el formulario actual
            }
        }


        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            RegistrarPedido registrarPedido = new RegistrarPedido();
            registrarPedido.Rol = rolUsuario;
            registrarPedido.Show();
            this.Hide();
        }

        private void btnActualizarPedido_Click(object sender, EventArgs e)
        {
            ActualizarPedido actualizarPedido = new ActualizarPedido();
            actualizarPedido.Rol = rolUsuario;
            actualizarPedido.Show();
            this.Hide();
        }
    }
}
