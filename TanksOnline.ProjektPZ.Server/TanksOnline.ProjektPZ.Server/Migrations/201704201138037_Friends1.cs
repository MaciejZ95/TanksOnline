namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        RelationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationId)
                .ForeignKey("dbo.Users", t => t.FriendId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            AddColumn("dbo.Users", "Photo", c => c.Binary());
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendId", "dbo.Users");
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "FriendId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropColumn("dbo.Users", "User_Id");
            DropColumn("dbo.Users", "Photo");
            DropTable("dbo.Friends");
        }
    }
}
