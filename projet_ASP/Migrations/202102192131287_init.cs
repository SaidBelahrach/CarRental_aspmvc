namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contrats", "idLocataire", "dbo.locataires");
            DropForeignKey("dbo.Contrats", "matricule", "dbo.Voitures");
            DropForeignKey("dbo.Contrats", "RetourVoiture_idRetour", "dbo.retoursVoitures");
            DropIndex("dbo.Contrats", new[] { "matricule" });
            DropIndex("dbo.Contrats", new[] { "idLocataire" });
            DropIndex("dbo.Contrats", new[] { "RetourVoiture_idRetour" });
            RenameColumn(table: "dbo.locataires", name: "ID", newName: "idLocataire");
            RenameColumn(table: "dbo.Voitures", name: "ID", newName: "matricule");
            RenameColumn(table: "dbo.retoursVoitures", name: "ID", newName: "idRetour");
            DropPrimaryKey("dbo.Voitures");
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        idAdmin = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idAdmin)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nomComplet = c.String(nullable: false),
                        adresse = c.String(nullable: false),
                        profileType = c.String(nullable: false),
                        imageBytes = c.Binary(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Favoris_idFavoris = c.Int(),
                        ListeNoire_idListeNoire = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Favoris", t => t.Favoris_idFavoris)
                .ForeignKey("dbo.ListeNoires", t => t.ListeNoire_idListeNoire)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Favoris_idFavoris)
                .Index(t => t.ListeNoire_idListeNoire);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        idReclamation = c.Int(nullable: false, identity: true),
                        Createur = c.Boolean(nullable: false),
                        description = c.String(nullable: false),
                        dateCreation = c.String(nullable: false),
                        valide = c.Boolean(nullable: false),
                        idProprietaire = c.Int(nullable: false),
                        idLocataire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idReclamation)
                .ForeignKey("dbo.locataires", t => t.idLocataire, cascadeDelete: true)
                .ForeignKey("dbo.proprietaires", t => t.idProprietaire, cascadeDelete: true)
                .Index(t => t.idProprietaire)
                .Index(t => t.idLocataire);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        idContrat = c.Int(nullable: false, identity: true),
                        dateReservation = c.DateTime(nullable: false),
                        dateDebut = c.DateTime(nullable: false),
                        dateFin = c.DateTime(nullable: false),
                        typeDePaiement = c.String(nullable: false),
                        cout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        doesCarReturned = c.Boolean(nullable: false),
                        idVoiture = c.Int(nullable: false),
                        idLocataire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idContrat)
                .ForeignKey("dbo.locataires", t => t.idLocataire, cascadeDelete: true)
                .ForeignKey("dbo.Voitures", t => t.idVoiture, cascadeDelete: true)
                .Index(t => t.idVoiture)
                .Index(t => t.idLocataire);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Favoris",
                c => new
                    {
                        idFavoris = c.Int(nullable: false, identity: true),
                        idAdmin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFavoris)
                .ForeignKey("dbo.Admins", t => t.idAdmin, cascadeDelete: true)
                .Index(t => t.idAdmin);
            
            CreateTable(
                "dbo.ListeNoires",
                c => new
                    {
                        idListeNoire = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        Admin_idAdmin = c.Int(),
                    })
                .PrimaryKey(t => t.idListeNoire)
                .ForeignKey("dbo.Admins", t => t.Admin_idAdmin)
                .Index(t => t.Admin_idAdmin);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        idNotification = c.Int(nullable: false, identity: true),
                        idOroginalNotification = c.Int(nullable: false),
                        type = c.String(),
                        hint = c.String(),
                        vu = c.Boolean(nullable: false),
                        cliked = c.Boolean(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idNotification)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.locataires", "Npermis", c => c.Int(nullable: false));
            AddColumn("dbo.locataires", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Voitures", "idVoiture", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Voitures", "nbPlaces", c => c.Int(nullable: false));
            AddColumn("dbo.Voitures", "automatique", c => c.Boolean(nullable: false));
            AddColumn("dbo.Voitures", "disponible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Voitures", "image", c => c.Binary());
            AddColumn("dbo.proprietaires", "type", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.retoursVoitures", "pinalise", c => c.Boolean(nullable: false));
            AddColumn("dbo.retoursVoitures", "amende", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.retoursVoitures", "idContrat", c => c.Int(nullable: false));
            AlterColumn("dbo.Voitures", "matricule", c => c.String(nullable: false));
            AlterColumn("dbo.Voitures", "coutParJour", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Voitures", "idVoiture");
            CreateIndex("dbo.locataires", "ApplicationUserID");
            CreateIndex("dbo.proprietaires", "ApplicationUserID");
            CreateIndex("dbo.retoursVoitures", "idContrat");
            AddForeignKey("dbo.locataires", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.proprietaires", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.retoursVoitures", "idContrat", "dbo.Reservations", "idContrat", cascadeDelete: true);
            DropColumn("dbo.locataires", "nomComplet");
            DropColumn("dbo.locataires", "tel");
            DropColumn("dbo.locataires", "adresse");
            DropColumn("dbo.locataires", "email");
            DropColumn("dbo.Voitures", "km");
            DropColumn("dbo.proprietaires", "nomComplet");
            DropColumn("dbo.proprietaires", "tel");
            DropColumn("dbo.proprietaires", "adresse");
            DropColumn("dbo.proprietaires", "email");
            DropTable("dbo.Contrats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contrats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateLocation = c.DateTime(nullable: false),
                        dateDebut = c.DateTime(nullable: false),
                        dateFin = c.DateTime(nullable: false),
                        typeDePaiement = c.String(nullable: false),
                        cout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        matricule = c.String(maxLength: 128),
                        idLocataire = c.Int(nullable: false),
                        RetourVoiture_idRetour = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.proprietaires", "email", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "adresse", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "tel", c => c.String(nullable: false));
            AddColumn("dbo.proprietaires", "nomComplet", c => c.String(nullable: false));
            AddColumn("dbo.Voitures", "km", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.locataires", "email", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "adresse", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "tel", c => c.String(nullable: false));
            AddColumn("dbo.locataires", "nomComplet", c => c.String(nullable: false));
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notifications", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ListeNoires", "Admin_idAdmin", "dbo.Admins");
            DropForeignKey("dbo.AspNetUsers", "ListeNoire_idListeNoire", "dbo.ListeNoires");
            DropForeignKey("dbo.AspNetUsers", "Favoris_idFavoris", "dbo.Favoris");
            DropForeignKey("dbo.Favoris", "idAdmin", "dbo.Admins");
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "idVoiture", "dbo.Voitures");
            DropForeignKey("dbo.retoursVoitures", "idContrat", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "idLocataire", "dbo.locataires");
            DropForeignKey("dbo.Reclamations", "idProprietaire", "dbo.proprietaires");
            DropForeignKey("dbo.proprietaires", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reclamations", "idLocataire", "dbo.locataires");
            DropForeignKey("dbo.locataires", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "ApplicationUserID" });
            DropIndex("dbo.ListeNoires", new[] { "Admin_idAdmin" });
            DropIndex("dbo.Favoris", new[] { "idAdmin" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.retoursVoitures", new[] { "idContrat" });
            DropIndex("dbo.Reservations", new[] { "idLocataire" });
            DropIndex("dbo.Reservations", new[] { "idVoiture" });
            DropIndex("dbo.proprietaires", new[] { "ApplicationUserID" });
            DropIndex("dbo.Reclamations", new[] { "idLocataire" });
            DropIndex("dbo.Reclamations", new[] { "idProprietaire" });
            DropIndex("dbo.locataires", new[] { "ApplicationUserID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ListeNoire_idListeNoire" });
            DropIndex("dbo.AspNetUsers", new[] { "Favoris_idFavoris" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropPrimaryKey("dbo.Voitures");
            AlterColumn("dbo.Voitures", "coutParJour", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Voitures", "matricule", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.retoursVoitures", "idContrat");
            DropColumn("dbo.retoursVoitures", "amende");
            DropColumn("dbo.retoursVoitures", "pinalise");
            DropColumn("dbo.proprietaires", "ApplicationUserID");
            DropColumn("dbo.proprietaires", "type");
            DropColumn("dbo.Voitures", "image");
            DropColumn("dbo.Voitures", "disponible");
            DropColumn("dbo.Voitures", "automatique");
            DropColumn("dbo.Voitures", "nbPlaces");
            DropColumn("dbo.Voitures", "idVoiture");
            DropColumn("dbo.locataires", "ApplicationUserID");
            DropColumn("dbo.locataires", "Npermis");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.ListeNoires");
            DropTable("dbo.Favoris");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Reservations");
            DropTable("dbo.Reclamations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Admins");
            AddPrimaryKey("dbo.Voitures", "ID");
            RenameColumn(table: "dbo.retoursVoitures", name: "idRetour", newName: "ID");
            RenameColumn(table: "dbo.Voitures", name: "matricule", newName: "ID");
            RenameColumn(table: "dbo.locataires", name: "idLocataire", newName: "ID");
            CreateIndex("dbo.Contrats", "RetourVoiture_idRetour");
            CreateIndex("dbo.Contrats", "idLocataire");
            CreateIndex("dbo.Contrats", "matricule");
            AddForeignKey("dbo.Contrats", "RetourVoiture_idRetour", "dbo.retoursVoitures", "ID");
            AddForeignKey("dbo.Contrats", "matricule", "dbo.Voitures", "ID");
            AddForeignKey("dbo.Contrats", "idLocataire", "dbo.locataires", "ID", cascadeDelete: true);
        }
    }
}
