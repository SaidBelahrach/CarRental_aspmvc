namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class add_reclamation_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamations",
                c => new
                {
                    idReclamation = c.Int(nullable: false, identity: true),
                    Createur = c.Boolean(nullable: false),
                    description = c.String(nullable: false),
                    idProprietaire = c.Int(nullable: false),
                    idLocataire = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.idReclamation)
                .ForeignKey("dbo.locataires", t => t.idLocataire, cascadeDelete: true)
                .ForeignKey("dbo.proprietaires", t => t.idProprietaire, cascadeDelete: true)
                .Index(t => t.idProprietaire)
                .Index(t => t.idLocataire);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "idProprietaire", "dbo.proprietaires");
            DropForeignKey("dbo.Reclamations", "idLocataire", "dbo.locataires");
            DropIndex("dbo.Reclamations", new[] { "idLocataire" });
            DropIndex("dbo.Reclamations", new[] { "idProprietaire" });
            DropTable("dbo.Reclamations");
        }
    }
}
