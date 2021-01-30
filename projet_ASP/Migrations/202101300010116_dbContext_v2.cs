namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbContext_v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.proprietaires", name: "ID", newName: "idProprietaire");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.proprietaires", name: "idProprietaire", newName: "ID");
        }
    }
}
