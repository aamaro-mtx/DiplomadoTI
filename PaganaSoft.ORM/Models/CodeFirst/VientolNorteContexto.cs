using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PaganaSoft.ORM.Models.CodeFirst
{
    public class VientolNorteContexto : DbContext
    {
        public VientolNorteContexto()
            : base("NrtwdCodeFirstCtx")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Producto>().Property(p => p.ProductoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Categoria>().Property(p => p.CategoriaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
