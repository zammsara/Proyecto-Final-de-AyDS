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
    public partial class PedidosPendientes : Form
    {
        public List<Pedido> listaPedidos { get; set; }
        public PedidosPendientes()
        {
            InitializeComponent();
            listaPedidos = new List<Pedido>();
            cmbFiltro.Text = "Todos";
        }
        public void CargarDatos()
        {
            // Asegúrate de que la lista no sea nula antes de asignarla al DataGridView
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                // Filtrar los pedidos excluyendo los que tienen los estados "Cancelado" o "Completado"
                var listaFiltrada = listaPedidos
                    .Where(pedido => pedido.Estado != "Cancelado" && pedido.Estado != "Completado")
                    .OrderBy(pedido => pedido.Fecha_Compra) // Ordenar por fecha de compra (más antigua a más reciente)
                    .Select(pedido => new PedidoResumen
                    {
                        ID_Pedido = pedido.ID_Pedido,
                        Colaborador = pedido.Colaborador,
                        Fecha_Compra = pedido.Fecha_Compra,
                        Estado = pedido.Estado
                    })
                    .ToList();

                // Asignar la lista filtrada y ordenada al DataGridView
                dgvPedidos.DataSource = listaFiltrada;
            }
        }


        private void ActualizarDataGridView(List<PedidoResumen> pedidosFiltrados)
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = listaPedidos;
            dgvPedidos.DataSource = pedidosFiltrados;
        }

        private void PedidosPendientes_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaPedidos = gestionArchivos.CargarPedidos(RegistrarPedido.rutaPedidos);
            CargarDatos();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del ComboBox
            string estadoSeleccionado = cmbFiltro.SelectedItem.ToString();

            // Filtrar la lista de pedidos según el estado seleccionado
            List<PedidoResumen> pedidosFiltrados;

            if (estadoSeleccionado == "Todos")
            {
                // Mostrar todos los pedidos si "Todos" está seleccionado
                pedidosFiltrados = listaPedidos
                    .Where(u => u.Estado != "Cancelado" && u.Estado != "Completado") // Excluir los pedidos cancelados o completados
                    .OrderBy(pedido => pedido.Fecha_Compra) // Ordenar por la fecha de compra, de más antigua a más reciente
                    .Select(pedido => new PedidoResumen
                    {
                        ID_Pedido = pedido.ID_Pedido,
                        Colaborador = pedido.Colaborador,
                        Fecha_Compra = pedido.Fecha_Compra,
                        Estado = pedido.Estado
                    })
                    .ToList();
            }
            else
            {
                // Filtrar por el estado seleccionado
                pedidosFiltrados = listaPedidos
                    .Where(u => u.Estado == estadoSeleccionado)
                    .Select(pedido => new PedidoResumen
                    {
                        ID_Pedido = pedido.ID_Pedido,
                        Colaborador = pedido.Colaborador,
                        Fecha_Compra = pedido.Fecha_Compra,
                        Estado = pedido.Estado
                    })
                    .ToList();
            }

            // Actualizar el DataGridView con los pedidos filtrados
            ActualizarDataGridView(pedidosFiltrados);
        }

    }
}
