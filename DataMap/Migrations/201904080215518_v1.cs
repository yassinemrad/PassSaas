namespace DataMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "image");
        }
    }
}
