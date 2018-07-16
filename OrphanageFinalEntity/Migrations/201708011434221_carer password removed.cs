namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carerpasswordremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carers", "Password", c => c.String());
        }
    }
}
