using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Usuarios
{
    internal class ModeloDeDatos
    {
        public class Usuarios
        {
            public string Usuario;
            public string Contraseña;
            public int Rol; // [Administrador] [Colaborador] [Cliente]
            public int Estado; // [Activo] [Inhabilitado]

            // Constructor para inicializar un objeto de la clase Usuarios
            public Usuarios(string usuario, string contraseña, int rol, int estado)
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
            public string Usuario;
            public string Contraseña;
            public string Nombre;
            public string Apellido;
            public string Correo;
            public int Telefono;
            public int Estado; // Estado del cliente: [Activo] [Inhabilitado]

            // Constructor para inicializar un objeto de la clase DetallesCliente
            public DetallesCliente(string usuario, string contraseña, string nombre, string apellido, string correo, int telefono, int estado)
            {
                Usuario = usuario;
                Contraseña = contraseña;
                Nombre = nombre;
                Apellido = apellido;
                Correo = correo;
                Telefono = telefono;
                Estado = estado;
            }
        }
    }
}
