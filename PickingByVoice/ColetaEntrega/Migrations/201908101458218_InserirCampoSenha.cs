namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserirCampoSenha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participante", "Senha", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participante", "Senha");
        }
    }
}
