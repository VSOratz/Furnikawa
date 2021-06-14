namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoTabelasEDI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "ParticipanteId", c => c.Int(nullable: false));
            AddColumn("dbo.MestreColeta", "ParticipanteId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemColeta", "ParticipanteId");
            CreateIndex("dbo.MestreColeta", "ParticipanteId");
            AddForeignKey("dbo.MestreColeta", "ParticipanteId", "dbo.Participante", "ParticipanteId");
            AddForeignKey("dbo.ItemColeta", "ParticipanteId", "dbo.Participante", "ParticipanteId");
            DropColumn("dbo.MestreColeta", "CNH_Motorista");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MestreColeta", "CNH_Motorista", c => c.String(nullable: false));
            DropForeignKey("dbo.ItemColeta", "ParticipanteId", "dbo.Participante");
            DropForeignKey("dbo.MestreColeta", "ParticipanteId", "dbo.Participante");
            DropIndex("dbo.MestreColeta", new[] { "ParticipanteId" });
            DropIndex("dbo.ItemColeta", new[] { "ParticipanteId" });
            DropColumn("dbo.MestreColeta", "ParticipanteId");
            DropColumn("dbo.ItemColeta", "ParticipanteId");
        }
    }
}
