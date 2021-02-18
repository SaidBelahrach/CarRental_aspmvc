namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addded_favoris_listNoire_table3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Favoris_idFavoris", newName: "idFavoris");
            RenameColumn(table: "dbo.AspNetUsers", name: "ListeNoire_idListeNoire", newName: "idListeNoire");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Favoris_idFavoris", newName: "IX_idFavoris");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_ListeNoire_idListeNoire", newName: "IX_idListeNoire");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_idListeNoire", newName: "IX_ListeNoire_idListeNoire");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_idFavoris", newName: "IX_Favoris_idFavoris");
            RenameColumn(table: "dbo.AspNetUsers", name: "idListeNoire", newName: "ListeNoire_idListeNoire");
            RenameColumn(table: "dbo.AspNetUsers", name: "idFavoris", newName: "Favoris_idFavoris");
        }
    }
}
