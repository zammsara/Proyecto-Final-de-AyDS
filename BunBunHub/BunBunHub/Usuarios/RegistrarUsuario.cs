using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Usuarios
{
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
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
                    // Habilitar los GroupBox si el rol es "Cliente"
                    grpDatosCliente.Enabled = true;
                    grpContacto.Enabled = true;
                }
                else
                {
                    // Deshabilitar los GroupBox si el rol no es "Cliente"
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
            GestionUsuario gestionUsuario = new GestionUsuario();
            gestionUsuario.Show();
            this.Hide();
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
                    // Si el número es válido, no hacemos nada adicional
                }
                else
                {
                    // Mostrar un mensaje de advertencia si el primer dígito no es válido
                    MessageBox.Show("El número de teléfono debe comenzar con 8, 9, 7, 6 (para móviles) o 2 (para fijos).",
                                    "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Clear();  // Limpiar el campo de entrada
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

        private void tbDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar sin registrar?", "Limpiar Formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            txtTelefono.Clear();
            txtUsuarioNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            tbDireccion.Clear();

            // Limpiar los ComboBox
            cmbRol.SelectedIndex = -1; // Restablece la selección
            cmbEstado.SelectedIndex = -1; // Restablece la selección
        }
    }
}
