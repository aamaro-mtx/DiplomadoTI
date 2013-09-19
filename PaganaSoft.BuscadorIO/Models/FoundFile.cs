
namespace PaganaSoft.BuscadorIO.Models
{
    public class FoundFile : BindableBase
    {
        private int _linenumber;
        public int LineNumber
        {
            get { return _linenumber; }
            set { SetProperty(ref _linenumber, value); }
        }

        private int _colname;
        public int ColumName
        {
            get { return _colname; }
            set { SetProperty(ref _colname, value); }
        }

        private string _filename;
        public string FileName
        {
            get { return _filename; }
            set { SetProperty(ref _filename, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
