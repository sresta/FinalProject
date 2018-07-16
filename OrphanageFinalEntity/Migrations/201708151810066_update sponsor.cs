namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesponsor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SponsorDetails", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SponsorDetails", "Amount");
        }
    }
}
