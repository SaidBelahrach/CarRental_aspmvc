namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Favoris_ListNoire : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "idListeNoire", "dbo.ListeNoires");
            DropForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris");
            DropIndex("dbo.AspNetUsers", new[] { "idListeNoire" });
            DropIndex("dbo.AspNetUsers", new[] { "Favoris_idFavoris" });
            AddColumn("dbo.ListeNoires", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Favoris", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Favoris", "ApplicationUserID");
            CreateIndex("dbo.ListeNoires", "ApplicationUserID");
            AddForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ListeNoires", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "idListeNoire");
            DropColumn("dbo.AspNetUsers", "Favoris_idFavoris");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Favoris_idFavoris", c => c.Int());
            AddColumn("dbo.AspNetUsers", "idListeNoire", c => c.Int());
            DropForeignKey("dbo.ListeNoires", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ListeNoires", new[] { "ApplicationUserID" });
            DropIndex("dbo.Favoris", new[] { "ApplicationUserID" });
            DropColumn("dbo.Favoris", "ApplicationUserID");
            DropColumn("dbo.ListeNoires", "ApplicationUserID");
            CreateIndex("dbo.AspNetUsers", "Favoris_idFavoris");
            CreateIndex("dbo.AspNetUsers", "idListeNoire");
            AddForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris", "idFavoris");
            AddForeignKey("dbo.AspNetUsers", "idListeNoire", "dbo.ListeNoires", "idListeNoire");
        }
    }
}
