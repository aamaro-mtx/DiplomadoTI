namespace PaganaSoft.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(),
                        CategoriaID = c.Int(),
                        PrecioUnitario = c.Decimal(precision: 18, scale: 2),
                        UnidadesEnStock = c.Short(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Productoes", new[] { "CategoriaID" });
            DropForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
