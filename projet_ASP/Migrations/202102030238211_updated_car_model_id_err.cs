namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_car_model_id_err : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Voitures", name: "ID", newName: "matricule");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Voitures", name: "matricule", newName: "ID");
        }
    }
}
