namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetirarObrigatoriedadeCamposItemCarga : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemColeta", "Numero", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ItemColeta", "Complemento", c => c.String(maxLength: 100));
            AlterColumn("dbo.ItemColeta", "Bairro", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemColeta", "Bairro", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ItemColeta", "Complemento", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ItemColeta", "Numero", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
