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
    public partial class ActualizarPedido : Form
    {
        public List<Pedido> listaPedidos {  get; set; }
        private Pedido pedidoSeleccionado;  // Variable para almacenar el pedido seleccionado
        private bool enEdicion = false;     // Para saber si estamos editando un pedido

        private List<Usuarios> listaUsuarios = new List<Usuarios>();
        public static string rutaUsuarios = "usuario.dat";

        public ActualizarPedido()
        {
            InitializeComponent();
            listaPedidos = new List<Pedido>();
            grpDetallesPedidoEditar.Enabled = false;
            btnGuardarCambiosPedido.Enabled = false; // Deshabilitar el botón Guardar al inicio

            GestionDeArchivos archivo = new GestionDeArchivos();
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);
        }

        //Visualizar registros en los DataGridView
        public void CargarDatos()
        {
            //Asegurarse de que la lista no sea nula antes de asignarla al DataGridView
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                dgvPedidos.DataSource = listaPedidos;
            }
        }

        public void ActualizarDatos(List<Pedido> listaPedidos)
        {
            //Asegurar de que las listas no sean nulas antes de asignarlas a los DataGridViews
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                dgvPedidos.DataSource = listaPedidos;
            }
        }

        private void ActualizarDataGridView()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = listaPedidos;
        }

        private void ActualizarPedido_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaPedidos = gestionArchivos.CargarPedidos(RegistrarPedido.rutaPedidos);
            CargarDatos();
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                pedidoSeleccionado = (Pedido)dgvPedidos.SelectedRows[0].DataBoundItem; // Obtener el pedido seleccionado
                btnEditarPedido.Enabled = true;  // Habilitar botón Editar Pedido
            }
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada en dgvPedidos
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                // Obtener el índice del pedido seleccionado
                int pedidoSeleccionadoIndex = dgvPedidos.SelectedRows[0].Index;

                // Obtener los datos del pedido
                Pedido pedido = listaPedidos[pedidoSeleccionadoIndex];

                // Cargar los datos del pedido en los controles
                txtIDPedidoEditar.Text = pedido.ID_Pedido.ToString();
                txtUsuarioClienteEditar.Text = pedido.Usuario;
                txtColaboradorEditar.Text = string.IsNullOrEmpty(pedido.Colaborador) ? "No asignado" : pedido.Colaborador;
                txtCostoCompraEditar.Text = pedido.Monto_Total.ToString();
                txtCostoMaterialEditar.Text = pedido.Monto_Material.ToString();
                cmbPuntoEntregaEditar.SelectedItem = pedido.Punto_Entrega;
                txtDescripcionEditar.Text = pedido.Descripción;
                cmbEstadoEditar.SelectedItem = pedido.Estado;
                dtpFechaCompraEditar.Value = pedido.Fecha_Compra;

                // Activar los controles necesarios para la edición
                grpDetallesPedidoEditar.Enabled = true;

                // Deshabilitar el botón Editar Pedido y habilitar el botón Guardar Cambios
                btnEditarPedido.Enabled = false;
                btnGuardarCambiosPedido.Enabled = true;

                // Marcar que estamos en edición
                enEdicion = true;
            }
            else
            {
                // Si no se seleccionó ninguna fila, mostrar un mensaje de advertencia
                MessageBox.Show("Seleccione una fila válida para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardarCambiosPedido_Click(object sender, EventArgs e)
        {
            // Validar si los campos están completos
            if (string.IsNullOrEmpty(txtUsuarioClienteEditar.Text) || string.IsNullOrEmpty(txtCostoCompraEditar.Text) ||
                string.IsNullOrEmpty(txtCostoMaterialEditar.Text) || string.IsNullOrEmpty(txtDescripcionEditar.Text) ||
                cmbPuntoEntregaEditar.SelectedItem == null || cmbEstadoEditar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el contenido de cmbPuntoEntrega
            if (cmbPuntoEntregaEditar.Text != "Metrocentro" && cmbPuntoEntregaEditar.Text != "Plaza Naturas")
            {
                // Si no es "Metrocentro" o "Plaza Naturas", mostrar un mensaje de error y colocar el foco en cmbPuntoEntrega
                MessageBox.Show("El punto de entrega debe ser 'Metrocentro' o 'Plaza Naturas'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPuntoEntregaEditar.Focus();
                return;
            }

            // Validar el contenido de cmbEstado
            if (cmbEstadoEditar.Text != "Recibido" && cmbEstadoEditar.Text != "En proceso" && cmbEstadoEditar.Text != "Listo para entrega" && cmbEstadoEditar.Text != "Completado" && cmbEstadoEditar.Text != "Cancelado")
            {
                // Si no es uno de los estados válidos, mostrar un mensaje de error y colocar el foco en cmbEstado
                MessageBox.Show("El estado ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstadoEditar.Focus();
                return;
            }

            // Validar que la fecha de compra no sea en el futuro
            if (dtpFechaCompraEditar.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de compra no es válida.", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el colaborador está validado correctamente
            if (txtColaboradorEditar.Text.Trim() != "No asignado" && lblColaboradorValidacion.Text != "El colaborador ha sido asignado")
            {
                MessageBox.Show("No se puede guardar el pedido. El colaborador no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todo está bien, actualizamos los datos del pedido
            if (enEdicion && dgvPedidos.SelectedRows.Count > 0)
            {
                // Obtener el índice del pedido seleccionado
                int pedidoSeleccionadoIndex = dgvPedidos.SelectedRows[0].Index;

                // Obtener los datos del pedido
                Pedido pedido = listaPedidos[pedidoSeleccionadoIndex];

                // Actualizar los datos del pedido con los valores editados
                pedido.Usuario = txtUsuarioClienteEditar.Text;
                // Si el colaborador es "No asignado", mantener "No asignado", de lo contrario asignar el valor ingresado
                pedido.Colaborador = string.IsNullOrEmpty(txtColaboradorEditar.Text) ? "No asignado" : txtColaboradorEditar.Text;
                pedido.Monto_Total = decimal.TryParse(txtCostoCompraEditar.Text, out decimal costoCompra) ? costoCompra : 0;
                pedido.Monto_Material = decimal.TryParse(txtCostoMaterialEditar.Text, out decimal costoMaterial) ? costoMaterial : 0;
                pedido.Punto_Entrega = cmbPuntoEntregaEditar.SelectedItem.ToString();
                pedido.Descripción = txtDescripcionEditar.Text;
                pedido.Estado = cmbEstadoEditar.SelectedItem.ToString();
                pedido.Fecha_Compra = dtpFechaCompraEditar.Value;

                GestionDeArchivos.GuardarPedidos(listaPedidos, RegistrarPedido.rutaPedidos);

                // Actualizar el DataGridView con los nuevos datos
                ActualizarDataGridView();
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = listaPedidos;

                // Deshabilitar el botón Guardar Cambios y habilitar el de Editar Pedido
                btnGuardarCambiosPedido.Enabled = false;
                btnEditarPedido.Enabled = true;

                // Marcar que ya no estamos en modo de edición
                enEdicion = false;

                // Mostrar un mensaje de éxito
                MessageBox.Show("Pedido actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Deshabilitar los controles de edición
                grpDetallesPedidoEditar.Enabled = false;
                LimpiarCamposPedido();
            }
            else
            {
                // Si no hay ningún pedido seleccionado
                MessageBox.Show("Seleccione un pedido válido para guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposPedido()
        {
            txtIDPedidoEditar.Clear();
            txtUsuarioClienteEditar.Clear();
            txtColaboradorEditar.Clear();
            txtCostoCompraEditar.Clear();
            txtCostoMaterialEditar.Clear();
            cmbPuntoEntregaEditar.SelectedIndex = -1;
            txtDescripcionEditar.Clear();
            cmbEstadoEditar.SelectedIndex = -1;

            // Asignar la fecha de hoy al DateTimePicker
            dtpFechaCompraEditar.Value = DateTime.Now;
        }

        private void btnCancelarCambiosPedido_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de mensaje de confirmación antes de cancelar la edición
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar la edición de este pedido?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige 'Sí', proceder con la cancelación
            if (resultado == DialogResult.Yes)
            {
                // Restaurar los valores originales del pedido
                if (enEdicion && dgvPedidos.SelectedRows.Count > 0)
                {
                    // Obtener el índice del pedido seleccionado
                    int pedidoSeleccionadoIndex = dgvPedidos.SelectedRows[0].Index;

                    // Obtener los datos originales del pedido
                    Pedido pedidoOriginal = listaPedidos[pedidoSeleccionadoIndex];

                    // Restaurar los valores en los controles
                    txtIDPedidoEditar.Text = pedidoOriginal.ID_Pedido.ToString();
                    txtUsuarioClienteEditar.Text = pedidoOriginal.Usuario;
                    txtColaboradorEditar.Text = string.IsNullOrEmpty(pedidoOriginal.Colaborador) ? "No asignado" : pedidoOriginal.Colaborador;
                    txtCostoCompraEditar.Text = pedidoOriginal.Monto_Total.ToString();
                    txtCostoMaterialEditar.Text = pedidoOriginal.Monto_Material.ToString();
                    cmbPuntoEntregaEditar.SelectedItem = pedidoOriginal.Punto_Entrega;
                    txtDescripcionEditar.Text = pedidoOriginal.Descripción;
                    cmbEstadoEditar.SelectedItem = pedidoOriginal.Estado;
                    dtpFechaCompraEditar.Value = pedidoOriginal.Fecha_Compra;

                    // Deshabilitar el grupo de detalles para editar
                    grpDetallesPedidoEditar.Enabled = false;

                    // Habilitar el botón Editar Pedido
                    btnEditarPedido.Enabled = true;

                    // Deshabilitar el botón Guardar Cambios
                    btnGuardarCambiosPedido.Enabled = false;

                    // Marcar que ya no estamos en modo de edición
                    enEdicion = false;

                    // Mostrar un mensaje de cancelación
                    MessageBox.Show("La edición del pedido ha sido cancelada.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposPedido();
                }
            }
        }


        // Lógica de navegación entre forms
        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            GestionPedidos gestionPedidos = new GestionPedidos();
            gestionPedidos.Show();
            this.Hide();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtColaboradorEditar_TextChanged(object sender, EventArgs e)
        {
            string colaborador = txtColaboradorEditar.Text.Trim();

            // Si el campo está vacío, vaciar el mensaje en lblValidarColaborador
            if (string.IsNullOrEmpty(colaborador))
            {
                lblColaboradorValidacion.Text = ""; // Vaciar el mensaje
                return;
            }

            // Si el colaborador no ha sido asignado
            if (colaborador == "No asignado")
            {
                lblColaboradorValidacion.Text = ""; // Vaciar el mensaje
                return;
            }

            // Buscar el usuario en la lista de usuarios
            var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.Usuario == colaborador);

            if (usuarioEncontrado != null)
            {
                // Si el usuario existe, verificar su rol
                if (usuarioEncontrado.Rol == "Colaborador")
                {
                    lblColaboradorValidacion.ForeColor = System.Drawing.Color.Green;
                    lblColaboradorValidacion.Text = "El colaborador ha sido asignado";
                }
                else
                {
                    lblColaboradorValidacion.ForeColor = System.Drawing.Color.Red;
                    lblColaboradorValidacion.Text = "*El usuario no puede asignarse a la orden";
                }
            }
            else
            {
                // Si el usuario no existe
                lblColaboradorValidacion.ForeColor = System.Drawing.Color.Red;
                lblColaboradorValidacion.Text = "*El usuario no existe";
            }
        }

        private void txtColaborador_Leave(object sender, EventArgs e)
        {
            // Si el TextBox está vacío, se le asigna "No asignado"
            if (string.IsNullOrEmpty(txtColaboradorEditar.Text.Trim()))
            {
                txtColaboradorEditar.Text = "No asignado";
            }
        }

        private void montos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Si no es un número ni Backspace, se cancela el evento (no se permite la tecla)
                e.Handled = true;
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del ComboBox
            string estadoSeleccionado = cmbFiltro.SelectedItem.ToString();

            // Filtrar la lista de pedidos según el estado seleccionado
            List<Pedido> pedidosFiltrados;

            if (estadoSeleccionado == "Todos")
            {
                // Mostrar todos los pedidos si "Todos" está seleccionado
                pedidosFiltrados = listaPedidos;
            }
            else
            {
                // Filtrar por el estado seleccionado
                pedidosFiltrados = listaPedidos.Where(u => u.Estado == estadoSeleccionado).ToList();
            }

            //Actualizar el DataGridView con los pedidos filtrados
            dgvPedidos.DataSource = pedidosFiltrados;
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaPedidos == null || listaPedidos.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para ordenar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string opcionSeleccionada = cmbOrdenar.SelectedItem.ToString();

            // Ordenar la lista según la opción seleccionada
            switch (opcionSeleccionada)
            {
                case "Predeterminado":
                    // Volver al orden original de la lista
                    var gestionDeArchivos = new GestionDeArchivos();
                    listaPedidos = gestionDeArchivos.CargarPedidos(RegistrarPedido.rutaPedidos);
                    break;

                case "Mayor a menor monto total":
                    listaPedidos = listaPedidos.OrderByDescending(p => p.Monto_Total).ToList();
                    break;

                case "Menor a mayor monto total":
                    listaPedidos = listaPedidos.OrderBy(p => p.Monto_Total).ToList();
                    break;

                case "Más recientes":
                    listaPedidos = listaPedidos.OrderByDescending(p => p.Fecha_Compra).ToList();
                    break;

                case "Más antiguos":
                    listaPedidos = listaPedidos.OrderBy(p => p.Fecha_Compra).ToList();
                    break;

                default:
                    MessageBox.Show("Selección no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Actualizar el DataGridView
            ActualizarDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar si el cuadro de texto está vacío
            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID de pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID ingresado en el cuadro de texto
            string idBusqueda = txtBusqueda.Text.Trim();

            // Buscar el pedido en la lista
            Pedido pedidoEncontrado = listaPedidos.FirstOrDefault(p => p.ID_Pedido == idBusqueda);

            if (pedidoEncontrado != null)
            {
                // Si se encuentra el pedido, seleccionarlo en el DataGridView
                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {
                    if (row.DataBoundItem is Pedido pedido && pedido.ID_Pedido == idBusqueda)
                    {
                        row.Selected = true; // Seleccionar la fila encontrada
                        dgvPedidos.FirstDisplayedScrollingRowIndex = row.Index; // Asegurar que sea visible
                        MessageBox.Show($"El pedido con ID '{idBusqueda}' encontrado y seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBusqueda.Clear();
                        return;
                    }
                }
            }
            else
            {
                // Si no se encuentra el pedido, mostrar mensaje de error
                MessageBox.Show($"No se encontró ningún pedido con el ID '{idBusqueda}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBusqueda.Clear();
            }
        }
    }
    
}
