namespace projet_ASP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingAdminBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins");
            DropIndex("dbo.ListeNoires", new[] { "Admin_idAdmin" });
            RenameColumn(table: "dbo.ListeNoires", name: "Admin_idAdmin", newName: "idAdmin");
            AlterColumn("dbo.ListeNoires", "idAdmin", c => c.Int(nullable: false));
            CreateIndex("dbo.ListeNoires", "idAdmin");
            AddForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins", "idAdmin", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ListeNoires", "idAdmin", "dbo.Admins");
            DropIndex("dbo.ListeNoires", new[] { "idAdmin" });
            AlterColumn("dbo.ListeNoires", "idAdmin", c => c.Int());
            RenameColumn(table: "dbo.ListeNoires", name: "idAdmin", newName: "Admin_idAdmin");
            CreateIndex("dbo.ListeNoires", "Admin_idAdmin");
            AddForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins", "idAdmin");
        }
    }
}
