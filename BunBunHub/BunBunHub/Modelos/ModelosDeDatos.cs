using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Modelos
{
    public class ModelosDeDatos
    {
        [Serializable]
        public class Usuarios
        {

            public string Usuario { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; } // [Administrador] [Colaborador] [Cliente]
            public string Estado { get; set; } // [Activo] [Inhabilitado]

        }

        [Serializable]
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

        }
    }
}
