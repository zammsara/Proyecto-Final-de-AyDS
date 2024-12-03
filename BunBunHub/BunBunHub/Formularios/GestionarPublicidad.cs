using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Formularios
{
    public partial class GestionarPublicidad : Form
    {
        // Ruta de la imagen predeterminada
        private string imagenPredeterminada = @"Resources\Predeterminada.jpg";
        public GestionarPublicidad()
        {
            InitializeComponent();
            CargarImagen();
            picPublicidad.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar imagen
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            // Crear el cuadro de diálogo para seleccionar archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Seleccionar una imagen";

            // Mostrar el cuadro de diálogo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                // Si se selecciona una imagen, cargarla en el PictureBox
                picPublicidad.Image = System.Drawing.Image.FromFile(rutaImagen);

                // Guardar la imagen como archivo binario
                GuardarImagen(rutaImagen);
            }
            else
            {
                // Si no se selecciona ninguna imagen, restaurar la imagen predeterminada
                picPublicidad.Image = System.Drawing.Image.FromFile(imagenPredeterminada);
            }
        }

        private void GuardarImagen(string rutaImagen)
        {
            try
            {
                // Convertir la imagen a un arreglo de bytes
                byte[] imagenBytes = File.ReadAllBytes(rutaImagen);

                // Guardar el arreglo de bytes en un archivo binario
                File.WriteAllBytes("imagen_guardada.bin", imagenBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message);
            }
        }

        private void CargarImagen()
        {
            // Verificar si el archivo binario que contiene la imagen guardada existe
            if (File.Exists("imagen_guardada.bin"))
            {
                try
                {
                    // Leer el arreglo de bytes desde el archivo binario
                    byte[] imagenBytes = File.ReadAllBytes("imagen_guardada.bin");

                    // Convertir los bytes en una imagen
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        picPublicidad.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    picPublicidad.Image = System.Drawing.Image.FromFile(imagenPredeterminada); // Imagen predeterminada en caso de error
                }
            }
            else
            {
                // Si no existe el archivo binario, mostrar la imagen predeterminada
                picPublicidad.Image = System.Drawing.Image.FromFile(imagenPredeterminada);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imagen recibida correctamente"); // Confirmación de llamada al método
            PanelCliente panelCliente = new PanelCliente();
            panelCliente.ActualizarImagen(picPublicidad.Image); // Pasar la imagen del PictureBox a PanelCliente
            panelCliente.Show();
            this.Hide();
        }
    }
}
