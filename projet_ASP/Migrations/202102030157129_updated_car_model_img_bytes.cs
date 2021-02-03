namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updated_car_model_img_bytes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voitures", "imagePath", c => c.Binary());
        }

        public override void Down()
        {
            AlterColumn("dbo.Voitures", "imagePath", c => c.String());
        }
    }
}
