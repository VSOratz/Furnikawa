namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarFlagsChartoString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "Tipo_Coleta", c => c.String());
            AddColumn("dbo.ItemColeta", "Status_Coleta", c => c.String());
            AddColumn("dbo.MestreColeta", "Status_Coleta", c => c.String());
            AddColumn("dbo.ItemColetaMovimentacao", "StatusMovimentacao", c => c.String());
            AddColumn("dbo.Participante", "FgTipoPessoa", c => c.String(nullable: false));
            AddColumn("dbo.Usuario", "Ativo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Ativo");
            DropColumn("dbo.Participante", "FgTipoPessoa");
            DropColumn("dbo.ItemColetaMovimentacao", "StatusMovimentacao");
            DropColumn("dbo.MestreColeta", "Status_Coleta");
            DropColumn("dbo.ItemColeta", "Status_Coleta");
            DropColumn("dbo.ItemColeta", "Tipo_Coleta");
        }
    }
}
