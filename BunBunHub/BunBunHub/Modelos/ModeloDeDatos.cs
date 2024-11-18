using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Modelos
{
    internal class ModeloDeDatos
    {
        public class Usuarios
        {
            // Propiedades con get y set
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; } // [Administrador] [Colaborador] [Cliente]
            public string Estado { get; set; } // [Activo] [Inhabilitado]

            // Constructor para inicializar un objeto de la clase Usuarios
            public Usuarios(string usuario, string contraseña, string rol, string estado)
            {
                Usuario = usuario;
                Contraseña = contraseña;
                Rol = rol;
                Estado = estado;
            }
        }

        // Clase que representa los detalles de un cliente
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

            // Constructor para inicializar un objeto de la clase DetallesCliente
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
