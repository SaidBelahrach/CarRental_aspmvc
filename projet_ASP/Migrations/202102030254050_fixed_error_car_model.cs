namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class fixed_error_car_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "matricule", "dbo.Voitures");
            DropIndex("dbo.Reservations", new[] { "matricule" });
            RenameColumn(table: "dbo.Reservations", name: "matricule", newName: "idVoiture");
            DropPrimaryKey("dbo.Voitures");
            AddColumn("dbo.Voitures", "idVoiture", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Voitures", "matricule", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "idVoiture", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Voitures", "idVoiture");
            CreateIndex("dbo.Reservations", "idVoiture");
            AddForeignKey("dbo.Reservations", "idVoiture", "dbo.Voitures", "idVoiture", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "idVoiture", "dbo.Voitures");
            DropIndex("dbo.Reservations", new[] { "idVoiture" });
            DropPrimaryKey("dbo.Voitures");
            AlterColumn("dbo.Reservations", "idVoiture", c => c.String(maxLength: 128));
            AlterColumn("dbo.Voitures", "matricule", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Voitures", "idVoiture");
            AddPrimaryKey("dbo.Voitures", "matricule");
            RenameColumn(table: "dbo.Reservations", name: "idVoiture", newName: "matricule");
            CreateIndex("dbo.Reservations", "matricule");
            AddForeignKey("dbo.Reservations", "matricule", "dbo.Voitures", "matricule");
        }
    }
}
