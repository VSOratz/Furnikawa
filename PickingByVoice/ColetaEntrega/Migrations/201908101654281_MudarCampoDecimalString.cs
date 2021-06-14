namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudarCampoDecimalString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participante", "NrCNH", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participante", "NrCNH", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
