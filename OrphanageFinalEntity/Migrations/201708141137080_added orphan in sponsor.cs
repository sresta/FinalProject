namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedorphaninsponsor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SponsorDetails", "OrphanId", c => c.Int(nullable: false));
            CreateIndex("dbo.SponsorDetails", "OrphanId");
            AddForeignKey("dbo.SponsorDetails", "OrphanId", "dbo.Orphans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SponsorDetails", "OrphanId", "dbo.Orphans");
            DropIndex("dbo.SponsorDetails", new[] { "OrphanId" });
            DropColumn("dbo.SponsorDetails", "OrphanId");
        }
    }
}
