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
    public partial class ActualizarCliente : Form
    {
        public List<DetallesCliente> listaClientes { get; set; }
        public static string rutaClientes = "cliente.dat";
        public List<Usuarios> listaUsuarios { get; set; }
        public static string rutaUsuarios = "usuario.dat";

        private DetallesCliente clienteSeleccionado;  // Variable para almacenar el cliente seleccionado
        public ActualizarCliente()
        {
            InitializeComponent();
            listaUsuarios = new List<Usuarios>();
            listaClientes = new List<DetallesCliente>();
            GestionDeArchivos archivo = new GestionDeArchivos();
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);
            listaClientes = archivo.CargarClientes(rutaClientes);

            grpActualizarCliente.Enabled = false;
        }

        //Visualizar registros en los DataGridView
        public void CargarDatos()
        {
            // Verificar si hay datos en listaClientes
            if (listaClientes != null && listaClientes.Count > 0)
            {
                dgvNula.DataSource = listaClientes;
            }
            else
            {
                MessageBox.Show("No hay clientes para mostrar.");
            }
        }
        private void ActualizarCliente_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaUsuarios = gestionArchivos.CargarUsuarios(RegistrarUsuario.rutaUsuarios);
            listaClientes = gestionArchivos.CargarClientes(RegistrarUsuario.rutaClientes);

            CargarDatos();
        }

        public void ActualizarDatos(List<Usuarios> listaUsuarios, List<DetallesCliente> listaClientes)
        {
            //Asegurar de que las listas no sean nulas antes de asignarlas a los DataGridViews
            if (listaClientes != null && listaClientes.Count > 0)
            {
                dgvNula.DataSource = listaClientes;
            }
        }

        private void ActualizarDataGridView()
        {
            dgvNula.DataSource = null;
            dgvNula.DataSource = listaClientes;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar si el cuadro de texto está vacío
            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBusqueda.Focus();
                return;
            }

            // Obtener el ID ingresado en el cuadro de texto
            string UsuarioBusqueda = txtBusqueda.Text.Trim();

            // Buscar el pedido en la lista
            DetallesCliente clienteSeleccionado = listaClientes.FirstOrDefault(p => p.Usuario == UsuarioBusqueda);

            if (clienteSeleccionado != null)
            {
                // Si se encuentra el pedido, seleccionarlo en el DataGridView
                foreach (DataGridViewRow row in dgvNula.Rows)
                {
                    if (row.DataBoundItem is DetallesCliente cliente && cliente.Usuario == UsuarioBusqueda)
                    {
                        row.Selected = true; // Seleccionar la fila encontrada
                        dgvNula.FirstDisplayedScrollingRowIndex = row.Index; // Asegurar que sea visible
                        txtBusqueda.Focus();
                        return;
                    }
                }
            }
            else
            {
                // Si no se encuentra el pedido, mostrar mensaje de error
                MessageBox.Show($"No se encontró ningún cliente con el usuario '{UsuarioBusqueda}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBusqueda.Clear();
                txtBusqueda.Focus();
            }
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Comprobar si el botón de guardar está habilitado (indicando que se están haciendo cambios)
            if (btnGuardarCambiosCliente.Enabled)
            {
                // Mostrar un mensaje de confirmación antes de volver
                var resultado = MessageBox.Show("Actualmente estás actualizando un registro. ¿Deseas volver sin guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Si el usuario selecciona "Sí", se regresa sin guardar
                if (resultado == DialogResult.Yes)
                {
                    GestionClientes gestionClientes = new GestionClientes();
                    gestionClientes.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si el botón de guardar está deshabilitado, simplemente vuelve al formulario sin preguntar
                GestionClientes gestionClientes = new GestionClientes();
                gestionClientes.Show();
                this.Hide();
            }

        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            // Comprobar si el botón de guardar está habilitado (indicando que se están haciendo cambios)
            if (btnGuardarCambiosCliente.Enabled)
            {
                var resultado = MessageBox.Show("Actualmente estás actualizando un registro. ¿Deseas volver sin guardar?", "Confirmar", MessageBoxButtons.YesNo,  MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    PanelColaborador panelColaborador = new PanelColaborador();
                    panelColaborador.Show();
                    this.Hide();
                }
            }
            else
            {
                PanelColaborador panelColaborador = new PanelColaborador();
                panelColaborador.Show();
                this.Hide();
            }
        }

        private void tlsbtnEditarCliente_Click(object sender, EventArgs e)
        {
            
            // Verificar que haya una fila seleccionada en dgvClientes
            if (dgvNula.SelectedRows.Count > 0)
            {
                // Obtener el índice del cliente seleccionado
                int clienteSeleccionadoIndex = dgvNula.SelectedRows[0].Index;

                // Obtener los datos del cliente
                DetallesCliente cliente = listaClientes[clienteSeleccionadoIndex];

                // Cargar los datos del cliente en los controles
                txtEditarNombre.Text = cliente.Nombre;  // Mostrar solo el nombre del cliente
                txtEditarApellido.Text = cliente.Apellido;
                txtEditarEdad.Text = cliente.Edad.ToString();
                txtEditarCorreo.Text = cliente.Correo;
                txtEditarTelefono.Text = cliente.Telefono.ToString();
                cmbEditarEstadoCliente.SelectedItem = cliente.Estado;

                // Rellenar el nombre de usuario en el nuevo TextBox
                txtEditarUsuario.Text = cliente.Usuario;  // Asignamos el nombre de usuario al nuevo TextBox

                // Activar los controles necesarios para la edición
                grpActualizarCliente.Enabled = true;
                grpDatosCliente.Enabled = true;
                grpContacto.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eliminarCliente_Click(object sender, EventArgs e)
        {
            
            // Verificar si hay una fila seleccionada en dgvClientes
            if (dgvNula.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del cliente seleccionado en dgvClientes
                    int clienteSeleccionadoIndex = dgvNula.SelectedRows[0].Index;

                    // Obtener el cliente desde la lista
                    DetallesCliente cliente = listaClientes[clienteSeleccionadoIndex];

                    // Eliminar el cliente de la lista de clientes
                    listaClientes.RemoveAt(clienteSeleccionadoIndex);

                    // Eliminar el usuario correspondiente de la lista de usuarios
                    Usuarios usuarioRelacionado = listaUsuarios.FirstOrDefault(u => u.Usuario == cliente.Usuario);
                    if (usuarioRelacionado != null)
                    {
                        listaUsuarios.Remove(usuarioRelacionado);
                    }

                    // Guardar los cambios en los archivos
                    GestionDeArchivos.GuardarUsuarios(listaUsuarios, RegistrarUsuario.rutaUsuarios);
                    GestionDeArchivos.GuardarClientes(listaClientes, RegistrarUsuario.rutaClientes);

                    // Actualizar los DataGridViews para reflejar los cambios
                    ActualizarDataGridView();  // Actualiza dgvUsuarios
                    dgvNula.DataSource = null;  // Limpiar el DataGridView de clientes
                    dgvNula.DataSource = listaClientes;  // Cargar la lista actualizada de clientes

                    MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarCambiosCliente_Click(object sender, EventArgs e)
        {
            // Validar si el correo es válido
            if (lblValidarCorreo.Text == "*El correo debe de contener @ y . para ser válido")
            {
                MessageBox.Show("El correo no es válido. Asegúrese de que contenga '@' y '.'", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditarCorreo.Focus();
                return;
            }

            // Validar si el teléfono es válido
            if (lblValidarTelefono.Text != "Número de teléfono válido")
            {
                MessageBox.Show("El número de teléfono no es válido. Por favor ingrese un número válido.", "Error de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditarTelefono.Focus();
                return;
            }

            // Validar si los campos están completos
            if (string.IsNullOrEmpty(txtEditarNombre.Text) || string.IsNullOrEmpty(txtEditarApellido.Text) || string.IsNullOrEmpty(txtEditarEdad.Text) ||
                string.IsNullOrEmpty(txtEditarCorreo.Text) || string.IsNullOrEmpty(txtEditarTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditarNombre.Focus();
                return;
            }

            // Validar si la edad es válida (debe ser entre 18 y 100 años)
            if (int.TryParse(txtEditarEdad.Text, out int edad))
            {
                if (edad < 18 || edad > 100)
                {
                    MessageBox.Show("La edad debe ser mayor o igual a 18 y menor o igual a 100.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEditarEdad.Focus();  // Mover el foco al campo de edad
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditarEdad.Focus();  // Mover el foco al campo de edad
                return;
            }

            // Obtener el nombre de usuario desde el TextBox txtEditarUsuario
            string nombreUsuario = txtEditarUsuario.Text;  // Usamos el valor directamente desde el TextBox de usuario

            // Obtener el cliente seleccionado usando el nombre de usuario
            DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == nombreUsuario);
            if (cliente != null)
            {
                // Actualizar los datos del cliente
                cliente.Nombre = txtEditarNombre.Text;  // Nombre del cliente
                cliente.Apellido = txtEditarApellido.Text;
                cliente.Edad = edad;  // Asignar la edad validada
                cliente.Correo = txtEditarCorreo.Text;
                cliente.Telefono = int.Parse(txtEditarTelefono.Text);
                cliente.Estado = cmbEditarEstadoCliente.SelectedItem.ToString();  // Estado del cliente

                // Si el cliente tiene un usuario asociado, actualizar los datos del usuario también
                Usuarios usuarioRelacionado = listaUsuarios.FirstOrDefault(u => u.Usuario == cliente.Usuario);
                if (usuarioRelacionado != null)
                {
                    usuarioRelacionado.Usuario = cliente.Usuario;  // Asegúrate de que el nombre de usuario también se actualice si es necesario
                    usuarioRelacionado.Estado = cliente.Estado;  // Actualizar el estado si es necesario
                }

                // Guardar los cambios en los archivos
                GestionDeArchivos.GuardarUsuarios(listaUsuarios, RegistrarUsuario.rutaUsuarios);
                GestionDeArchivos.GuardarClientes(listaClientes, RegistrarUsuario.rutaClientes);

                // Actualizar los DataGridViews para reflejar los cambios
                ActualizarDataGridView();  // Actualiza el DataGridView de usuarios
                dgvNula.DataSource = null;  // Limpiar el DataGridView de clientes
                dgvNula.DataSource = listaClientes;  // Recargar la lista actualizada de clientes

                MessageBox.Show("Datos del cliente actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos y deshabilitar los controles
                LimpiarCamposCliente();
                grpActualizarCliente.Enabled = false;
            }
            else
            {
                MessageBox.Show("El cliente no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCamposCliente()
        {
            txtEditarNombre.Clear();
            txtEditarApellido.Clear();
            txtEditarEdad.Clear();
            txtEditarCorreo.Clear();
            txtEditarTelefono.Clear();
            cmbEditarEstadoCliente.SelectedIndex = -1;
            
        }

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de mensaje de confirmación antes de cancelar la edición
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar la actualización de los datos del cliente?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige 'Sí', proceder con la cancelación
            if (resultado == DialogResult.Yes)
            {
                // Limpiar los campos de texto
                LimpiarCamposCliente();

                // Deshabilitar los controles del GroupBox para evitar más ediciones
                grpActualizarCliente.Enabled = false;
                grpDatosCliente.Enabled = false;
                grpContacto.Enabled = false;
            }
        }

        private void letras_keyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un número o un espacio
            if (char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  // Bloquear la entrada de números y espacios
            }
        }

        private void seleccionar_click(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }
        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un número o un carácter especial
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;  // Bloquear la entrada de números y caracteres especiales
            }
        }

        private void soloNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado no es un número ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear la entrada de cualquier otro carácter
            }
        }

        private void txtEditarCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtEditarCorreo.Text;

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

        private void txtEditarTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtEditarTelefono.Text;

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
    }
}
