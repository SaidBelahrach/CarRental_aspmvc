namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favoris_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favoris", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Favoris", "ApplicationUserID");
            AddForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Favoris", new[] { "ApplicationUserID" });
            DropColumn("dbo.Favoris", "ApplicationUserID");
        }
    }
}
