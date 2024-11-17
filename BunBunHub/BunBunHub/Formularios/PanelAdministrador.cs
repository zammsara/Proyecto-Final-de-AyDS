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
    public partial class PanelAdministrador : Form
    {
        public PanelAdministrador()
        {
            InitializeComponent();
            btnCerrarSesion.MouseDown += ComponentesVisuales.EfectosVisuales.OnBtn_MouseDown;
            btnCerrarSesion.MouseUp += ComponentesVisuales.EfectosVisuales.OnBtn_MouseUp;
            btnUsuarios.MouseDown += ComponentesVisuales.EfectosVisuales.OnBtn_MouseDown;
            btnUsuarios.MouseUp += ComponentesVisuales.EfectosVisuales.OnBtn_MouseUp;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Acceso iniciarSesion = new Acceso();
            iniciarSesion.Show();
            this.Hide();

        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Cerrar(object sender, FormClosingEventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuarios GestionUsuariosForm = new GestionUsuarios();
            GestionUsuariosForm.Show();
            this.Hide();
        }
    }
}
