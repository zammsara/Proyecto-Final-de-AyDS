using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BunBunHub.Modelos.ModelosDeDatos;

namespace BunBunHub.Dao
{
    internal class GestionDeArchivos
    {
        public static void GuardarUsuarios(List<Usuarios> listaUsuarios, string rutaUsuarios)
        {
            using (FileStream archivoUsuario = new FileStream(rutaUsuarios, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivoUsuario))
                {
                    foreach (Usuarios usuario in listaUsuarios)
                    {
                        escritor.Write(usuario.Usuario.Length);
                        escritor.Write(usuario.Usuario.ToCharArray());
                        escritor.Write(usuario.Contraseña.Length);
                        escritor.Write(usuario.Contraseña.ToCharArray());
                        escritor.Write(usuario.Rol.Length);
                        escritor.Write(usuario.Rol.ToCharArray());
                        escritor.Write(usuario.Estado.Length);
                        escritor.Write(usuario.Estado.ToCharArray());
                    }
                }
            }
        }

        public static void GuardarClientes(List<DetallesCliente> listaClientes, string rutaClientes)
        {
            using (FileStream archivoCliente = new FileStream(rutaClientes, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivoCliente))
                {
                    foreach (DetallesCliente cliente in listaClientes)
                    {
                        escritor.Write(cliente.Usuario.Length);
                        escritor.Write(cliente.Usuario.ToCharArray());
                        escritor.Write(cliente.Contraseña.Length);
                        escritor.Write(cliente.Contraseña.ToCharArray());
                        escritor.Write(cliente.Nombre.Length);
                        escritor.Write(cliente.Nombre.ToCharArray());
                        escritor.Write(cliente.Apellido.Length);
                        escritor.Write(cliente.Apellido.ToCharArray());
                        escritor.Write(cliente.Edad);
                        escritor.Write(cliente.Correo.Length);
                        escritor.Write(cliente.Correo.ToCharArray());
                        escritor.Write(cliente.Telefono);
                        escritor.Write(cliente.Estado.Length);
                        escritor.Write(cliente.Estado.ToCharArray());
                    }
                }
            }
        }

        public List<Usuarios> CargarUsuarios(string rutaUsuarios)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            if (!File.Exists(rutaUsuarios)) // Verificar si el archivo existe
            {
                return usuarios; // Si no existe el archivo, retornamos la lista vacía
            }

            using (FileStream archivoUsuarios = new FileStream(rutaUsuarios, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivoUsuarios))
                {
                    try
                    {
                        while (archivoUsuarios.Position != archivoUsuarios.Length)
                        {
                            int tamaño = lector.ReadInt32();
                            char[] UsuarioArray = lector.ReadChars(tamaño);
                            string nombreUsuario = new string(UsuarioArray);
                            tamaño = lector.ReadInt32();
                            char[] ContraseñaArray = lector.ReadChars(tamaño);
                            string contraseña = new string(ContraseñaArray);
                            tamaño = lector.ReadInt32();
                            char[] RolArray = lector.ReadChars(tamaño);
                            string rol = new string(RolArray);
                            tamaño = lector.ReadInt32();
                            char[] EstadoArray = lector.ReadChars(tamaño);
                            string estado = new string(EstadoArray);

                            Usuarios usuario = new Usuarios(nombreUsuario, contraseña, rol, estado);
                            usuarios.Add(usuario);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        // Se ha alcanzado el final del archivo
                    }
                }
            }
            return usuarios;
        }

        public List<DetallesCliente> CargarClientes(string rutaClientes)
        {
            List<DetallesCliente> clientes = new List<DetallesCliente>();

            if (!File.Exists(rutaClientes)) // Verificar si el archivo existe
            {
                return clientes; // Si no existe el archivo, retornamos la lista vacía
            }

            using (FileStream archivoClientes = new FileStream(rutaClientes, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivoClientes))
                {
                    try
                    {
                        while (archivoClientes.Position != archivoClientes.Length)
                        {
                            // Leer el campos
                            int tamaño = lector.ReadInt32();
                            char[] UsuarioArray = lector.ReadChars(tamaño);
                            string usuario = new string(UsuarioArray);
                            tamaño = lector.ReadInt32();
                            char[] ContraseñaArray = lector.ReadChars(tamaño);
                            string contraseña = new string(ContraseñaArray);
                            tamaño = lector.ReadInt32();
                            char[] NombreArray = lector.ReadChars(tamaño);
                            string nombre = new string(NombreArray);
                            tamaño = lector.ReadInt32();
                            char[] ApellidoArray = lector.ReadChars(tamaño);
                            string apellido = new string(ApellidoArray);
                            int edad = lector.ReadInt32();
                            tamaño = lector.ReadInt32();
                            char[] CorreoArray = lector.ReadChars(tamaño);
                            string correo = new string(CorreoArray);
                            int telefono = lector.ReadInt32();
                            tamaño = lector.ReadInt32();
                            char[] EstadoArray = lector.ReadChars(tamaño);
                            string estado = new string(EstadoArray);

                            // Crear el objeto DetallesCliente y agregarlo a la lista
                            DetallesCliente cliente = new DetallesCliente(usuario, contraseña, nombre, apellido, edad, correo, telefono, estado);
                            clientes.Add(cliente);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        // Se ha alcanzado el final del archivo
                    }
                }
            }

            return clientes;
        }

        public static void GuardarPedidos(List<Pedido> listaPedidos, string rutaPedidos)
        {
            using (FileStream archivoPedidos = new FileStream(rutaPedidos, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivoPedidos))
                {
                    foreach (Pedido pedido in listaPedidos)
                    {
                        // Escribir los campos de la clase Pedido
                        escritor.Write(pedido.ID_Pedido.Length);
                        escritor.Write(pedido.ID_Pedido.ToCharArray());
                        escritor.Write(pedido.Usuario.Length);
                        escritor.Write(pedido.Usuario.ToCharArray());
                        escritor.Write(pedido.Colaborador.Length);
                        escritor.Write(pedido.Colaborador.ToCharArray());
                        escritor.Write(pedido.Fecha_Compra.ToString());// Convertir a string para escribir
                        escritor.Write(pedido.Monto_Total);
                        escritor.Write(pedido.Monto_Material);
                        escritor.Write(pedido.Punto_Entrega.Length);
                        escritor.Write(pedido.Punto_Entrega.ToCharArray());
                        escritor.Write(pedido.Descripción.Length);
                        escritor.Write(pedido.Descripción.ToCharArray());
                        escritor.Write(pedido.Estado.Length);
                        escritor.Write(pedido.Estado.ToCharArray());
                    }
                }
            }
        }

        public List<Pedido> CargarPedidos(string rutaPedidos)
        {
            List<Pedido> pedidos = new List<Pedido>();

            if (!File.Exists(rutaPedidos)) // Verificar si el archivo existe
            {
                return pedidos; // Si no existe el archivo, retornamos la lista vacía
            }
            using (FileStream archivoPedidos = new FileStream(rutaPedidos, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivoPedidos))
                {
                    try
                    {
                        while (archivoPedidos.Position != archivoPedidos.Length)
                        {
                            // Leer el campos
                            int tamaño = lector.ReadInt32();
                            char[] IDArray = lector.ReadChars(tamaño);
                            string idPedido = new string(IDArray);
                            tamaño = lector.ReadInt32();
                            char[] UsuarioClienteArray = lector.ReadChars(tamaño);
                            string usuarioCliente = new string(UsuarioClienteArray);
                            tamaño = lector.ReadInt32();
                            char[] UsuarioColaboradorArray = lector.ReadChars(tamaño);
                            string usuarioColaborador = new string(UsuarioColaboradorArray);
                            DateTime fechaCompra = DateTime.Parse(lector.ReadString());
                            decimal costoCompra = lector.ReadDecimal();
                            decimal costoMaterial = lector.ReadDecimal();
                            tamaño = lector.ReadInt32();
                            char[] PuntoEntregaArray = lector.ReadChars(tamaño);
                            string puntoEntrega = new string(PuntoEntregaArray);
                            tamaño = lector.ReadInt32();
                            char[] DescripcionArray = lector.ReadChars(tamaño);
                            string descripcion = new string(DescripcionArray);
                            tamaño = lector.ReadInt32();
                            char[] EstadoArray = lector.ReadChars(tamaño);
                            string estado = new string(EstadoArray);

                            // Crear el objeto Pedido y añadirlo a la lista
                            Pedido pedido = new Pedido(idPedido, usuarioCliente, usuarioColaborador, fechaCompra, costoCompra, costoMaterial, puntoEntrega, descripcion, estado);
                            pedidos.Add(pedido);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        // Se ha alcanzado el final del archivo
                    }
                }
            }
            return pedidos;
        }

        public static void GuardarInforme(List<Informe> listaInforme, string rutaInforme)
        {
            using (FileStream archivoInformes = new FileStream(rutaInforme, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivoInformes))
                {
                    foreach (Informe informe in listaInforme)
                    {
                        // Escribir los campos de la clase Informe
                        escritor.Write(informe.Fecha_Inicio.ToString()); // Convertir a string para escribir
                        escritor.Write(informe.Fecha_Final.ToString()); // Convertir a string para escribir
                        escritor.Write(informe.Total_Pedidos);
                        escritor.Write(informe.Completados);
                        escritor.Write(informe.Total_Completados);
                        escritor.Write(informe.Cancelados);
                        escritor.Write(informe.Total_Cancelados);
                        escritor.Write(informe.Procesando);
                        escritor.Write(informe.Total_Procesando);
                        escritor.Write(informe.Ingresos);
                        escritor.Write(informe.Egresos);
                        escritor.Write(informe.Ganancias);
                        escritor.Write(informe.Rentabilidad.Length);
                        escritor.Write(informe.Rentabilidad.ToCharArray());
                    }
                }
            }
        }

        public List<Informe> CargarInforme(string rutaInforme)
        {
            List<Informe> informes = new List<Informe>();
            if (!File.Exists(rutaInforme)) // Verificar si el archivo existe
            {
                return informes; // Si no existe el archivo, retornamos la lista vacía
            }
            using (FileStream archivoInformes = new FileStream(rutaInforme, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivoInformes))
                {
                    try
                    {
                        while (archivoInformes.Position != archivoInformes.Length)
                        {
                            // Leer el campos
                            DateTime fechaInicio = DateTime.Parse(lector.ReadString());
                            DateTime fechaFinal = DateTime.Parse(lector.ReadString());
                            int totalPedidos = lector.ReadInt32();
                            int completados = lector.ReadInt32();
                            decimal totalCompletados = lector.ReadDecimal();
                            int cancelados = lector.ReadInt32();
                            decimal totalCancelados = lector.ReadDecimal();
                            int procesando = lector.ReadInt32();
                            decimal totalProcesando = lector.ReadDecimal();
                            decimal ingresos = lector.ReadDecimal();
                            decimal egresos = lector.ReadDecimal();
                            decimal ganancias = lector.ReadDecimal();
                            int tamaño = lector.ReadInt32();
                            char[] rentabilidadArray = lector.ReadChars(tamaño);
                            string rentabilidad = new string(rentabilidadArray);

                            // Crear el objeto Informe y añadirlo a la lista
                            Informe informe = new Informe(fechaInicio, fechaFinal, totalPedidos, completados, totalCompletados, cancelados, totalCancelados, procesando, totalProcesando, ingresos, egresos, ganancias, rentabilidad);
                            informes.Add(informe);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        // Se ha alcanzado el final del archivo
                    }
                }
            }
            return informes;
        }
    }
}
