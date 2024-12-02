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

namespace BunBunHub.Formularios
{
    public partial class GenerarInformes : Form
    {
        public GenerarInformes()
        {
            InitializeComponent();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
    }
}
