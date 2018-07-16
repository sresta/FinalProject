namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orphans", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Orphans", "CarerId", "dbo.Carers");
            DropIndex("dbo.Orphans", new[] { "CarerId" });
            DropIndex("dbo.Orphans", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Orphans", name: "CarerId", newName: "Carer_Id");
            AddColumn("dbo.Orphans", "CarerName", c => c.String());
            AlterColumn("dbo.Orphans", "Carer_Id", c => c.Int());
            CreateIndex("dbo.Orphans", "Carer_Id");
            AddForeignKey("dbo.Orphans", "Carer_Id", "dbo.Carers", "Id");
            DropColumn("dbo.Orphans", "Roles");
            DropColumn("dbo.Orphans", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orphans", "Role_Id", c => c.Int());
            AddColumn("dbo.Orphans", "Roles", c => c.String());
            DropForeignKey("dbo.Orphans", "Carer_Id", "dbo.Carers");
            DropIndex("dbo.Orphans", new[] { "Carer_Id" });
            AlterColumn("dbo.Orphans", "Carer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Orphans", "CarerName");
            RenameColumn(table: "dbo.Orphans", name: "Carer_Id", newName: "CarerId");
            CreateIndex("dbo.Orphans", "Role_Id");
            CreateIndex("dbo.Orphans", "CarerId");
            AddForeignKey("dbo.Orphans", "CarerId", "dbo.Carers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orphans", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
