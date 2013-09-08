using System;

namespace PaganaSoft.BuscadorIO.Models
{
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);

    #region Clases Auxiliares
    public class ErrorEventArgs : EventArgs
    {
        public int ID { get; set; }
        public string Mensaje { get; set; }
        public string Source { get; set; }
    }
    #endregion
}
