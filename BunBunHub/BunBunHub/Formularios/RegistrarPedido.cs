using BunBunHub.Dao;
using BunBunHub.Modelos;
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
    public partial class RegistrarPedido : Form
    {
        public static string rutaPedidos = "pedidos.dat";
        private string rolUsuario; // Variable para almacenar el rol del usuario actual

        private List<Usuarios> listaUsuarios;
        private List<Pedidos> listaPedidos; //Lista de pedidos
        public RegistrarPedido(List<Usuarios> usuarios)
        {
            InitializeComponent();
            listaUsuarios = usuarios; // Cargar lista de usuarios al inicializar
            listaPedidos = new List<Pedidos>();// Inicializar la lista vacía al cargar el formulario
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ValidarCampos()
        {
            //Verificar que todos los controles tengan información
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUsuarioCliente.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioCliente.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUsuarioColaborador.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioColaborador.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCostoCompra.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostoCompra.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCostoMaterial.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostoMaterial.Focus();
                return;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Cargar la lista de usuarios
            listaUsuarios = ManejoArchivos<Usuarios>.CargarDatos("usuarios.dat");
            
            // Mostrar la lista cargada para depuración
            foreach (var usuario in listaUsuarios)
            {
                MessageBox.Show($"Usuario: {usuario.Usuario}, Rol: {usuario.Rol}, Estado: {usuario.Estado}");
            }

            // Verificar que todos los controles tengan información
            ValidarCampos();

            // Verificar que los ComboBox tengan un valor seleccionado
            if (cmbPuntoEntrega.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear un nuevo pedido
            Pedidos nuevoPedido = new Pedidos
            {
                IDPedido = int.Parse(txtID.Text),
                FechaCompra = dtpFechaCompra.Value.ToString("yyyy-MM-dd"),
                UsuarioCliente = txtUsuarioCliente.Text,
                Estado = cmbEstado.SelectedItem.ToString(),
                PuntoEntrega = cmbPuntoEntrega.SelectedItem.ToString(),
                Descripcion = txtDescripcion.Text,
                UsuarioColaborador = txtUsuarioColaborador.Text,
                CostoMaterial = txtCostoMaterial.Text,
                CostoCompra = txtCostoCompra.Text

            };

            //Leer los datos existentes
            listaPedidos = ManejoArchivos<Pedidos>.CargarDatos(RegistrarPedido.rutaPedidos);

            // Agregar nuevo pedido a la lista
            listaPedidos.Add(nuevoPedido);

            // Guadar la lista completa en el archivo
            ManejoArchivos<Pedidos>.GuardarDatos(RegistrarPedido.rutaPedidos, listaPedidos);

            MessageBox.Show("Pedido registrado correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            txtUsuarioCliente.Focus();
        }

        // Método para generar un nuevo IDPedido
        private int GenerarNuevoID()
        {
            // Si no hay pedidos, comenzamos en 1
            if (listaPedidos.Count == 0)
                return 1;

            // Encontrar el ID más alto en la lista de pedidos
            int maxID = listaPedidos.Max(pedido => pedido.IDPedido);

            // Retornar el siguiente ID
            return maxID + 1;
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtUsuarioCliente.Clear();
            txtDescripcion.Clear();
            txtUsuarioColaborador.Clear();
            txtCostoMaterial.Clear();
            txtCostoCompra.Clear();

            // Limpiar los combobox
            cmbEstado.SelectedIndex = -1;
            cmbPuntoEntrega.SelectedIndex = -1;
        }

        private void RegistrarPedido_Load(object sender, EventArgs e)
        {
            int nuevoID = GenerarNuevoID();
            txtID.Text = nuevoID.ToString(); // Mostrar el ID en el TextBox
        }

        private void ValidarUsuario()
        {
            
        }

        private void txtUsuarioCliente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUsuarioColaborador_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCostoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, puntos, comas y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear el carácter
            }
        }

        private void txtCostoMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, puntos, comas y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear el carácter
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            GestionPedidos GestionPedidosForm = new GestionPedidos();
            GestionPedidosForm.Show();
            this.Hide();
        }
    }
}
