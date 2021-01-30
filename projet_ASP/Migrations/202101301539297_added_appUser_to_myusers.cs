namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_appUser_to_myusers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.locataires", "tel");
            DropColumn("dbo.locataires", "email");
            DropColumn("dbo.proprietaires", "tel");
            DropColumn("dbo.proprietaires", "email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.proprietaires", "email", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "tel", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "email", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "tel", c => c.String(nullable: false));
        }
    }
}
