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
    public partial class VisualizarPedidos : Form
    {
        // Propiedades para recibir los datos
        public List<Pedidos> ListaPedidos { get; set; }
        public VisualizarPedidos(List<Pedidos>pedidos)
        {
            InitializeComponent();
            ListaPedidos = pedidos;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            GestionPedidos GestionPedidosForm = new GestionPedidos();
            GestionPedidosForm.Show();
            this.Hide();
        }

        private void LeerDatosDesdeArchivo()
        {
            // Cargar usuarios
            ListaPedidos = ManejoArchivos<Pedidos>.CargarDatos(RegistrarPedido.rutaPedidos);
        }

        private void ConfigurarColumnas()
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.Columns.Add("IDPedido", "ID Pedido");
            dgvPedidos.Columns.Add("FechaCompra", "Fecha de compra");
            dgvPedidos.Columns.Add("UsuarioCliente", "Cliente");
            dgvPedidos.Columns.Add("Estado", "Estado");
            dgvPedidos.Columns.Add("PuntoEntrega", "Punto de entrega");
            dgvPedidos.Columns.Add("Descripcion", "Descripcion");
            dgvPedidos.Columns.Add("UsuarioColaborador", "Colaborador");
            dgvPedidos.Columns.Add("CostoCompra", "Costo de compra");
            dgvPedidos.Columns.Add("CostoMaterial", "Costo de material");
        }

        private void ActualizarDataGridView()
        {
            // Verificar si las listas están inicializadas y no son nulas
            if (ListaPedidos == null)
            {
                ListaPedidos = new List<Pedidos>(); // Si es null, inicializa una lista vacía
            }

            dgvPedidos.Rows.Clear();

            ConfigurarColumnas();
            dgvPedidos.Rows.Clear();

            foreach(var pedido in ListaPedidos)
            {
                dgvPedidos.Rows.Add(pedido.IDPedido, pedido.FechaCompra, pedido.UsuarioCliente, pedido.Estado,
                                    pedido.PuntoEntrega, pedido.Descripcion, pedido.UsuarioColaborador,
                                    pedido.CostoMaterial, pedido.CostoCompra);
            }


        }

        private void VisualizarPedidos_Load(object sender, EventArgs e)
        {
            // Deshabilitar los GroupBox
            grbEdIdentificacionPedido.Enabled = false;
            grbEdDetallesPedido.Enabled = false;

            // Inicialización de columnas del DataGriedView
            ConfigurarColumnas();

            //Leer datos desde archivo
            LeerDatosDesdeArchivo();

            // Aplicar configuración adicional para DataGridView
            dgvPedidos.ReadOnly = false;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = true;

            dgvPedidos.ReadOnly = false;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = true;

            // Cargar los datos al DataGriedView
            ActualizarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if(dgvPedidos.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este pedido?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del pedido selccionado
                    int pedidoSeleccionado = dgvPedidos.SelectedRows[0].Index;

                    // Obtener el pedido que será eliminado
                    Pedidos pedido = ListaPedidos[pedidoSeleccionado];

                    // Eliminar el pedido de la lista de pedidos
                    ListaPedidos.RemoveAt(pedidoSeleccionado);

                    //Guardar los cambios en el archivo
                    ManejoArchivos<Pedidos>.GuardarDatos(RegistrarPedido.rutaPedidos, ListaPedidos);

                    // Actualizar el DataGridView
                    ActualizarDataGridView();

                    MessageBox.Show("Pedido eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        // Actualizar los campos de edición según la fila seleccionada del DataGridView de Pedidos
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvPedidos.SelectedRows[0];

                txtEdID.Text = filaSeleccionada.Cells["IDPedido"].Value?.ToString();

                txtEdUsuarioCliente.Text = filaSeleccionada.Cells["UsuarioCliente"].Value?.ToString();
                cmbEdEstado.SelectedItem = filaSeleccionada.Cells["Estado"].Value?.ToString();
                cmbEdPuntoEntrega.SelectedItem = filaSeleccionada.Cells["PuntoEntrega"].Value?.ToString();
                txtEdDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value?.ToString();
                txtEdUsuarioColaborador.Text = filaSeleccionada.Cells["UsuarioColaborador"].Value?.ToString();
                txtEdCostoCompra.Text = filaSeleccionada.Cells["CostoCompra"].Value?.ToString();
                txtEdCostoMaterial.Text = filaSeleccionada.Cells["CostoMaterial"].Value?.ToString();

                // Obtener el valor de la columna FechaCompra
                string fechaCompraString = filaSeleccionada.Cells["FechaCompra"].Value?.ToString();

                // Verificar que la fecha no sea nula o vacía antes de asignarla
                if (!string.IsNullOrWhiteSpace(fechaCompraString))
                {
                    if (DateTime.TryParseExact(fechaCompraString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaCompra))
                    {
                        dtpEdFechaCompra.Value = fechaCompra;
                    }
                    else
                    {
                        MessageBox.Show("El formato de la fecha no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dtpEdFechaCompra.Value = DateTime.Now; // O algún valor predeterminado
                }
            }
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                // Activar el GroupBox para la edición
                grbEdDetallesPedido.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que los campos no esten vacíos
            if (string.IsNullOrWhiteSpace(txtEdDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdDescripcion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEdUsuarioColaborador.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdUsuarioColaborador.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEdCostoCompra.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdCostoCompra.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEdCostoMaterial.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdCostoMaterial.Focus();
                return;
            }

            // Validar que se haya seleccionado una opción de los ComboBoxes
            if (cmbEdEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEdPuntoEntrega.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un punto de entrega antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que hay una fila seleccionada
            if (dgvPedidos.Rows.Count > 0)
            {
                // Obtener el índice del usuario seleccionado
                int pedidoSeleccionado = dgvPedidos.SelectedRows[0].Index;

                // Actualizar los datos de la lista de pedidos
                Pedidos pedido = ListaPedidos[pedidoSeleccionado];
                pedido.Estado = cmbEdEstado.SelectedItem.ToString();
                pedido.PuntoEntrega = cmbEdPuntoEntrega.SelectedItem.ToString();
                pedido.Descripcion = txtEdDescripcion.Text;
                pedido.UsuarioColaborador = txtEdUsuarioColaborador.Text;
                pedido.CostoCompra = txtEdCostoCompra.Text;
                pedido.CostoMaterial = txtEdCostoMaterial.Text;

                // Reflejar los cambios en el DataGridView
                dgvPedidos.Rows[pedidoSeleccionado].Cells["Estado"].Value = pedido.Estado;
                dgvPedidos.Rows[pedidoSeleccionado].Cells["PuntoEntrega"].Value = pedido.PuntoEntrega;
                dgvPedidos.Rows[pedidoSeleccionado].Cells["Descripcion"].Value = pedido.Descripcion;
                dgvPedidos.Rows[pedidoSeleccionado].Cells["UsuarioColaborador"].Value = pedido.UsuarioColaborador;
                dgvPedidos.Rows[pedidoSeleccionado].Cells["CostoCompra"].Value = pedido.CostoCompra;
                dgvPedidos.Rows[pedidoSeleccionado].Cells["CostoMaterial"].Value = pedido.CostoMaterial;

                // Guardar los datos en el archivo
                ManejoArchivos<Pedidos>.GuardarDatos(RegistrarPedido.rutaPedidos, ListaPedidos);

                MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                grbEdDetallesPedido.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para guardar los cambios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
