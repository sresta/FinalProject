namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpasswordfieldinsupervisor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supervisors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supervisors", "Password");
        }
    }
}
