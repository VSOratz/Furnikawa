namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoCampoEDItamanhos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EdiImportaItem", "CPFMOTORISTA", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.EdiImportaItem", "NOMEMOTORISTA", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.EdiImportaItem", "NOMEEMPRESA", c => c.String(maxLength: 200));
            AlterColumn("dbo.EdiImportaItem", "RUA", c => c.String(maxLength: 200));
            AlterColumn("dbo.EdiImportaItem", "TPENTREGA", c => c.String(nullable: false, maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EdiImportaItem", "TPENTREGA", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.EdiImportaItem", "RUA", c => c.String(maxLength: 50));
            AlterColumn("dbo.EdiImportaItem", "NOMEEMPRESA", c => c.String(maxLength: 50));
            AlterColumn("dbo.EdiImportaItem", "NOMEMOTORISTA", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.EdiImportaItem", "CPFMOTORISTA", c => c.String(nullable: false, maxLength: 8));
        }
    }
}
