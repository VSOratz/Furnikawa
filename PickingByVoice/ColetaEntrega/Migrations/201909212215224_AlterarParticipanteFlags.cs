namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarParticipanteFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participante", "FgEmpresa", c => c.String());
            AddColumn("dbo.Participante", "FgAtivo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participante", "FgAtivo");
            DropColumn("dbo.Participante", "FgEmpresa");
        }
    }
}
