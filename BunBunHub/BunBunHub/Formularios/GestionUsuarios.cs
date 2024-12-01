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
    public partial class GestionUsuarios : Form
    {
        private List<Usuarios> listaUsuarios; // Lista de usuarios
        private List<DetallesCliente> listaClientes; // Lista de clientes
        public GestionUsuarios()
        {
            InitializeComponent();
        }
        //Eventos Básicos
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuarios = new RegistrarUsuario();
            registrarUsuarios.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
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
            else if (rolUsuario == "Colaborador")
            {
                // Si el rol es "Colaborador", abrir el panel de colaborador
                PanelColaborador panelColaborador = new PanelColaborador();
                panelColaborador.Show();
            }

            // Cerrar el formulario actual de GestionUsuarios
            this.Close();
        }

        private void btnActualizarRegistro_Click(object sender, EventArgs e)
        {
            VisualizarUsuarios actualizarRegistro = new VisualizarUsuarios(listaUsuarios, listaClientes);
            actualizarRegistro.Show();
            this.Hide();
        }
    }
}
