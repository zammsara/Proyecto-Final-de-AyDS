using BunBunHub.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class VisualizarUsuarios : Form
    {
        // Propiedades para recibir los datos
        public List<Usuarios> ListaUsuarios { get; set; }
        public List<DetallesCliente> ListaDetallesClientes { get; set; }
        public VisualizarUsuarios(List<Usuarios> usuarios, List<DetallesCliente> clientes)
        {
            InitializeComponent();
            ListaUsuarios = usuarios;
            ListaDetallesClientes = clientes;
        }

        // Botones básicos
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tlsVolverBtn_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.Show();
            this.Hide();
        }

        private void tlsHomeBtn_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void tlsbtnVolver_Click(object sender, EventArgs e)
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

        // Leer los datos de los archivos de usuarios y clientes
        private void LeerDatosDesdeArchivo()
        {
            // Cargar usuarios
            ListaUsuarios = ManejoArchivos<Usuarios>.CargarDatos(RegistrarUsuario.nuevarutaUsuarios);

            // Cargar clientes
            ListaDetallesClientes = ManejoArchivos<DetallesCliente>.CargarDatos(RegistrarUsuario.nuevarutaClientes);
        }

        // Actualiza los datos en los DataGridView
        private void ActualizarDataGridView()
        {
            // Verifica si las listas están inicializadas y no son nulas
            if (ListaUsuarios == null)
            {
                ListaUsuarios = new List<Usuarios>();  // Si es null, inicializa una lista vacía
            }

            if (ListaDetallesClientes == null)
            {
                ListaDetallesClientes = new List<DetallesCliente>();  // Si es null, inicializa una lista vacía
            }

            dgvUsuario.Rows.Clear();

            ConfigurarColumnasUsuarios();
            dgvUsuario.Rows.Clear();

            // Agregar usuarios básicos (Administrador/Colaborador)
            foreach (var usuario in ListaUsuarios)
            {
                dgvUsuario.Rows.Add(usuario.Usuario, usuario.Contraseña, usuario.Rol, usuario.Estado);
            }

            ConfigurarColumnasClientes();
            dgvClientes.Rows.Clear();

            // Agregar clientes al DataGridView con sus campos adicionales
            foreach (var cliente in ListaDetallesClientes)
            {
                dgvClientes.Rows.Add(cliente.Usuario, cliente.Contraseña, cliente.Estado,
                                     cliente.Nombre, cliente.Apellido, cliente.Correo, cliente.Edad, cliente.Telefono);
            }
        }


        //Configuración de las columnas del DataGridView de usuarios
        private void ConfigurarColumnasUsuarios()
        {
            dgvUsuario.Columns.Clear();
            dgvUsuario.Columns.Add("Usuario", "Usuario");
            dgvUsuario.Columns.Add("Contraseña", "Contraseña");
            dgvUsuario.Columns.Add("Rol", "Rol");
            dgvUsuario.Columns.Add("Estado", "Estado");
        }

        //Configuración de las columnas del DataGridView de clientes
        private void ConfigurarColumnasClientes()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Usuario", "Usuario");
            dgvClientes.Columns.Add("Contraseña", "Contraseña");
            dgvClientes.Columns.Add("Estado", "Estado");
            dgvClientes.Columns.Add("Nombre", "Nombre");
            dgvClientes.Columns.Add("Apellido", "Apellido");
            dgvClientes.Columns.Add("Correo", "Correo");
            dgvClientes.Columns.Add("Edad", "Edad");
            dgvClientes.Columns.Add("Telefono", "Teléfono");
        }


        //Método para inicializar opciones del ComboBox para filtrar por roles
        private void InicializarComboBoxFiltro()
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Administrador");
            cmbFiltro.Items.Add("Colaborador");
            cmbFiltro.Items.Add("Cliente");
            cmbFiltro.SelectedIndex = 0; // Seleccionar "Todos" por defecto
        }

        // Eventos que se cargan junto con el formulario
        private void VisualizarUsuarios_Load(object sender, EventArgs e)
        {
            // Deshabilitar el GroupBox al cargar el formulario
            grpCredenciales.Enabled = false;

            // Inicialización de columnas de DataGriedViews
            ConfigurarColumnasUsuarios();
            ConfigurarColumnasClientes();

            // Inicializar opciones del ComboBox para el rol editar usuario
            cmbEditarRol.Items.AddRange(new string[] { "Cliente", "Administrador", "Colaborador" });

            // Leer los datos del archivo
            LeerDatosDesdeArchivo();

            // Inicializar opciones del ComboBox para filtrar
            InicializarComboBoxFiltro();

            // Aplicar configuración adicional para DataGridView
            dgvUsuario.ReadOnly = false;
            dgvUsuario.AllowUserToAddRows = false;
            dgvUsuario.AllowUserToDeleteRows = true;

            dgvClientes.ReadOnly = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = true;

            // Cargar los datos al DataGriedView
            ActualizarDataGridView();
        }

        

        

        // Guardar cambios realizados en la lista de usuarios
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtEditarUsuario.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditarUsuario.Focus();
                return;
            }


            if (string.IsNullOrEmpty(txtEditarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditarContraseña.Focus();
                return;
            }

            if (cmbEditarRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un rol antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEditarEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione el estado antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la contraseña y su confirmación coincidan
            if (txtEditarContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("La contraseña y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que hay una fila seleccionada
            if (dgvUsuario.SelectedRows.Count > 0)
            {
                // Obtener el índice del usuario seleccionado
                int usuarioSeleccionado = dgvUsuario.SelectedRows[0].Index;

                // Actualizar los datos en la lista de usuarios
                Usuarios usuario = ListaUsuarios[usuarioSeleccionado];
                usuario.Usuario = txtEditarUsuario.Text;
                usuario.Contraseña = txtEditarContraseña.Text;
                usuario.Rol = cmbEditarRol.SelectedItem.ToString();
                usuario.Estado = cmbEditarEstado.SelectedItem.ToString();

                // Reflejar los cambios en el DataGridView
                dgvUsuario.Rows[usuarioSeleccionado].Cells["Usuario"].Value = usuario.Usuario;
                dgvUsuario.Rows[usuarioSeleccionado].Cells["Contraseña"].Value = usuario.Contraseña;
                dgvUsuario.Rows[usuarioSeleccionado].Cells["Rol"].Value = usuario.Rol;
                dgvUsuario.Rows[usuarioSeleccionado].Cells["Estado"].Value = usuario.Estado;

                // Actualizar también los detalles del cliente si el usuario editado es un cliente
                DetallesCliente clienteRelacionado = ListaDetallesClientes.FirstOrDefault(c => c.Usuario == usuario.Usuario);
                if (clienteRelacionado != null)
                {
                    clienteRelacionado.Usuario = usuario.Usuario;
                    clienteRelacionado.Estado = usuario.Estado; // Actualizar estado si aplica
                }


                // Guardar los datos actualizados en los archivos
                ManejoArchivos<Usuarios>.GuardarDatos(RegistrarUsuario.nuevarutaUsuarios, ListaUsuarios);
                ManejoArchivos<DetallesCliente>.GuardarDatos(RegistrarUsuario.nuevarutaClientes, ListaDetallesClientes);

                // Desactivar el GroupBox y limpiar los campos
                grpCredenciales.Enabled = false;
                txtEditarUsuario.Clear();
                txtEditarContraseña.Clear();
                txtConfirmarContraseña.Clear();
                cmbEditarRol.SelectedIndex = -1;
                cmbEditarEstado.SelectedIndex = -1;

                // Actualizar ambos DataGridView
                ActualizarDataGridView();

                MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para guardar los cambios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    // Guardar cambios relizados en la lista de clientes
    private void btnGuardarCambiosC_Click(object sender, EventArgs e)
        {
            // Validar que haya seleccionado una opción
            if (cmbEditarEstadoCliente.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione el estado antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el índice del cliente seleccionado
            int clienteSeleccionado = dgvClientes.SelectedRows[0].Index;

            // Actualizar los datos en la lista de clientes
            DetallesCliente cliente = ListaDetallesClientes[clienteSeleccionado];
            cliente.Estado = cmbEditarEstadoCliente.SelectedItem.ToString();

            // Sincronizar con la lista de usuarios
            var usuario = ListaUsuarios.FirstOrDefault(u => u.Usuario == cliente.Usuario);
            if (usuario != null)
            {
                usuario.Estado = cliente.Estado;
            }

            // Guardar los datos actualizados en los archivos
            ManejoArchivos<DetallesCliente>.GuardarDatos(RegistrarUsuario.nuevarutaClientes, ListaDetallesClientes);
            ManejoArchivos<Usuarios>.GuardarDatos(RegistrarUsuario.nuevarutaUsuarios, ListaUsuarios);

            // Actualizar el DataGriedView
            ActualizarDataGridView();

            MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // Método para filtrar usuarios según el rol
        private void FiltrarUsuariosPorRol(string rol)
        {
            List<Usuarios> usuariosFiltrados;

            if (rol == "Todos")
            {
                // Mostrar todos los usuarios
                usuariosFiltrados = ListaUsuarios;
            }
            else
            {
                // Filtrar usuarios por rol específico
                usuariosFiltrados = ListaUsuarios.Where(u => u.Rol == rol).ToList();
            }

            // Actualizar DataGridView con los datos filtrados
            dgvUsuario.Rows.Clear();
            foreach (var usuario in usuariosFiltrados)
            {
                dgvUsuario.Rows.Add(usuario.Usuario, usuario.Contraseña, usuario.Rol, usuario.Estado);
            }
        }

        // Filtrar usuarios según el rol seleccionado en el ComboBox
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rolSeleccionado = cmbFiltro.SelectedItem.ToString();
            FiltrarUsuariosPorRol(rolSeleccionado);
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvUsuario.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del usuario seleccionado
                    int usuarioSeleccionado = dgvUsuario.SelectedRows[0].Index;

                    // Obtener el usuario que será eliminado
                    Usuarios usuario = ListaUsuarios[usuarioSeleccionado];

                    // Eliminar el usuario de la lista de usuarios
                    ListaUsuarios.RemoveAt(usuarioSeleccionado);

                    // Verificar si el usuario es un cliente
                    DetallesCliente clienteRelacionado = ListaDetallesClientes.FirstOrDefault(c => c.Usuario == usuario.Usuario);
                    if (clienteRelacionado != null)
                    {
                        // Eliminar el cliente de la lista de clientes
                        ListaDetallesClientes.Remove(clienteRelacionado);
                    }

                    // Guardar los cambios en los archivos
                    ManejoArchivos<Usuarios>.GuardarDatos(RegistrarUsuario.nuevarutaUsuarios, ListaUsuarios);
                    ManejoArchivos<DetallesCliente>.GuardarDatos(RegistrarUsuario.nuevarutaClientes, ListaDetallesClientes);

                    // Actualizar el DataGridView
                    ActualizarDataGridView();

                    MessageBox.Show("Usuario eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el índice de fila sea válido
            if (e.RowIndex >= 0 && e.RowIndex < dgvUsuarios.Rows.Count)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvUsuarios.Rows[e.RowIndex];

                // Verificar que no haya celdas nulas antes de asignar valores
                if (filaSeleccionada.Cells["Usuario"].Value != null &&
                    filaSeleccionada.Cells["Contraseña"].Value != null &&
                    filaSeleccionada.Cells["Rol"].Value != null &&
                    filaSeleccionada.Cells["Estado"].Value != null)
                {
                    // Asignar valores a los TextBoxes y ComboBoxes
                    txtEditarUsuario.Text = filaSeleccionada.Cells["Usuario"].Value.ToString();
                    txtEditarContraseña.Text = filaSeleccionada.Cells["Contraseña"].Value.ToString();

                    // Verificar si el valor existe en el ComboBox antes de seleccionarlo
                    string rol = filaSeleccionada.Cells["Rol"].Value.ToString();
                    if (cmbEditarRol.Items.Contains(rol))
                    {
                        cmbEditarRol.SelectedItem = rol;
                    }
                    else
                    {
                        cmbEditarRol.SelectedIndex = -1; // Sin selección si el valor no es válido
                    }

                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                    if (cmbEditarEstado.Items.Contains(estado))
                    {
                        cmbEditarEstado.SelectedItem = estado;
                    }
                    else
                    {
                        cmbEditarEstado.SelectedIndex = -1; // Sin selección si el valor no es válido
                    }

                    // Marcar la fila como seleccionada explícitamente
                    dgvUsuarios.Rows[e.RowIndex].Selected = true;
                }
                else
                {
                    MessageBox.Show("La fila seleccionada contiene datos nulos o inválidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarUusarios_Click(object sender, EventArgs e)
        {
            
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dgvUsuario.SelectedRows.Count > 0)
                {
                    // Obtener el índice del usuario seleccionado
                    int usuarioSeleccionado = dgvUsuario.SelectedRows[0].Index;

                    // Obtener el usuario desde la lista
                    Usuarios usuario = ListaUsuarios[usuarioSeleccionado];

                    // Cargar los datos en los controles
                    txtEditarUsuario.Text = usuario.Usuario;
                    txtEditarContraseña.Text = usuario.Contraseña;
                    txtConfirmarContraseña.Text = usuario.Contraseña;

                    cmbEditarRol.SelectedItem = usuario.Rol;
                    cmbEditarEstado.SelectedItem = usuario.Estado;

                    // Activar el GroupBox para edición
                    grpCredenciales.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila válida para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        // Actualizar los campos de edición según la fila seleccionada del DataGridView de Usuarios
        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvUsuario.SelectedRows[0];

                txtEditarUsuario.Text = filaSeleccionada.Cells["Usuario"].Value?.ToString();
                txtEditarContraseña.Text = filaSeleccionada.Cells["Contraseña"].Value?.ToString();
                txtConfirmarContraseña.Text = ""; // Vaciar siempre este campo
                cmbEditarRol.SelectedItem = filaSeleccionada.Cells["Rol"].Value?.ToString();
                cmbEditarEstado.SelectedItem = filaSeleccionada.Cells["Estado"].Value?.ToString();
            }
        }

        // Actualizar los campos de edición según la fila seleccionada del DataGridView de DetallesCliente
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var filaSeleccionadaC = dgvClientes.SelectedRows[0];

                cmbEditarEstadoCliente.SelectedItem = filaSeleccionadaC.Cells["Estado"].Value?.ToString();
                txtEditarNombre.Text = filaSeleccionadaC.Cells["Nombre"].Value?.ToString();
                txtEditarApellido.Text = filaSeleccionadaC.Cells["Apellido"].Value?.ToString();
                txtEditarCorreo.Text = filaSeleccionadaC.Cells["Correo"].Value?.ToString();
                txtEditarEdad.Text = filaSeleccionadaC.Cells["Edad"].Value?.ToString();
                txtEditarTelefono.Text = filaSeleccionadaC.Cells["Telefono"].Value?.ToString();
            }
        }

        //
    }
}
