using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PaganaSoft.SerializacionCSV.Models
{
    [Serializable]
    public class Product 
    {
        public Product()
        {

        }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public string UnidadDeMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
