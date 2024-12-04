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
    public partial class PanelCliente : Form
    {
        public PanelCliente()
        {
            InitializeComponent();
            // Acceder al nombre y rol desde la clase estática
            string nombreUsuario = UsuarioSesion.NombreUsuario;
            string rolUsuario = UsuarioSesion.RolUsuario;

            // Mostrar el nombre en un label
            lblNombreUsuario.Text = nombreUsuario;
        }

        // Propiedad para actualizar la imagen en panel Cliente
        public void ActualizarImagen(System.Drawing.Image imagen)
        {
            picPublicidad2.Image = imagen;
            picPublicidad2.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar imagen al PictureBox
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
    }
}
