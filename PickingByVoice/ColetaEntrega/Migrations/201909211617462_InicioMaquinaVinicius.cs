namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioMaquinaVinicius : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ItemColeta", "Local_Coleta", c => c.String(nullable: false, maxLength: 100));
            //AlterColumn("dbo.ItemColeta", "DhColeta", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.MestreColeta", "Previsao_Retorno", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.Participante", "NmRazaoSocial", c => c.String(nullable: false, maxLength: 250));
            //AlterColumn("dbo.Participante", "NmFantasia", c => c.String(nullable: false, maxLength: 100));
            //AlterColumn("dbo.Participante", "CEP", c => c.String(nullable: false));
            //AlterColumn("dbo.Participante", "Email", c => c.String(nullable: false, maxLength: 100));
            //DropColumn("dbo.ItemColeta", "CnpjEmpresaDestino");
            //DropColumn("dbo.ItemColeta", "EmpresaDestino");
            //DropColumn("dbo.ItemColeta", "Rua");
            //DropColumn("dbo.ItemColeta", "Numero");
            //DropColumn("dbo.ItemColeta", "Complemento");
            //DropColumn("dbo.ItemColeta", "Bairro");
            //DropColumn("dbo.ItemColeta", "SgUser");
            //DropColumn("dbo.ItemColeta", "DtManutencao");
            //DropColumn("dbo.MestreColeta", "Num_Romaneio");
            //DropColumn("dbo.MestreColeta", "Nome_Motorista");
            //DropColumn("dbo.MestreColeta", "Placa");
            //DropColumn("dbo.MestreColeta", "SgUser");
            //DropColumn("dbo.MestreColeta", "DtManutencao");
            //DropColumn("dbo.Participante", "NrCNH");
            //DropColumn("dbo.Participante", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participante", "Senha", c => c.String(maxLength: 10));
            AddColumn("dbo.Participante", "NrCNH", c => c.String());
            AddColumn("dbo.MestreColeta", "DtManutencao", c => c.DateTime(nullable: false));
            AddColumn("dbo.MestreColeta", "SgUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MestreColeta", "Placa", c => c.String(nullable: false));
            AddColumn("dbo.MestreColeta", "Nome_Motorista", c => c.String(nullable: false));
            AddColumn("dbo.MestreColeta", "Num_Romaneio", c => c.Int(nullable: false));
            AddColumn("dbo.ItemColeta", "DtManutencao", c => c.DateTime());
            AddColumn("dbo.ItemColeta", "SgUser", c => c.String(maxLength: 50));
            AddColumn("dbo.ItemColeta", "Bairro", c => c.String(maxLength: 100));
            AddColumn("dbo.ItemColeta", "Complemento", c => c.String(maxLength: 100));
            AddColumn("dbo.ItemColeta", "Numero", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ItemColeta", "Rua", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "EmpresaDestino", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "CnpjEmpresaDestino", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Participante", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Participante", "CEP", c => c.String());
            AlterColumn("dbo.Participante", "NmFantasia", c => c.String(maxLength: 100));
            AlterColumn("dbo.Participante", "NmRazaoSocial", c => c.String(maxLength: 250));
            AlterColumn("dbo.MestreColeta", "Previsao_Retorno", c => c.DateTime());
            AlterColumn("dbo.ItemColeta", "DhColeta", c => c.DateTime());
            DropColumn("dbo.ItemColeta", "Local_Coleta");
        }
    }
}
