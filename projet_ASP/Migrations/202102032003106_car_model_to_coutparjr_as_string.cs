namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class car_model_to_coutparjr_as_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voitures", "coutParJour", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Voitures", "coutParJour", c => c.Double(nullable: false));
        }
    }
}
