namespace Conexion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Libroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        sintesis = c.String(maxLength: 255),
                        NumeroPagina = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.AutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libroes", "AutorId", "dbo.Autors");
            DropIndex("dbo.Libroes", new[] { "AutorId" });
            DropTable("dbo.Libroes");
            DropTable("dbo.Autors");
        }
    }
}
