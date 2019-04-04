namespace DataMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "reciverr_Id", newName: "reciver_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_reciverr_Id", newName: "IX_reciver_Id");
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.reclamations", "user_Id", "dbo.Users");
            DropIndex("dbo.reclamations", new[] { "user_Id" });
            DropTable("dbo.reclamations");
            RenameIndex(table: "dbo.Messages", name: "IX_reciver_Id", newName: "IX_reciverr_Id");
            RenameColumn(table: "dbo.Messages", name: "reciver_Id", newName: "reciverr_Id");
        }
    }
}
