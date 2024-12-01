using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BunBunHub.Dao
{
    public static class ManejoArchivos<T> where T : class
    {
        public static void GuardarDatos(string rutaArchivo, List<T> datos)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, datos); // Serializa la lista de datos
            }
        }

        public static List<T> CargarDatos(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                return new List<T>(); // Si no existe el archivo, retorna una lista vacía

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<T>)formatter.Deserialize(fs); // Deserializa los datos
            }
        }
    }
}
