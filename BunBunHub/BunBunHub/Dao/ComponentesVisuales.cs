using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunBunHub.Dao
{
    internal class ComponentesVisuales
    {
        public static class EfectosVisuales
        {
            public static void OnBtn_MouseEnter(object sender, EventArgs e)
            {
                // Cambiar color de fondo y texto cuando el mouse entra
                Button btn = sender as Button;
                btn.BackColor = Color.DodgerBlue;
                btn.ForeColor = Color.Blue;
            }
            public static void OnBtn_MouseLeave(object sender, EventArgs e)
            {
                // Restaurar el color original cuando el mouse sale
                Button btn = sender as Button;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
            public static void OnBtn_MouseDown(object sender, MouseEventArgs e)
            {
                // Disminuir el tamaño del botón para simular que se presiona
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.Width -= 5;
                    btn.Height -= 5;
                }
            }
            public static void OnBtn_MouseUp(object sender, MouseEventArgs e)
            {
                // Restaurar el tamaño original del botón cuando el clic se libera
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.Width += 5;
                    btn.Height += 5;
                }
            }
        }
    }
}
