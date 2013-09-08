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
        public DefaultViewModel()
        {
            this.Errors = new List<ErrorEventArgs>();
            DemoFile = new FoundFile()
            {
                LineNumber = 12,
                ColumName = 25,
                FileName = "Cupcake Ipsum",
                Text = "Cupcake ipsum dolor. Sit amet tootsie roll lollipop halvah brownie ice cream pastry."
            };
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

        public List<FoundFile> Search(string path, string sKey, bool? all = null)
        {
            Searcher se = new Searcher();
            Founds = se.Search(path, sKey, all);
            se.Error += se_Error;
            return Founds;
        }

        void se_Error(object sender, ErrorEventArgs e)
        {
            this.Errors.Add(e);
        }

    }
}
