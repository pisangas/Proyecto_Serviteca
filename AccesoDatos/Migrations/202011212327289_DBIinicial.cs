namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBIinicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Apellido = c.String(nullable: false, maxLength: 20),
                        Cedula = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Direccion = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        VehiculoId = c.Int(nullable: false, identity: true),
                        Kilometraje = c.Int(nullable: false),
                        Matricula = c.String(nullable: false, maxLength: 10),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        ValorServicio = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioId)
                .ForeignKey("dbo.Vehiculos", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicios", "VehiculoId", "dbo.Vehiculos");
            DropForeignKey("dbo.Vehiculos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Servicios", new[] { "VehiculoId" });
            DropIndex("dbo.Vehiculos", new[] { "ClienteId" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Vehiculos");
            DropTable("dbo.Clientes");
        }
    }
}
