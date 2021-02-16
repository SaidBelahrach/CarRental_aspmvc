namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listNoire_shared_btwn_admins : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins");
            DropIndex("dbo.ListeNoires", new[] { "idAdmin" });
            RenameColumn(table: "dbo.ListeNoires", name: "idAdmin", newName: "Admin_idAdmin");
            AlterColumn("dbo.ListeNoires", "Admin_idAdmin", c => c.Int());
            CreateIndex("dbo.ListeNoires", "Admin_idAdmin");
            AddForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins", "idAdmin");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins");
            DropIndex("dbo.ListeNoires", new[] { "Admin_idAdmin" });
            AlterColumn("dbo.ListeNoires", "Admin_idAdmin", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ListeNoires", name: "Admin_idAdmin", newName: "idAdmin");
            CreateIndex("dbo.ListeNoires", "idAdmin");
            AddForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins", "idAdmin", cascadeDelete: true);
        }
    }
}
