namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoCampoEDICPF : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EdiImportaItem", "CPFMOTORISTA", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EdiImportaItem", "CPFMOTORISTA", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
