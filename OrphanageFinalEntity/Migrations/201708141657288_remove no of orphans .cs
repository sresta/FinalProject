namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenooforphans : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Supervisors", "NumberofOrphan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supervisors", "NumberofOrphan", c => c.Int(nullable: false));
        }
    }
}
