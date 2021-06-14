namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        DocumentoId = c.Int(nullable: false, identity: true),
                        DocumentoNum = c.String(nullable: false, maxLength: 12),
                        DocumentoSeq = c.String(nullable: false, maxLength: 12),
                        Photo = c.String(),
                        ItemColetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.ItemColeta", t => t.ItemColetaId, cascadeDelete: true)
                .Index(t => t.ItemColetaId);
            
            CreateTable(
                "dbo.ItemColeta",
                c => new
                    {
                        ItemColetaId = c.Int(nullable: false, identity: true),
                        DhColeta = c.DateTime(nullable: false),
                        Local_Coleta = c.String(nullable: false, maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MestreColetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemColetaId)
                .ForeignKey("dbo.MestreColeta", t => t.MestreColetaId, cascadeDelete: true)
                .Index(t => t.MestreColetaId);
            
            CreateTable(
                "dbo.Inconformidade",
                c => new
                    {
                        InconformidadeId = c.Int(nullable: false, identity: true),
                        InconformidadeSeq = c.String(nullable: false, maxLength: 12),
                        ListaSeq = c.String(nullable: false, maxLength: 12),
                        MaterialCod = c.String(nullable: false, maxLength: 40),
                        QtdeSeparada = c.String(nullable: false, maxLength: 10),
                        DhInconformidade = c.String(),
                        FgEnviado = c.String(nullable: false, maxLength: 1),
                        ItemColetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InconformidadeId)
                .ForeignKey("dbo.ItemColeta", t => t.ItemColetaId, cascadeDelete: true)
                .Index(t => t.ItemColetaId);
            
            CreateTable(
                "dbo.MestreColeta",
                c => new
                    {
                        MestreColetaId = c.Int(nullable: false, identity: true),
                        CNH_Motorista = c.String(nullable: false),
                        Previsao_Retorno = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MestreColetaId);
            
            CreateTable(
                "dbo.Participante",
                c => new
                    {
                        ParticipanteId = c.Int(nullable: false, identity: true),
                        CgcCPF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NmRazaoSocial = c.String(nullable: false, maxLength: 250),
                        NmFantasia = c.String(nullable: false, maxLength: 100),
                        InscricaoEstadual = c.String(maxLength: 30),
                        RegistroGeral = c.String(maxLength: 10),
                        CEP = c.String(nullable: false),
                        Numero = c.String(maxLength: 5),
                        Complemento = c.String(maxLength: 100),
                        NrTelefone = c.String(maxLength: 15),
                        NrCelular = c.String(maxLength: 16),
                        Email = c.String(nullable: false, maxLength: 100),
                        SgUser = c.String(nullable: false, maxLength: 50),
                        DtManutencao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemColeta", "MestreColetaId", "dbo.MestreColeta");
            DropForeignKey("dbo.Inconformidade", "ItemColetaId", "dbo.ItemColeta");
            DropForeignKey("dbo.Documento", "ItemColetaId", "dbo.ItemColeta");
            DropIndex("dbo.Inconformidade", new[] { "ItemColetaId" });
            DropIndex("dbo.ItemColeta", new[] { "MestreColetaId" });
            DropIndex("dbo.Documento", new[] { "ItemColetaId" });
            DropTable("dbo.Participante");
            DropTable("dbo.MestreColeta");
            DropTable("dbo.Inconformidade");
            DropTable("dbo.ItemColeta");
            DropTable("dbo.Documento");
        }
    }
}
