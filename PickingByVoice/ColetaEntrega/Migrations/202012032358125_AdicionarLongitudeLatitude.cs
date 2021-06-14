namespace ColetaEntrega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarLongitudeLatitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemColeta", "Latitude", c => c.String());
            AddColumn("dbo.ItemColeta", "Longetude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemColeta", "Longetude");
            DropColumn("dbo.ItemColeta", "Latitude");
        }
    }
}
