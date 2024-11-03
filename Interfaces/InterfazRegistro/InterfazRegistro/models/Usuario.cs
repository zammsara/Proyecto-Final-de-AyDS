using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazRegistro.models
{
    public struct Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool EsCliente { get; set; }
        public bool EsColaborador { get; set; }

        public Usuario(string nombre, string apellido, DateTime fechaNacimiento,
                       string usuarioNombre, string contrasena, string confirmarContrasena,
                       string telefono, string correo, string direccion,
                       bool esCliente, bool esColaborador)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            UsuarioNombre = usuarioNombre;
            Contrasena = contrasena;
            ConfirmarContrasena = confirmarContrasena;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            EsCliente = esCliente;
            EsColaborador = esColaborador;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Apellido: {Apellido}, Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}, " +
                   $"Usuario: {UsuarioNombre}, Teléfono: {Telefono}, Correo: {Correo}, Dirección: {Direccion}, " +
                   $"Cliente: {EsCliente}, Colaborador: {EsColaborador}";
        }
    }
}
