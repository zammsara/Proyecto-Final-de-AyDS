using BunBunHub.Dao;
using BunBunHub.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class RegistrarUsuario : Form
    {

        public static string nuevarutaUsuarios = "usuario.dat";
        public static string nuevarutaClientes = "cliente.dat";

        private List<Usuarios> listaUsuarios; // Lista de usuarios
        private List<DetallesCliente> listaClientes; // Lista de clientes
        public RegistrarUsuario()
        {
            InitializeComponent();
            // Inicializar las listas vacías al cargar el formulario
            listaUsuarios = new List<Usuarios>();
            listaClientes = new List<DetallesCliente>();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;

            // Verificar los controles más importantes
            if (!string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbRol.SelectedIndex != -1 ||
                cmbEstado.SelectedIndex != -1)
            {
                hayDatos = true;
            }

            // Si hay datos en algún control, mostrar el mensaje
            if (hayDatos)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea volver? Los datos no se guardarán.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GestionUsuarios gestionUsuarios = new GestionUsuarios();
                    gestionUsuarios.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, solo volver sin mostrar mensaje
                GestionUsuarios gestionUsuariosSinMensaje = new GestionUsuarios();
                gestionUsuariosSinMensaje.Show();
                this.Hide();
            }
        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            // Verificar si al menos uno de los controles tiene datos
            bool hayDatos = false;

            // Verificar los controles más importantes
            if (!string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbRol.SelectedIndex != -1 ||
                cmbEstado.SelectedIndex != -1)
            {
                hayDatos = true;
            }

            // Si hay datos en algún control, mostrar el mensaje
            if (hayDatos)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea volver? Los datos no se guardarán.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    PanelAdministrador panelAdministrador = new PanelAdministrador();
                    panelAdministrador.Show();
                    this.Hide();
                }
            }
            else
            {
                // Si no hay datos, solo volver sin mostrar mensaje

                // Verificar el rol del usuario actual almacenado en la clase Sesion
                string rolUsuario = Sesion.UsuarioSesion.RolUsuario;

                // Comprobar el rol y mostrar el formulario adecuado
                if (rolUsuario == "Administrador")
                {
                    // Si el rol es "Administrador", abrir el panel de administrador
                    PanelAdministrador panelAdministrador = new PanelAdministrador();
                    panelAdministrador.Show();
                }
                else if (rolUsuario == "Colaborador")
                {
                    // Si el rol es "Colaborador", abrir el panel de colaborador
                    PanelColaborador panelColaborador = new PanelColaborador();
                    panelColaborador.Show();
                }

                // Cerrar el formulario actual de GestionPedido
                this.Close();
            }
        }


        private void tlsbtnVisualizarRegistros_Click(object sender, EventArgs e)
        {
            VisualizarUsuarios actualizarRegistro = new VisualizarUsuarios(listaUsuarios, listaClientes);
            actualizarRegistro.Show();
            this.Hide();
        }

        private void tlsbtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se limpiarán todos los controles ¿Está seguro de que desea limpiar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtTelefono.Clear();
                txtUsuarioNombre.Clear();
                txtContraseña.Clear();
                txtConfirmarContraseña.Clear();
                txtCorreo.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtEdad.Clear();
                lblConfirmación.Text = "";
                lblValidacion.Text = "";
                lblValidarTelefono.Text = "";

                // Limpiar los ComboBox
                cmbRol.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
            }
        }

        private void tlsbtnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los controles tengan información
            ValidarCampos();

            // Verificar que los ComboBox tengan un valor seleccionado
            if (cmbRol.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar las condiciones que deben cumplirse antes de guardar
            if (lblValidacion.Text != "Contraseña Válida")
            {
                MessageBox.Show("La contraseña no es válida", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblConfirmación.Text != "Las contraseñas cohinciden")
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifique la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rolSeleccionado = cmbRol.SelectedItem.ToString();

            //Si el rol es Cliente, verificar que los campos adicionales estén llenos
            if (rolSeleccionado == "Cliente") 
            {
                if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuarioNombre.Focus();
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
                    MessageBox.Show("El número de teléfono no es válido. Por favor, verifique el número.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar edad (mayor de 18 años)
                if (int.TryParse(txtEdad.Text, out int edadValida))
                {
                    if (edadValida < 18)
                    {
                        MessageBox.Show("El cliente debe ser mayor de 18 años.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad para corregir
                        return;
                    }
                    else if (edadValida > 100)
                    {
                        MessageBox.Show("Por favor, ingresa una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEdad.Focus(); // Coloca el cursor en el campo de edad si no es un número válido
                        return;
                    }
                }
            }


            // Lógica según el rol seleccionado
            if (rolSeleccionado == "Cliente")
            {
                // Crear un nuevo cliente
                DetallesCliente nuevoCliente = new DetallesCliente
                {
                    Usuario = txtUsuarioNombre.Text,
                    Contraseña = txtContraseña.Text,
                    Estado = cmbEstado.SelectedItem.ToString(),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Correo = txtCorreo.Text,
                    Edad = int.Parse(txtEdad.Text),
                   Telefono = int.Parse(txtTelefono.Text)
                };

                // Leer los datos existentes
                listaClientes = ManejoArchivos<DetallesCliente>.CargarDatos(RegistrarUsuario.nuevarutaClientes);

                // Agregar nuevo cliente a la lista
                listaClientes.Add(nuevoCliente);

                // Guardar la lista completa en el archivo
                ManejoArchivos<DetallesCliente>.GuardarDatos(RegistrarUsuario.nuevarutaClientes, listaClientes);

                // Crear un nuevo usuario 
                Usuarios nuevoUsuario = new Usuarios
                {
                    Usuario = txtUsuarioNombre.Text,
                    Contraseña = txtContraseña.Text,
                    Rol = rolSeleccionado,
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                // Leer los datos existentes
                listaUsuarios = ManejoArchivos<Usuarios>.CargarDatos(RegistrarUsuario.nuevarutaUsuarios);

                // Agregar a la lista de usuarios
                listaUsuarios.Add(nuevoUsuario);

                //Guardar datos en el archivo
                ManejoArchivos<Usuarios>.GuardarDatos("usuario.dat", listaUsuarios);

                //Desactivar los controles después de registrar un cliente
                grpDatosCliente.Enabled = false;
                grpContacto.Enabled = false;

                MessageBox.Show("Usuario registrado correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (rolSeleccionado == "Administrador" || rolSeleccionado == "Colaborador")
            {
                // Crear un nuevo usuario 
                Usuarios nuevoUsuario = new Usuarios
                { 
                    Usuario = txtUsuarioNombre.Text,
                    Contraseña = txtContraseña.Text,
                    Rol = rolSeleccionado,
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                // Leer los datos existentes
                listaUsuarios = ManejoArchivos<Usuarios>.CargarDatos(RegistrarUsuario.nuevarutaUsuarios);

                // Agregar a la lista de usuarios
                listaUsuarios.Add(nuevoUsuario); 

                //Guardar datos en el archivo
                ManejoArchivos<Usuarios>.GuardarDatos("usuario.dat", listaUsuarios); 

                MessageBox.Show("Usuario registrado correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Limpiar los campos después de guardar
            LimpiarCampos();
            txtUsuarioNombre.Focus();
        }

        private void ValidarCampos()
        {
            // Verificar que todos los controles tengan información
            if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text) )
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioNombre.Focus(); // Coloca el cursor en el campo vacío
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus(); // Coloca el cursor en el campo vacío
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus(); // Coloca el cursor en el campo vacío
                return;
            }
        }

        private void LimpiarCampos()
        {
            txtTelefono.Clear();
            txtUsuarioNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            lblConfirmación.Text = "";
            lblValidacion.Text = "";
            lblValidarTelefono.Text = "";

            // Limpiar los ComboBox
            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Comprobar si hay un elemento seleccionado (SelectedIndex != -1)
            if (cmbRol.SelectedIndex != -1)
            {
                // Verificar si el rol seleccionado es "Cliente"
                if (cmbRol.SelectedItem.ToString() == "Cliente")
                {
                    grpDatosCliente.Enabled = true;
                    grpContacto.Enabled = true;
                }
                else
                {
                    grpDatosCliente.Enabled = false;
                    grpContacto.Enabled = false;
                }
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            string contraseña = txtContraseña.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                lblValidacion.Text = "";
                return;
            }

            if (contraseña.Length < 8)
            {
                lblValidacion.ForeColor = System.Drawing.Color.Firebrick;
                lblValidacion.Text = "*La contraseña es muy corta";
            }
            else if (contraseña.Length > 10)
            {
                lblValidacion.ForeColor = System.Drawing.Color.Red;
                lblValidacion.Text = "*La contraseña es muy larga";
            }
            // Validación de símbolos permitidos
            else if (!Regex.IsMatch(contraseña, @"^[a-zA-Z0-9*_!/&]+$"))
            {
                lblValidacion.ForeColor = System.Drawing.Color.Red;
                lblValidacion.Text = "*Solo se permiten simbolos *, _, !, / o &";
            }
            // Si la contraseña es válida
            else
            {
                lblValidacion.ForeColor = System.Drawing.Color.Green;
                lblValidacion.Text = "Contraseña Válida";
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla presionada es un espacio (código ASCII 32), no se permite
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            // Si el TextBox de confirmar contraseña está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                lblConfirmación.Text = "";
                return;
            }

            if (txtConfirmarContraseña.Text != txtContraseña.Text)
            {
                lblConfirmación.ForeColor = System.Drawing.Color.Firebrick;
                lblConfirmación.Text = "*Las contraseñas no coinciden";
            }
            else
            {
                lblConfirmación.ForeColor = System.Drawing.Color.Green;
                lblConfirmación.Text = "Las contraseñas cohinciden";
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
            else
            {
                // Si el teléfono es válido
                lblValidarTelefono.ForeColor = System.Drawing.Color.Green;
                lblValidarTelefono.Text = "Número de teléfono válido";
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            // Si el TextBox está vacío, no hacer nada y no mostrar ningún mensaje
            if (string.IsNullOrEmpty(correo))
            {
                lblCorreoValidacion.Text = " ";
                return;
            } 
            
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblCorreoValidacion.ForeColor = System.Drawing.Color.Firebrick;
                lblCorreoValidacion.Text = "*El correo debe de contener @ y punto";
            }else
            {
                lblCorreoValidacion.Text = " ";
            }

        }
    }
}
