namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirCNPJItemColeta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "CnpjEmpresaDestino", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemColeta", "CnpjEmpresaDestino");
        }
    }
}
