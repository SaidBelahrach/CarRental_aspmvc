namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_car_model_removed_km : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Voitures", "km");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voitures", "km", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
