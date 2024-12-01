using BunBunHub.Dao;
using BunBunHub.Modelos;
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
    public partial class GestionPedidos : Form
    {
        List<Pedidos> ListaPedidos; //Lista de pedidos
        public GestionPedidos()
        {
            InitializeComponent();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            List<Usuarios> listaUsuarios = ManejoArchivos<Usuarios>.CargarDatos("usuarios.dat");

            RegistrarPedido RegistrarPedidoForm = new RegistrarPedido(listaUsuarios);
            RegistrarPedidoForm.Show();
            this.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Verificar el rol del usuario actual almacenado en la clase Sesion
            string rolUsuario = Sesion.UsuarioSesion.RolUsuario;

            // Comprobar el rol y mostrar el formulario adecuado
            if (rolUsuario == "Administrador")
            {
                // Si el rol es "Administrador", abrir el panel de administrador
                PanelAdministrador panelAdministrador = new PanelAdministrador();
                panelAdministrador.Show();
            }
            else if(rolUsuario == "Colaborador")
            {
                // Si el rol es "Colaborador", abrir el panel de colaborador
                PanelColaborador panelColaborador = new PanelColaborador();
                panelColaborador.Show();
            }
           
            // Cerrar el formulario actual de GestionPedido
            this.Close();
        }

        private void btnVisualizarPedidos_Click(object sender, EventArgs e)
        {
            VisualizarPedidos visualizarPedidosForm = new VisualizarPedidos(ListaPedidos);
            visualizarPedidosForm.Show();
            this.Hide();
        }
    }
    
}
