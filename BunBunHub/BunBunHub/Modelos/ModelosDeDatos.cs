using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Modelos
{
    public class ModelosDeDatos
    {
        public class Usuarios
        {
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; } // [Administrador] [Colaborador] [Cliente]
            public string Estado { get; set; } // [Activo] [Inhabilitado]

            public Usuarios(string usuario, string contraseña, string rol, string estado)
            {
                Usuario = usuario;
                Contraseña = contraseña;
                Rol = rol;
                Estado = estado;
            }
        }

        public class DetallesCliente
        {
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }
            public string Correo { get; set; }
            public int Telefono { get; set; }
            public string Estado { get; set; } // [Activo] [Inhabilitado] [Eliminado]

            public DetallesCliente(string usuario, string contraseña, string nombre, string apellido, int edad, string correo, int telefono, string estado)
            {
                Usuario = usuario;
                Contraseña = contraseña;
                Nombre = nombre;
                Apellido = apellido;
                Edad = edad;
                Correo = correo;
                Telefono = telefono;
                Estado = estado;
            }
        }

        public static class UsuarioSesion
        {
            public static string NombreUsuario { get; set; }
            public static string RolUsuario { get; set; }
        }

        public static class Tracking
        {
            public static string IdPedido { get; set; }
        }

        public class Pedido
        {
            public string ID_Pedido { get; set; } // Número de orden
            public string Usuario { get; set; } // Cliente
            public string Colaborador { get; set; } // Colaborador asignado al pedido
            public DateTime Fecha_Compra { get; set; }
            public decimal Monto_Total { get; set; }
            public decimal Monto_Material { get; set; }
            public string Punto_Entrega { get; set; }
            public string Descripción { get; set; }
            public string Estado { get; set; } // [Recibido] [En Proceso] [Listo para Entrega] [Completado] [Cancelado]

            public Pedido (string iDPedido, string usuarioCliente, string usuarioColaborador, DateTime fechaCompra, decimal costoCompra, decimal costoMaterial, string puntoEntrega, string descripcion, string estado)
            {
                ID_Pedido = iDPedido;
                Usuario = usuarioCliente;
                Colaborador = usuarioColaborador;
                Fecha_Compra = fechaCompra;
                Monto_Total = costoCompra;
                Monto_Material = costoMaterial;
                Punto_Entrega = puntoEntrega;
                Descripción = descripcion;
                Estado = estado;
            }
        }

        public class Informe
        {
            public DateTime Fecha_Inicio { get; set; }
            public DateTime Fecha_Final { get; set; }
            public int Total_Pedidos { get; set; }
            public int Completados { get; set; }
            public decimal Total_Completados { get; set; }
            public int Cancelados { get; set; }
            public decimal Total_Cancelados { get; set; }
            public int Procesando { get; set; }
            public decimal Total_Procesando { get; set; }
            public decimal Ingresos { get; set; }
            public decimal Egresos { get; set; }
            public decimal Ganancias { get; set; }
            public string Rentabilidad { get; set; }

            public Informe (DateTime fechaInicio, DateTime fechaFinal, int totalPedidos, int completados, decimal totalCompletados, int cancelados, decimal totalCancelados, int procesando, decimal totalProcesando, decimal ingresos, decimal egresos, decimal ganancias, string rentabilidad)
            {
                Fecha_Inicio = fechaInicio;
                Fecha_Final = fechaFinal;
                Total_Pedidos = totalPedidos;
                Completados = completados;
                Total_Completados = totalCompletados;
                Cancelados = cancelados;
                Total_Cancelados = totalCancelados;
                Procesando = procesando;
                Total_Procesando = totalProcesando;
                Ingresos = ingresos;
                Egresos = egresos;
                Ganancias = ganancias;
                Rentabilidad = rentabilidad;
            }
        }

        public class ClienteResumen
        {
            public string Usuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        public class Imagen
        {
            public Image Image { get; set; }

            public static Imagen FromFile(string path)
            {
                return new Imagen { Image = Image.FromFile(path) };
            }

            public static Imagen FromStream(MemoryStream stream)
            {
                return new Imagen { Image = Image.FromStream(stream) };
            }
        }

    }
}
