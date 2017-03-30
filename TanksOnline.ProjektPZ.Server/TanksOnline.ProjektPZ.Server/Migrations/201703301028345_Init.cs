namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayersLimit = c.Int(nullable: false),
                        RoomStatus = c.Int(nullable: false),
                        Match_Id = c.Int(),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Match_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActualPlayer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TankHP = c.Int(nullable: false),
                        IdInMatch = c.Int(nullable: false),
                        TurretAngle = c.Single(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Match_Id = c.Int(),
                        GameRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .ForeignKey("dbo.GameRooms", t => t.GameRoom_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Match_Id)
                .Index(t => t.GameRoom_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        TankInfo_Id = c.Int(nullable: false),
                        UserScore_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TankInfoes", t => t.TankInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserScores", t => t.UserScore_Id, cascadeDelete: true)
                .Index(t => t.TankInfo_Id)
                .Index(t => t.UserScore_Id);
            
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
            DropForeignKey("dbo.Players", "GameRoom_Id", "dbo.GameRooms");
            DropForeignKey("dbo.GameRooms", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.GameRooms", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Players", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Players", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "UserScore_Id", "dbo.UserScores");
            DropForeignKey("dbo.Users", "TankInfo_Id", "dbo.TankInfoes");
            DropIndex("dbo.Users", new[] { "UserScore_Id" });
            DropIndex("dbo.Users", new[] { "TankInfo_Id" });
            DropIndex("dbo.Players", new[] { "GameRoom_Id" });
            DropIndex("dbo.Players", new[] { "Match_Id" });
            DropIndex("dbo.Players", new[] { "User_Id" });
            DropIndex("dbo.GameRooms", new[] { "Owner_Id" });
            DropIndex("dbo.GameRooms", new[] { "Match_Id" });
            DropTable("dbo.UserScores");
            DropTable("dbo.TankInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.Players");
            DropTable("dbo.Matches");
            DropTable("dbo.GameRooms");
        }
    }
}
