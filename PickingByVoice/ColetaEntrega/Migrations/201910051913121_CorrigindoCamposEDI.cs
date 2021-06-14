namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoCamposEDI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EDI_IMPORTA_ITEM",
                c => new
                    {
                        ID_IMPORTAITEM = c.Int(nullable: false, identity: true),
                        ID_IMPORTAMESTRE = c.Int(nullable: false),
                        SEQITEM = c.Double(nullable: false),
                        STATUS = c.String(nullable: false, maxLength: 1),
                        NRROMANEIO = c.String(nullable: false, maxLength: 100),
                        CPFMOTORISTA = c.String(nullable: false, maxLength: 11),
                        NOMEMOTORISTA = c.String(nullable: false, maxLength: 11),
                        PLACA = c.String(nullable: false, maxLength: 8),
                        NRNOTA = c.String(maxLength: 10),
                        DTCOLETA = c.DateTime(nullable: false),
                        CNPJEMPRESA = c.String(maxLength: 14),
                        NOMEEMPRESA = c.String(maxLength: 50),
                        RUA = c.String(maxLength: 50),
                        NUMERO = c.String(maxLength: 10),
                        COMPLEMENTO = c.String(),
                        BAIRRO = c.String(),
                        VLNOTA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QUANTIDADE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PESO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TPENTREGA = c.String(nullable: false),
                        DTPREVISAO = c.DateTime(nullable: false),
                        FGATIVO = c.String(nullable: false, maxLength: 1),
                        SGUSER = c.String(nullable: false, maxLength: 50),
                        DTMANUTENCAO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_IMPORTAITEM);
            
            CreateTable(
                "dbo.EDI_IMPORTA_MESTRE",
                c => new
                    {
                        ID_IMPORTAMESTRE = c.Int(nullable: false, identity: true),
                        DtImportacao = c.DateTime(nullable: false),
                        NmArquivo = c.String(nullable: false, maxLength: 150),
                        Status = c.String(nullable: false, maxLength: 1),
                        SgUser = c.String(maxLength: 50),
                        DtManutencao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_IMPORTAMESTRE);
            
            AddColumn("dbo.ItemColeta", "CnpjEmpresaDestino", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "EmpresaDestino", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Rua", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ItemColeta", "Numero", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ItemColeta", "Complemento", c => c.String());
            AddColumn("dbo.ItemColeta", "Bairro", c => c.String());
            AddColumn("dbo.ItemColeta", "SgUser", c => c.String(maxLength: 50));
            AddColumn("dbo.ItemColeta", "DtManutencao", c => c.DateTime(nullable: false));
            AddColumn("dbo.MestreColeta", "NrRomaneio", c => c.String());
            AddColumn("dbo.MestreColeta", "Placa", c => c.String());
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
            DropColumn("dbo.MestreColeta", "NrRomaneio");
            DropColumn("dbo.ItemColeta", "DtManutencao");
            DropColumn("dbo.ItemColeta", "SgUser");
            DropColumn("dbo.ItemColeta", "Bairro");
            DropColumn("dbo.ItemColeta", "Complemento");
            DropColumn("dbo.ItemColeta", "Numero");
            DropColumn("dbo.ItemColeta", "Rua");
            DropColumn("dbo.ItemColeta", "EmpresaDestino");
            DropColumn("dbo.ItemColeta", "CnpjEmpresaDestino");
            DropTable("dbo.EDI_IMPORTA_MESTRE");
            DropTable("dbo.EDI_IMPORTA_ITEM");
        }
    }
}
