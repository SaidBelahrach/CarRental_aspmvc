namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updated_car_class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "imagePath", c => c.String());
            AddColumn("dbo.Voitures", "disponible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Voitures", "imagePath", c => c.String());
            AddColumn("dbo.Reservations", "dateReservation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "dateLocation");
        }

        public override void Down()
        {
            AddColumn("dbo.Reservations", "dateLocation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "dateReservation");
            DropColumn("dbo.Voitures", "imagePath");
            DropColumn("dbo.Voitures", "disponible");
            DropColumn("dbo.AspNetUsers", "imagePath");
        }
    }
}
