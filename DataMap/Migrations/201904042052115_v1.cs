namespace DataMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.reclamations", "user_Id", "dbo.Users");
            DropIndex("dbo.reclamations", new[] { "user_Id" });
            AddColumn("dbo.Users", "Role", c => c.String());
            AddColumn("dbo.Modules", "idtask", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "idprojet", c => c.Int(nullable: false));
            AddColumn("dbo.Projets", "idmodul", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "dateAjout", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Tasks", "iduser", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "idmodul", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "idprojet", c => c.Int(nullable: false));
            AddColumn("dbo.reclamations", "user", c => c.Int(nullable: false));
            DropColumn("dbo.reclamations", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.reclamations", "user_Id", c => c.Int());
            DropColumn("dbo.reclamations", "user");
            DropColumn("dbo.Tasks", "idprojet");
            DropColumn("dbo.Tasks", "idmodul");
            DropColumn("dbo.Tasks", "iduser");
            DropColumn("dbo.Tasks", "dateAjout");
            DropColumn("dbo.Projets", "idmodul");
            DropColumn("dbo.Modules", "idprojet");
            DropColumn("dbo.Modules", "idtask");
            DropColumn("dbo.Users", "Role");
            CreateIndex("dbo.reclamations", "user_Id");
            AddForeignKey("dbo.reclamations", "user_Id", "dbo.Users", "Id");
        }
    }
}
