namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_car_model_img_b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voitures", "image", c => c.Binary());
            DropColumn("dbo.Voitures", "imagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voitures", "imagePath", c => c.Binary());
            DropColumn("dbo.Voitures", "image");
        }
    }
}
