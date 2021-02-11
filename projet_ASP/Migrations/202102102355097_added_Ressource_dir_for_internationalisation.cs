namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Ressource_dir_for_internationalisation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.proprietaires", "type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.proprietaires", "type", c => c.String());
        }
    }
}
