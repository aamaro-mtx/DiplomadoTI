using PaganaSoft.BuscadorIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.BuscadorIO.ViewModels
{
    public class DefaultViewModel : BindableBase
    {
        private FoundsCollection _foundslist = new FoundsCollection();

        public FoundsCollection FoundsList
        {
            get { return _foundslist; }
            set { SetProperty(ref _foundslist, value); }
        }






        public DefaultViewModel()
        {
            this.Errors = new List<ErrorEventArgs>();          
        }


        private List<ErrorEventArgs> _errors;

        public List<ErrorEventArgs> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }


        private List<FoundFile> _founds;

        public List<FoundFile> Founds
        {
            get { return _founds; }
            set { _founds = value; }
        }
        private FoundFile _demofile;
        public FoundFile DemoFile
        {
            get { return _demofile; }
            set { SetProperty(ref _demofile, value); }
        }

        public void Search(string path, string sKey, bool? all = null)
        {
            FoundsList.Clear();
            Searcher se = new Searcher();
            se.Error += se_Error;

            Founds = se.Search(path, sKey, all);
            foreach (var f in Founds)
            {
                FoundsList.Add(f);
            }

        }

        //public List<FoundFile> Search(string path, string sKey, bool? all = null)
        //{
        //    Searcher se = new Searcher();
        //    se.Error += se_Error;

        //    Founds = se.Search(path, sKey, all);
        //    foreach (var f in Founds)
        //    {
        //        FoundsList.Add(f);
        //    }

        //    return Founds;
        //}

        void se_Error(object sender, ErrorEventArgs e)
        {
            this.Errors.Add(e);
            throw new Exception(e.Mensaje);
        }

    }
}
