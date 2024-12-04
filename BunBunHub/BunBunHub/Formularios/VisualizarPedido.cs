/*Los datos del pedido que se deben mostrar son: nombre, edad, apellido, correo, telefono, id de pedido, fecha de compra, 
 punto de entrega, descripción, estado y monto total*/

using BunBunHub.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class VisualizarPedido : Form
    {
        public string IdPedido { get; set; }
        public string Usuario { get; set; }
        public List<Pedido> listaPedidos { get; set; }
        public static string rutaPedidos = "pedidos.dat";
        private List<DetallesCliente> listaClientes { get; set; }
        public static string rutaClientes = "cliente.dat";
        private Pedido pedidoOriginal; // Para almacenar los datos originales del pedido

        public VisualizarPedido()
        {
            InitializeComponent();
            listaPedidos = new List<Pedido>();
            GestionDeArchivos archivo = new GestionDeArchivos();
            listaPedidos = archivo.CargarPedidos(rutaPedidos);
            listaClientes = archivo.CargarClientes(rutaClientes);
        }

        private void VisualizarPedido_Load(object sender, EventArgs e)
        {
            // Buscar el pedido por IdPedido
            Pedido pedido = listaPedidos.FirstOrDefault(p => p.ID_Pedido == IdPedido);

            if (pedido != null)
            {
                // Guardamos el pedido original para restaurarlo si es necesario
                pedidoOriginal = pedido;

                // Buscar los datos del cliente usando el nombre de usuario
                DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);

                if (cliente != null)
                {
                    // Cargar los datos del cliente en los controles
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEdad.Text = cliente.Edad.ToString();
                    txtCorreo.Text = cliente.Correo;
                    txtTelefono.Text = cliente.Telefono.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente con ese nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Cargar los datos del pedido en los controles
                txtIDPedido.Text = pedido.ID_Pedido;
                dtpFechaCompra.Text = pedido.Fecha_Compra.ToString("dd/MM/yyyy");
                cmbPuntoEntrega.SelectedItem = pedido.Punto_Entrega;
                txtDescripcion.Text = pedido.Descripción;
                txtEstado.Text = pedido.Estado;
                txtMontoTotal.Text = "C$ " + pedido.Monto_Total.ToString();
            }
            else
            {
                MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerrar el formulario si no se encuentra el pedido
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Habilitar los campos editables
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEdad.Enabled = true;
            txtCorreo.Enabled = true;
            txtTelefono.Enabled = true;
            cmbPuntoEntrega.Enabled = true;

            // Cambiar la propiedad ReadOnly para permitir la edición
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtEdad.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            cmbPuntoEntrega.DropDownStyle = ComboBoxStyle.DropDown;

            // Desactivar el botón "Actualizar"
            btnActualizar.Enabled = false;

            // Activar los botones "Guardar" y "Cancelar"
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (lblValidarTelefono.Text != "Número de teléfono válido")
            {
                MessageBox.Show("El número de teléfono no es válido. Por favor, verifique e intente nuevamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (lblValidarCorreo.Text == "*El correo debe de contener @ y . para ser válido")
            {
                MessageBox.Show("El correo ingresado no es válido. Verifique e intente nuevamente.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            // Validar edad (mayor de 18 años)
            if (int.TryParse(txtEdad.Text, out int edadValida))
            {
                if (edadValida < 18)
                {
                    MessageBox.Show("El cliente debe ser mayor de 18 años.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEdad.Focus(); // Coloca el cursor en el campo de edad para corregir
                    return;
                }
                else if (edadValida > 100)
                {
                    MessageBox.Show("Por favor, ingresa una edad válida.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEdad.Focus(); // Coloca el cursor en el campo de edad si no es un número válido
                    return;
                }
            }

            if (cmbPuntoEntrega.Text != "Metrocentro" && cmbPuntoEntrega.Text != "Plaza Naturas")
            {
                // Si no es "Metrocentro" o "Plaza Naturas", mostrar un mensaje de error y colocar el foco en cmbPuntoEntrega
                MessageBox.Show("Punto de entrega no Seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPuntoEntrega.Focus();
                return;
            }

            // Actualizar los datos del pedido y del cliente
            Pedido pedido = listaPedidos.FirstOrDefault(p => p.ID_Pedido == IdPedido);
            if (pedido != null)
            {
                // Actualizar el pedido con los datos modificados
                pedido.Punto_Entrega = cmbPuntoEntrega.SelectedItem.ToString();
                pedido.Descripción = txtDescripcion.Text;
                pedido.Estado = txtEstado.Text;
                pedido.Monto_Total = decimal.Parse(txtMontoTotal.Text, System.Globalization.NumberStyles.Currency);

                // Actualizar el cliente con los datos modificados
                DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);
                if (cliente != null)
                {
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Edad = int.Parse(txtEdad.Text);
                    cliente.Correo = txtCorreo.Text;
                    cliente.Telefono = int.Parse(txtTelefono.Text);

                }

                // Guardar los cambios en los archivos
                GestionDeArchivos.GuardarPedidos(listaPedidos, rutaPedidos);
                GestionDeArchivos.GuardarClientes(listaClientes, rutaClientes);


                // Desactivar los campos y restaurar el estado inicial
                DesactivarCampos();

                // Reactivar el botón "Actualizar"
                btnActualizar.Enabled = true;

                // Desactivar los botones "Guardar" y "Cancelar"
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;

                MessageBox.Show("Los cambios se han guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Restaurar los datos originales del pedido
            if (pedidoOriginal != null)
            {
                // Restaurar los datos del cliente
                DetallesCliente cliente = listaClientes.FirstOrDefault(c => c.Usuario == Usuario);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEdad.Text = cliente.Edad.ToString();
                    txtCorreo.Text = cliente.Correo;
                    txtTelefono.Text = cliente.Telefono.ToString();
                }

                // Restaurar los datos del pedido
                txtIDPedido.Text = pedidoOriginal.ID_Pedido;
                dtpFechaCompra.Text = pedidoOriginal.Fecha_Compra.ToString("dd/MM/yyyy");
                cmbPuntoEntrega.SelectedItem = pedidoOriginal.Punto_Entrega;
                txtDescripcion.Text = pedidoOriginal.Descripción;
                txtEstado.Text = pedidoOriginal.Estado;
                txtMontoTotal.Text = "C$ " + pedidoOriginal.Monto_Total.ToString();
            }

            // Desactivar los campos y restaurar el estado inicial
            DesactivarCampos();

            // Reactivar el botón "Actualizar"
            btnActualizar.Enabled = true;

            // Desactivar los botones "Guardar" y "Cancelar"
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void DesactivarCampos()
        {
            // Desactivar los campos de entrada
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEdad.Enabled = false;
            txtCorreo.Enabled = false;
            txtTelefono.Enabled = false;
            cmbPuntoEntrega.Enabled = false;

            // Configurar los campos como ReadOnly
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtEdad.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            cmbPuntoEntrega.DropDownStyle = ComboBoxStyle.DropDownList;

            lblValidarTelefono.Text = "";
        }

        // Lógica de Navegación
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            PanelCliente panelCliente = new PanelCliente();
            panelCliente.Show();
            this.Close();
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void letrasEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, el retroceso (Backspace) y los espacios
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrEmpty(correo))
            {
                lblValidarCorreo.Text = " ";
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblValidarCorreo.ForeColor = System.Drawing.Color.Firebrick;
                lblValidarCorreo.Text = "*El correo debe de contener @ y . para ser válido";
            }
            else
            {
                lblValidarCorreo.Text = " ";
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(telefono))
            {
                lblValidarTelefono.Text = "";
                return;
            }

            // Verificar si el teléfono tiene exactamente 8 dígitos
            if (telefono.Length < 8)
            {
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*Número de teléfono inválido";
            }
            else if (telefono.Length > 8)
            {
                // Si el número tiene más de 8 dígitos, limitamos la entrada a los primeros 8
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*Número de teléfono inválido";
            }
            // Verificar que el primer dígito sea válido (8, 5, 7, 2)
            else if (telefono[0] != '8' && telefono[0] != '5' && telefono[0] != '7' && telefono[0] != '2')
            {
                lblValidarTelefono.ForeColor = System.Drawing.Color.Red;
                lblValidarTelefono.Text = "*El número debe comenzar por 8, 5, 7 ó 2.";
            }
            else if (txtTelefono.Enabled == false)
            {
                lblValidarTelefono.Text = "";
            }
            else
            {
                // Si el teléfono es válido
                lblValidarTelefono.ForeColor = System.Drawing.Color.Green;
                lblValidarTelefono.Text = "Número de teléfono válido";
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
    }
}
