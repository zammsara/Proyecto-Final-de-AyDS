using BunBunHub.Modelos;
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
using static BunBunHub.Modelos.ModeloDeDatos;

namespace BunBunHub.Formularios
{
    public partial class VisualizarUsuarios : Form
    {
        private string rutaArchivo = "usuarios.dat";
        public VisualizarUsuarios()
        {
            InitializeComponent();
            ConfigurarCmb();
        }

        private void CargarDatosEnDataGridView()
        {
            if (File.Exists(rutaArchivo))
            {
                var usuarios = new List<ModeloDeDatos.Usuarios>(); // Lista temporal para cargar los datos

                // Leer las líneas del archivo
                var lineas = File.ReadAllLines(rutaArchivo);
                foreach (var linea in lineas)
                {
                    // Asumimos que los datos están separados por comas en el archivo
                    var partes = linea.Split(',');

                    if (partes.Length == 4) // Validar formato
                    {
                        var usuario = new ModeloDeDatos.Usuarios(partes[0], partes[1], partes[2], partes[3]);
                        usuarios.Add(usuario);
                    }
                }

                // Actualizar el DataGridView con los datos
                DgvUsuarios.DataSource = null; // Limpia el origen de datos anterior
                DgvUsuarios.DataSource = usuarios;
            }
            else
            {
                MessageBox.Show("El archivo no existe o no contiene datos.", "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Método para configurar el combobox de los filtros
        private void ConfigurarCmb()
        {
            CmbFiltro.Items.Add("Todos los usuarios");
            CmbFiltro.Items.Add("Administrador");
            CmbFiltro.Items.Add("Colaborador");
            CmbFiltro.Items.Add("Cliente");
            CmbFiltro.SelectedIndex = 0; // Seleccionar "Todos los usuarios" por defecto
        }

        private void VisualizarUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatosEnDataGridView();
        }
    }
}
