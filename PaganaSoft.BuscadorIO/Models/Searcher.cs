using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PaganaSoft.BuscadorIO.Models
{
    public class Searcher
    {
        public event ErrorEventHandler Error;
        public Searcher()
        {
            Matches = new List<FoundFile>();
            Key = string.Empty;
        }
        public string Key { get; set; }
        public List<FoundFile> Matches { get; set; }

        /// <summary>
        /// Funcion que busca una cadena especifica dentro de un archivo.
        /// </summary>
        /// <param name="path">Ruta del archivo el cual se va a procesar.</param>
        /// <param name="sKey">Cadena a  buscar dentro del archivo.</param>
        /// <param name="all">Indica si se analizaran los suddirectorios.</param>
        /// <returns></returns>
        public List<FoundFile> Search(string path, string sKey, bool? all = null)
        {
            Key = sKey;
            SearchInDirectory(path);
            if (all.Value)
                RecursiveSearch(path);

            return Matches;
        }

        /// <summary>
        /// Recorre un path especifico en busca de subdirectorios para ser procesados
        /// </summary>
        /// <param name="sPathDir">Ruta del archivo el cual se va a procesar.</param>
        private void RecursiveSearch(string sPathDir)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(sPathDir))
                {
                    SearchInDirectory(dir);
                    RecursiveSearch(dir);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Exception {0}", ex.Message);
                ThrowError(ex);
            }
        }

        /// <summary>
        /// Recorre un directorio especifico obteniendo los archivos para ser procesados
        /// </summary>
        /// <param name="sPathDir">Ruta del archivo el cual se va a procesar.</param>
        private void SearchInDirectory(string sPathDir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(sPathDir))
                {
                    SearchString(file);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception {0}", ex.Message);
                ThrowError(ex);
            }
        }       

        /// <summary>
        /// Busca una cadena dentro de un archivo especifico.
        /// </summary>
        /// <param name="path">Ruta del archivo el cual se va a procesar.</param>
        private void SearchString(string path)
        {
            try
            {
                int noLine = 0;
                string[] lines = File.ReadAllLines(path);
                FileInfo fileinfo = new FileInfo(path);
                foreach (var line in lines)
                {
                    noLine++;
                    if (line.Contains(Key))
                    {
                        int noCol = line.IndexOf(Key);
                        FoundFile found = new FoundFile()
                        {
                            FileName = fileinfo.Name,
                            ColumName = noCol,
                            LineNumber = noLine,
                            Text = line
                        };
                        Matches.Add(found);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception {0}", ex.Message);
                ThrowError(ex);
            }

        }
        
        /// <summary>
        /// Funcion que lanza el evento Error asociado a la clase.
        /// </summary>
        /// <param name="ex"></param>
        private void ThrowError(Exception ex)
        {
            if (Error != null)
            {
                Error(this,
                    new ErrorEventArgs()
                    {
                        ID = ex.GetHashCode(),
                        Mensaje = ex.Message,
                        Source = ex.Source
                    });
            }
        }
    }
}
