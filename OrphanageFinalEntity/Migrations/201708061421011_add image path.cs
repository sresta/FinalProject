namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimagepath : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrphanImages", "OrphanId", "dbo.Orphans");
            DropIndex("dbo.OrphanImages", new[] { "OrphanId" });
            AddColumn("dbo.Orphans", "ImagePath", c => c.String());
            DropTable("dbo.OrphanImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrphanImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrphanId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Orphans", "ImagePath");
            CreateIndex("dbo.OrphanImages", "OrphanId");
            AddForeignKey("dbo.OrphanImages", "OrphanId", "dbo.Orphans", "Id", cascadeDelete: true);
        }
    }
}
