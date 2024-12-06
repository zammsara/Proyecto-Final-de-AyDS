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
    public partial class OrdenesClientes : Form
    {
        public string Usuario { get; set; }
        public List<Pedido> listaPedidos { get; set; }
        public OrdenesClientes()
        {
            InitializeComponent();
            listaPedidos = new List<Pedido>();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarDatos()
        {
            // Asegúrate de que la lista no sea nula antes de proceder
            if (listaPedidos != null && listaPedidos.Count > 0)
            {
                // Filtrar los pedidos por el usuario actual
                var listaFiltrada = listaPedidos
                    .Where(pedido => pedido.Usuario == Usuario) // Filtra por el nombre de usuario
                    .OrderBy(pedido => pedido.Fecha_Compra) // Ordenar por fecha de compra de más antigua a más reciente
                    .Select(pedido => new HistorialCliente
                    {
                        ID_Pedido = pedido.ID_Pedido,
                        Fecha_Compra = pedido.Fecha_Compra,
                        Monto_Total = pedido.Monto_Total,
                        Punto_Entrega = pedido.Punto_Entrega,
                        Descripción = pedido.Descripción,
                        Estado = pedido.Estado
                    })
                    .ToList();

                // Verificar si el usuario tiene pedidos
                if (listaFiltrada.Count > 0)
                {
                    // Asignar la lista filtrada al DataGridView
                    dgvPedidos.DataSource = listaFiltrada;
                }
                else
                {
                    // Si no hay pedidos, mostrar un mensaje y cerrar el formulario
                    MessageBox.Show("Aún no has realizado pedidos en BunBunStiches", "Sin pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                // Si no hay pedidos cargados, cerrar el formulario
                MessageBox.Show("No se han encontrado pedidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void OrdenesClientes_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaPedidos = gestionArchivos.CargarPedidos(RegistrarPedido.rutaPedidos);
            CargarDatos();
        }

    }
}

