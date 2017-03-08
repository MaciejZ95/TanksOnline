namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration001_Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TankInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ColorR = c.Int(nullable: false),
                        ColorG = c.Int(nullable: false),
                        ColorB = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        TankInfo_Id = c.Int(),
                        UserScore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TankInfoes", t => t.TankInfo_Id)
                .ForeignKey("dbo.UserScores", t => t.UserScore_Id)
                .Index(t => t.TankInfo_Id)
                .Index(t => t.UserScore_Id);
            
            CreateTable(
                "dbo.UserScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayedGames = c.Int(nullable: false),
                        WonGames = c.Int(nullable: false),
                        LostGames = c.Int(nullable: false),
                        AFK_kicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserScore_Id", "dbo.UserScores");
            DropForeignKey("dbo.Users", "TankInfo_Id", "dbo.TankInfoes");
            DropIndex("dbo.Users", new[] { "UserScore_Id" });
            DropIndex("dbo.Users", new[] { "TankInfo_Id" });
            DropTable("dbo.UserScores");
            DropTable("dbo.Users");
            DropTable("dbo.TankInfoes");
        }
    }
}
