namespace Z_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonRole_reqAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Role", c => c.String());
            AlterColumn("dbo.Donors", "Role", c => c.String());
        }
    }
}
