using BunBunHub.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;
using BunBunHub.Dao;

namespace BunBunHub.Formularios
{
    public partial class PanelCliente : Form
    {
        private string nombreUsuario;
        public PanelCliente()
        {
            InitializeComponent();
            picEstado.Image = Image.FromFile(@"Resources\picBuscar.png");
            picEstado.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asignamos el valor de nombreUsuario en el constructor
            nombreUsuario = UsuarioSesion.NombreUsuario;  // Ahora está disponible en toda la clase
            string rolUsuario = UsuarioSesion.RolUsuario;

            // Mostrar el nombre en un label
            lblNombreUsuario.Text = nombreUsuario;

            // Mostrar la imagen cargada en la clase estática
            picPublicidad2.Image = ImagenPublicidad.ObtenerImagen();
            picPublicidad2.SizeMode = PictureBoxSizeMode.StretchImage;

            btnVisualizarPedido.Visible = false;
            picCancelado.Visible = false;
        }

        // Propiedad para actualizar la imagen en panel Cliente
        public void ActualizarImagen(System.Drawing.Image imagen)
        {
            picPublicidad2.Image = imagen;
            picPublicidad2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void txtIdPedido_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPedido.Text) || txtIdPedido.Text == "P0000")
            {
                picCancelado.Visible = false;
                picEstado.Visible = true;
                picEstado.Image = Image.FromFile(@"Resources\picBuscar.png");
                btnVisualizarPedido.Visible = false;
            }
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar que el textBox no esté vacío
            if (string.IsNullOrWhiteSpace(txtIdPedido.Text) || txtIdPedido.Text == "P0000")
            {
                MessageBox.Show("Ingrese un ID de pedido", "Datos no ingresados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdPedido.Focus();
                return;
            }

            string idIngresado = txtIdPedido.Text;
            string nombreUsuario = UsuarioSesion.NombreUsuario; // Obtenemos el nombre de usuario desde la sesión

            // Verificar si el archivo existe antes de intentar cargarlo
            if (!File.Exists("pedidos.dat")) // Cambia aquí si necesitas otra ruta
            {
                MessageBox.Show("El archivo de pedidos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar la lista de pedidos desde el archivo
            GestionDeArchivos gestionArchivos = new GestionDeArchivos();
            List<Pedido> listaPedidos = gestionArchivos.CargarPedidos("pedidos.dat");

            // Buscar el pedido por el ID ingresado
            Pedido pedidoEncontrado = listaPedidos.FirstOrDefault(u => u.ID_Pedido == idIngresado);

            if (pedidoEncontrado != null)
            {
                // Verificamos si el nombre del usuario de la orden coincide con el nombre del usuario actual
                if (pedidoEncontrado.Usuario == nombreUsuario)
                {
                    // Si es el mismo usuario, mostramos la imagen de estado y habilitamos el botón
                    btnVisualizarPedido.Visible = true;

                    // Mostrar el estado del pedido
                    switch (pedidoEncontrado.Estado)
                    {
                        case "Recibido":
                            picEstado.Image = Image.FromFile(@"Resources\picRecibido.png");
                            picEstado.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                        case "En proceso":
                            picEstado.Image = Image.FromFile(@"Resources\picProcesando.png");
                            picEstado.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                        case "Listo para entrega":
                            picEstado.Image = Image.FromFile(@"Resources\picEntrega.png");
                            picEstado.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                        case "Completado":
                            picEstado.Image = Image.FromFile(@"Resources\picCompletado.png");
                            picEstado.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                        case "Cancelado":
                            picCancelado.Visible = true;
                            picEstado.Visible = false;
                            picCancelado.Image = Image.FromFile(@"Resources\picCancelado.png");
                            picCancelado.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                        default:
                            MessageBox.Show("Estado no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtIdPedido.Clear();
                            txtIdPedido.Focus();
                            picCancelado.Visible = false;
                            btnVisualizarPedido.Visible = false;
                            picEstado.Image = null;
                        break;
                    }
                }
                else
                {
                    // Si no es el mismo usuario, mostramos el mensaje de error
                    MessageBox.Show("La orden no existe. Verifique e intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picCancelado.Visible = false;
                    txtIdPedido.Clear();
                    txtIdPedido.Focus();

                    // Si el pedido no existe, ocultamos el botón de visualización y limpiamos la imagen
                    btnVisualizarPedido.Visible = false;
                    picEstado.Image = Image.FromFile(@"Resources\picBuscar.png");
                }
            }
            else
            {
                MessageBox.Show("La orden no existe. Verifique e intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picCancelado.Visible = false;
                txtIdPedido.Clear();
                txtIdPedido.Focus();

                // Si el pedido no existe, ocultamos el botón de visualización y limpiamos la imagen
                btnVisualizarPedido.Visible = false;
                picEstado.Image = Image.FromFile(@"Resources\picBuscar.png");
            }
            txtIdPedido.Focus();
        }


        private void txtIdPedido_Leave(object sender, EventArgs e)
        {
            // Si el TextBox está vacío, se le asigna "No asignado"
            if (string.IsNullOrEmpty(txtIdPedido.Text.Trim()))
            {
                txtIdPedido.Text = "P0000";
            }
        }

        private void seleccionar_enter(object sender, EventArgs e)
        {
            //Seleccione la respuesta completa en el control TextBox.
            TextBox answerBox = sender as TextBox;

            if (answerBox != null)
            {
                answerBox.SelectAll();
            }
        }

        private void btnVisualizarPedido_Click(object sender, EventArgs e)
        {
            VisualizarPedido visualizarPedido = new VisualizarPedido();
            visualizarPedido.IdPedido = txtIdPedido.Text; 
            visualizarPedido.Usuario = nombreUsuario;  
            visualizarPedido.ShowDialog();
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
