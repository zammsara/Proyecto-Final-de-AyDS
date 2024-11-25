using BunBunHub.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class ActualizarRegistro : Form
    {
        // Propiedades para recibir los datos
        public List<Usuarios> ListaUsuarios { get; set; }
        public List<DetallesCliente> ListaDetallesClientes { get; set; }

        public ActualizarRegistro(List<Usuarios> usuarios, List<DetallesCliente> clientes)
        {
            InitializeComponent();
            ListaUsuarios = usuarios;
            ListaDetallesClientes = clientes;
        }

        
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

        private void tlsbtnHome_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
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

        private void LeerDatosDesdeArchivo()
        {
            // Cargar usuarios
            ListaUsuarios = ManejoArchivos<Usuarios>.CargarDatos(RegistrarUsuario.nuevarutaUsuarios);

            // Cargar clientes
            ListaDetallesClientes = ManejoArchivos<DetallesCliente>.CargarDatos(RegistrarUsuario.nuevarutaClientes);
        }
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

        //Configuración de las columnas del dgv de usuarios
        private void ConfigurarColumnasUsuarios()
        {
            dgvUsuario.Columns.Clear();
            dgvUsuario.Columns.Add("Usuario", "Usuario");
            dgvUsuario.Columns.Add("Contraseña", "Contraseña");
            dgvUsuario.Columns.Add("Rol", "Rol");
            dgvUsuario.Columns.Add("Estado", "Estado");
        }

        //Configuración de las columnas del dgv de clientes
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

        //Método para inicializar opciones del ComboBox para filtrar
        private void InicializarComboBoxFiltro()
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Administrador");
            cmbFiltro.Items.Add("Colaborador");
            cmbFiltro.Items.Add("Cliente");
            cmbFiltro.SelectedIndex = 0; // Seleccionar "Todos" por defecto
        }


        private void ActualizarRegistro_Load(object sender, EventArgs e)
        {
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
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvClientes.SelectedRows.Count > 0)
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

        // Guardar los cambios relizados en la lista de Usuarios
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

            // Obtener el índice del usuario seleccionado
            int usuarioSeleccionado = dgvUsuario.SelectedRows[0].Index;

            // Actualizar los datos en la lista de usuarios
            Usuarios usuario = ListaUsuarios[usuarioSeleccionado];
            usuario.Usuario = txtEditarUsuario.Text;
            usuario.Contraseña = txtEditarContraseña.Text;
            usuario.Rol = cmbEditarRol.SelectedItem.ToString();
            usuario.Estado = cmbEditarEstado.SelectedItem.ToString();

            // Sincronizar con la lista de clientes si el usuario es un cliente
            if (usuario.Rol == "Cliente")
            {
                // Buscar al cliente correspondiente en la lista de clientes
               var cliente = ListaDetallesClientes.FirstOrDefault(c => c.Usuario == usuario.Usuario);
                if (cliente != null)
                {
                    cliente.Contraseña = usuario.Contraseña;
                    cliente.Estado = usuario.Estado;
                }
            }

            // Guardar los datos actualizados en los archivos
            ManejoArchivos<Usuarios>.GuardarDatos(RegistrarUsuario.nuevarutaUsuarios, ListaUsuarios);
            ManejoArchivos<DetallesCliente>.GuardarDatos(RegistrarUsuario.nuevarutaClientes, ListaDetallesClientes);


            // Actualizar el DataGridView
            ActualizarDataGridView();

            MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Guardar los cambios realizados en la lista de Clientes
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

       
    }

    //Validación de usuario único
   
}
