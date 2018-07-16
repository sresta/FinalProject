namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orphans", "Roles", c => c.String());
            AddColumn("dbo.Orphans", "Role_Id", c => c.Int());
            CreateIndex("dbo.Orphans", "Role_Id");
            AddForeignKey("dbo.Orphans", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orphans", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Orphans", new[] { "Role_Id" });
            DropColumn("dbo.Orphans", "Role_Id");
            DropColumn("dbo.Orphans", "Roles");
        }
    }
}
