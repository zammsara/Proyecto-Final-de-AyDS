﻿using System;
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
    public partial class PanelAdministrador : Form
    {
        public PanelAdministrador()
        {
            InitializeComponent();
            // Acceder al nombre y rol desde la clase estática
            string nombreUsuario = UsuarioSesion.NombreUsuario;
            string rolUsuario = UsuarioSesion.RolUsuario;

            // Mostrar el nombre en un label
            lblNombreUsuario.Text = nombreUsuario;
        }
        //Evetos Básicos
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuarios GestionUsuariosForm = new GestionUsuarios();
            GestionUsuariosForm.Show();
            this.Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            GestionPedidos GestionPedidosForm = new GestionPedidos();
            GestionPedidosForm.Show();
            this.Hide();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            GenerarInformes generarInformes = new GenerarInformes();
            generarInformes.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Está seguro de que desea salir?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Principal iniciarSesion = new Principal();
            iniciarSesion.Show();
            this.Hide();
        }

        private void btnPublicidad_Click(object sender, EventArgs e)
        {
            PanelCliente panelCliente = new PanelCliente();
            GestionarPublicidad gestionarPublicidad = new GestionarPublicidad(panelCliente);
            gestionarPublicidad.ShowDialog();
        }

        private void btnPedidosActuales_Click(object sender, EventArgs e)
        {
            PedidosPendientes pedidosPendientes = new PedidosPendientes();
            pedidosPendientes.ShowDialog();
        }

        private void btnInformacin_Click(object sender, EventArgs e)
        {
            InformaciónSistema infoForm = new InformaciónSistema();
            infoForm.ShowDialog();
        }
    }
}
