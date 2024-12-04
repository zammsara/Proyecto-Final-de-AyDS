using BunBunHub.Dao;
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

        // Funcionalidades
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener el rango de fechas
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFinal.Value;

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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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

            MessageBox.Show("Informe guardado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            dtpInicio.Focus();
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
    }
}
