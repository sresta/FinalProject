namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbackgrounddetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrphanBackgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrphanId = c.Int(nullable: false),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        Relative = c.String(),
                        AddressDetail = c.String(),
                        ContactNo = c.String(),
                        BoardedDetail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orphans", t => t.OrphanId, cascadeDelete: true)
                .Index(t => t.OrphanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrphanBackgrounds", "OrphanId", "dbo.Orphans");
            DropIndex("dbo.OrphanBackgrounds", new[] { "OrphanId" });
            DropTable("dbo.OrphanBackgrounds");
        }
    }
}
