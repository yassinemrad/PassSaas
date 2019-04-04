namespace DataMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lom : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.reclamations", "user_Id", "dbo.Users");
            DropIndex("dbo.reclamations", new[] { "user_Id" });
            AddColumn("dbo.Users", "Role", c => c.String());
            AddColumn("dbo.reclamations", "user", c => c.Int(nullable: false));
            DropColumn("dbo.reclamations", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.reclamations", "user_Id", c => c.Int());
            DropColumn("dbo.reclamations", "user");
            DropColumn("dbo.Users", "Role");
            CreateIndex("dbo.reclamations", "user_Id");
            AddForeignKey("dbo.reclamations", "user_Id", "dbo.Users", "Id");
        }
    }
}
