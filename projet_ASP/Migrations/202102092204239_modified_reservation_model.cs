namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified_reservation_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "doesCarReturned", c => c.Boolean(nullable: false));
            AddColumn("dbo.retoursVoitures", "pinalise", c => c.Boolean(nullable: false));
            AddColumn("dbo.retoursVoitures", "amende", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.retoursVoitures", "amende");
            DropColumn("dbo.retoursVoitures", "pinalise");
            DropColumn("dbo.Reservations", "doesCarReturned");
        }
    }
}
