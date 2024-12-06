using BunBunHub.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class InformacionCliente : Form
    {
        private List<DetallesCliente> listaClientes { get; set; }
        public static string rutaClientes = "cliente.dat";
        private List<Usuarios> listaUsuarios { get; set; }
        public static string rutaUsuarios = "usuario.dat";

        private DetallesCliente clienteOriginal; // Para almacenar los datos originales del cliente
        public string Usuario { get; set; }

        public InformacionCliente()
        {
            InitializeComponent();
            listaClientes = new List<DetallesCliente>();
            listaUsuarios = new List<Usuarios>();
            GestionDeArchivos archivo = new GestionDeArchivos();
            listaClientes = archivo.CargarClientes(rutaClientes);
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            // Verificar si el botón "Guardar" está habilitado (lo que indica que se están realizando cambios)
            if (btnGuardar.Enabled)
            {
                // Mostrar un cuadro de mensaje para confirmar si el usuario quiere salir sin guardar
                DialogResult resultado = MessageBox.Show("Estás actualizando los datos de perfil. ¿Quieres salir sin guardar?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", no se cierra el formulario
                }
            }

            // Si no hay cambios pendientes o el usuario eligió salir, cerrar el formulario
            PanelCliente panelCliente = new PanelCliente();
            panelCliente.Show();
            this.Close(); // Cerrar el formulario actual
        }

        private void InformacionCliente_Load(object sender, EventArgs e)
        {

            // Buscar el pedido por IdPedido
            DetallesCliente cliente = listaClientes.FirstOrDefault(p => p.Usuario == Usuario);

            // Guardamos el pedido original para restaurarlo si es necesario
            clienteOriginal = cliente;

            if (cliente != null)
            {
                // Cargar los datos del cliente en los controles
                txtUsuario.Text = cliente.Usuario;
                txtContraseña.Text = cliente.Contraseña;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEdad.Text = cliente.Edad.ToString();
                txtCorreo.Text = cliente.Correo;
                txtTelefono.Text = cliente.Telefono.ToString();
            }
            else
            {
                MessageBox.Show("No se encontró el cliente con ese nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que quieres eliminar tu perfil? Ya no tendrás acceso al sistema.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            );

            // Si el usuario confirma la eliminación
            if (resultado == DialogResult.Yes)
            {
                // Eliminar el cliente de la lista de detalles de clientes
                DetallesCliente clienteAEliminar = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);
                if (clienteAEliminar != null)
                {
                    listaClientes.Remove(clienteAEliminar);
                }

                // Eliminar el usuario de la lista de usuarios
                Usuarios usuarioAEliminar = listaUsuarios.FirstOrDefault(u => u.Usuario == Usuario);
                if (usuarioAEliminar != null)
                {
                    listaUsuarios.Remove(usuarioAEliminar);
                }

                // Guardar las listas actualizadas (sin el usuario ni el cliente eliminado)
                GestionDeArchivos.GuardarClientes(listaClientes, rutaClientes);
                GestionDeArchivos.GuardarUsuarios(listaUsuarios, rutaUsuarios);

                // Cerrar todos los formularios previos
                Application.OpenForms.Cast<Form>().ToList().ForEach(form => form.Close());

                // Mostrar mensaje de éxito
                MessageBox.Show("Tu perfil ha sido eliminado exitosamente. BunBunHub se despide.", "Perfil eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirigir al formulario de inicio de sesión
                Principal iniciarSesion = new Principal();
                iniciarSesion.Show();
            }
            else
            {
                // Si el usuario no confirma, no se hace nada
                return;
            }

            this.Close();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblValidarTelefono.ForeColor = System.Drawing.Color.Green;
            lblValidarTelefono.Text = "Número de teléfono válido";

            // Buscar el pedido por IdPedido
            DetallesCliente cliente = listaClientes.FirstOrDefault(p => p.Usuario == Usuario);

            if (cliente != null)
            {
                // Habilitar los campos editables solo si el pedido no está Completado o Cancelado
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtEdad.Enabled = true;
                txtCorreo.Enabled = true;
                txtTelefono.Enabled = true;

                // Cambiar la propiedad ReadOnly para permitir la edición
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtEdad.ReadOnly = false;
                txtCorreo.ReadOnly = false;
                txtTelefono.ReadOnly = false;

                // Desactivar el botón "Actualizar"
                btnEditar.Enabled = false;

                // Activar los botones "Guardar" y "Cancelar"
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró el perfil de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerrar el formulario si no se encuentra el pedido
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
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

            if (lblValidarCorreo.Text == "*El correo debe de contener @ y . para ser válido")
            {
                MessageBox.Show("El correo ingresado no es válido. Verifique e intente nuevamente.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (lblValidarTelefono.Text == "")
            {
                MessageBox.Show("No se ha ingresado un número de teléfono. Por favor, verifique e intente nuevamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (lblValidarTelefono.Text != "Número de teléfono válido")
            {
                MessageBox.Show("El número de teléfono no es válido. Por favor, verifique e intente nuevamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
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

            DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);
            if (cliente != null)
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Edad = int.Parse(txtEdad.Text);
                cliente.Correo = txtCorreo.Text;
                cliente.Telefono = int.Parse(txtTelefono.Text);
            }

            GestionDeArchivos.GuardarClientes(listaClientes, rutaClientes);

            // Desactivar los campos y restaurar el estado inicial
            DesactivarCampos();

            // Reactivar el botón "Actualizar"
            btnEditar.Enabled = true;

            // Desactivar los botones "Guardar" y "Cancelar"
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            MessageBox.Show("Los cambios se han guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DesactivarCampos()
        {
            // Desactivar los campos de entrada
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEdad.Enabled = false;
            txtCorreo.Enabled = false;
            txtTelefono.Enabled = false;

            // Configurar los campos como ReadOnly
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtEdad.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTelefono.ReadOnly = true;

            lblValidarTelefono.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de mensaje para confirmar si el usuario quiere cancelar la actualización
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que quieres cancelar la actualización del perfil?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return; // Si el usuario selecciona "No", no se cancela y el formulario permanece abierto
            }

            // Restaurar los datos originales del pedido si el usuario confirma la cancelación
            if (clienteOriginal != null)
            {
                // Restaurar los datos del cliente
                DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEdad.Text = cliente.Edad.ToString();
                    txtCorreo.Text = cliente.Correo;
                    txtTelefono.Text = cliente.Telefono.ToString();
                }

                // Restaurar los datos del pedido
                txtNombre.Text = clienteOriginal.Nombre;
                txtApellido.Text = clienteOriginal.Apellido;
                txtEdad.Text = clienteOriginal.Edad.ToString();
                txtCorreo.Text = clienteOriginal.Correo;
                txtTelefono.Text = clienteOriginal.Telefono.ToString();
            }

            // Desactivar los campos y restaurar el estado inicial
            DesactivarCampos();

            // Reactivar el botón "Actualizar"
            btnEditar.Enabled = true;

            // Desactivar los botones "Guardar" y "Cancelar"
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void letrasEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, el retroceso (Backspace) y los espacios
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void sinEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un espacio
            if (e.KeyChar == ' ')
            {
                // Evitar que el espacio sea ingresado
                e.Handled = true;
            }
        }

        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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
            else if (txtTelefono.Enabled == false)
            {
                lblValidarTelefono.Text = "";
            }
            else
            {
                // Si el teléfono es válido
                lblValidarTelefono.ForeColor = System.Drawing.Color.Green;
                lblValidarTelefono.Text = "Número de teléfono válido";
            }
        }
    }
}
