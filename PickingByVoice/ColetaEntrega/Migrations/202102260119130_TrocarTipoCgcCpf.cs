namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrocarTipoCgcCpf : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ItemColetaMovimentacao");
            AddColumn("dbo.ItemColetaMovimentacao", "itemColetaMovimentacaoId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemColetaMovimentacao", "DhInclusao", c => c.DateTime(nullable: false));
            AddColumn("dbo.ItemColetaMovimentacao", "Latitude", c => c.String());
            AddColumn("dbo.ItemColetaMovimentacao", "Longetude", c => c.String());
            AddColumn("dbo.ItemColetaMovimentacao", "SgUser", c => c.String(maxLength: 50));
            AlterColumn("dbo.Participante", "CgcCPF", c => c.String(nullable: false));
            AddPrimaryKey("dbo.ItemColetaMovimentacao", "itemColetaMovimentacaoId");
            DropColumn("dbo.ItemColetaMovimentacao", "DhCriacao");
            DropColumn("dbo.ItemColetaMovimentacao", "NmUsuarioCriou");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemColetaMovimentacao", "NmUsuarioCriou", c => c.String());
            AddColumn("dbo.ItemColetaMovimentacao", "DhCriacao", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.ItemColetaMovimentacao");
            AlterColumn("dbo.Participante", "CgcCPF", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ItemColetaMovimentacao", "SgUser");
            DropColumn("dbo.ItemColetaMovimentacao", "Longetude");
            DropColumn("dbo.ItemColetaMovimentacao", "Latitude");
            DropColumn("dbo.ItemColetaMovimentacao", "DhInclusao");
            DropColumn("dbo.ItemColetaMovimentacao", "itemColetaMovimentacaoId");
            AddPrimaryKey("dbo.ItemColetaMovimentacao", "ItemColetaId");
        }
    }
}
