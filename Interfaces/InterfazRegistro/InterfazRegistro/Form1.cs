using InterfazRegistro.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazRegistro
{
    public partial class Form1 : Form
    {
        private List<Usuario> usuariosRegistrados = new List<Usuario>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Recoger y validar datos
            string nombre = tbNombre.Text;
            string apellido = tbApellido.Text;
            DateTime fechaNacimiento = dtpFechaNac.Value;
            string usuarioNombre = tbUsuarioNombre.Text;
            string contrasena = tbContrasena.Text;
            string confirmarContrasena = tbConfirmarContra.Text;
            string telefono = tbTelefono.Text;
            string correo = tbCorreo.Text;
            string direccion = tbDireccion.Text;
            bool esCliente = chkCliente.Checked;
            bool esColaborador = chkColaborador.Checked;


            // Validacion de campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(usuarioNombre) || string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(confirmarContrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            if (contrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Verificar si el usuario ya esta registrado
            foreach (var usuario in usuariosRegistrados)
            {
                if (usuario.UsuarioNombre == usuarioNombre)
                {
                    MessageBox.Show("Este usuario ya está registrado.");
                    return;
                }
            }

            // Crear instancia del struct Usuario
            Usuario nuevoUsuario = new Usuario(nombre, apellido, fechaNacimiento, usuarioNombre, contrasena,
                                               confirmarContrasena, telefono, correo, direccion,
                                               esCliente, esColaborador);

            // Agregar el nuevo usuario a la lista de registrados
            usuariosRegistrados.Add(nuevoUsuario);

            // Confirmación de registro
            MessageBox.Show("Usuario registrado correctamente:\n");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
