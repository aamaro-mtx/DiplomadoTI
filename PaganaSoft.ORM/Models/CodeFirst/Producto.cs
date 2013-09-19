using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.ORM.Models.CodeFirst
{
    public partial class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<short> UnidadesEnStock { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
