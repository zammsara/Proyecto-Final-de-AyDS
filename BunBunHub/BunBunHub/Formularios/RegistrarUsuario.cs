using BunBunHub.Dao;
using BunBunHub.Modelos;
using Microsoft.Win32;
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
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class RegistrarUsuario : Form
    {
        private List<Usuarios> listaUsuarios = new List<Usuarios>();
        private List<DetallesCliente> listaClientes = new List<DetallesCliente>();
        public static string rutaUsuarios = "usuario.dat";
        public static string rutaClientes = "cliente.dat";

        public RegistrarUsuario()
        {
            InitializeComponent();
            GestionDeArchivos archivo = new GestionDeArchivos();

            // Cargar los registros de los roles
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);
            listaClientes = archivo.CargarClientes(rutaClientes);
        }

        private void tlsbtnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los controles tengan información
            if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioNombre.Focus(); // Coloca el cursor en el campo vacío
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus(); // Coloca el cursor en el campo vacío
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus(); // Coloca el cursor en el campo vacío
                return;
            }

            // Verificar que los ComboBox tengan un valor seleccionado
            if (cmbRol.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return;
            }

            // Validar las condiciones que se deben cumplir antes de guardar
            if (lblValidarUsuarioNuevo.Text == "*Nombre de usuario no disponible")
            {
                MessageBox.Show("El nombre de usuario ingresado ya está en uso. Selecciona otro nombre", "Usuario no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioNombre.Focus();
                return;
            }

            if (lblValidacion.Text != "Contraseña Válida")
            {
                MessageBox.Show("La contraseña no es válida", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            if (lblConfirmación.Text != "Las contraseñas cohinciden")
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifique la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus();
                return;
            }

            string rolSeleccionado = cmbRol.SelectedItem.ToString(); //obtener el rol seleccionado

            //Si el rol es Cliente, verificar que los campos adicionales estén llenos
            if (rolSeleccionado == "Cliente")
            {
                if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuarioNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEdad.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEdad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                if (lblValidarTelefono.Text != "Número de teléfono válido")
                {
                    MessageBox.Show("El número de teléfono no es válido. Por favor, verifique e intente nuevamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                if (lblValidarCorreo.Text == "*El correo debe de contener @ y . para ser válido")
                {
                    MessageBox.Show("El correo ingresado no es válido. Verifique e intente nuevamente.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                // Validar edad (mayor de 18 años)
                if (int.TryParse(txtEdad.Text, out int edadValida))
                {
                    if (edadValida < 18)
                    {
                        MessageBox.Show("El cliente debe ser mayor de 18 años.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad para corregir
                        return;
                    }
                    else if (edadValida > 100)
                    {
                        MessageBox.Show("Por favor, ingresa una edad válida.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad si no es un número válido
                        return;
                    }
                }
            }

            // Crear el nuevo registro
            if (rolSeleccionado == "Administrador" || rolSeleccionado == "Colaborador")
            {
                string usuario = txtUsuarioNombre.Text;
                string contraseña = txtContraseña.Text;
                rolSeleccionado = cmbRol.SelectedItem.ToString(); //obtener el rol seleccionado
                string estado = cmbEstado.SelectedItem.ToString();
                Usuarios nuevoUsuario = new Usuarios(usuario, contraseña, rolSeleccionado, estado);


                listaUsuarios.Add(nuevoUsuario);
                GestionDeArchivos.GuardarUsuarios(listaUsuarios, rutaUsuarios);
                MessageBox.Show("Usuario guardado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rolSeleccionado == "Cliente")
            {
                string usuario = txtUsuarioNombre.Text;
                string contraseña = txtContraseña.Text;
                rolSeleccionado = cmbRol.SelectedItem.ToString(); //obtener el rol seleccionado
                string estado = cmbEstado.SelectedItem.ToString();

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int edad = int.Parse(txtEdad.Text);
                string correo = txtCorreo.Text;
                int telefono = int.Parse(txtTelefono.Text);

                // Crear el nuevo usuario y cliente
                Usuarios nuevoUsuario = new Usuarios(usuario, contraseña, rolSeleccionado, estado);
                DetallesCliente nuevoCliente = new DetallesCliente(usuario, contraseña, nombre, apellido, edad, correo, telefono, estado);

                // Agregar el nuevo usuario y cliente a sus respectivas listas
                listaUsuarios.Add(nuevoUsuario);
                listaClientes.Add(nuevoCliente);

                // Guardar los datos en los archivos correspondientes
                GestionDeArchivos.GuardarUsuarios(listaUsuarios, rutaUsuarios);  // Guardar usuarios
                GestionDeArchivos.GuardarClientes(listaClientes, rutaClientes);  // Guardar clientes

                MessageBox.Show("Cliente guardado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimpiarCampos();
            txtUsuarioNombre.Focus();
        }

        private void tlsbtnVisualizarRegistros_Click(object sender, EventArgs e)
        {
            bool hayDatos = false;

            // Verificar los controles más importantes
            if (!string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) || !string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) || !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) || !string.IsNullOrWhiteSpace(txtCorreo.Text) || !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbRol.SelectedIndex != -1 || cmbEstado.SelectedIndex != -1)
            {
                hayDatos = true;
            }

            if (hayDatos)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea visualizar los registros? Los datos en los controles no se guardarán.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ActualizarRegistro actualizarRegistro = new ActualizarRegistro();
                    actualizarRegistro.listaUsuarios = listaUsuarios;
                    actualizarRegistro.listaClientes = listaClientes;
                    actualizarRegistro.CargarDatos();
                    actualizarRegistro.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, solo ir sin mostrar mensaje
                ActualizarRegistro actualizarRegistro = new ActualizarRegistro();
                actualizarRegistro.listaUsuarios = listaUsuarios;
                actualizarRegistro.listaClientes = listaClientes;
                actualizarRegistro.CargarDatos();
                actualizarRegistro.Show();
                this.Hide();
            }
        }

        private void tlsbtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

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
            grpDatosCliente.Enabled = false;
            grpContacto.Enabled = false;
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

        // Restricción de los textBox
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
            // Permitir letras, el retroceso (Backspace) y los espacios
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
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
            else
            {
                // Convierte la tecla presionada a minúscula y la asigna al TextBox
                e.KeyChar = Char.ToLower(e.KeyChar);
            }
        }
        private void sinEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un espacio
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Impide que el espacio sea ingresado
            }
        }
        private void seleccionar_enter(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }
        private void sinEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un espacio
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  // Bloquear la entrada de espacios
            }
            else
            {
                // Convertir la tecla a minúscula antes de ingresar el texto
                e.KeyChar = char.ToLower(e.KeyChar);
            }
        }

        // Validación de datos
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
            else if (contraseña.Length > 12)
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
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrEmpty(correo))
            {
                lblValidarCorreo.Text = " ";
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblValidarCorreo.ForeColor = System.Drawing.Color.Firebrick;
                lblValidarCorreo.Text = "*El correo debe de contener @ y . para ser válido";
            }
            else
            {
                lblValidarCorreo.Text = " ";
            }
        }
        private void txtUsuarioNombre_TextChanged(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuarioNombre.Text.Trim().ToLower(); // Convertir a minúsculas para una comparación insensible a mayúsculas

            // Validar si el nombre de usuario tiene menos de 6 caracteres
            if (nombreUsuario.Length < 6 && nombreUsuario.Length > 0)
            {
                lblValidarUsuarioNuevo.ForeColor = System.Drawing.Color.Red;
                lblValidarUsuarioNuevo.Text = "*El nombre de usuario es muy corto";
                return; // Salir del método si el nombre de usuario es muy corto
            }

            // Verificar que el nombre de usuario no exista ya
            bool usuarioExistente = listaUsuarios.Any(u => u.Usuario.ToLower() == nombreUsuario);

            if (usuarioExistente)
            {
                lblValidarUsuarioNuevo.ForeColor = System.Drawing.Color.Red;
                lblValidarUsuarioNuevo.Text = "*Nombre de usuario no disponible";
            }
            else
            {
                lblValidarUsuarioNuevo.Text = ""; // Limpiar el mensaje si el nombre de usuario es válido
            }
        }

        // Lógica de navegación entre forms
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnVolver_Click(object sender, EventArgs e)
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
        private void btnPanelControl_Click(object sender, EventArgs e)
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
    }
}
