namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Updated_Favoris : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "idFavoris", newName: "Favoris_idFavoris");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_idFavoris", newName: "IX_Favoris_idFavoris");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Favoris_idFavoris", newName: "IX_idFavoris");
            RenameColumn(table: "dbo.AspNetUsers", name: "Favoris_idFavoris", newName: "idFavoris");
        }
    }
}
