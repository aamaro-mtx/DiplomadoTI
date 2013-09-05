using PaganaSoft.BuscadorIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.BuscadorIO.ViewModels
{
    public class DefaultViewModel :BindableBase
    {
        public DefaultViewModel()
        {
            DemoFile = new FoundFile()
            {
                LineNumber = 12,
                ColumName = 25,
                FileName = "nombre de ejemplo",
                Text = "Este es el texto que debera de tener el archivo"
            };
        }

        private FoundFile _demofile;
        public FoundFile DemoFile
        {
            get { return _demofile; }
            set { SetProperty(ref _demofile, value); }
        }

    }
}
