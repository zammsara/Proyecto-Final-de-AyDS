using BunBunHub.Panel_de_Control;
using BunBunHub.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub
{
    public partial class Acceso : Form
    {
        public Acceso()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = tbUsuario.Text;
            string contrasenaIngresada = tbContrasena.Text;

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
                        Administrador administradorForm = new Administrador();
                        administradorForm.Show();
                        this.Hide();
                        break;

                    case "Colaborador": // Colaborador
                        Colaborador colaboradorForm = new Colaborador();
                        colaboradorForm.Show();
                        this.Hide();
                        break;

                    case "Cliente": // Cliente
                        Cliente clienteForm = new Cliente();
                        clienteForm.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o el usuario está inactivo.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbContrasena_TextChanged(object sender, EventArgs e)
        {
            tbContrasena.UseSystemPasswordChar = true;
        }

        private void Acceso_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
