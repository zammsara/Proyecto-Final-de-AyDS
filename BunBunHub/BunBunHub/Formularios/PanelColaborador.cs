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
    public partial class PanelColaborador : Form
    {
        private string rolUsuario;
        public PanelColaborador()
        {
            InitializeComponent();
            // Acceder al nombre y rol desde la clase estática
            string nombreUsuario = UsuarioSesion.NombreUsuario;
            rolUsuario = UsuarioSesion.RolUsuario;

            // Mostrar el nombre en un label
            lblNombreUsuario.Text = nombreUsuario;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Si selecciona "Sí", abrir el formulario Principal
                Principal iniciarSesion = new Principal();
                iniciarSesion.Show();

                // Ocultar el formulario actual
                this.Hide();
            }
            else
            {
                // Si selecciona "No", no hacer nada. No se cierra ni se cambia de formulario.
            }

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            GestionPedidos gestionPedidos = new GestionPedidos();
            gestionPedidos.Rol = rolUsuario;
            gestionPedidos.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            GestionClientes gestionClientes = new GestionClientes();
            gestionClientes.Show();
            this.Hide();
        }

        private void btnPedidosActuales_Click(object sender, EventArgs e)
        {
            PedidosPendientes pedidosPendientes = new PedidosPendientes();
            pedidosPendientes.ShowDialog();
        }

        private void btnInformacin_Click(object sender, EventArgs e)
        {
            InformaciónSistema infoForm = new InformaciónSistema();
            infoForm.ShowDialog();
        }
    }
}
