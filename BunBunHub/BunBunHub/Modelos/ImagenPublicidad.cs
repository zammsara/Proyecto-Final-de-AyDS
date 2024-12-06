using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Modelos
{
    public static class ImagenPublicidad
    {
        private static Image imagenSeleccionada;

        public static Image ObtenerImagen()
        {
            if (imagenSeleccionada == null)
            {
                imagenSeleccionada = Image.FromFile(@"Resources\Predeterminada.jpg");
            }
            return imagenSeleccionada;
        }

        // Establece una nueva imagen
        public static void EstablecerImagen(Image nuevaImagen)
        {
            imagenSeleccionada = nuevaImagen;
        }

        // Carga la imagen desde un archivo binario, si existe
        public static void CargarImagenDesdeArchivo()
        {
            string rutaArchivo = "imagen_guardada.bin";
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    byte[] imagenBytes = File.ReadAllBytes(rutaArchivo);
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        imagenSeleccionada = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    imagenSeleccionada = Image.FromFile(@"Resources\Predeterminada.jpg");
                }
            }
            else
            {
                imagenSeleccionada = Image.FromFile(@"Resources\Predeterminada.jpg");
            }
        }
    }
}
