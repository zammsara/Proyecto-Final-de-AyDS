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
    public partial class ActualizarRegistro : Form
    {
        public List<Usuarios> listaUsuarios {  get; set; }
        public List<DetallesCliente> listaClientes { get; set; }

        private Usuarios usuarioSeleccionado; // Definir la variable a nivel de clase
        public ActualizarRegistro()
        {
            InitializeComponent();
            listaUsuarios = new List<Usuarios>();
            listaClientes = new List<DetallesCliente>();

            // Deshabilitar GroupBoxs al cargar el formulario
            grpCredenciales.Enabled = false;
            grpActualizarCliente.Enabled = false;
        }

        //Visualizar registros en los DataGridView
        public void CargarDatos()
        {
            //Asegurarse de que las listas no sean nulas antes de asignarlas a los DataGridViews
            if (listaUsuarios != null && listaUsuarios.Count > 0)
            {
                dgvUsuarios.DataSource = listaUsuarios;
            }
            if (listaClientes != null && listaClientes.Count > 0)
            {
                dgvClientes.DataSource = listaClientes;
            }

        }
        public void ActualizarDatos(List<Usuarios> listaUsuarios, List<DetallesCliente> listaClientes)
        {
            //Asegurar de que las listas no sean nulas antes de asignarlas a los DataGridViews
            if (listaUsuarios != null && listaUsuarios.Count > 0)
            {
                dgvUsuarios.DataSource = listaUsuarios;
            }
            if (listaClientes != null && listaClientes.Count > 0)
            {
                dgvClientes.DataSource = listaClientes;
            }
        }
        private void ActualizarDataGridView()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
        }
        private void ActualizarRegistro_Load(object sender, EventArgs e)
        {
            // Establecer el valor predeterminado como "Todos"
            cmbFiltro.SelectedIndex = 0;

            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaUsuarios = gestionArchivos.CargarUsuarios(RegistrarUsuario.rutaUsuarios);
            listaClientes = gestionArchivos.CargarClientes(RegistrarUsuario.rutaClientes);

            CargarDatos();
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
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    if (row.DataBoundItem is DetallesCliente cliente && cliente.Usuario == UsuarioBusqueda)
                    {
                        row.Selected = true; // Seleccionar la fila encontrada
                        dgvClientes.FirstDisplayedScrollingRowIndex = row.Index; // Asegurar que sea visible
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

        // Lógica de navegación entre forms
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tlsbtnVolver_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }
        private void tlsVolverBtn_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }
        private void tlsbtnNuevoRegistro_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }
        private void tlsbtnHome_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }
        private void tlsHomeBtn_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }
        private void tlsbtnPanelControl_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        // Funcionalidades
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del ComboBox
            string rolSeleccionado = cmbFiltro.SelectedItem.ToString();

            // Filtrar la lista de usuarios según el rol seleccionado
            List<Usuarios> usuariosFiltrados;

            if (rolSeleccionado == "Todos")
            {
                // Mostrar todos los usuarios si "Todos" está seleccionado
                usuariosFiltrados = listaUsuarios;
            }
            else
            {
                // Filtrar por el rol seleccionado
                usuariosFiltrados = listaUsuarios.Where(u => u.Rol == rolSeleccionado).ToList();
            }
            // Actualizar el DataGridView con los usuarios filtrados
            dgvUsuarios.DataSource = usuariosFiltrados;
        }

        // TabPage de Usuarios
        private void tlsbtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del usuario seleccionado
                    int usuarioSeleccionadoIndex = dgvUsuarios.SelectedRows[0].Index;

                    // Obtener el usuario que será eliminado
                    Usuarios usuario = listaUsuarios[usuarioSeleccionadoIndex];

                    // Eliminar el usuario de la lista de usuarios
                    listaUsuarios.RemoveAt(usuarioSeleccionadoIndex);

                    // Verificar si el usuario es un cliente
                    DetallesCliente clienteRelacionado = listaClientes.FirstOrDefault(c => c.Usuario == usuario.Usuario);
                    if (clienteRelacionado != null)
                    {
                        // Eliminar el cliente de la lista de clientes
                        listaClientes.Remove(clienteRelacionado);
                    }

                    // Guardar los cambios en los archivos
                    GestionDeArchivos.GuardarUsuarios(listaUsuarios, RegistrarUsuario.rutaUsuarios);
                    GestionDeArchivos.GuardarClientes(listaClientes, RegistrarUsuario.rutaClientes);

                    // Actualizar los DataGridViews para reflejar los cambios
                    ActualizarDataGridView(); // Actualiza el DataGridView de usuarios

                    // Limpiar el DataGridView de clientes y volver a cargar los datos actualizados
                    dgvClientes.DataSource = null;  // Limpiar la fuente de datos
                    dgvClientes.DataSource = listaClientes; // Volver a cargar la lista de clientes

                    MessageBox.Show("Usuario eliminado correctamente.", "Cambios guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del usuario seleccionado
                    int usuarioSeleccionadoIndex = dgvUsuarios.SelectedRows[0].Index;

                    // Obtener el usuario que será eliminado
                    Usuarios usuario = listaUsuarios[usuarioSeleccionadoIndex];

                    // Eliminar el usuario de la lista de usuarios
                    listaUsuarios.RemoveAt(usuarioSeleccionadoIndex);

                    // Verificar si el usuario es un cliente
                    DetallesCliente clienteRelacionado = listaClientes.FirstOrDefault(c => c.Usuario == usuario.Usuario);
                    if (clienteRelacionado != null)
                    {
                        // Eliminar el cliente de la lista de clientes
                        listaClientes.Remove(clienteRelacionado);
                    }

                    // Guardar los cambios en los archivos
                    GestionDeArchivos.GuardarUsuarios(listaUsuarios, RegistrarUsuario.rutaUsuarios);
                    GestionDeArchivos.GuardarClientes(listaClientes, RegistrarUsuario.rutaClientes);

                    // Actualizar los DataGridViews para reflejar los cambios
                    ActualizarDataGridView(); // Actualiza el DataGridView de usuarios

                    // Limpiar el DataGridView de clientes y volver a cargar los datos actualizados
                    dgvClientes.DataSource = null;  // Limpiar la fuente de datos
                    dgvClientes.DataSource = listaClientes; // Volver a cargar la lista de clientes

                    MessageBox.Show("Usuario eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tlsbtnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                int usuarioSeleccionadoIndex = dgvUsuarios.SelectedRows[0].Index;

                // Obtener el usuario desde la lista
                usuarioSeleccionado = listaUsuarios[usuarioSeleccionadoIndex];

                // Cargar los datos del usuario en los controles
                txtUsuarioNombre.Text = usuarioSeleccionado.Usuario;
                txtContraseña.Text = usuarioSeleccionado.Contraseña;
                txtConfirmarContraseña.Text = usuarioSeleccionado.Contraseña; // Confirmar contraseña igual a la original
                cmbEstado.SelectedItem = usuarioSeleccionado.Estado;

                // Activar el GroupBox para edición
                grpCredenciales.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                int usuarioSeleccionadoIndex = dgvUsuarios.SelectedRows[0].Index;

                // Obtener el usuario desde la lista
                usuarioSeleccionado = listaUsuarios[usuarioSeleccionadoIndex];

                // Cargar los datos del usuario en los controles
                txtUsuarioNombre.Text = usuarioSeleccionado.Usuario;
                txtContraseña.Text = usuarioSeleccionado.Contraseña;
                txtConfirmarContraseña.Text = usuarioSeleccionado.Contraseña; // Confirmar contraseña igual a la original
                cmbEstado.SelectedItem = usuarioSeleccionado.Estado;

                // Activar el GroupBox para edición
                grpCredenciales.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Fila no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar si los campos están completos
            if (string.IsNullOrEmpty(txtUsuarioNombre.Text) || string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtConfirmarContraseña.Text) || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si las contraseñas coinciden
            if (txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarContraseña.Focus();
                return;
            }

            // Actualizar los datos del usuario en la lista de usuarios
            usuarioSeleccionado.Usuario = txtUsuarioNombre.Text;
            usuarioSeleccionado.Contraseña = txtContraseña.Text;
            usuarioSeleccionado.Estado = cmbEstado.SelectedItem.ToString();

            // Verificar si el usuario es un cliente y reflejar los cambios en la lista de clientes
            if (usuarioSeleccionado.Rol == "Cliente")
            {
                // Buscar el cliente relacionado en la lista de clientes
                DetallesCliente clienteRelacionado = listaClientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado.Usuario);

                if (clienteRelacionado != null)
                {
                    // Actualizar los datos del cliente con los nuevos valores
                    clienteRelacionado.Usuario = usuarioSeleccionado.Usuario;
                    clienteRelacionado.Contraseña = usuarioSeleccionado.Contraseña;
                    clienteRelacionado.Estado = usuarioSeleccionado.Estado;
                }
            }

            // Actualizar los DataGridViews con los cambios
            ActualizarDataGridView(); // Actualizar el DataGridView de usuarios
            dgvClientes.DataSource = null;  // Limpiar el DataGridView de clientes
            dgvClientes.DataSource = listaClientes; // Volver a cargar la lista de clientes

            // Guardar los cambios en los archivos
            GestionDeArchivos.GuardarUsuarios(listaUsuarios, RegistrarUsuario.rutaUsuarios);
            GestionDeArchivos.GuardarClientes(listaClientes, RegistrarUsuario.rutaClientes);

            MessageBox.Show("Los cambios se han guardado exitosamente.", "Usuario Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos
            txtUsuarioNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            cmbEstado.SelectedIndex = -1;

            // Deshabilitar el GroupBox de edición
            grpCredenciales.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de mensaje de confirmación antes de cancelar los cambios
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar los cambios?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige 'Sí', cancelar los cambios
            if (resultado == DialogResult.Yes)
            {
                // Limpiar los campos de texto
                txtUsuarioNombre.Clear();
                txtContraseña.Clear();
                txtConfirmarContraseña.Clear();

                // Restablecer el ComboBox a su valor inicial (sin selección)
                cmbEstado.SelectedIndex = -1;

                // Deshabilitar el GroupBox para evitar ediciones
                grpCredenciales.Enabled = false;
            }
        }

        // TabPage Clientes
        private void tlsbtnEliminarCliente_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en dgvClientes
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del cliente seleccionado en dgvClientes
                    int clienteSeleccionadoIndex = dgvClientes.SelectedRows[0].Index;

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
                    dgvClientes.DataSource = null;  // Limpiar el DataGridView de clientes
                    dgvClientes.DataSource = listaClientes;  // Cargar la lista actualizada de clientes

                    MessageBox.Show("Cliente y usuario eliminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void eliminarCliente_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en dgvClientes
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del cliente seleccionado en dgvClientes
                    int clienteSeleccionadoIndex = dgvClientes.SelectedRows[0].Index;

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
                    dgvClientes.DataSource = null;  // Limpiar el DataGridView de clientes
                    dgvClientes.DataSource = listaClientes;  // Cargar la lista actualizada de clientes

                    MessageBox.Show("Cliente y usuario eliminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tlsbtnActualizarCliente_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada en dgvClientes
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el índice del cliente seleccionado
                int clienteSeleccionadoIndex = dgvClientes.SelectedRows[0].Index;

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
        private void tlsbtnEditarCliente_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada en dgvClientes
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el índice del cliente seleccionado
                int clienteSeleccionadoIndex = dgvClientes.SelectedRows[0].Index;

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

        private void btnGuardarCambiosCliente_Click(object sender, EventArgs e)
        {
            // Validar si el correo es válido
            if (lblValidarCorreo.Text == "*El correo debe de contener @ y . para ser válido")
            {
                MessageBox.Show("El correo no es válido. Asegúrese de que contenga '@' y '.'", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si el teléfono es válido
            if (lblValidarTelefono.Text != "Número de teléfono válido")
            {
                MessageBox.Show("El número de teléfono no es válido. Por favor ingrese un número válido.", "Error de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si los campos están completos
            if (string.IsNullOrEmpty(txtEditarNombre.Text) || string.IsNullOrEmpty(txtEditarApellido.Text) || string.IsNullOrEmpty(txtEditarEdad.Text) ||
                string.IsNullOrEmpty(txtEditarCorreo.Text) || string.IsNullOrEmpty(txtEditarTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvClientes.DataSource = null;  // Limpiar el DataGridView de clientes
                dgvClientes.DataSource = listaClientes;  // Recargar la lista actualizada de clientes

                // Actualizar el DataGridView de usuarios si es necesario
                dgvUsuarios.DataSource = null;  // Limpiar el DataGridView de usuarios
                dgvUsuarios.DataSource = listaUsuarios;  // Recargar la lista actualizada de usuarios

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

        // Restricción de txtBox
        private void seleccionar_click(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }
        private void restricciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un espacio
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Impide que el espacio sea ingresado
                return;
            }

            // Convertir cualquier letra a minúsculas
            e.KeyChar = char.ToLower(e.KeyChar);
        }
        private void soloNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado no es un número ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear la entrada de cualquier otro carácter
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
        private void letras_keyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un número o un espacio
            if (char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  // Bloquear la entrada de números y espacios
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

        // Validación de Datos
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
    }
}