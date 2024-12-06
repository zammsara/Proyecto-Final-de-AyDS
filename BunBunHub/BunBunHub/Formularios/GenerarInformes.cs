using BunBunHub.Dao;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Formularios
{
    public partial class GenerarInformes : Form
    {
        public List<Informe> listaInforme { get; set; }
        public static string rutaInforme = "informe.dat";

        public List<Pedido> listaPedidos = new List<Pedido>();
        public static string rutaPedidos = "pedidos.dat";

        public GenerarInformes()
        {
            InitializeComponent();
            listaInforme = new List<Informe>();

            GestionDeArchivos archivo = new GestionDeArchivos();
            listaPedidos = archivo.CargarPedidos(rutaPedidos);

            dtpInicio.Value = DateTime.Now;
            dtpFinal.Value = DateTime.Now;
            btnGuardar.Enabled = false; 
        }

        public void CargarDatos()
        {
            //Asegurarse de que la lista no sea nula antes de asignarla al DataGridView
            if (listaInforme != null && listaInforme.Count > 0)
            {
                dgvInformes.DataSource = listaInforme;
            }
        }
        public void ActualizarDatos(List<Informe> listaInforme)
        {
            //Asegurar de que las listas no sean nulas antes de asignarlas a los DataGridViews
            if (listaInforme != null && listaInforme.Count > 0)
            {
                dgvInformes.DataSource = listaInforme;
            }
        }

        private void ActualizarDataGridView()
        {
            dgvInformes.DataSource = null;
            dgvInformes.DataSource = listaInforme;
        }

        private void GenerarInformes_Load(object sender, EventArgs e)
        {
            // Crear una instancia de GestionDeArchivos
            var gestionArchivos = new GestionDeArchivos();

            // Cargar los datos si ya están asignados
            listaInforme = gestionArchivos.CargarInforme(rutaInforme);
            CargarDatos();
        }

        private void VerificarCampos()
        {
            // Verificar si los campos relevantes no están vacíos
            bool hayDatos = !string.IsNullOrWhiteSpace(txtTotalPedidos.Text) && !string.IsNullOrWhiteSpace(txtCompletados.Text);

            // Activar o desactivar el botón "Guardar" en base a los datos
            btnGuardar.Enabled = hayDatos;
        }


        // Funcionalidades
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener el rango de fechas
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFinal.Value;

            // Validación de fechas
            if (fechaFin < fechaInicio)
            {
                // Mostrar mensaje de error
                MessageBox.Show("La fecha de finalización no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Establecer ambos DateTimePickers a la fecha actual
                dtpInicio.Value = DateTime.Now;
                dtpFinal.Value = DateTime.Now;
                dtpInicio.Focus();

                return;
            }

            List<Pedido> pedidosEnRango = new List<Pedido>();

            foreach (var pedido in listaPedidos)
            {
                if (pedido.Fecha_Compra >= fechaInicio && pedido.Fecha_Compra <= fechaFin)
                {
                    pedidosEnRango.Add(pedido);  // Agregar a la lista si está dentro del rango de fechas
                }
            }

            // Calcular los totales de Pedidos
            int totalPedidos = pedidosEnRango.Count;
            int Completados = 0, Cancelados = 0, Recibido = 0, Proceso = 0, ListoEntregar = 0;
            decimal MontoCompletados = 0, MontoCancelados = 0, MontoRecibido = 0, MontoProceso = 0, MontoListoEntregar = 0;

            // Usamos un bucle for para iterar sobre los pedidos en el rango de fechas
            foreach (var pedido in pedidosEnRango)
            {
                // Sumar los totales por estado
                switch (pedido.Estado)
                {
                    case "Completado":
                        Completados++;
                        MontoCompletados += pedido.Monto_Total;
                        break;
                    case "Cancelado":
                        Cancelados++;
                        MontoCancelados += pedido.Monto_Total;
                        break;
                    case "Recibido":
                        Recibido++;
                        MontoRecibido += pedido.Monto_Total;
                        break;
                    case "En proceso":
                        Proceso++;
                        MontoProceso += pedido.Monto_Total;
                        break;
                    case "Listo para entrega":
                        ListoEntregar++;
                        MontoListoEntregar += pedido.Monto_Total;
                        break;
                }
            }

            // Calcular los pedidos procesando
            int Procesando = Recibido + Proceso + ListoEntregar;
            decimal MontoProcesando = MontoRecibido + MontoProceso + MontoListoEntregar;

            // Calcular los totales de Resultados
            decimal Ingresos = MontoCompletados;
            decimal Egresos = 0;

            // Usamos un bucle for para calcular los egresos de "Completado"
            foreach (var pedido in pedidosEnRango)
            {
                if (pedido.Estado == "Completado")
                {
                    Egresos += pedido.Monto_Material;
                }
            }

            decimal Ganancias = Ingresos - Egresos;
            string Rentabilidad;

            if (Ganancias > 0)
            {
                Rentabilidad = "Positiva";
            }
            else if (Ganancias < 0)
            {
                Rentabilidad = "Negativa";
            }
            else
            {
                Rentabilidad = "Nula";
            }

            // Mostrar los resultados
            txtTotalPedidos.Text = totalPedidos.ToString();
            txtCompletados.Text = Completados.ToString();
            txtCancelados.Text = Cancelados.ToString();
            txtProcesando.Text = Procesando.ToString();
            txtMontoCompletados.Text = MontoCompletados.ToString();
            txtMontoCancelados.Text = MontoCancelados.ToString();
            txtMontoProcesando.Text = MontoProcesando.ToString();
            txtIngresos.Text = Ingresos.ToString();
            txtEgresos.Text = Egresos.ToString();
            txtGanancias.Text = Ganancias.ToString();
            txtRentabilidad.Text = Rentabilidad;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preguntar al usuario si está seguro de guardar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea guardar los datos?", "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Continuar con el proceso de guardar el informe

                DateTime inicio = dtpInicio.Value;
                DateTime final = dtpFinal.Value;
                int totalPedidos = int.Parse(txtTotalPedidos.Text);
                int completados = int.Parse(txtCompletados.Text);
                int cancelados = int.Parse(txtCancelados.Text);
                int procesando = int.Parse(txtProcesando.Text);
                decimal montoCompletados = decimal.Parse(txtMontoCompletados.Text);
                decimal montoCancelados = decimal.Parse(txtMontoCancelados.Text);
                decimal montoProcesando = decimal.Parse(txtMontoProcesando.Text);
                decimal ingresos = decimal.Parse(txtIngresos.Text);
                decimal egresos = decimal.Parse(txtEgresos.Text);
                decimal ganancias = decimal.Parse(txtGanancias.Text);
                string rentabilidad = txtRentabilidad.Text;

                // Crear y agregar el nuevo informe
                Informe nuevoInforme = new Informe(inicio, final, totalPedidos, completados, montoCompletados, cancelados, montoCancelados, procesando, montoProcesando, ingresos, egresos, ganancias, rentabilidad);
                listaInforme.Add(nuevoInforme);
                GestionDeArchivos.GuardarInforme(listaInforme, rutaInforme);

                // Actualizar el DataGridView con los nuevos datos
                ActualizarDataGridView();

                // Confirmación de guardado exitoso
                MessageBox.Show("Informe guardado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                LimpiarCampos();
                dtpInicio.Focus();
            }
        }


        private void LimpiarCampos()
        {
            dtpInicio.Value = DateTime.Now;
            dtpFinal.Value = DateTime.Now;
            txtTotalPedidos.Clear();
            txtCompletados.Clear();
            txtCancelados.Clear();
            txtProcesando.Clear();
            txtMontoCompletados.Clear();
            txtMontoCancelados.Clear();
            txtMontoProcesando.Clear();
            txtIngresos.Clear();
            txtEgresos.Clear();
            txtGanancias.Clear();
            txtRentabilidad.Clear();
        }

        // Lógica de navegación entre forms

        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnPanelControl_Click(object sender, EventArgs e)
        {
            PanelAdministrador panelAdministrador = new PanelAdministrador();
            panelAdministrador.Show();
            this.Hide();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // Crear el DataSource con la lista de datos
            ReportDataSource dataSource = new ReportDataSource("DsDatos", listaInforme);

            // Crear una instancia del formulario FrmReporte
            FrmReporte frmReportes = new FrmReporte();

            // Limpiar cualquier fuente de datos anterior
            frmReportes.reportViewer1.LocalReport.DataSources.Clear();

            // Agregar la fuente de datos
            frmReportes.reportViewer1.LocalReport.DataSources.Add(dataSource);

            // Establecer el informe embebido
            frmReportes.reportViewer1.LocalReport.ReportEmbeddedResource = "BunBunHub.Reportes.RptBunBunHub.rdlc";

            // Actualizar el reporte
            frmReportes.reportViewer1.RefreshReport();

            // Mostrar el formulario con el reporte
            frmReportes.ShowDialog();
        }

        private void txtTotalPedidos_TextChanged(object sender, EventArgs e)
        {
            VerificarCampos();
        }

        private void txtCompletados_TextChanged(object sender, EventArgs e)
        {
            VerificarCampos();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvInformes.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este informe?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice del informe seleccionado
                    int informeSeleccionadoIndex = dgvInformes.SelectedRows[0].Index;

                    // Obtener el informe que será eliminado
                    Informe informe = listaInforme[informeSeleccionadoIndex];

                    // Eliminar el usuario de la lista de usuarios
                    listaInforme.RemoveAt(informeSeleccionadoIndex);

                    GestionDeArchivos.GuardarInforme(listaInforme, GenerarInformes.rutaInforme);
                    // Actualizar los DataGridViews para reflejar los cambios
                    ActualizarDataGridView(); // Actualiza el DataGridView de usuarios

                    // Limpiar el DataGridView de clientes y volver a cargar los datos actualizados
                    dgvInformes.DataSource = null;  // Limpiar la fuente de datos
                    dgvInformes.DataSource = listaInforme; // Volver a cargar la lista de clientes

                    MessageBox.Show("Informe eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
