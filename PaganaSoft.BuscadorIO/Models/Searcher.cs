using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PaganaSoft.BuscadorIO.Models
{
    public class Searcher
    {
        public List<FoundFile> Matches { get; set; }

        public List<FoundFile> Search(string path, string parameter, bool? all = null)
        {
            if (all.Value)
                RecursiveSearch(path, parameter);
            else
                SearchString(path, parameter);
            return Matches;
        }

        private void RecursiveSearch(string sDir, string parameter)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        //Debug.WriteLine("{0}",f);
                        SearchString(f, parameter);
                    }
                    RecursiveSearch(d, parameter);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Exception {0}", ex.Message);
            }
        }

        private void SearchString(string path, string parameter)
        {
            try
            {
                int noLine = 0;
                string[] lines = File.ReadAllLines(path);
                FileInfo fileinfo = new FileInfo(path);
                foreach (var line in lines)
                {
                    noLine++;
                    if (line.Contains(parameter))
                    {
                        int noCol = line.IndexOf(parameter);
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

                throw;//Debug.WriteLine("Exception {0}", ex.Message);
            }

        }
    }
}
