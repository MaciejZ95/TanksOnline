namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "Date");
        }
    }
}
