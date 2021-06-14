namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TirarObrigatoriedadeParticipantes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participante", "NmRazaoSocial", c => c.String(maxLength: 250));
            AlterColumn("dbo.Participante", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participante", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Participante", "NmRazaoSocial", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
