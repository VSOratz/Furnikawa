namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TentativaMudarCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "EmpresaDestino", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Rua", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Numero", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Complemento", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Bairro", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.MestreColeta", "Nome_Motorista", c => c.String(nullable: false));
            AddColumn("dbo.Participante", "NrCNH", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MestreColeta", "SgUser", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Participante", "NmFantasia", c => c.String(maxLength: 100));
            AlterColumn("dbo.Participante", "CEP", c => c.String());
            DropColumn("dbo.ItemColeta", "Local");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemColeta", "Local", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Participante", "CEP", c => c.String(nullable: false));
            AlterColumn("dbo.Participante", "NmFantasia", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.MestreColeta", "SgUser", c => c.String(maxLength: 50));
            DropColumn("dbo.Participante", "NrCNH");
            DropColumn("dbo.MestreColeta", "Nome_Motorista");
            DropColumn("dbo.ItemColeta", "Bairro");
            DropColumn("dbo.ItemColeta", "Complemento");
            DropColumn("dbo.ItemColeta", "Numero");
            DropColumn("dbo.ItemColeta", "Rua");
            DropColumn("dbo.ItemColeta", "EmpresaDestino");
        }
    }
}
