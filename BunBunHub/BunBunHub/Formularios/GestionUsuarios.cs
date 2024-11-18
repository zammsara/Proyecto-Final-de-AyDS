using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunBunHub.Dao;

namespace BunBunHub.Formularios
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
            btnRegistrarUsuario.MouseDown += ComponentesVisuales.EfectosVisuales.OnBtn_MouseDown;
            btnRegistrarUsuario.MouseUp += ComponentesVisuales.EfectosVisuales.OnBtn_MouseUp;
        }
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuarios = new RegistrarUsuario();
            registrarUsuarios.Show();
            this.Hide();
        }

        private void btnVisualizarUsuario_Click(object sender, EventArgs e)
        {
            //VisualizarUsuarios visualizarUsuarios = new VisualizarUsuarios();
            //visualizarUsuarios.Show();
            //this.Hide();
        }
    }
}
