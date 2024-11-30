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
            dgvPedidos.Columns.Add("CostoMaterial", "Costo de material");
            dgvPedidos.Columns.Add("CostoCompra", "Costo de compra");
        }

        private void ActualizarDataGriedView()
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
            ActualizarDataGriedView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        
        }
    }
}
