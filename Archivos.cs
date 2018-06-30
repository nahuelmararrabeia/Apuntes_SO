using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WSCopiarArchivos
{
    public static class Archivos
    {
        public static void Copy(string origen, string destino, string error, System.IO.FileSystemEventArgs e)
        {
            
            string[] pathArchivosOrigen = Directory.GetFiles(origen, "", SearchOption.AllDirectories);
            string[] directorios = Directory.GetDirectories(origen, "", SearchOption.AllDirectories);
            for (int i = 0; i <= directorios.Length; i++)            
            {
                string pathDestino = destino;                
                string[] p = directorios[i].Split('\\');
                for (int j = 5; j < p.Length; j++)
                { pathDestino = Path.Combine(pathDestino,p[j]); }
                
                if (!Directory.Exists(pathDestino))
                { Directory.CreateDirectory(pathDestino); }

            }

            
            string archivoDestino = destino;
            string archivoError = error;
            string[] a = e.FullPath.Split('\\');            

            for (int j = 5; j < a.Length; j++)
            { 
                archivoDestino = Path.Combine(archivoDestino, a[j]);
                archivoError = Path.Combine(archivoError, a[j]);
            }


            if (File.Exists(archivoDestino))
            {
                File.Copy(e.FullPath, archivoError);
            }
            else
                File.Copy(e.FullPath, archivoDestino);
 
        }

        public static void Move(string origen, string destino, string error, System.IO.FileSystemEventArgs e)
        {
            string[] pathArchivosOrigen = Directory.GetFiles(origen, "", SearchOption.AllDirectories);
            string[] directorios = Directory.GetDirectories(origen, "", SearchOption.AllDirectories);
            for (int i = 0; i <= directorios.Length; i++)
            {
                string pathDestino = destino;                
                string[] p = directorios[i].Split('\\');
                for (int j = 5; j < p.Length; j++)
                { pathDestino = Path.Combine(pathDestino, p[j]); }
                if (!Directory.Exists(pathDestino))
                { Directory.CreateDirectory(pathDestino); }
            }


            string archivoDestino = destino;
            string archivoError = error;
            string[] a = e.FullPath.Split('\\');

            for (int j = 5; j < a.Length; j++)
            {
                archivoDestino = Path.Combine(archivoDestino, a[j]);
                archivoError = Path.Combine(archivoError, a[j]);
            }


            if (File.Exists(archivoDestino))
            {
                File.Move(e.FullPath, archivoError);
            }
            else
                File.Move(e.FullPath, archivoDestino);

            //for (int i = 0; i <= directorios.Length; i++)
            //{
            //    string directoryName = Path.GetDirectoryName(directorios[i]);
            //    if (!Directory.Exists(archivoDestino))
            //    { Directory.Delete(directorios[i]); }
            //}
        }
    }
}
