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

        [Serializable]
        public class Pedidos
        {
            public int IDPedido { get; set; } // Número de orden
            public string UsuarioCliente { get; set; } // Cliente
            public string PuntoEntrega { get; set; }
            public string UsuarioColaborador { get; set; } // Colaborador asignado al pedido
            public string FechaCompra { get; set; }
            public string Descripcion { get; set; }
            public string CostoCompra { get; set; }
            public string CostoMaterial { get; set; }
            public string Estado { get; set; } // [Recibido] [En Proceso] [Listo para Entrega] [Completado] [Cancelado]


        }
    }
}
