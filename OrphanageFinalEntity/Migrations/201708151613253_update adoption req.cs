namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateadoptionreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdoptionRequests", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.AdoptionRequests", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.AdoptionRequests", "Married", c => c.String(nullable: false));
            AlterColumn("dbo.AdoptionRequests", "Profession", c => c.String(nullable: false));
            AlterColumn("dbo.AdoptionRequests", "ReasonOfAdoption", c => c.String(nullable: false));
            DropColumn("dbo.AdoptionRequests", "DateOfMarriage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdoptionRequests", "DateOfMarriage", c => c.DateTime());
            AlterColumn("dbo.AdoptionRequests", "ReasonOfAdoption", c => c.String());
            AlterColumn("dbo.AdoptionRequests", "Profession", c => c.String());
            AlterColumn("dbo.AdoptionRequests", "Married", c => c.String());
            AlterColumn("dbo.AdoptionRequests", "Address", c => c.String());
            AlterColumn("dbo.AdoptionRequests", "Gender", c => c.String());
        }
    }
}
