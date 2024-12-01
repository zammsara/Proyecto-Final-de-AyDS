using BunBunHub.Dao;
using BunBunHub.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;
using static BunBunHub.Modelos.Sesion;

namespace BunBunHub
{
    public partial class Principal : Form
    {
        PanelAdministrador ventanaAdministrador;
        public Principal()
        {
            InitializeComponent();
        }
        // Eventos Basico
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresada = txtContrasena.Text;

            // Verificar si el archivo existe antes de intentar cargarlo
            if (!File.Exists("usuario.dat")) // Cambia aquí si necesitas otra ruta
            {
                MessageBox.Show("El archivo de usuarios no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar la lista de usuarios desde el archivo
            List<Usuarios> listaUsuarios = ManejoArchivos<Usuarios>.CargarDatos("usuario.dat");

            // Buscar al usuario con las credenciales ingresadas
            Usuarios usuarioEncontrado = listaUsuarios.FirstOrDefault(u =>
                u.Usuario == usuarioIngresado &&
                u.Contraseña == contrasenaIngresada &&
                u.Estado == "Activo");

            if (usuarioEncontrado != null)
            {
                // Almacenar los datos del usuario en la clase estática
                UsuarioSesion.NombreUsuario = usuarioEncontrado.Usuario;
                UsuarioSesion.RolUsuario = usuarioEncontrado.Rol;

                // Proceder según el rol del usuario encontrado
                switch (usuarioEncontrado.Rol)
                {
                    case "Administrador":
                        PanelAdministrador administradorPanel = new PanelAdministrador();
                        administradorPanel.Show();
                        this.Hide();
                        break;

                    case "Colaborador":
                        PanelColaborador colaboradorPanel = new PanelColaborador();
                        colaboradorPanel.Show();
                        this.Hide();
                        break;

                    case "Cliente":
                        PanelCliente clientePanel = new PanelCliente();
                        clientePanel.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o el usuario no está activo.",
                                "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaginaWeb_Click(object sender, EventArgs e)
        {
            // URL que quieres abrir
            string url = "https://bunbunstitches.carrd.co/";

            try
            {
                // Intenta abrir la URL en el navegador predeterminado
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Maneja cualquier error (si ocurre)
                MessageBox.Show("No se pudo abrir la página web: " + ex.Message);
            }
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            // URL que quieres abrir
            string url = "https://www.instagram.com/bunbunstitches/";

            try
            {
                // Intenta abrir la URL en el navegador predeterminado
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Maneja cualquier error (si ocurre)
                MessageBox.Show("No se pudo abrir la página web: " + ex.Message);
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }
    }
}
