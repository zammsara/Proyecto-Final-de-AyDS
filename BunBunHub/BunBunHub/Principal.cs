using BunBunHub.Dao;
using BunBunHub.Formularios;
using BunBunHub.Modelos;
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

namespace BunBunHub
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            ImagenPublicidad.CargarImagenDesdeArchivo();
        }
        // Eventos Basico
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento del botón Iniciar sesión
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Verificar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Fallo en Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresada = txtContrasena.Text;

            // Verificar si el archivo existe antes de intentar cargarlo
            if (!File.Exists("usuario.dat")) // Cambia aquí si necesitas otra ruta
            {
                MessageBox.Show("El archivo de usuarios no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar la lista de usuarios desde el archivo
            GestionDeArchivos gestionArchivos = new GestionDeArchivos();
            List<Usuarios> listaUsuarios = gestionArchivos.CargarUsuarios("usuario.dat"); // Aquí usamos la carga sin filtrar por rol

            // Buscar al usuario con las credenciales ingresadas
            Usuarios usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.Usuario == usuarioIngresado && u.Contraseña == contrasenaIngresada && u.Estado == "Activo");

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
                MessageBox.Show("Credenciales incorrectas. Verifique e intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtContrasena.Text = "●●●●●●●●●●";
                txtUsuario.Focus();
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

        private void minuculas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Convertir la tecla presionada a minúscula
            e.KeyChar = Char.ToLower(e.KeyChar);
        }
    }
}