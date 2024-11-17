using BunBunHub.Dao;
using BunBunHub.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub
{
    public partial class Acceso : Form
    {
        PanelAdministrador ventanaAdministrador;
        public Acceso()
        {
            InitializeComponent();
            btnSitioWeb.MouseEnter += ComponentesVisuales.EfectosVisuales.OnBtn_MouseEnter;
            btnSitioWeb.MouseLeave += ComponentesVisuales.EfectosVisuales.OnBtn_MouseLeave;
            btnSitioWeb.MouseDown += ComponentesVisuales.EfectosVisuales.OnBtn_MouseDown;
            btnSitioWeb.MouseUp += ComponentesVisuales.EfectosVisuales.OnBtn_MouseUp;
            btnIniciarSesion.MouseDown += ComponentesVisuales.EfectosVisuales.OnBtn_MouseDown;
            btnIniciarSesion.MouseUp += ComponentesVisuales.EfectosVisuales.OnBtn_MouseUp;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresada = txtContrasena.Text;

            bool credencialesValidas = false;
            string rol = "";
            string estado = "";

            // Comprobar si el archivo de usuarios existe
            if (!File.Exists(RegistrarUsuario.rutaUsuarios))
            {
                MessageBox.Show("El archivo de usuarios no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FileStream archivo = new FileStream(RegistrarUsuario.rutaUsuarios, FileMode.Open, FileAccess.Read))
            using (BinaryReader lector = new BinaryReader(archivo, Encoding.UTF8))
            {
                while (archivo.Position < archivo.Length)
                {
                    string usuario = lector.ReadString();
                    string contrasena = lector.ReadString();
                    string rolUsuario = lector.ReadString();
                    string estadoUsuario = lector.ReadString();

                    // Verificar si las credenciales coinciden
                    if (usuario == usuarioIngresado && contrasena == contrasenaIngresada && estadoUsuario == "Activo")
                    {
                        credencialesValidas = true;
                        rol = rolUsuario;  // Almacenar el rol
                        estado = estadoUsuario;  // Almacenar el estado
                        break;
                    }
                }
            }

            if (credencialesValidas)
            {
                // Si las credenciales son válidas y el estado es "Activo", proceder según el rol
                switch (rol)
                {
                    case "Administrador": // Administrador
                        PanelAdministrador administradorPanel = new PanelAdministrador();
                        administradorPanel.Show();
                        this.Hide();
                        break;

                    case "Colaborador": // Colaborador
                        PanelColaborador colaboradorPanel = new PanelColaborador();
                        colaboradorPanel.Show();
                        this.Hide();
                        break;

                    case "Cliente": // Cliente
                        PanelCliente clientePanel= new PanelCliente();
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
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dirigir al sitio web
        private void btnSitioWeb_Click(object sender, EventArgs e)
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

        // Evento: mover a Dao
        private void answer_Enter(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }

        // Contraseña oculta
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
        }
    }
}
