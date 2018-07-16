namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ContactNo = c.String(),
                        NumberofOrphan = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrphanImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrphanId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orphans", t => t.OrphanId, cascadeDelete: true)
                .Index(t => t.OrphanId);
            
            CreateTable(
                "dbo.Orphans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Disable = c.Boolean(nullable: false),
                        JoinedDate = c.DateTime(nullable: false),
                        LeaveDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        LastLogin = c.DateTime(),
                        AuthCode = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrphanImages", "OrphanId", "dbo.Orphans");
            DropIndex("dbo.OrphanImages", new[] { "OrphanId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Orphans");
            DropTable("dbo.OrphanImages");
            DropTable("dbo.Carers");
            DropTable("dbo.Admins");
        }
    }
}
