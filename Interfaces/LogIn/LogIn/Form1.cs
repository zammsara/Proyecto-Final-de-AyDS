using LogIn.forms;
using LogIn.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class LogIn : Form
    {
        private List<Usuario> usuarios; // Lista de usuarios predefinidos para la demostracion
        public LogIn()
        {
            InitializeComponent();
            // Inicializar algunos usuarios de ejemplo
            usuarios = new List<Usuario>
        {
            new Usuario("oliver", "oliver123", "colaborador"),
            new Usuario("abigail", "abigail123", "cliente")
        };
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            if(tbContrasena.Text == "Contraseña")
            {
                tbContrasena.UseSystemPasswordChar = false;
            }
            else
            {
                tbContrasena.UseSystemPasswordChar = true;
            }
        }

        private void tbContrasena_TextChanged(object sender, EventArgs e)
        {
            tbContrasena.UseSystemPasswordChar = true;
        }

        private void tbContrasena_Leave(object sender, EventArgs e)
        {
            if(tbContrasena.Text == "")
            {
                tbContrasena.Text = "Contraseña";
                tbContrasena.UseSystemPasswordChar = false;
            }
        }

        private void tbContrasena_Enter(object sender, EventArgs e)
        {
            pFondoContrasena.BackColor = Color.Blue;
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.UseSystemPasswordChar = false;
            }

            pFondoUsuario.BackColor = Color.Gray;
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            pFondoUsuario.BackColor = Color.Blue;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = tbUsuario.Text;
            string contrasenaIngresada = tbContrasena.Text;

            // Verificar si existe un usuario que coincida con las credenciales ingresadas
            bool usuarioValido = usuarios.Any(u => u.VerificarCredenciales(usuarioIngresado, contrasenaIngresada));

            if (usuarioValido)
            {
                // Obtener el usuario específico después de confirmar que es válido
                Usuario usuario = usuarios.First(u => u.VerificarCredenciales(usuarioIngresado, contrasenaIngresada));

                // Redirigir según el tipo de usuario
                if (usuario.TipoUsuario == "cliente")
                {
                    ClienteFrm clienteForm = new ClienteFrm();
                    clienteForm.Show();
                }
                else if (usuario.TipoUsuario == "colaborador")
                {
                    ColaboradorFrm colaboradorForm = new ColaboradorFrm();
                    colaboradorForm.Show();
                }
                this.Hide(); // Ocultar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
    }

