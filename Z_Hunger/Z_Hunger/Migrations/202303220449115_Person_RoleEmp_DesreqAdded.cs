namespace Z_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person_RoleEmp_DesreqAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "Role", c => c.String());
            AddColumn("dbo.Employees", "Role", c => c.String());
            AlterColumn("dbo.Employees", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Status", c => c.String());
            DropColumn("dbo.Employees", "Role");
            DropColumn("dbo.Donors", "Role");
        }
    }
}
