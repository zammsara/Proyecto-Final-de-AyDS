﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Formularios
{
    public partial class PanelColaborador : Form
    {
        public PanelColaborador()
        {
            InitializeComponent();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Principal iniciarSesion = new Principal();
            iniciarSesion.Show();
            this.Hide();
        }
    }
}
