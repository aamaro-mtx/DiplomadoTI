namespace PaganaSoft.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActulizarNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            RenameTable(name: "dbo.Productoes", newName: "Producto");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Producto", newName: "Productoes");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
