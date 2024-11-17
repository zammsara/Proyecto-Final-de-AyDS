using BunBunHub.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModeloDeDatos;

namespace BunBunHub.Formularios
{
    public partial class RegistrarUsuario : Form
    {
        public static string rutaUsuarios = "usuarios.dat";
        public static string rutaClientes = "clientes.dat";
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        //salir del proyecto
        private void btnCerrarSistema_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //volver al forms anterior
        private void toolbtnvolver_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;

            // Verificar los controles más importantes
            if (!string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbRol.SelectedIndex != -1 ||
                cmbEstado.SelectedIndex != -1)
            {
                hayDatos = true;
            }

            // Si hay datos en algún control, mostrar el mensaje
            if (hayDatos)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea volver? Los datos no se guardarán.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GestionUsuarios gestionUsuarios = new GestionUsuarios();
                    gestionUsuarios.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, solo volver sin mostrar mensaje
                GestionUsuarios gestionUsuariosSinMensaje = new GestionUsuarios();
                gestionUsuariosSinMensaje.Show();
                this.Hide();
            }
        }

        //volver al panel de administradores
        private void home_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;

            // Verificar los controles más importantes
            if (!string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbRol.SelectedIndex != -1 ||
                cmbEstado.SelectedIndex != -1)
            {
                hayDatos = true;
            }

            // Si hay datos en algún control, mostrar el mensaje
            if (hayDatos)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea volver? Los datos no se guardarán.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    PanelAdministrador panelAdministrador = new PanelAdministrador();
                    panelAdministrador.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, solo volver sin mostrar mensaje
                PanelAdministrador panelAdministrador = new PanelAdministrador();
                panelAdministrador.Show();
                this.Hide();
            }
        }

        // Limpiar Controles
        private void toolBtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtTelefono.Clear();
                txtUsuarioNombre.Clear();
                txtContraseña.Clear();
                txtConfirmarContraseña.Clear();
                txtCorreo.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtEdad.Clear();
                lblConfirmación.Text = "";
                lblValidacion.Text = "";
                lblValidarTelefono.Text = "";

                // Limpiar los ComboBox
                cmbRol.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1; 
            }
        }

        // Guardar Registro
        private void toolbtnGuardar_Click(object sender, EventArgs e)
        { 
            // Verificar que todos los controles tengan información
            if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que los ComboBox tengan un valor seleccionado
            if (cmbRol.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar las condiciones que deben cumplirse antes de guardar
            if (lblValidacion.Text != "Contraseña Válida")
            {
                MessageBox.Show("La contraseña no es válida", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblConfirmación.Text != "Las contraseñas cohinciden")
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifique la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = txtUsuarioNombre.Text;
            string contraseña = txtContraseña.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            string rol = cmbRol.Text; // Administrador, Colaborador, Cliente
            string estado = cmbEstado.Text; // Activo, Inactivo

            // Si el rol es Cliente, verificar que los campos adicionales estén llenos
            if (rol == "Cliente")
            {
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(edad) ||
                    string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(telefono))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lblValidarTelefono.Text != "Número de teléfono válido")
                {
                    MessageBox.Show("El número de teléfono no es válido. Por favor, verifique el número.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar edad (mayor de 18 años)
                if (int.TryParse(txtEdad.Text, out int edadValida))
                {
                    if (edadValida < 18)
                    {
                        MessageBox.Show("El cliente debe ser mayor de 18 años.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad para corregir
                        return;
                    }
                    else if (edadValida > 100)
                    {
                        MessageBox.Show("Por favor, ingresa una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad si no es un número válido
                        return;
                    }
                }
            }

            ModeloDeDatos.Usuarios usuarioOB = new ModeloDeDatos.Usuarios(usuario, contraseña, rol, estado);
            ModeloDeDatos.DetallesCliente ClienteOB = null;

            // Si el rol es "Cliente", crear el objeto DetallesCliente
            if (rol == "Cliente")
            {
                ClienteOB = new DetallesCliente(usuario, contraseña, nombre, apellido, int.Parse(edad), correo, int.Parse(telefono), estado);
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

            // Deshabilitar los controles después de registrar un cliente
            if (rol == "Cliente")
            {
                grpDatosCliente.Enabled = false;
                grpContacto.Enabled = false;
            }

            // Limpiar los campos después de guardar
            LimpiarCampos();
            txtUsuarioNombre.Focus();
        }

        // Método para limpiar los campos
        private void LimpiarCampos()
        {
            txtTelefono.Clear();
            txtUsuarioNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            lblConfirmación.Text = "";
            lblValidacion.Text = "";
            lblValidarTelefono.Text = "";

            // Limpiar los ComboBox
            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
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
                Escritor.Write(clienteOB.Edad);
                Escritor.Write(clienteOB.Correo);
                Escritor.Write(clienteOB.Telefono);
                Escritor.Write(usuarioOB.Rol);
                Escritor.Write(usuarioOB.Estado);
            }

            MessageBox.Show("Cliente registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        // Validación de Datos
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            string contraseña = txtContraseña.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                lblValidacion.Text = "";
                return;
            }

            if (contraseña.Length < 8)
            {
                lblValidacion.ForeColor = System.Drawing.Color.Red;
                lblValidacion.Text = "*La contraseña es muy corta";
            }
            else if (contraseña.Length > 10)
            {
                lblValidacion.ForeColor = System.Drawing.Color.Red;
                lblValidacion.Text = "*La contraseña es muy larga";
            }
            // Validación de símbolos permitidos
            else if (!Regex.IsMatch(contraseña, @"^[a-zA-Z0-9*_!/&]+$"))
            {
                lblValidacion.ForeColor = System.Drawing.Color.Red;
                lblValidacion.Text = "*Solo se permiten simbolos *, _, !, / o &";
            }
            // Si la contraseña es válida
            else
            {
                lblValidacion.ForeColor = System.Drawing.Color.Green;
                lblValidacion.Text = "Contraseña Válida";
            }
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            // Si el TextBox de confirmar contraseña está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                lblConfirmación.Text = "";
                return;
            }

            if (txtConfirmarContraseña.Text != txtContraseña.Text)
            {
                lblConfirmación.ForeColor = System.Drawing.Color.Red;
                lblConfirmación.Text = "*Las contraseñas no coinciden";
            }
            else
            {
                lblConfirmación.ForeColor = System.Drawing.Color.Green;
                lblConfirmación.Text = "Las contraseñas cohinciden";
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(telefono))
            {
                lblValidarTelefono.Text = "";
                return;
            }

            // Verificar si el teléfono tiene exactamente 8 dígitos
            if (telefono.Length < 8)
            {
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*Número de teléfono inválido";
            }
            else if (telefono.Length > 8)
            {
                // Si el número tiene más de 8 dígitos, limitamos la entrada a los primeros 8
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*Número de teléfono inválido";
            }
            // Verificar que el primer dígito sea válido (8, 5, 7, 2)
            else if (telefono[0] != '8' && telefono[0] != '5' && telefono[0] != '7' && telefono[0] != '2')
            {
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*El número debe comenzar por 8, 5, 7 ó 2.";
            }
            else
            {
                // Si el teléfono es válido
                lblValidarTelefono.ForeColor = System.Drawing.Color.Green;
                lblValidarTelefono.Text = "Número de teléfono válido";
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla presionada es un espacio (código ASCII 32), no se permite
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
    }
}
