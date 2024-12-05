using BunBunHub.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class GestionarPublicidad : Form
    {
        // Ruta de la imagen predeterminada
        private string imagenPredeterminada = @"Resources\Predeterminada.jpg";
        private PanelCliente panelCliente;
        public GestionarPublicidad(PanelCliente panelCliente)
        {
            InitializeComponent();
            this.panelCliente = panelCliente;
            CargarImagen();
            picPublicidad.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Close();
        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Seleccionar una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                picPublicidad.Image = System.Drawing.Image.FromFile(rutaImagen);
                GuardarImagen(rutaImagen);
                ImagenPublicidad.EstablecerImagen(picPublicidad.Image); // Aquí usamos System.Drawing.Image
                panelCliente.ActualizarImagen(picPublicidad.Image);
            }
            else
            {
                picPublicidad.Image = System.Drawing.Image.FromFile(imagenPredeterminada);
                ImagenPublicidad.EstablecerImagen(picPublicidad.Image); // Aquí usamos System.Drawing.Image
                panelCliente.ActualizarImagen(picPublicidad.Image);
            }
        }

        private void GuardarImagen(string rutaImagen)
        {
            try
            {
                byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
                File.WriteAllBytes("imagen_guardada.bin", imagenBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message);
            }
        }

        private void CargarImagen()
        {
            // Si la imagen está guardada en la clase estática, cargarla
            picPublicidad.Image = ImagenPublicidad.ObtenerImagen();
        }
    }
}
