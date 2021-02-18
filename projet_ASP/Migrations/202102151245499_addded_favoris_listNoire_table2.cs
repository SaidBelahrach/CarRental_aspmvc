namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addded_favoris_listNoire_table2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                {
                    idAdmin = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.idAdmin)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);

            CreateTable(
                "dbo.Favoris",
                c => new
                {
                    idFavoris = c.Int(nullable: false, identity: true),
                    idAdmin = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.idFavoris)
                .ForeignKey("dbo.Admins", t => t.idAdmin, cascadeDelete: true)
                .Index(t => t.idAdmin);

            CreateTable(
                "dbo.ListeNoires",
                c => new
                {
                    idListeNoire = c.Int(nullable: false, identity: true),
                    description = c.String(),
                    idAdmin = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.idListeNoire)
                .ForeignKey("dbo.Admins", t => t.idAdmin, cascadeDelete: true)
                .Index(t => t.idAdmin);

            AddColumn("dbo.AspNetUsers", "Favoris_idFavoris", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ListeNoire_idListeNoire", c => c.Int());
            AddColumn("dbo.Reclamations", "dateCreation", c => c.String(nullable: false));
            AddColumn("dbo.Reclamations", "valide", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Favoris_idFavoris");
            CreateIndex("dbo.AspNetUsers", "ListeNoire_idListeNoire");
            AddForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris", "idFavoris");
            AddForeignKey("dbo.AspNetUsers", "ListeNoire_idListeNoire", "dbo.ListeNoires", "idListeNoire");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ListeNoire_idListeNoire", "dbo.ListeNoires");
            DropForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins");
            DropForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris");
            DropForeignKey("dbo.Favoris", "idAdmin", "dbo.Admins");
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ListeNoires", new[] { "idAdmin" });
            DropIndex("dbo.Favoris", new[] { "idAdmin" });
            DropIndex("dbo.AspNetUsers", new[] { "ListeNoire_idListeNoire" });
            DropIndex("dbo.AspNetUsers", new[] { "Favoris_idFavoris" });
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropColumn("dbo.Reclamations", "valide");
            DropColumn("dbo.Reclamations", "dateCreation");
            DropColumn("dbo.AspNetUsers", "ListeNoire_idListeNoire");
            DropColumn("dbo.AspNetUsers", "Favoris_idFavoris");
            DropTable("dbo.ListeNoires");
            DropTable("dbo.Favoris");
            DropTable("dbo.Admins");
        }
    }
}
