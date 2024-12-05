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
            MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Principal iniciarSesion = new Principal();
            iniciarSesion.Show();
            this.Hide();
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
    }
}
