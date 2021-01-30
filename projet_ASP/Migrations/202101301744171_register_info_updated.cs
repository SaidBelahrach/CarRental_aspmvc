namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class register_info_updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.locataires", "nomComplet");
            DropColumn("dbo.locataires", "adresse");
            DropColumn("dbo.proprietaires", "nomComplet");
            DropColumn("dbo.proprietaires", "adresse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.proprietaires", "adresse", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "nomComplet", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "adresse", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "nomComplet", c => c.String(nullable: false));
        }
    }
}
