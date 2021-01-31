namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class editited_voiture_tab1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.proprietaires", name: "idProprietaire", newName: "ID");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.proprietaires", name: "ID", newName: "idProprietaire");
        }
    }
}
