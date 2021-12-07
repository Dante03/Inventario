namespace appToy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Juguetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descripcion = c.String(maxLength: 100, unicode: false),
                        RestriccionEdad = c.Int(),
                        Compania = c.String(nullable: false, maxLength: 50, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Juguetes", new[] { "Id" });
            DropTable("dbo.Juguetes");
        }
    }
}
