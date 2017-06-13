namespace CalculadoraIntereses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prestars",
                c => new
                    {
                        PrestamoID = c.Int(nullable: false, identity: true),
                        Plazo = c.Int(nullable: false),
                        Interes = c.Double(nullable: false),
                        CantidadPrestada = c.Double(nullable: false),
                        Cuota = c.Double(nullable: false),
                        IniciodePrestamo = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrestamoID);
            
            AddColumn("dbo.Prestamos", "Cuota", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prestamos", "Cuota");
            DropTable("dbo.Prestars");
        }
    }
}
