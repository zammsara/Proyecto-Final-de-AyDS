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
    public partial class GestionUsuarios : Form
    {
        private List<Usuarios> listaUsuarios = new List<Usuarios>();
        private List<DetallesCliente> listaClientes = new List<DetallesCliente>();
        public static string rutaUsuarios = "usuario.dat";
        public static string rutaClientes = "cliente.dat";
        public GestionUsuarios()
        {
            InitializeComponent();
            GestionDeArchivos archivo = new GestionDeArchivos();

            // Cargar los registros de los roles
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);
            listaClientes = archivo.CargarClientes(rutaClientes);

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
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnActualizarRegistro_Click(object sender, EventArgs e)
        {
            ActualizarRegistro actualizarRegistro = new ActualizarRegistro();
            actualizarRegistro.listaUsuarios = listaUsuarios;
            actualizarRegistro.listaClientes = listaClientes;
            actualizarRegistro.CargarDatos();
            actualizarRegistro.Show();
            this.Hide();
        }

        private void lblPaneldeControl_Click(object sender, EventArgs e)
        {

        }

        private void lblBunBunHub_Click(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
