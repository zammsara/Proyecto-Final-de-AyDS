using BunBunHub.Dao;
using System.IO;
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
        public string Rol { get; set; }
        private string rolUsuario;
        private List<Pedido> listaPedidos = new List<Pedido>();
        private List<DetallesCliente> listaClientes = new List<DetallesCliente>();
        private List<Usuarios> listaUsuarios = new List<Usuarios>();
        public static string rutaClientes = "cliente.dat";
        public static string rutaPedidos = "pedidos.dat";
        public static string rutaUsuarios = "usuario.dat";
        private static int ultimoID = 1;

        public RegistrarPedido()
        {
            InitializeComponent();
            rolUsuario = UsuarioSesion.RolUsuario;
            GestionDeArchivos archivo = new GestionDeArchivos();

            listaPedidos = archivo.CargarPedidos(rutaPedidos);
            listaClientes = archivo.CargarClientes(rutaClientes);
            listaUsuarios = archivo.CargarUsuarios(rutaUsuarios);

            // Cargar el último ID desde el archivo
            ultimoID = CargarUltimoID();
            dtpFechaCompra.Value = DateTime.Now;
        }

        private void RegistrarPedido_Load(object sender, EventArgs e)
        {
            string nuevoID = "P" + ultimoID.ToString("D4");
            txtIDPedido.Text = nuevoID;
        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;
            if (!string.IsNullOrEmpty(txtApellidoCliente.Text) || !string.IsNullOrEmpty(txtCorreoCliente.Text) || !string.IsNullOrEmpty(txtTelefonoCliente.Text) || !string.IsNullOrEmpty(txtUsuarioCliente.Text) || !string.IsNullOrEmpty(txtCostoCompra.Text) ||
                !string.IsNullOrEmpty(txtCostoMaterial.Text) || !string.IsNullOrEmpty(cmbPuntoEntrega.Text) || !string.IsNullOrEmpty(txtDescripcion.Text))
            {
                hayDatos = true;
            }

            // Si hay datos, preguntar al usuario si desea volver sin guardar
            if (hayDatos)
            {
                DialogResult resultado = MessageBox.Show("Hay datos no guardados. ¿Desea volver sin guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Verificar el rol y abrir el panel correspondiente
                    if (Rol == "Colaborador")
                    {
                        PanelColaborador panelColaborador = new PanelColaborador();
                        panelColaborador.Show();
                        this.Hide();  // Ocultar el formulario actual
                    }
                    else
                    {
                        // Si el usuario elige "Sí", regresar al panel de administrador
                        PanelAdministrador panelAdministrador = new PanelAdministrador();
                        panelAdministrador.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                // Verificar el rol y abrir el panel correspondiente
                if (Rol == "Colaborador")
                {
                    PanelColaborador panelColaborador = new PanelColaborador();
                    panelColaborador.Show();
                    this.Hide();  // Ocultar el formulario actual
                }
                else
                {
                    // Si el usuario elige "Sí", regresar al panel de administrador
                    PanelAdministrador panelAdministrador = new PanelAdministrador();
                    panelAdministrador.Show();
                    this.Hide();
                }
            }
        }

        private void btnBuscarUsuarioCliente_Click(object sender, EventArgs e)
        {
            ListaClientes listaClientesForm = new ListaClientes();
            listaClientesForm.ShowDialog();  // Mostrar el formulario y esperar su cierre

            // Después de que el formulario se cierre, obtener el usuario seleccionado
            if (listaClientesForm.DialogResult == DialogResult.OK)
            {
                // Obtener el usuario seleccionado directamente de la propiedad pública
                txtUsuarioCliente.Text = listaClientesForm.UsuarioSeleccionado;

                // Buscar el cliente en la lista de clientes usando el usuario seleccionado
                var cliente = listaClientes.FirstOrDefault(c => c.Usuario == listaClientesForm.UsuarioSeleccionado);

                if (cliente != null)
                {
                    txtNombreCliente.Text = cliente.Nombre;
                    txtApellidoCliente.Text = cliente.Apellido;
                    txtCorreoCliente.Text = cliente.Correo;
                    txtTelefonoCliente.Text = cliente.Telefono.ToString();

                    // El cliente existe, llenar los TextBox con sus datos
                    MessageBox.Show("El cliente ha sido asignado al pedido con éxito.", "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // El cliente no existe, mostrar mensaje de error
                    MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuarioCliente.Clear();
                    txtUsuarioCliente.Focus(); // Poner el foco en el TextBox para que ingrese otro cliente

                    // Limpiar los campos dentro del GroupBox grpDetallesCliente
                    foreach (Control control in grpDetallesCliente.Controls)
                    {
                        if (control is TextBox)
                        {
                            ((TextBox)control).Clear();
                        }
                    }
                }
            }
        }


        // Funcionalidades
        private void tlsbtnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si alguno de los campos esenciales está vacío
            if (string.IsNullOrEmpty(txtApellidoCliente.Text) ||
                string.IsNullOrEmpty(txtCorreoCliente.Text) ||
                string.IsNullOrEmpty(txtTelefonoCliente.Text) ||
                string.IsNullOrEmpty(txtUsuarioCliente.Text) ||
                string.IsNullOrEmpty(txtColaborador.Text) ||
                string.IsNullOrEmpty(txtCostoCompra.Text) ||
                string.IsNullOrEmpty(txtCostoMaterial.Text) ||
                string.IsNullOrEmpty(cmbPuntoEntrega.Text) ||
                string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrEmpty(cmbEstado.Text))
            {
                // Si cualquier campo esencial está vacío, muestra un mensaje de error
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el colaborador está validado correctamente
            if (txtColaborador.Text.Trim() != "No asignado" && lblValidarColaborador.Text != "El colaborador ha sido asignado")
            {
                MessageBox.Show("No se puede guardar el pedido. El colaborador no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el contenido de cmbPuntoEntrega
            if (cmbPuntoEntrega.Text != "Metrocentro" && cmbPuntoEntrega.Text != "Plaza Naturas")
            {
                // Si no es "Metrocentro" o "Plaza Naturas", mostrar un mensaje de error y colocar el foco en cmbPuntoEntrega
                MessageBox.Show("Punto de entrega no Seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPuntoEntrega.Focus();
                return;
            }

            // Validar el contenido de cmbEstado
            if (cmbEstado.Text != "Recibido" && cmbEstado.Text != "En proceso" && cmbEstado.Text != "Listo para entrega" && cmbEstado.Text != "Completado" && cmbEstado.Text != "Cancelado")
            {
                // Si no es uno de los estados válidos, mostrar un mensaje de error y colocar el foco en cmbEstado
                MessageBox.Show("El estado ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstado.Focus();
                return;
            }

            // Validar que la fecha de compra no sea en el futuro
            if (dtpFechaCompra.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de compra no es válida.", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todas las validaciones pasaron, entonces crear y agregar el nuevo pedido
            string ID = txtIDPedido.Text;
            string usuario = txtUsuarioCliente.Text;
            string colaborador = txtColaborador.Text;
            DateTime fechaCompra = dtpFechaCompra.Value;
            decimal montoTotal = decimal.Parse(txtCostoCompra.Text);  // Conversión a decimal
            decimal montoMaterial = decimal.Parse(txtCostoMaterial.Text);
            string puntoEntrega = cmbPuntoEntrega.Text;
            string descripcion = txtDescripcion.Text;
            string estado = cmbEstado.Text;

            // Crear y agregar el nuevo pedido
            Pedido nuevoPedido = new Pedido(ID, usuario, colaborador, fechaCompra, montoTotal, montoMaterial, puntoEntrega, descripcion, estado);
            listaPedidos.Add(nuevoPedido);
            GestionDeArchivos.GuardarPedidos(listaPedidos, rutaPedidos);

            // Incrementar el ID para el siguiente pedido
            ultimoID++;

            // Guardar el último ID en el archivo
            GuardarUltimoID(ultimoID);

            // Mostrar mensaje de éxito
            MessageBox.Show("Pedido guardado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            txtUsuarioCliente.Focus();
        }

        private void LimpiarCampos()
        {
            // No incrementar el ID, solo actualizar el campo con el último ID válido
            string nuevoID = "P" + ultimoID.ToString("D4");
            txtIDPedido.Text = nuevoID;

            // Limpiar los demás campos
            txtUsuarioCliente.Clear();
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtCorreoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtColaborador.Text = "No asignado";  // Valor predeterminado
            txtCostoCompra.Clear();
            txtCostoMaterial.Clear();
            cmbPuntoEntrega.SelectedIndex = -1;  // Dejar vacío el ComboBox
            txtDescripcion.Clear();
            cmbEstado.Text = "Recibido";
            lblValidarColaborador.Text = "";  // Limpiar el mensaje de validación
        }

        private void tlsbtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

        // Lógica de Navegación entre forms
        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;
            if (!string.IsNullOrEmpty(txtApellidoCliente.Text) || !string.IsNullOrEmpty(txtCorreoCliente.Text) || !string.IsNullOrEmpty(txtTelefonoCliente.Text) || !string.IsNullOrEmpty(txtUsuarioCliente.Text) || !string.IsNullOrEmpty(txtCostoCompra.Text) ||
                !string.IsNullOrEmpty(txtCostoMaterial.Text) || !string.IsNullOrEmpty(cmbPuntoEntrega.Text) || !string.IsNullOrEmpty(txtDescripcion.Text))
            {
                hayDatos = true;
            }

            // Si hay datos, preguntar al usuario si desea volver sin guardar
            if (hayDatos)
            {
                DialogResult resultado = MessageBox.Show("Hay datos no guardados. ¿Desea volver sin guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Si el usuario elige "Sí", regresar a la pestaña anterior
                    GestionPedidos gestionPedidos = new GestionPedidos();
                    gestionPedidos.Rol = rolUsuario;
                    gestionPedidos.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, volver al panel sin preguntar
                GestionPedidos gestionPedidos = new GestionPedidos();
                gestionPedidos.Rol = rolUsuario;
                gestionPedidos.Show();
                this.Hide();
            }
        }

        private void tlsbtnVisualizarPedidos_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;
            if (!string.IsNullOrEmpty(txtApellidoCliente.Text) || !string.IsNullOrEmpty(txtCorreoCliente.Text) || !string.IsNullOrEmpty(txtTelefonoCliente.Text) || !string.IsNullOrEmpty(txtUsuarioCliente.Text) || !string.IsNullOrEmpty(txtCostoCompra.Text) ||
                !string.IsNullOrEmpty(txtCostoMaterial.Text) || !string.IsNullOrEmpty(txtDescripcion.Text) || !string.IsNullOrEmpty(cmbEstado.Text))
            {
                hayDatos = true;
            }

            // Si hay datos, preguntar al usuario si desea volver sin guardar
            if (hayDatos)
            {
                DialogResult resultado = MessageBox.Show("Hay datos no guardados. ¿Desea volver sin guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Si el usuario elige "Sí", regresar al panel de administrador
                    ActualizarPedido actualizarPedido = new ActualizarPedido();
                    actualizarPedido.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, volver al panel sin preguntar
                ActualizarPedido actualizarPedido = new ActualizarPedido();
                actualizarPedido.Show();
                this.Hide();
            }
        }

        // Eventos para restringir y validar datos
        private void txtColaborador_Leave(object sender, EventArgs e)
        {
            // Si el TextBox está vacío, se le asigna "No asignado"
            if (string.IsNullOrEmpty(txtColaborador.Text.Trim()))
            {
                txtColaborador.Text = "No asignado";
            }
        }
        private void montos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Si no es un número ni Backspace, se cancela el evento (no se permite la tecla)
                e.Handled = true;
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

        // Validación de Datos
        private void txtColaborador_TextChanged(object sender, EventArgs e)
        {
            string colaborador = txtColaborador.Text.Trim();

            // Si el campo está vacío, vaciar el mensaje en lblValidarColaborador
            if (string.IsNullOrEmpty(colaborador))
            {
                lblValidarColaborador.Text = ""; // Vaciar el mensaje
                return;
            }

            // Si el colaborador no ha sido asignado
            if (colaborador == "No asignado")
            {
                lblValidarColaborador.Text = ""; // Vaciar el mensaje
                return;
            }

            // Buscar el usuario en la lista de usuarios
            var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.Usuario == colaborador);

            if (usuarioEncontrado != null)
            {
                // Si el usuario existe, verificar su rol
                if (usuarioEncontrado.Rol == "Colaborador")
                {
                    lblValidarColaborador.ForeColor = System.Drawing.Color.Green;
                    lblValidarColaborador.Text = "El colaborador ha sido asignado";
                }
                else
                {
                    lblValidarColaborador.ForeColor = System.Drawing.Color.Red;
                    lblValidarColaborador.Text = "*El usuario no puede asignarse a la orden";
                }
            }
            else
            {
                // Si el usuario no existe
                lblValidarColaborador.ForeColor = System.Drawing.Color.Red;
                lblValidarColaborador.Text = "*El usuario no existe";
            }
        }

        // Método para guardar el último ID en un archivo
        private void GuardarUltimoID(int ultimoID)
        {
            string rutaID = "ultimoID.txt";  // Ruta del archivo donde se guardará el ID
            File.WriteAllText(rutaID, ultimoID.ToString());
        }

        // Método para cargar el último ID desde un archivo
        private int CargarUltimoID()
        {
            string rutaID = "ultimoID.txt";  // Ruta del archivo donde se guardará el ID

            // Verificar si el archivo existe
            if (File.Exists(rutaID))
            {
                // Leer el valor del último ID desde el archivo
                string contenido = File.ReadAllText(rutaID);
                if (int.TryParse(contenido, out int ultimoID))
                {
                    return ultimoID;
                }
            }

            // Si no existe el archivo o no se puede leer, devolver 1 como valor predeterminado
            // Crear el archivo si no existe
            File.WriteAllText(rutaID, "1"); // Inicializa el archivo con el valor 1
            return 1;
        }

    }
}
