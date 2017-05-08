namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserScoreUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.GameRooms", "Match_Id", "dbo.Matches");
            DropIndex("dbo.GameRooms", new[] { "Match_Id" });
            DropIndex("dbo.Players", new[] { "Match_Id" });
            CreateTable(
                "dbo.PlayerPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdInMatch = c.Int(nullable: false),
                        DealedHits = c.Int(nullable: false),
                        HitsTaken = c.Int(nullable: false),
                        Kills = c.Int(nullable: false),
                        Dead = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                        GameRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameRooms", t => t.GameRoom_Id)
                .Index(t => t.User_Id)
                .Index(t => t.GameRoom_Id);
            
            AddColumn("dbo.UserScores", "DealedHits", c => c.Int(nullable: false));
            AddColumn("dbo.UserScores", "HitsTaken", c => c.Int(nullable: false));
            DropColumn("dbo.GameRooms", "Match_Id");
            DropColumn("dbo.Players", "TurretAngle");
            DropColumn("dbo.Players", "Match_Id");
            DropColumn("dbo.UserScores", "AFK_kicks");
            DropTable("dbo.Matches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActualPlayer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserScores", "AFK_kicks", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Match_Id", c => c.Int());
            AddColumn("dbo.Players", "TurretAngle", c => c.Single(nullable: false));
            AddColumn("dbo.GameRooms", "Match_Id", c => c.Int());
            DropForeignKey("dbo.PlayerPoints", "GameRoom_Id", "dbo.GameRooms");
            DropForeignKey("dbo.PlayerPoints", "User_Id", "dbo.Users");
            DropIndex("dbo.PlayerPoints", new[] { "GameRoom_Id" });
            DropIndex("dbo.PlayerPoints", new[] { "User_Id" });
            DropColumn("dbo.UserScores", "HitsTaken");
            DropColumn("dbo.UserScores", "DealedHits");
            DropTable("dbo.PlayerPoints");
            CreateIndex("dbo.Players", "Match_Id");
            CreateIndex("dbo.GameRooms", "Match_Id");
            AddForeignKey("dbo.GameRooms", "Match_Id", "dbo.Matches", "Id");
            AddForeignKey("dbo.Players", "Match_Id", "dbo.Matches", "Id");
        }
    }
}
