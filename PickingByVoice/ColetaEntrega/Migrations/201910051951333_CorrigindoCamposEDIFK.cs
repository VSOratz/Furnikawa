namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoCamposEDIFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EdiImportaItem",
                c => new
                    {
                        EdiImportaItemId = c.Int(nullable: false, identity: true),
                        EdiImportaMestreId = c.Int(nullable: false),
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
                        TPENTREGA = c.String(nullable: false, maxLength: 15),
                        DTPREVISAO = c.DateTime(nullable: false),
                        FGATIVO = c.String(nullable: false, maxLength: 1),
                        SGUSER = c.String(nullable: false, maxLength: 50),
                        DTMANUTENCAO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EdiImportaItemId)
                .ForeignKey("dbo.EdiImportaMestre", t => t.EdiImportaMestreId)
                .Index(t => t.EdiImportaMestreId);
            
            CreateTable(
                "dbo.EdiImportaMestre",
                c => new
                    {
                        EdiImportaMestreId = c.Int(nullable: false, identity: true),
                        DtImportacao = c.DateTime(nullable: false),
                        NmArquivo = c.String(nullable: false, maxLength: 150),
                        Status = c.String(nullable: false, maxLength: 1),
                        SgUser = c.String(maxLength: 50),
                        DtManutencao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EdiImportaMestreId);
            
            DropTable("dbo.EDI_IMPORTA_ITEM");
            DropTable("dbo.EDI_IMPORTA_MESTRE");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.EdiImportaItem", "EdiImportaMestreId", "dbo.EdiImportaMestre");
            DropIndex("dbo.EdiImportaItem", new[] { "EdiImportaMestreId" });
            DropTable("dbo.EdiImportaMestre");
            DropTable("dbo.EdiImportaItem");
        }
    }
}
