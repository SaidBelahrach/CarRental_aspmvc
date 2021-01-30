namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified_app_user_class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nomComplet", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "adresse", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "profileType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "profileType");
            DropColumn("dbo.AspNetUsers", "adresse");
            DropColumn("dbo.AspNetUsers", "nomComplet");
        }
    }
}
