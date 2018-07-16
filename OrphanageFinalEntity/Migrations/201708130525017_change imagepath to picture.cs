namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeimagepathtopicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orphans", "Picture", c => c.String());
            DropColumn("dbo.Orphans", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orphans", "ImagePath", c => c.String());
            DropColumn("dbo.Orphans", "Picture");
        }
    }
}
