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
using static BunBunHub.Usuarios.ModeloDeDatos;

namespace BunBunHub.Usuarios
{
    public partial class RegistrarUsuario : Form
    {
        public static string rutaUsuarios = "usuarios.dat";
        public static string rutaClientes = "clientes.dat";
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        // Métodos públicos para obtener el texto de los TextBox
        public string ObtenerUsuario()
        {
            return txtUsuarioNombre.Text;
        }

        public string ObtenerContraseña()
        {
            return txtContraseña.Text;
        }

        public string ObtenerRol()
        {
            return cmbRol.Text;
        }

        public string ObtenerEstado()
        {
            return cmbEstado.Text;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void lblSistema_Click(object sender, EventArgs e)
        {

        }

        private void grpDatosCliente_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Comprobar si hay un elemento seleccionado (SelectedIndex != -1)
            if (cmbRol.SelectedIndex != -1)
            {
                // Verificar si el rol seleccionado es "Cliente"
                if (cmbRol.SelectedItem.ToString() == "Cliente")
                {
                    grpDatosCliente.Enabled = true;
                    grpContacto.Enabled = true;
                }
                else
                {
                    grpDatosCliente.Enabled = false;
                    grpContacto.Enabled = false;
                }
            }
        }


        private void grpContacto_Enter(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar sin registrar? Los datos no se guardarán.", "Cerrar sin Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                GestionUsuario gestionUsuario = new GestionUsuario();
                gestionUsuario.Show();
                this.Hide();
            }
        }

        private void tbNombre_StyleChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras. No se pueden ingresar números o símbolos.",
                        "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras. No se pueden ingresar números o símbolos.",
                        "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Solo se permiten números. No se pueden ingresar letras o símbolos.",
                                "Entrada no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;

            // Verificar si el teléfono tiene exactamente 8 dígitos
            if (telefono.Length == 8)
            {
                // Verificar que el primer dígito sea uno de los válidos (8, 9, 7, 6, 2)
                if (telefono[0] == '8' || telefono[0] == '9' || telefono[0] == '7' || telefono[0] == '6' || telefono[0] == '2')
                {
                }
                else
                {
                    // Mostrar un mensaje de advertencia si el primer dígito no es válido
                    MessageBox.Show("El número de teléfono debe comenzar con 8, 9, 7, 6 (para móviles) o 2 (para fijos).",
                                    "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Clear();
                }
            }
            else if (telefono.Length > 8)
            {
                // Si el número tiene más de 8 dígitos, mostramos un mensaje de advertencia
                MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.",
                                "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Text = telefono.Substring(0, 8);  // Limitar a 8 dígitos
            }
        }

        private void txtUsuarioNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            /*string confirmarContraseña = txtConfirmarContraseña.Text;
            string contraseña = txtContraseña.Text;

            // Comparar las contraseñas
            if (confirmarContraseña.Length -1 != contraseña.Length - 1)
            {
                // Mostrar mensaje de error, por ejemplo:
                MessageBox.Show("Las contraseñas no coinciden, por favor intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el campo de 'Confirmar Contraseña'
                txtConfirmarContraseña.Clear();
            }*/
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar sin registrar?", "Limpiar Formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtTelefono.Clear();
                txtUsuarioNombre.Clear();
                txtContraseña.Clear();
                txtConfirmarContraseña.Clear();
                txtCorreo.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtDireccion.Clear();

                // Limpiar los ComboBox
                cmbRol.SelectedIndex = -1; // Restablece la selección
                cmbEstado.SelectedIndex = -1; // Restablece la selección
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = txtUsuarioNombre.Text;
            string contraseña = txtContraseña.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            string rol = cmbRol.Text; // Administrador, Colaborador, Cliente
            string estado = cmbEstado.Text; // 1: Activo, 0: Inactivo

            ModeloDeDatos.Usuarios usuarioOB = new ModeloDeDatos.Usuarios(usuario, contraseña, rol, estado);
            ModeloDeDatos.DetallesCliente ClienteOB = null;

            if (rol == "Cliente")
            {
                ClienteOB = new DetallesCliente(usuario, contraseña, nombre, apellido, correo, int.Parse(telefono), estado);
            }

            switch (rol)
            {
                case "Administrador":
                    GuardarAdministrador(usuarioOB);
                    break;

                case "Colaborador":
                    GuardarColaborador(usuarioOB);
                    break;

                case "Cliente":
                    GuardarCliente(usuarioOB);

                    if (ClienteOB != null)
                    {
                        GuardarDetallesCliente(usuarioOB, ClienteOB);
                    }
                    break;

                default:
                    MessageBox.Show("Rol no válido. Por favor seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            txtTelefono.Clear();
            txtUsuarioNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();

            // Limpiar los ComboBox
            cmbRol.SelectedIndex = -1; // Restablece la selección
            cmbEstado.SelectedIndex = -1; // Restablece la selección
        }

        private void GuardarCliente(ModeloDeDatos.Usuarios usuarioOB)
        {
            using (FileStream mUsuario = new FileStream(rutaUsuarios, FileMode.Append))
            using (BinaryWriter Escritor = new BinaryWriter(mUsuario, Encoding.UTF8))
            {
                Escritor.Write(usuarioOB.Usuario);
                Escritor.Write(usuarioOB.Contraseña);
                Escritor.Write("Cliente");
                Escritor.Write(usuarioOB.Estado);
            }
        }
        private void GuardarAdministrador(ModeloDeDatos.Usuarios usuarioOB)
        {
            using (FileStream mUsuario = new FileStream(rutaUsuarios, FileMode.Append))
            using (BinaryWriter Escritor = new BinaryWriter(mUsuario, Encoding.UTF8))
            {
                Escritor.Write(usuarioOB.Usuario);
                Escritor.Write(usuarioOB.Contraseña);
                Escritor.Write("Administrador");
                Escritor.Write(usuarioOB.Estado);
            }

            MessageBox.Show("Administrador registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GuardarColaborador(ModeloDeDatos.Usuarios usuarioOB)
        {
            using (FileStream mUsuario = new FileStream(rutaUsuarios, FileMode.Append))
            using (BinaryWriter Escritor = new BinaryWriter(mUsuario, Encoding.UTF8))
            {
                Escritor.Write(usuarioOB.Usuario);
                Escritor.Write(usuarioOB.Contraseña);
                Escritor.Write("Colaborador");
                Escritor.Write(usuarioOB.Estado);
            }

            MessageBox.Show("Colaborador registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GuardarDetallesCliente(ModeloDeDatos.Usuarios usuarioOB, DetallesCliente clienteOB)
        {
            // Guardar los datos del cliente en el archivo clientes.dat
            using (FileStream mCliente = new FileStream(rutaClientes, FileMode.Append))
            using (BinaryWriter Escritor = new BinaryWriter(mCliente, Encoding.UTF8))
            {
                Escritor.Write(usuarioOB.Usuario);
                Escritor.Write(usuarioOB.Contraseña);
                Escritor.Write(clienteOB.Nombre);
                Escritor.Write(clienteOB.Apellido);
                Escritor.Write(clienteOB.Correo);
                Escritor.Write(clienteOB.Telefono);
                Escritor.Write(usuarioOB.Rol);
                Escritor.Write(usuarioOB.Estado);
            }

            MessageBox.Show("Cliente registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
