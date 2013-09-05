using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PaganaSoft.BuscadorIO.Models
{
    public class Buscador
    {
        public void Search(string path,string parameter, bool? all = null)
        {
            if (all.HasValue)
                RecursiveSearch(path,parameter);
            else
                SearchString(path,parameter);
            
        }

     private  void RecursiveSearch(string sDir,string parameter)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        //Debug.WriteLine("{0}",f);
                        SearchString(f,parameter);
                    }
                    RecursiveSearch(d,parameter);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Exception {0}", ex.Message);
            }
        }
        
        private void SearchString (string path,string parameter)
        {
            //DirSearch(path);
            //int noLine = 0;
            //int noColum = 0;
            ////if (!File.Exists(path))
            ////{
            ////    // Create a file to write to.
            ////    using (StreamWriter sw = File.CreateText(path))
            ////    {
            ////        sw.WriteLine("Hello");
            ////        sw.WriteLine("And");
            ////        sw.WriteLine("Welcome");
            ////    }
            ////}

            //// Open the file to read from.
            
            //path = @"C:\tmp\output.txt";
            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        noLine++;
            //        noColum= s.IndexOf("hola");
            //        Debug.WriteLine("{0}{1}", noLine, noColum);
            //    }


            //    //var texto = sr.ReadToEnd();
            //    //var var = texto.Split('\n').ToList();

            //    ////var u = var.SelectMany(a => a.Contains("hola"));
            //    //var lista = var.FindAll(a => a.Contains("hola")).ToList();
                
                
            //}
        }
    }
}
