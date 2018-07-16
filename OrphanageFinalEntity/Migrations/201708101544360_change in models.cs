namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptionRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        Married = c.String(),
                        DateOfMarriage = c.DateTime(),
                        Profession = c.String(),
                        MonthlyIncome = c.Int(nullable: false),
                        ReasonOfAdoption = c.String(),
                        IfAnyChild = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SponsorDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        PaymentNo = c.Int(nullable: false),
                        DateOfReceipt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Supervisors", "FirstName", c => c.String());
            AddColumn("dbo.Supervisors", "LastName", c => c.String());
            AddColumn("dbo.Users", "ContactNo", c => c.String());
            DropColumn("dbo.Supervisors", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supervisors", "Name", c => c.String());
            DropForeignKey("dbo.SponsorDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.AdoptionRequests", "UserId", "dbo.Users");
            DropIndex("dbo.SponsorDetails", new[] { "UserId" });
            DropIndex("dbo.AdoptionRequests", new[] { "UserId" });
            DropColumn("dbo.Users", "ContactNo");
            DropColumn("dbo.Supervisors", "LastName");
            DropColumn("dbo.Supervisors", "FirstName");
            DropTable("dbo.SponsorDetails");
            DropTable("dbo.AdoptionRequests");
        }
    }
}
