namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addflags_to_notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "vu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notifications", "cliked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "cliked");
            DropColumn("dbo.Notifications", "vu");
        }
    }
}
