namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class editited_voiture_tab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "matricule", "dbo.Voitures");
            DropPrimaryKey("dbo.Voitures");
            AlterColumn("dbo.Voitures", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Voitures", "ID");
            AddForeignKey("dbo.Reservations", "matricule", "dbo.Voitures", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "matricule", "dbo.Voitures");
            DropPrimaryKey("dbo.Voitures");
            AlterColumn("dbo.Voitures", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Voitures", "ID");
            AddForeignKey("dbo.Reservations", "matricule", "dbo.Voitures", "ID");
        }
    }
}
