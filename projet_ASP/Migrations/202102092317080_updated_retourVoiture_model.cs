namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_retourVoiture_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "RetourVoiture_idRetour", "dbo.retoursVoitures");
            DropIndex("dbo.Reservations", new[] { "RetourVoiture_idRetour" });
            AddColumn("dbo.retoursVoitures", "idContrat", c => c.Int(nullable: false));
            CreateIndex("dbo.retoursVoitures", "idContrat");
            AddForeignKey("dbo.retoursVoitures", "idContrat", "dbo.Reservations", "idContrat", cascadeDelete: true);
            DropColumn("dbo.Reservations", "RetourVoiture_idRetour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "RetourVoiture_idRetour", c => c.Int());
            DropForeignKey("dbo.retoursVoitures", "idContrat", "dbo.Reservations");
            DropIndex("dbo.retoursVoitures", new[] { "idContrat" });
            DropColumn("dbo.retoursVoitures", "idContrat");
            CreateIndex("dbo.Reservations", "RetourVoiture_idRetour");
            AddForeignKey("dbo.Reservations", "RetourVoiture_idRetour", "dbo.retoursVoitures", "idRetour");
        }
    }
}
