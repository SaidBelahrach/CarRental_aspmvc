namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class add_img_to_appUser_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "imageBytes", c => c.Binary());
            DropColumn("dbo.AspNetUsers", "imagePath");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "imagePath", c => c.String());
            DropColumn("dbo.AspNetUsers", "imageBytes");
        }
    }
}
