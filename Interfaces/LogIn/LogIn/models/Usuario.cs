using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn.models
{
    public struct Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; } // "cliente" o "colaborador"

        public Usuario(string nombreUsuario, string contrasena, string tipoUsuario)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            TipoUsuario = tipoUsuario;
        }

        // Método para verificar si las credenciales son correctas
        public bool VerificarCredenciales(string usuario, string contrasena)
        {
            return NombreUsuario == usuario && Contrasena == contrasena;
        }
    }
}
