using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Modelos
{
    internal class ModelosDeDatos
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
    }
}
