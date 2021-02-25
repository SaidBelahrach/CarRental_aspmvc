namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlackListAndFavorisUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "idListeNoire", "dbo.ListeNoires");
            DropForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris");
            DropForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins");
            DropIndex("dbo.AspNetUsers", new[] { "idListeNoire" });
            DropIndex("dbo.AspNetUsers", new[] { "Favoris_idFavoris" });
            DropIndex("dbo.ListeNoires", new[] { "Admin_idAdmin" });
            RenameColumn(table: "dbo.ListeNoires", name: "Admin_idAdmin", newName: "idAdmin");
            AddColumn("dbo.ListeNoires", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Favoris", "ApplicationUserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.ListeNoires", "idAdmin", c => c.Int(nullable: false));
            CreateIndex("dbo.Favoris", "ApplicationUserID");
            CreateIndex("dbo.ListeNoires", "ApplicationUserID");
            CreateIndex("dbo.ListeNoires", "idAdmin");
            AddForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ListeNoires", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins", "idAdmin", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "idListeNoire");
            DropColumn("dbo.AspNetUsers", "Favoris_idFavoris");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Favoris_idFavoris", c => c.Int());
            AddColumn("dbo.AspNetUsers", "idListeNoire", c => c.Int());
            DropForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins");
            DropForeignKey("dbo.ListeNoires", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favoris", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ListeNoires", new[] { "idAdmin" });
            DropIndex("dbo.ListeNoires", new[] { "ApplicationUserID" });
            DropIndex("dbo.Favoris", new[] { "ApplicationUserID" });
            AlterColumn("dbo.ListeNoires", "idAdmin", c => c.Int());
            DropColumn("dbo.Favoris", "ApplicationUserID");
            DropColumn("dbo.ListeNoires", "ApplicationUserID");
            RenameColumn(table: "dbo.ListeNoires", name: "idAdmin", newName: "Admin_idAdmin");
            CreateIndex("dbo.ListeNoires", "Admin_idAdmin");
            CreateIndex("dbo.AspNetUsers", "Favoris_idFavoris");
            CreateIndex("dbo.AspNetUsers", "idListeNoire");
            AddForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins", "idAdmin");
            AddForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris", "idFavoris");
            AddForeignKey("dbo.AspNetUsers", "idListeNoire", "dbo.ListeNoires", "idListeNoire");
        }
    }
}
