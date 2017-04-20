namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendId", "dbo.Users");
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "FriendId" });
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "User_Id");
            DropTable("dbo.Friends");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        RelationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationId);
            
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Photo", c => c.Binary());
            CreateIndex("dbo.Friends", "FriendId");
            CreateIndex("dbo.Friends", "UserId");
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Friends", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Friends", "FriendId", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
    }
}
