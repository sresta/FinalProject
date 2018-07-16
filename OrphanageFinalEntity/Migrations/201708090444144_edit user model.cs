namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editusermodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "LastLogin");
            DropColumn("dbo.Users", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LastLogin", c => c.DateTime());
        }
    }
}
