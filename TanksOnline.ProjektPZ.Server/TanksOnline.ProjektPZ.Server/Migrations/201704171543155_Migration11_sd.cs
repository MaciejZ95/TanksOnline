namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration11_sd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Photo");
        }
    }
}
