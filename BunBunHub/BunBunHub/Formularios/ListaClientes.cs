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
    public partial class ListaClientes : Form
    {
        public List<DetallesCliente> listaClientes { get; set; }
        public DetallesCliente ClienteSeleccionado { get; set; }
        public string UsuarioSeleccionado { get; private set; }
        public ListaClientes()
        {
            InitializeComponent();
            listaClientes = new List<DetallesCliente>();
        }

        public void CargarDatos()
        {
            // Asegúrate de que la lista no sea nula antes de asignarla al DataGridView
            if (listaClientes != null && listaClientes.Count > 0)
            {
                // Convertir listaClientes a una lista de ClienteResumen
                var listaResumen = listaClientes.Select(cliente => new ClienteResumen
                {
                    Usuario = cliente.Usuario,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido
                }).ToList();

                // Asignar la lista filtrada al DataGridView
                dgvClientes.DataSource = listaResumen;
            }
        }
        private void ActualizarDataGridView()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RegistrarPedido registrarPedido = new RegistrarPedido();
            registrarPedido.Show();
            this.Close();
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaClientes = gestionArchivos.CargarClientes(RegistrarUsuario.rutaClientes);
            CargarDatos();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si se hace doble clic en una fila del DataGridView, se selecciona el cliente
            if (e.RowIndex >= 0)
            {
                ClienteSeleccionado = (DetallesCliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK;  // Cierra el formulario y marca como éxito
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Si se hace clic en el botón "Seleccionar", seleccionamos el cliente de la fila seleccionada
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el objeto de tipo ClienteResumen seleccionado
                var clienteResumenSeleccionado = (ClienteResumen)dgvClientes.SelectedRows[0].DataBoundItem;

                // Buscar el cliente correspondiente en la lista original de DetallesCliente
                ClienteSeleccionado = listaClientes.FirstOrDefault(cliente => cliente.Usuario == clienteResumenSeleccionado.Usuario);

                if (ClienteSeleccionado != null)
                {
                    UsuarioSeleccionado = ClienteSeleccionado.Usuario; // Guardamos el usuario seleccionado

                    this.DialogResult = DialogResult.OK;  // Cierra el formulario y marca como éxito
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar una fila.", "Selección fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
