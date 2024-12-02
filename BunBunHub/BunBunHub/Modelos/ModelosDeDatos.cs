using System;
using System.Collections.Generic;
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
    }
}
