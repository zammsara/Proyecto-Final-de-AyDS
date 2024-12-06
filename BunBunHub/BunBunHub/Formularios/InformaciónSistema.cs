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
    public partial class InformaciónSistema : Form
    {
        public InformaciónSistema()
        {
            // Acceder al rol desde la clase estática
            string rolUsuario = UsuarioSesion.RolUsuario;

            InitializeComponent();
            MostrarInformacion(rolUsuario);
        }

        private void MostrarInformacion(string rolUsuario)
        {
            string mensaje = string.Empty;

            switch (rolUsuario)
            {
                case "Administrador":
                    mensaje = "¡Bienvenido al Panel Administrativo de BunBunHub! 🎉\n\n"
                            + "Aquí tienes el control total para gestionar el sistema:\n"
                            + "- Administra usuarios, pedidos y reportes financieros.\n"
                            + "- Supervisa los pedidos pendientes y mantén todo organizado.\n"
                            + "- Decide las imágenes de publicidad para tus clientes.\n\n"
                            + "¡Gracias por liderar el éxito de BunBunHub!";
                    break;
                case "Colaborador":
                    mensaje = "¡Hola! Gracias por ser parte de BunBunHub 💪\n\n"
                            + "En este panel, puedes:\n"
                            + "- Registrar y actualizar información de nuestros valiosos clientes.\n"
                            + "- Gestionar pedidos y asegurarte de que todo esté en marcha.\n"
                            + "- Visualizar los pedidos pendientes para mantener un servicio eficiente.\n\n"
                            + "¡Tu contribución hace la diferencia cada día!";
                    break;
                case "Cliente":
                    mensaje = "¡Bienvenido a BunBunHub! 🐰💖\n\n"
                            + "Nos encanta tenerte aquí. Desde este panel, puedes:\n"
                            + "- Consultar el estado de tus pedidos y modificarlos según necesites.\n"
                            + "- Actualizar tu perfil o gestionar tu cuenta fácilmente.\n"
                            + "- Explorar tu historial de pedidos para revivir tus mejores compras.\n\n"
                            + "¡Gracias por confiar en nosotros para tus creaciones personalizadas!";
                    break;
                default:
                    mensaje = "Rol no reconocido. Contacta al administrador.";
                    break;
            }

            lblInformacion.Text = mensaje;
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
