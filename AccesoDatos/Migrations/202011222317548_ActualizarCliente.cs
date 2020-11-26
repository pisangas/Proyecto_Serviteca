namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarCliente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cedula", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Cedula", c => c.String(nullable: false));
        }
    }
}
