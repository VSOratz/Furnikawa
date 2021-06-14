namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbInconformidadeTipo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InconformidadeTipo",
                c => new
                    {
                        InconformidadeTipoId = c.Int(nullable: false, identity: true),
                        dsTipo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InconformidadeTipoId);
            
            AddColumn("dbo.Inconformidade", "InconformidadeTipoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inconformidade", "InconformidadeTipoId");
            AddForeignKey("dbo.Inconformidade", "InconformidadeTipoId", "dbo.InconformidadeTipo", "InconformidadeTipoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inconformidade", "InconformidadeTipoId", "dbo.InconformidadeTipo");
            DropIndex("dbo.Inconformidade", new[] { "InconformidadeTipoId" });
            DropColumn("dbo.Inconformidade", "InconformidadeTipoId");
            DropTable("dbo.InconformidadeTipo");
        }
    }
}
