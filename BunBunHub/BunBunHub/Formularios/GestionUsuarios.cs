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
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnActualizarRegistro_Click(object sender, EventArgs e)
        {
            ActualizarRegistro actualizarRegistro = new ActualizarRegistro(listaUsuarios, listaClientes);
            actualizarRegistro.Show();
            this.Hide();
        }
    }
}
