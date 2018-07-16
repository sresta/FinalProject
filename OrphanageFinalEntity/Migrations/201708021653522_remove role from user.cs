namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerolefromuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
        }
    }
}
