namespace DataMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        from = c.String(),
                        to = c.String(),
                        timeSend = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        read = c.Int(nullable: false),
                        User_Id = c.Int(),
                        reciverr_Id = c.Int(),
                        sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.reciverr_Id)
                .ForeignKey("dbo.Users", t => t.sender_Id)
                .Index(t => t.User_Id)
                .Index(t => t.reciverr_Id)
                .Index(t => t.sender_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Age = c.Int(),
                        Country = c.String(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        reciver_Id = c.Int(),
                        sender_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.reciver_Id)
                .ForeignKey("dbo.Users", t => t.sender_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.reciver_Id)
                .Index(t => t.sender_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        projet_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Projets", t => t.projet_id)
                .Index(t => t.projet_id);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        endDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        description = c.String(),
                        cathegory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        estimation = c.String(),
                        realDuration = c.Int(nullable: false),
                        etat = c.Int(nullable: false),
                        modules_id = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Modules", t => t.modules_id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.modules_id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.reclamations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        objet = c.String(),
                        description = c.String(),
                        etat = c.Int(nullable: false),
                        date = c.String(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.reclamations", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "modules_id", "dbo.Modules");
            DropForeignKey("dbo.Modules", "projet_id", "dbo.Projets");
            DropForeignKey("dbo.Messages", "sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "reciverr_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Notifications", "sender_Id", "dbo.Users");
            DropForeignKey("dbo.Notifications", "reciver_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.reclamations", new[] { "user_Id" });
            DropIndex("dbo.Tasks", new[] { "user_Id" });
            DropIndex("dbo.Tasks", new[] { "modules_id" });
            DropIndex("dbo.Modules", new[] { "projet_id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            DropIndex("dbo.Notifications", new[] { "sender_Id" });
            DropIndex("dbo.Notifications", new[] { "reciver_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "sender_Id" });
            DropIndex("dbo.Messages", new[] { "reciverr_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropTable("dbo.CustomRoles");
            DropTable("dbo.reclamations");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projets");
            DropTable("dbo.Modules");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
