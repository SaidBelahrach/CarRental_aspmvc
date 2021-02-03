namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_models : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.locataires", name: "ID", newName: "idLocataire");
            RenameColumn(table: "dbo.proprietaires", name: "ID", newName: "idProprietaire");
            RenameColumn(table: "dbo.Reservations", name: "ID", newName: "idContrat");
            RenameColumn(table: "dbo.retoursVoitures", name: "ID", newName: "idRetour");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.retoursVoitures", name: "idRetour", newName: "ID");
            RenameColumn(table: "dbo.Reservations", name: "idContrat", newName: "ID");
            RenameColumn(table: "dbo.proprietaires", name: "idProprietaire", newName: "ID");
            RenameColumn(table: "dbo.locataires", name: "idLocataire", newName: "ID");
        }
    }
}
