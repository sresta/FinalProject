namespace OrphanageFinalEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecarertosupervisor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Carers", newName: "Supervisors");
            RenameColumn(table: "dbo.Orphans", name: "Carer_Id", newName: "Supervisor_Id");
            RenameIndex(table: "dbo.Orphans", name: "IX_Carer_Id", newName: "IX_Supervisor_Id");
            AddColumn("dbo.Orphans", "SupervisorName", c => c.String());
            DropColumn("dbo.Orphans", "CarerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orphans", "CarerName", c => c.String());
            DropColumn("dbo.Orphans", "SupervisorName");
            RenameIndex(table: "dbo.Orphans", name: "IX_Supervisor_Id", newName: "IX_Carer_Id");
            RenameColumn(table: "dbo.Orphans", name: "Supervisor_Id", newName: "Carer_Id");
            RenameTable(name: "dbo.Supervisors", newName: "Carers");
        }
    }
}
