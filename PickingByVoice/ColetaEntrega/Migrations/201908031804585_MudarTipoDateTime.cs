namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudarTipoDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemColeta", "DhColeta", c => c.DateTime());
            AlterColumn("dbo.ItemColeta", "DtManutencao", c => c.DateTime());
            AlterColumn("dbo.MestreColeta", "Previsao_Retorno", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MestreColeta", "Previsao_Retorno", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ItemColeta", "DtManutencao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ItemColeta", "DhColeta", c => c.DateTime(nullable: false));
        }
    }
}
