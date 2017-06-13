namespace CalculadoraIntereses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(),
                        Correo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        PrestamoID = c.Int(nullable: false, identity: true),
                        Plazo = c.DateTime(nullable: false),
                        Interes = c.Double(nullable: false),
                        CantidadPrestada = c.Double(nullable: false),
                        IdCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrestamoID)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true);


        }
        
        public override void Down()
        {
            DropTable("dbo.Prestamos");
            DropTable("dbo.Clientes");
        }
    }
}
