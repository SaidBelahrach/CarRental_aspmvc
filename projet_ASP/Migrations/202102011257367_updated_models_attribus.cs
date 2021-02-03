namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updated_models_attribus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.locataires", "Npermis", c => c.Int(nullable: false));
            AddColumn("dbo.proprietaires", "type", c => c.String());
            AddColumn("dbo.Voitures", "nbPlaces", c => c.Int(nullable: false));
            AddColumn("dbo.Voitures", "automatique", c => c.Boolean(nullable: false));
        }
        public override void Down()
        {
            DropColumn("dbo.Voitures", "automatique");
            DropColumn("dbo.Voitures", "nbPlaces");
            DropColumn("dbo.proprietaires", "type");
            DropColumn("dbo.locataires", "Npermis");
        }
    }
}
