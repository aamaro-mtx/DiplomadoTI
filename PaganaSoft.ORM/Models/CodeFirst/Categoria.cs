using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.ORM.Models.CodeFirst
{
    public partial class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
