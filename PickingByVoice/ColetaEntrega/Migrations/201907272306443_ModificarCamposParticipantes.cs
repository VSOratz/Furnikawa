namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarCamposParticipantes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "Local", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "SgUser", c => c.String(maxLength: 50));
            AddColumn("dbo.ItemColeta", "DtManutencao", c => c.DateTime(nullable: false));
            AddColumn("dbo.MestreColeta", "Num_Romaneio", c => c.Int(nullable: false));
            AddColumn("dbo.MestreColeta", "Placa", c => c.String(nullable: false));
            AddColumn("dbo.MestreColeta", "SgUser", c => c.String(maxLength: 50));
            AddColumn("dbo.MestreColeta", "DtManutencao", c => c.DateTime(nullable: false));
            DropColumn("dbo.ItemColeta", "Local_Coleta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemColeta", "Local_Coleta", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.MestreColeta", "DtManutencao");
            DropColumn("dbo.MestreColeta", "SgUser");
            DropColumn("dbo.MestreColeta", "Placa");
            DropColumn("dbo.MestreColeta", "Num_Romaneio");
            DropColumn("dbo.ItemColeta", "DtManutencao");
            DropColumn("dbo.ItemColeta", "SgUser");
            DropColumn("dbo.ItemColeta", "Local");
        }
    }
}
