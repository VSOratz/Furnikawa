namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasNovas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documento", "ItemColetaId", "dbo.ItemColeta");
            DropForeignKey("dbo.Inconformidade", "ItemColetaId", "dbo.ItemColeta");
            DropForeignKey("dbo.ItemColeta", "MestreColetaId", "dbo.MestreColeta");
            CreateTable(
                "dbo.ItemColetaMovimentacao",
                c => new
                    {
                        ItemColetaId = c.Int(nullable: false),
                        DescricaoMovimentacao = c.String(),
                        DhCriacao = c.DateTime(nullable: false),
                        NmUsuarioCriou = c.String(),
                    })
                .PrimaryKey(t => t.ItemColetaId)
                .ForeignKey("dbo.ItemColeta", t => t.ItemColetaId)
                .Index(t => t.ItemColetaId);
            
            CreateTable(
                "dbo.UsuarioEmpresaHistorico",
                c => new
                    {
                        UsuarioEmpresaHistoricoId = c.Int(nullable: false, identity: true),
                        DhInteracao = c.DateTime(nullable: false),
                        RotaInteracao = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        ParticipanteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioEmpresaHistoricoId)
                .ForeignKey("dbo.Participante", t => t.ParticipanteId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ParticipanteId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Senha = c.String(),
                        DhCriacao = c.DateTime(nullable: false),
                        NmUsuarioCriou = c.String(),
                        DhAlteracao = c.DateTime(nullable: false),
                        NmUsuarioAlterou = c.String(),
                        ParticipanteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Participante", t => t.ParticipanteId)
                .Index(t => t.ParticipanteId);
            
            CreateTable(
                "dbo.UsuarioEmpresa",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        ParticipanteId = c.Int(nullable: false),
                        DhCriacao = c.DateTime(nullable: false),
                        NmUsuarioCriou = c.String(),
                        DhAlteracao = c.DateTime(nullable: false),
                        NmUsuarioAlterou = c.String(),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.ParticipanteId })
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            AddForeignKey("dbo.Documento", "ItemColetaId", "dbo.ItemColeta", "ItemColetaId");
            AddForeignKey("dbo.Inconformidade", "ItemColetaId", "dbo.ItemColeta", "ItemColetaId");
            AddForeignKey("dbo.ItemColeta", "MestreColetaId", "dbo.MestreColeta", "MestreColetaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemColeta", "MestreColetaId", "dbo.MestreColeta");
            DropForeignKey("dbo.Inconformidade", "ItemColetaId", "dbo.ItemColeta");
            DropForeignKey("dbo.Documento", "ItemColetaId", "dbo.ItemColeta");
            DropForeignKey("dbo.UsuarioEmpresa", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioEmpresaHistorico", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "ParticipanteId", "dbo.Participante");
            DropForeignKey("dbo.UsuarioEmpresaHistorico", "ParticipanteId", "dbo.Participante");
            DropForeignKey("dbo.ItemColetaMovimentacao", "ItemColetaId", "dbo.ItemColeta");
            DropIndex("dbo.UsuarioEmpresa", new[] { "UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "ParticipanteId" });
            DropIndex("dbo.UsuarioEmpresaHistorico", new[] { "ParticipanteId" });
            DropIndex("dbo.UsuarioEmpresaHistorico", new[] { "UsuarioId" });
            DropIndex("dbo.ItemColetaMovimentacao", new[] { "ItemColetaId" });
            DropTable("dbo.UsuarioEmpresa");
            DropTable("dbo.Usuario");
            DropTable("dbo.UsuarioEmpresaHistorico");
            DropTable("dbo.ItemColetaMovimentacao");
            AddForeignKey("dbo.ItemColeta", "MestreColetaId", "dbo.MestreColeta", "MestreColetaId", cascadeDelete: true);
            AddForeignKey("dbo.Inconformidade", "ItemColetaId", "dbo.ItemColeta", "ItemColetaId", cascadeDelete: true);
            AddForeignKey("dbo.Documento", "ItemColetaId", "dbo.ItemColeta", "ItemColetaId", cascadeDelete: true);
        }
    }
}
